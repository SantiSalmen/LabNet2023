const restartbutton = document.querySelector('#restartbutton')
const subbutton = document.querySelector('#subbutton');
const start = document.querySelector('#start')
let windowContainer = document.querySelector('#windowId');
let randomNumber;
let guesNum = document.querySelector('#guessNum');
let htmlLives = document.querySelector('.lives');
let htmlTrys = document.querySelector('.Trys');
let htmlHighscore = document.querySelector('.highscore');
let gameMessege = "";
let highScore = 0;
let score;
let lives = 5;
let trys = [];
let runPage = true;


StartGame();
if(runPage){  
    start.addEventListener('click', function(e){
        e.preventDefault();
        windowContainer.style.visibility = 'hidden';
        StartGame();
    });
    restartbutton.addEventListener('click', function(e){
        e.preventDefault();
        StartGame();
    });
    subbutton.addEventListener("click", function(e){
        e.preventDefault();
        const guess = parseInt(guesNum.value);
        Valid(guess);  
    });
    
};


function Valid(guess){
    if (isNaN(guess))
    {
        alert('Coloca un caracter valido');
    } else if (guess > 20 || guess < 1)
    {
        alert('Solo puedes colocar numeros entre 1 y 20');
    } else {
        trys.push(guess);
        
        CheckNum(guess);
    };
};

function CheckNum(guess)
{
    if(guess > randomNumber)
    {
        gameMessege.innerHTML = "El numero es mas bajo";
        lives--;
        htmlLives.innerHTML = lives;
        htmlTrys.innerHTML = trys;
        
    }else if(guess < randomNumber){
        
        gameMessege.innerHTML = "El numero es mas alto";
        lives--;
        htmlLives.innerHTML = lives;
        htmlTrys.innerHTML = trys;
        
    }
    else if (guess === randomNumber) {
        score = CalculateScore();
        htmlHighscore.innerHTML =`${score} Pts` ;
        StartGame();
        alert("Ganaste!! Nadie será despedido hoy!!");     
        
    };
    if(lives === 0) {
        EndGame();
    };
};

function CalculateScore() {
    
    let scoreNumber = 0;
    
    if (lives === 5) 
    {scoreNumber = 100} 
    else if (lives === 4)
    {scoreNumber = 80}
    else if (lives === 3)
    {scoreNumber = 60}
    else if (lives === 2)
    {scoreNumber = 40}
    else if (lives === 1)
    {scoreNumber = 20}
    else {scoreNumber = 0};
    
    if (scoreNumber > highScore) 
    {
        highScore = scoreNumber;
    };

    return highScore;
      
};

function EndGame() {
    alert('Perdiste, el sistema blockeó el acceso!! Presiona aceptar para volver a jugar.');
    StartGame();
};


function StartGame(){
    randomNumber = parseInt((Math.random()*20) +1);
    gameMessege = document.querySelector('#gameMessege');
    trys = [];
    lives = 5;
    htmlLives.innerHTML = lives;
    htmlTrys.innerHTML = trys;
};