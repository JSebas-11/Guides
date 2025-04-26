using Main;
using System;
using System.Numerics;
/// <summary>
/// Desarrollo de juego básico de Tres en Raya para practicar estructuras de control, 
/// arreglos, POO y manipulación de la consola. Requerimientos:
///     -Puede ser jugado por dos jugadores o contra un IA simple con jugadas aleatorias.
///     -Las casillas deben estar numeradas para que los jugadores elijan su movimiento. 
///     -Se deben alternar los turnos después de cada movimiento.
///     -El juego se podra jugar por un numero especifico de rondas.
///     -Se debe llevar marcador de victorias, derrotas y empates.
///     -El juego verifica si un jugador ha ganado después de cada turno. 
///         Un jugador gana si consigue tres símbolos en línea (horizontal, vertical o diagonal).
///         Si el tablero se llena y no hay ganador, el juego termina en empate.
///     -El jugador ingresa el número de la casilla donde desea colocar su símbolo.
///         Si el jugador elige una casilla ocupada o fuera del rango, se debe mostrar un 
///         mensaje de error y pedir otro intento.
///     -Mostrar mensaje de ganador (si hubo) y preguntar si quieren jugar otra vez o salir del programa.
/// </summary>

namespace ticTac {
    struct Player{
        internal char icon;
        internal int turn;

        internal Player(char _icon, int _turn){
            this.icon = _icon;
            this.turn = _turn;
        }
        public string Move(){ //Metodo usado para modo VS IA
            //Retornamos un numero random entre 1 y 9, convertido a string
            return new Random().Next(1, 9).ToString();
        }
    }

    public class Board{
        private int rows, cols;
        private char[,] positions; //Matrix con valores que iran dentro de la matrix

