use diesel::pg::PgConnection;
use r2d2;
use r2d2_diesel::ConnectionManager;

use std::env;
use dotenv::dotenv;
use rocket::request::{FromRequest, Outcome};
use rocket::{Request, request, State};
use rocket::http::Status;

pub struct DbConn(
    pub r2d2::PooledConnection<ConnectionManager<PgConnection>>
);

pub fn init_db() -> Pool {
    let manager = ConnectionManager::<PgConnection>::new(database_url());
    Pool::new(manager).expect("db pool")
}

fn database_url() -> String {
    dotenv().ok();
    env::var("DATABASE_URL").expect("DATABASE_URL must be set")
}

type Pool = r2d2::Pool<ConnectionManager<PgConnection>>;

impl<'a, 'r> FromRequest<'a, 'r> for DbConn {
    type Error = ();
    fn from_request(request: &'a Request<'r>) ->   request::Outcome<DbConn, Self::Error> {
        let pool = request.guard::<State<Pool>>()?;
        match pool.get() {
            Ok(conn) => Outcome::Success(DbConn(conn)),
            Err(_) => Outcome::Failure((Status::ServiceUnavailable, ())),
        }
    }
}
