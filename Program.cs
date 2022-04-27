// See https://aka.ms/new-console-template for more information
/* 
Benjamin Pratt
CSE 210 Tic-Tac-Toe
This program creates a tic-tac-toe game for the user to play.
*/
public class ticTacToe
{
    // Writes the board using the array of characters named square
    static void writeBoard(char[] squares){
        Console.WriteLine($"{squares[0]}|{squares[1]}|{squares[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{squares[3]}|{squares[4]}|{squares[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{squares[6]}|{squares[7]}|{squares[8]}\n");
    }

    //Returns a boolean value based on if 3 values in a line
    //are equivalent.
    static bool winningBoard(char[] squares) 
    {
        return ((squares[0] == squares[1] && squares[1] == squares[2]) ||
                (squares[3] == squares[4] && squares[4] == squares[5]) ||
                (squares[6] == squares[7] && squares[7] == squares[8]) ||
                (squares[0] == squares[3] && squares[3] == squares[6]) ||
                (squares[1] == squares[4] && squares[4] == squares[7]) ||
                (squares[2] == squares[5] && squares[5] == squares[8]) ||
                (squares[0] == squares[4] && squares[4] == squares[8]) ||
                (squares[2] == squares[4] && squares[4] == squares[6]));
    }

    //Checks if there are any places in the board left and returns
    //a bool.
    static bool isDraw(char[] squares)
    {
        int j = 0;
        //adds up the number of spaces that contain 'x' or 'o'
        foreach(char i in squares)
        {
            if(i == 'x' || i == 'o')
            {
                j++;
            }
        }
        //if the number of spaces equals 9, then the game is declared a draw. 
        return j == 9;
    }

    //Changes the turn to the other player.
    static char changeTurn(char turn) 
    {
        if (turn == 'x')
        {
            turn = 'o';
        } else
        {
            turn = 'x';
        }
        return turn;
    }

    //Main creates the character array, displays the output,
    //and does the turns.
    public static void Main(string[] args)
    {
        //initialize variables
        char[] squares = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
        char turn = 'x';
        
        //write the board
        writeBoard(squares);
        
        //while the game hasn't ended, it lets the players do their
        //turns
        while(!winningBoard(squares) && !isDraw(squares))
        {
            //read user input
            var squareNumber = "\0";
            bool inputWorks = false;
            //check the user input to make sure it is valid
            //I am almost certain there is a better way to
            //check the inputs because this is a lotta code
            // for a single input
            while(!inputWorks || squareNumber is null)
            {
                Console.Write($"{turn}'s turn to choose a square (1-9): ");
                squareNumber = Console.ReadLine();
                //checks if input is between 1 and 9
                switch(squareNumber)
                {
                    case "1" or "2" or "3" or "4" or "5"
                         or "6" or "7" or "8" or "9": 
                        inputWorks = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        inputWorks = false;
                        break;
                }
                
                //checks if the square is already taken
                //also checks if it input is already false so that
                //there is not an error when it checks the square
                if (squareNumber is null || inputWorks == false ||
                    squares[Int32.Parse(squareNumber) - 1] == 'x' ||
                    squares[Int32.Parse(squareNumber) - 1] == 'o')
                {
                    inputWorks = false;
                }
            }
            
            //Parses squareNumber, subtracts it by 1, and changes the char
            //at that location in the array to either an x or a y.
            squares[Int32.Parse(squareNumber) - 1] = turn; 
            //changes who's turn it is
            turn = changeTurn(turn);

            //outputs the current board state
            Console.WriteLine();
            writeBoard(squares);
        }

        //output that the game ended
        Console.WriteLine("Good game. Thanks for playing!");
        
    }
}
