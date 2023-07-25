const express = require("express");
const path = require("path");
const app = express();
const port = 3000;
app.use(express.static(path.join(__dirname, "public")));

app.get("/hello", (req, res) => {
  console.log(req.url);
  res.send("Hello World!");
});
app.get("/about/:name", (req, res) => {
  res.send("About page!" + req.params.name);
  // aditya()
  // res.sendFile(path.join(__dirname, "index.html"));
});

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
});
