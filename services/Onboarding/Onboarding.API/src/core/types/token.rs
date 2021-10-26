use crate::core::types::error::RepoError;
use crate::db::models::token::QueryToken;

pub trait TokenRepo {
    fn verify(&self, token: &String) -> Result<Option<QueryToken>, RepoError>;
    fn remove(&self, token: &String);
}