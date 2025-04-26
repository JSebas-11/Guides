using System;
using firstClass;
using arrays;
using ticTac;
using others;
using LinqBasis;

namespace Main{
    public class Program{
        public static void CleanWait(){
            Console.WriteLine("Type any char to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args) {

            Fundamentals.FundamentalsMain();
            CleanWait();

            streamControl.streamControlMain();
            CleanWait();

            Person.OopMain();
            CleanWait();

            MyArray.ArrayMain();
            CleanWait();

            MyMatrix.MatrixMain();
            CleanWait();
            
            IrrMatrix.MainIrrMatrix();
            CleanWait();

            Date.DateMain();
            CleanWait();

            DelEve.DelEveMain();
            CleanWait();

            LinqObje.LinqMain();
            CleanWait();

            Game.TicTacMain();
            CleanWait();
        }
    }
}
