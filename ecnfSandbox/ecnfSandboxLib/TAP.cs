using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    /// <summary>
    /// a class using async/await. TAP stands for "Task Asynchronous Programming" which
    /// is a pattern that is similiar to planning when to do a task, just like
    /// you would using the Eisenhower matrix.
    /// 
    /// The compiler automatically remembers what he has to do and does it when 
    /// he has free time for it.
    /// </summary>
    public class TAP
    {
        //1) you can use them to get resources from networks such as the internet
        private static string URL = "http://acevancleef.bplaced.net/c_sharp/c_sharp-sandbox-async_target_resource.txt";

        public async Task<string> DownloadTXTFromInternetAsync()
        {
            HttpClient _httpClient = new HttpClient();
            string stringData = await _httpClient.GetStringAsync(URL);
            return stringData;
        }

        //2) or to calculate expensive calculations (expens. in runtime or memory)
        //   by giving this Task to another thread, freeing the UI thread (prevents unresponsive GUI).
        /// <summary>
        /// the method to be sent into seperate thread: Task.Run(thisMethod)
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public Boolean isTicTacToeGameWon(int[,] board)
        {
            Boolean isWon = false;
            if(board[0,0] == board[1,1] && board[1, 1] == board[2, 2])
            {
                isWon = true;
            }
            //and so on with more checking conditions
            return isWon;
        }

        public async Task<bool> isTicTacToeGameWonAsync(int[,] gameboard)
        {
            return await Task.Run(() => isTicTacToeGameWon(gameboard));

            /* Note:
             * - Task.Run(takes an Action delegate): no arguments!
             * - await is required (for schedule management).
             * - the caller of this method needs await 
             *   for type conversion from Task<bool> to bool.
             *- don't forget async on caller and this method.
             *
             */
        }



        /** #LessonLearned
         *  Für I/O gebundene Aufgaben: async/await ohne Task.Run()
         *  Für CPU-gebundene Aufgaben: async/await MIT Task.Run(() => ..);
         */





        /****** preparing test data *****/
        public int[,] setup2DGameBoard()
        {
            int[,] gameboard = new int[3, 3];
                //2D array init: <datatype>[,] <name> = new <datatype>[WIDTH, HEIGHT]
            //setup the board:
                //gameboard[x,y] = ..;
            gameboard[0, 0] = 1;    //1 = Player 1, 2 = Player 2
            gameboard[0, 1] = 2;
            gameboard[0, 2] = 2;

            gameboard[1, 0] = 2;
            gameboard[1, 1] = 1;
            gameboard[1, 2] = 2;

            gameboard[2, 0] = 2;
            gameboard[2, 1] = 2;
            gameboard[2, 2] = 1;

            return gameboard;
        }

        public void printGameBoard(int[,] gameboard)
        {
            //Note: gameboard.GetLength(int) to get length of one dimension

            Console.WriteLine("Printing 2D array...");
            for (int y = 0; y < gameboard.GetLength(1); ++y)
            {
                for(int x = 0; x < gameboard.GetLength(0); ++x)
                {
                    Console.Write($"{gameboard[x, y]},");
                    if(x % gameboard.GetLength(0) - 2 == 0){
                        Console.Write("\n");
                    }
                }
            }
        }
    }
}
