#![feature(proc_macro_hygiene, decl_macro)]

#[macro_use]
extern crate rocket;
#[macro_use]
extern crate diesel;

mod core;
mod db;
mod http;
mod settings;

use http::resources::register::handler::*;
use http::errors::handlers::*;
use rocket_cors::{AllowedOrigins};
use db::init_db;

fn main() {
    let allowed_origins = AllowedOrigins::All;

    let cors = rocket_cors::CorsOptions {
        allowed_origins,
        ..Default::default()
    }
        .to_cors().expect("err");

    rocket::ignite()
        .attach(cors)
        .manage(init_db())
        .mount("/api", routes![register_user_handler])
        .register(catchers![
            not_found,
            unauthenticated,
            unauthorized,
            bad_request,
            unprocessable_entity,
            internal_server_error
        ])
        .launch();
}