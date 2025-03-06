let score = 0;
let piecesPlaced = 0;

function createPieces() {
    const piecesContainer = document.getElementById('pieces');
    piecesContainer.innerHTML = '';  // Clear previous pieces

    for (let i = 0; i < 3; i++) {
        const piece = document.createElement('div');
        piece.classList.add('piece');
        piece.setAttribute('draggable', 'true');
        piece.id = `piece${i}`;
        piecesContainer.appendChild(piece);
        
        piece.addEventListener('dragstart', dragStart);
        piece.addEventListener('dragend', dragEnd);
    }
}

function dragStart(e) {
    setTimeout(() => {
        e.target.classList.add('hide');
    }, 0);
    e.dataTransfer.setData('text', e.target.id);
}

function dragEnd(e) {
    e.target.classList.remove('hide');
}

function dragOver(e) {
    e.preventDefault();
}

function dragEnter(e) {
    e.preventDefault();
    e.target.classList.add('hovered');
}

function dragLeave(e) {
    e.target.classList.remove('hovered');
}

function drop(e) {
    const pieceId = e.dataTransfer.getData('text');
    const piece = document.getElementById(pieceId);
    if (e.target.classList.contains('grid-cell') && !e.target.hasChildNodes()) {
        e.target.appendChild(piece);
        e.target.classList.remove('hovered');
        piecesPlaced++;
        updateScore();
        
        // Check if all pieces have been placed
        if (piecesPlaced === 3) {
            setTimeout(() => {
                createPieces();  // Generate new pieces
                piecesPlaced = 0;  // Reset counter
            }, 500);  // Delay before regenerating pieces
        }
    }
}

function updateScore() {
    score += 10;  // Adjust the score increment as needed
    document.getElementById('score').innerText = score;
}

// Create grid dynamically
function createGrid() {
    const grid = document.getElementById('grid');
    for (let i = 0; i < 25; i++) {
        const cell = document.createElement('div');
        cell.classList.add('grid-cell');
        grid.appendChild(cell);
    }
}

// Initialize game
function init() {
    createGrid();
    createPieces();
    
    const gridCells = document.querySelectorAll('.grid-cell');
    gridCells.forEach(cell => {
        cell.addEventListener('dragover', dragOver);
        cell.addEventListener('dragenter', dragEnter);
        cell.addEventListener('dragleave', dragLeave);
        cell.addEventListener('drop', drop);
    });
}

init();  // Start the game
