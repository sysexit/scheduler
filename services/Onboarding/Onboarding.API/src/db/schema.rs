table! {
    tokens (email) {
        email -> Varchar,
        token-> Varchar,
    }
}

table! {
     logins (email) {
        email -> Varchar,
        password -> Varchar,
        group -> Integer,
    }
}