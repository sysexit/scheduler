use serde::{Deserialize};

#[derive(Debug, Deserialize)]
pub struct Database {
    pub database_url: String,
}