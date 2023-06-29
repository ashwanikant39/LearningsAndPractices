const fs = require("fs");

// fs.readFile("file.txt", "utf8", (err, data) => {
//   console.log(err, data);
// });
// const a = fs.readFileSync("file.txt");
// console.log(a.toString);

// fs.writeFile('file2.txt', 'hello world', ()=>{
//     console.log("written")
// })

const b = fs.writeFileSync("file3.txt", "hello world!");
console.log("written");
console.log("Finished");

