use serde::{Serialize};
use thiserror::Error;

#[derive(Error, Debug, Serialize)]
pub enum RepoError {
    #[error("repo error: {0}")]
    RepoError(String),
}

#[derive(Error, Debug, Serialize)]
pub enum RegisterUserError {
    #[error("invalid input: {0}")]
    InvalidInput(String),
    #[error("repo error: {0}")]
    RepoError(String),
}

impl From<RepoError> for RegisterUserError {
    fn from(e: RepoError) -> RegisterUserError {
        RegisterUserError::RepoError(e.to_string())
    }
}