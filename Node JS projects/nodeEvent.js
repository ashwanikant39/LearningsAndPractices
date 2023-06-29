const eventEmitter = require("events");
class MyEmitter extends eventEmitter {}
const myEmitter = new MyEmitter();
myEmitter.on("waterFull", () => {
  console.log("Please turn off motor");
  setTimeout(() => {
    console.log("repeat");
  }, 4000);
});
console.log("Hello1");
myEmitter.emit("waterFull");
console.log("Hello2");
