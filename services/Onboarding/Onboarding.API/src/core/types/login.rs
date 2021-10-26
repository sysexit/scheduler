use crate::core::types::error::RepoError;
use serde::{Serialize, Deserialize};
use crate::db::models::login::InsertLogin;

#[derive(Debug, Serialize, Deserialize)]
pub struct Password {
    pub password: String,
    pub confirm_password: String,
}

#[derive(Debug, Serialize, Deserialize)]
pub struct PersonalDetails {
    pub preferred_name: Option<String>,
    pub visa: Option<String>,
    pub dateofbirth: String,
    pub phone: String,
    pub address: String,
    pub city: String,
    pub state: String,
    pub zip: u16,
}

#[derive(Debug, Serialize, Deserialize)]
pub struct BankDetails {
    pub name: String,
    pub bsb: u32,
    pub number: u32,
    pub tfn: u32,
}

#[derive(Debug, Serialize, Deserialize)]
pub struct SuperDetails {
    pub name: Option<String>,
    pub number: Option<u64>,
    pub usi: Option<u64>,
    pub webaddr: Option<String>,
}

#[derive(Debug, Serialize, Deserialize)]
pub struct PersonalInformation {
    pub personal: PersonalDetails,
    pub bank: BankDetails,
    pub superann: SuperDetails,
}

#[derive(Debug, Serialize, Deserialize)]
pub struct RegisterUserInput {
    pub token: String,
    pub password: Password,
    pub info: PersonalInformation,
}

#[derive(Serialize, Deserialize, Debug, Clone)]
pub struct PasswordInsert {
    name: String,
    password: String,
}

#[derive(Debug, Serialize)]
pub struct RegisterUserOutput {
    pub status: String,
}

pub trait LoginRepo {
    fn insert_login(&self, info: &InsertLogin) -> Result<usize, RepoError>;
}