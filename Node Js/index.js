const fs = require("fs");
const http = require("http");
// const a = readFile;
const url = require("url");
const port = process.env.PORT || 3000;
console.log(port);

const server = http.createServer((req, res) => {
  console.log(req.url);
  res.setHeader("Content-Type", "text/html");
  if (req.url == "/") {
    res.statusCode = 200;
    res.end("<h1>Welcome to server </h1>");
  } else if (req.url == "/api") {
    fs.readFile('', "utf-8", (err, data) => {
      const productData = JSON.parse(data);
      console.log(productData);
    });
  } else if (req.url == "/Hello") {
    res.statusCode = 200;
    res.end("<h1>Hello s server </h1>");
  } else if (req.url == "/game") {
    res.statusCode = 200;
    const data = fs.readFileSync("index.html", "utf-8");
    res.end(data.toString());
  } else if (req.url == "/about") {
    res.statusCode = 200;
    res.end("<h1>This is about server </h1>");
  } else {
    // res.aditya();
    res.statusCode = 404;
    res.end("<h1>page not found</h1>");
  }
});

server.listen(port, () => {
  console.log(`Server is listening on port ${port}`);
});
