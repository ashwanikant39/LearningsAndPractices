let dropCount = 0; // Track the number of successful drops
const maxDrops = 3; // Maximum number of shapes to drop before regenerating

// Create a 10x10 grid of boxes (100 items)
// let gridItem;
const gridContainer = document.querySelector(".grid-container");
// Dynamically create 100 boxes in the grid
for (let i = 0; i < 100; i++) {
  const gridItem = document.createElement("div");
  gridItem.classList.add("grid-item");
  gridItem.id = "box-" + i; // Assign an ID to each grid item
  gridItem.ondragover = allowDrop;
  gridItem.ondrop = drop;
  gridContainer.appendChild(gridItem);
}

let cells = document.querySelectorAll(".grid-item");
// console.log(cells);
cells.forEach((cell) => {
  // console.log(cell);
  cell.addEventListener("click", (e) => {
    console.log("clicked", cell.id);
  });
  // console.log("hi");
});
// Generate random shapes
function generateShapes() {
  const shapeContainer = document.getElementById("shape-container");
  shapeContainer.innerHTML = ""; // Clear previous shapes

  for (let i = 0; i < 3; i++) {
    const shapeDiv = document.createElement("div");
    shapeDiv.classList.add("shape");
    shapeDiv.setAttribute("draggable", "true");
    shapeDiv.ondragstart = drag;

    // Generate random shape blocks (2 to 4 blocks)
    const blockCount = Math.floor(Math.random() * 3) + 2;
    for (let j = 0; j < blockCount; j++) {
      const block = document.createElement("div");
      block.classList.add("shape-block");
      shapeDiv.appendChild(block);
    }

    // Append the shape to the shape container
    shapeContainer.appendChild(shapeDiv);
  }
}

// Allow dragging the shapes
function drag(event) {
  event.dataTransfer.setData("text", event.target.outerHTML); // Transfer shape's HTML
  setTimeout(() => {
    event.target.style.visibility = "hidden"; // Hide the element while dragging
  }, 0);
}

// Allow dropping on grid items
function allowDrop(event) {
  event.preventDefault(); // Necessary for allowing drop
}

// // Handle dropping the shape
function drop(event) {
  event.preventDefault();
  const shapeHTML = event.dataTransfer.getData("text");
  if (event.target.innerHTML === "") {
    // Only allow dropping if grid item is empty
    event.target.innerHTML = shapeHTML;

    // Increment the drop count
    dropCount++;

    // Check if all shapes have been dropped
    if (dropCount === maxDrops) {
      // Reset drop count and generate new shapes
      dropCount = 0;
      generateShapes();
    }
  }
}

// Generate shapes when the page loads
generateShapes();
