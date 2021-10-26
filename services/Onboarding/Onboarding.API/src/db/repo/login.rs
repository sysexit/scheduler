use diesel;
use diesel::prelude::*;

use crate::core::types::error::{RepoError};
use crate::core::types::login::{LoginRepo};
use crate::db::DbConn;
use crate::db::models::login::InsertLogin;
use crate::db::schema::logins;

pub struct PostgresqlLoginRepo<'a> {
    db_conn: &'a DbConn,
}

impl<'a> PostgresqlLoginRepo<'a> {
    pub fn new(conn: &'a DbConn) -> PostgresqlLoginRepo<'a> {
        PostgresqlLoginRepo { db_conn: conn }
    }
}

impl<'a> LoginRepo for PostgresqlLoginRepo<'a> {
    fn insert_login(&self, info: &InsertLogin) -> Result<usize, RepoError> {
        let result = diesel::insert_into(logins::table)
            .values(info)
            .execute(&*self.db_conn.0).expect("err1");

        Ok(result)
    }
}