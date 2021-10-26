use diesel;
use diesel::prelude::*;

use crate::core::types::error::RepoError;
use crate::core::types::token::TokenRepo;
use crate::db::DbConn;
use crate::db::models::token::QueryToken;
use crate::db::schema::tokens;

pub struct PostgresqlTokenRepo<'a> {
    db_conn: &'a DbConn,
}

impl<'a> PostgresqlTokenRepo<'a> {
    pub fn new(conn: &'a DbConn) -> PostgresqlTokenRepo<'a> {
        PostgresqlTokenRepo { db_conn: conn }
    }
}

impl<'a> TokenRepo for PostgresqlTokenRepo<'a> {
    fn verify(&self, token: &String) -> Result<Option<QueryToken>, RepoError> {
        let mut result = tokens::table
            .filter(tokens::token.eq(token))
            .load::<QueryToken>(&*self.db_conn.0).expect("err1");

        if result.len() > 0 {
            Ok(Some(result.pop().unwrap()))
        } else {
            Ok(None)
        }
    }

    fn remove(&self, token: &String) {
        let result = diesel::delete(tokens::table)
            .filter(tokens::token.eq(token))
            .execute(&*self.db_conn.0);

        assert_eq!(Ok(1), result);
    }
}
