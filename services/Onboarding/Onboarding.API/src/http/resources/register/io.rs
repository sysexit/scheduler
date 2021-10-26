use crate::core::types::login::{RegisterUserOutput};
use crate::core::types::error::RegisterUserError;
use rocket::{Request, Response, response};
use rocket::http::Status;
use rocket::response::Responder;
use crate::http::api::ApiResult;
use crate::http::errors::io::ErrorWrapper;

impl<'r> Responder<'r> for ApiResult<RegisterUserOutput, RegisterUserError> {
    fn respond_to(self, req: &Request) -> Result<Response<'r>, Status> {
        let mut build = Response::build();

        match self.0 {
            Ok(output) => {
                build
                    .merge(response::content::Json(serde_json::to_string(&output)).respond_to(req)?);
                build.status(Status::Ok).ok()
            }
            Err(err) => {
                let err_response = match err {
                    RegisterUserError::RepoError(message) => ErrorWrapper::repo_error(message),
                    RegisterUserError::InvalidInput(message) => ErrorWrapper::invalid_input(message),
                };
                build.merge(
                    response::content::Json(serde_json::to_string(&err_response)).respond_to(req)?,
                );
                build.status(Status::BadRequest).ok()
            }
        }
    }
}
