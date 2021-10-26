let express = require("express");

let app = express();

app.set("trust proxy", true);

let routes = require("./config/routes");
app.use(routes);

app.listen(4456, function () {
  console.log("HTTP server started.");
});
