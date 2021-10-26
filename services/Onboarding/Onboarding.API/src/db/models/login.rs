use crate::db::schema::*;

#[derive(Insertable, Debug)]
#[table_name = "logins"]
pub struct InsertLogin {
    pub email: String,
    pub password: String,
}