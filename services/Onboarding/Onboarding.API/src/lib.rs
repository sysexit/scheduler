#![feature(proc_macro_hygiene, decl_macro)]

#[macro_use] extern crate rocket;

#[macro_use]
extern crate diesel;
extern crate serde;
extern crate bcrypt;
extern crate lettre;

pub mod core;
pub mod db;
pub mod settings;
pub mod http;
