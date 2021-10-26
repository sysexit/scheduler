FROM rustlang/rust:nightly as builder

ADD . /app
WORKDIR /app
RUN cargo build --release

FROM debian:buster-slim
RUN apt-get update && apt-get install -y ca-certificates libssl-dev libpq-dev

WORKDIR /app
EXPOSE 4466

COPY Rocket.toml /app
COPY --from=builder /app/target/release/onboardingapi /app/onboardingapi

CMD /app/onboardingapi
