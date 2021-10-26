use crate::core::types::error::RegisterUserError;
use crate::core::types::login::{LoginRepo, RegisterUserInput, RegisterUserOutput, PersonalInformation};
use crate::core::types::token::TokenRepo;
use bcrypt::{hash};
use crate::db::models::login::InsertLogin;
use serde_json::to_string;
use lettre::transport::smtp::authentication::Credentials;
use lettre::{Message, SmtpTransport, Transport};
use std::env;

pub fn insert_login<L, T>(
    details: RegisterUserInput,
    login_repo: &L,
    token_repo: &T,
) -> Result<RegisterUserOutput, RegisterUserError>
    where
        L: LoginRepo,
        T: TokenRepo
{
    // verify token and email are correct
    let user_token = token_repo.verify(&details.token)?;
    if !user_token.is_some() {
        return Err(RegisterUserError::InvalidInput("Invalid token".to_string()));
    }

    // passwords match
    if details.password.password != details.password.confirm_password {
        return Err(RegisterUserError::InvalidInput("Passwords do no match!".to_string()));
    }

    let hashed = hash(&details.password.password, 10).unwrap();
    let email = user_token.unwrap().email.clone();

    send_email(&details.info, email.clone());

    login_repo.insert_login(&InsertLogin {
        email: email.clone(),
        password: hashed,
    })?;
    token_repo.remove(&details.token);

    Ok(RegisterUserOutput { status: "Ok".to_string() })
}

fn send_email(info: &PersonalInformation, user_email: String) {
    let msg = to_string(info).expect("error");
    let mut sub = user_email.clone();
    sub.push_str(": Personal Information Document");

    let email = Message::builder()
        .from(env::var("EMAIL_FROM").unwrap().parse().unwrap())
        .reply_to(env::var("EMAIL_FROM").unwrap().parse().unwrap())
        .to(env::var("EMAIL_HR_TO").unwrap().parse().unwrap())
        .subject(sub)
        .body(msg)
        .unwrap();

    let creds = Credentials::new(env::var("EMAIL_ACCOUNT").unwrap(), env::var("EMAIL_PASSWORD").unwrap());

    let mailer = SmtpTransport::relay(env::var("EMAIL_SERVER").unwrap().as_str())
        .unwrap()
        .credentials(creds)
        .build();

    match mailer.send(&email) {
        Ok(_) => println!("Email sent successfully!"),
        Err(e) => panic!("Could not send email: {:?}", e),
    }
}