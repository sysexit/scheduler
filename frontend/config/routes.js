const path = require("path");
const express = require("express");

let app = express();
const publicPath = path.resolve(__dirname, "../dist/main");
const schedulerPublicPath = path.resolve(__dirname, "../dist/scheduler");
const hrPublicPath = path.resolve(__dirname, "../dist/hr");

app.use('/', express.static(publicPath));
app.use('/scheduler/', express.static(schedulerPublicPath));
app.use('/hr/', express.static(hrPublicPath));

app.get("/", (req, res) => {
  res.sendFile(path.resolve(__dirname, "../dist/main", "index.html"));
});

app.get("/scheduler/*", (req, res) => {
  res.sendFile(path.resolve(__dirname, "../dist/scheduler", "index.html"));
});

app.get("/hr/*", (req, res) => {
  res.sendFile(path.resolve(__dirname, "../dist/hr", "index.html"));
});

module.exports = app;
