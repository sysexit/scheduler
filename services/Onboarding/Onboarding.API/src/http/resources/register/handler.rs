use crate::core::types::error::RegisterUserError;
use crate::core::types::login::{RegisterUserInput, RegisterUserOutput};
use crate::core::usecases::insert_login::*;
use crate::db::DbConn;
use crate::db::repo::login::PostgresqlLoginRepo;
use crate::db::repo::token::PostgresqlTokenRepo;
use crate::http::api::ApiResult;
use rocket_contrib::json::Json;

#[post("/onboarding", format = "application/json", data = "<register_user_input>")]
pub fn register_user_handler(
    register_user_input: Json<RegisterUserInput>,
    db: DbConn,
) -> ApiResult<RegisterUserOutput, RegisterUserError> {
    let login_repo = PostgresqlLoginRepo::new(&db);
    let token_repo = PostgresqlTokenRepo::new(&db);

    ApiResult(
        insert_login(
            register_user_input.into_inner(),
            &login_repo,
            &token_repo,
        )
    )
}