        internal Board(){
            this.rows = 3;
            this.cols = 3;
            this.positions = new char[3, 3]{ //Valores por defecto
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };
        }
        public void Reset(){ //Volver tablero a su estado inicial
            this.positions = new char[3, 3] {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };
        }
        public bool IsTaken(char valuePosition) { 
            /*Comprobar si existe algun valor (icon) en la posicion ingresada
             valuePosition representa el numero en la tabla*/
            for (int i = 0; i < this.rows; i++){
                for (int j = 0; j < this.cols; j++){
                    //Aun tiene el valor por defecto, asi que no ha sido ocupado
                    if (this.positions[i, j] == valuePosition){
                        return false;
                    }
                }
            }
            return true;
        }
        public bool SetPosition(char value, char newValue) {
            /*value -> numero que representa posicion en tablero
             -newValue -> valor que ocupara posicion de value*/
            for (int i = 0; i < this.rows; i++){
                for (int j = 0; j < this.cols; j++){
                    if (this.positions[i, j] == value){
                        this.positions[i, j] = newValue;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Winner(char icon){
            //Verificacion de posible 3 en raya en filas y columnas
            for (int i = 0; i < this.rows; i++){
                bool rowWin = true, colWin = true;
                for (int j = 0; j < this.rows; j++){
                    if (this.positions[i, j] != icon) rowWin = false;
                    if (this.positions[j, i] != icon) colWin = false;
                }
                if (rowWin || colWin) return true;
            }
            //Verificacion de posible 3 en raya en diagonales
            bool mainDiag = true, secDiag= true;
            for (int i = 0; i < this.rows; i++){
                if (this.positions[i, i] != icon) mainDiag = false;
                if (this.positions[this.rows-i-1, i] != icon) secDiag = false;
            }
            return (mainDiag || secDiag);
        }
        public void Show(){
            Console.WriteLine("_____________");
            for (int i = 0; i < this.rows; i++){
                Console.WriteLine("|   |   |   |");
                Console.Write("|");
                for (int j = 0; j < this.cols; j++){
                    Console.Write($" {this.positions[i, j]} |");
                }
                Console.WriteLine("\n|___|___|___|");
            }
        }
    }

    public class Game {
        //Metodo que apartir de un strig comprueba que si sea un numero y en un rango especifico
        public static bool ComprobeNum(string toEvaluate, int starts, int ends){
            bool isNum = int.TryParse(toEvaluate, out int number);
            if (!isNum){
                Console.WriteLine("You must type a number ome");
                return false;
            } else {
                if (!(number >= starts && number <= ends)){
                    Console.WriteLine($"What are you doing papi? Number out of range [{starts}-{ends}]");
                    return false;
                }
                return true;
            }
        }
        public static int GameMode(){
            string modeStr;
            bool isValid;
            
            do{
                Console.WriteLine("Select mode:\n1. VS IA\n2. VS Player\n0. Exit");
                modeStr = Console.ReadLine();
                isValid = Game.ComprobeNum(modeStr, 0, 2);
            } while (!isValid);

            if (modeStr == "0"){
                Console.WriteLine("Closing game...");
                Environment.Exit(0);
            }

            return int.Parse(modeStr);
        }
        public static int Rounds(){

            bool isValid;
            string roundStr;
            do{
                Console.Write("How many rounds do you want to play -> ");
                roundStr = Console.ReadLine();
                isValid = Game.ComprobeNum(roundStr, 1, 10);
            } while (!isValid);

            return int.Parse(roundStr);
        }

        public static char AskPlayerMove(Board board, int turn, string lines){
            //Funcion encargada de pedir movimiento y verificar que sea posible
            string playerMove;
            bool playerMoveValid;
            bool taken;

            while (true){
                board.Show();
                Console.WriteLine(lines);
                Console.Write($"Player {turn} turn (type number's position) -> ");
                playerMove = Console.ReadLine();
                playerMoveValid = Game.ComprobeNum(playerMove, 1, 9);

                if (!playerMoveValid){
                    Program.CleanWait();
                    continue;
                }

                taken = board.IsTaken(char.Parse(playerMove));
                if (taken){
                    Console.WriteLine("This position already has been taken men, try again");
                    Program.CleanWait();
                    continue;
                }

                return char.Parse(playerMove);
            }
        }
        public static void ShowCounter(int p1Wins, int p2Wins, int mode, string lines){
            Console.WriteLine($"{lines}\nCounter:");
            if (mode == 1){
                Console.WriteLine($"Player wins: {p1Wins} - IA wins: {p2Wins}");
            } else if (mode == 2) {
                Console.WriteLine($"Player 1 wins: {p1Wins} - Player 2 wins: {p2Wins}");
            }
            Console.WriteLine(lines);
        }

        public static void TicTacMain() {
            var StraightLines = new string('-', 30);

            bool finishGame = false;
            while (!finishGame){ //Bucle principal
                
                var mainBoard = new Board();
                //Nos retornara: 1 (VS IA) / 2 (VS PLAYER) 
                var mode = Game.GameMode(); 
                Console.Clear();
                var rounds = Game.Rounds();
                Console.Clear();

                var player1 = new Player('X', 1);
                var player2 = new Player('O', 2);
                int player1Wins = 0;
                int player2Wins = 0;
                //Bucle que se ejecutara mientras hayan rondas por jugar
                for (int i = 1; i <= rounds; i++){

                    bool winner = false;
                    int turn = 1;
                    while (!winner)
                    { //Bucle de la ronda que se ejecutara hasta que haya se acaben los movimientos o haya ganador
                        if (mode == 1)
                        {
                            if (turn == 1)
                            {
                                mainBoard.SetPosition(AskPlayerMove(mainBoard, 1, StraightLines), player1.icon);
                                Console.Clear();
                                winner = mainBoard.Winner(player1.icon);
                                if (winner)
                                {
                                    mainBoard.Show();
                                    Console.WriteLine($"{StraightLines}\nYou won, you are a rock\n{StraightLines}");
                                    player1Wins++;
                                    mainBoard.Reset();
                                }
                                turn = 2;
                            }
                            else if (turn == 2)
                            {
                                bool taken = true;
                                char iaMove = '0';
                                while (taken)
                                {
                                    iaMove = char.Parse(player2.Move());
                                    taken = mainBoard.IsTaken(iaMove);
                                }
                                mainBoard.SetPosition(iaMove, player2.icon);
                                mainBoard.Show();

                                winner = mainBoard.Winner(player2.icon);
                                if (winner)
                                {
                                    Console.WriteLine($"{StraightLines}\nHaha, a shit of IA beat you\n{StraightLines}");
                                    player2Wins++;
                                    mainBoard.Reset();
                                }
                                else
                                {
                                    Console.WriteLine($"{StraightLines}\nIa has played, the ball is in your court\n{StraightLines}");
                                    Program.CleanWait();
                                    turn = 1;
                                }
                            }
                        }
                        else if (mode == 2)
                        {
                            if (turn == 1)
                            {
                                mainBoard.SetPosition(AskPlayerMove(mainBoard, 1, StraightLines), player1.icon);
                                Console.Clear();
                                winner = mainBoard.Winner(player1.icon);
                                if (winner)
                                {
                                    mainBoard.Show();
                                    Console.WriteLine($"{StraightLines}\nPlayer 1 won, what's wrong with you 'Player 2'?\n{StraightLines}");
                                    player1Wins++;
                                    mainBoard.Reset();
                                }
                                turn = 2;
                            }
                            else if (turn == 2)
                            {
                                mainBoard.SetPosition(AskPlayerMove(mainBoard, 2, StraightLines), player2.icon);
                                Console.Clear();
                                winner = mainBoard.Winner(player2.icon);
                                if (winner)
                                {
                                    mainBoard.Show();
                                    Console.WriteLine($"{StraightLines}\nPlayer 1 won, what's wrong with you 'Player 2'?\n{StraightLines}");
                                    player1Wins++;
                                    mainBoard.Reset();
                                }
                                turn = 1;
                            }
                        }
                    }
                    ShowCounter(player1Wins, player2Wins, mode, StraightLines);
                    Program.CleanWait();
                }
            }
        }
    }
}
