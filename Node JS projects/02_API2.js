// // // import node.js built-in http module

// // var http = require("http");

// // // creating server

// // http
// //   .createServer(function (req, res) {
// //     // Write response to client

// //     res.write("Hello World!");

// //     // End the response

// //     res.end();
// //   })
// //   .listen(4200);
// // console.log("hello world")

// let marks = [1, 7, 9, 4, 6, 8, null, undefined];

// // for(let i=0; i<=marks.length-1; i++){
// //     console.log(marks[i]+"  ")
// // }

// //   marks.forEach((Element) => {
// //     console.log(Element);
// //   });

// //   let name = "Aditya";
// //   let name2 = Array.from(name);
// //   console.log(name2);

// for (let i of marks) {
//   console.log(i);
// }

let n = new Date();
console.log(n);
console.log(n.getDay());
console.log(n.getDate());
console.log(n.getMonth() + 1);
console.log(n.getHours());
