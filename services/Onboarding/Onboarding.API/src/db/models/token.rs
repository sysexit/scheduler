use crate::db::schema::*;

#[derive(Queryable, Identifiable, Debug)]
#[table_name = "tokens"]
#[primary_key(email)]
pub struct QueryToken {
    pub email: String,
    pub token: String,
}