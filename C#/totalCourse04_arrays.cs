using System;
using System.Drawing;

namespace arrays { 
    internal class MyArray{
        private int size;
        private int[] array;
    
        MyArray(int _size){
            //Declaracion
            array = new int[_size];
            size = array.Length; //Propiedad para obtener cantidad elementos
        }
        MyArray(int[] _array){
            array = _array;
            size = _array.Length; 
        }
    
        public void Fill(){
            for (int i = 0; i < this.size; i++){
                Console.Write($"Type element {i} -> ");
                //Definir valor elemento en posicion i
                array[i] = int.Parse(Console.ReadLine());
            }
        }
    
        public void Show(){
            foreach (int item in array){
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    
        public static void ArrayMain(){
            Console.Write("Type the array's size -> ");
            var array1 = new MyArray(int.Parse(Console.ReadLine()));
    
            array1.Fill();
            array1.Show();
    
            var array2 = new MyArray(new int[] {1, 2, 3, 4, 5});
            array2.Show();
        }
    }
    
    internal class MyMatrix{
        private int cols;
        private int rows;
        private int dimensions;
        private int[,] matrix;

        //matrix.GetLength(dim) dim = 0 -> cantidad filas / dim = 1 -> cantidad columnas
        MyMatrix(int _rows, int _cols){
            //Declaracion ( , <- representa cantidad de dimensiones)
            matrix = new int[_rows, _cols];
            rows = _rows;
            cols = _cols;
            dimensions = matrix.Rank; //Obtener cantidad de dimensiones
        }
    
        public void Fill(){
            for (int i = 0; i < this.rows; i++){
                for (int j = 0; j < this.cols; j++){
                    Console.Write($"Type value for position [{i}][{j}] -> ");
                    this.matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
    
        public void Show(){
            for (int i = 0; i < this.rows; i++){
                for (int j = 0; j < this.cols; j++){
                    Console.Write($"{this.matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    
        public static void MatrixMain(){
            Console.Write("Type the rows' matrix -> ");
            var rows = int.Parse(Console.ReadLine());
            Console.Write("Type the cols' matrix -> ");
            var cols = int.Parse(Console.ReadLine());
    
            var matrix1 = new MyMatrix(rows, cols);
    
            matrix1.Fill();
            matrix1.Show();
        }
    }

    internal class IrrMatrix{
        private int rows;
        private int[][] matrix;

        public IrrMatrix(int _rows){
            this.rows = _rows;
            matrix = new int[rows][];
        }
        public void InitRows(){
            for (int i = 0; i < this.rows; i++){
                Console.Write($"How many elements do you want to throw in vector's matrix [{i}] -> ");
                this.matrix[i] = new int[int.Parse(Console.ReadLine())];
            }
        }
        public void Fill(){
            for (int i = 0; i < this.rows; i++){
                for (int j = 0; j < this.matrix[i].Length; j++){
                    Console.Write($"Element position [{i}][{j}] -> ");
                    this.matrix[i][j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public void Show(){
            for (int i = 0; i < this.rows; i++){
                for (int j = 0; j < this.matrix[i].Length; j++){
                    Console.Write($"{this.matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void MainIrrMatrix(){
            Console.Write("Matrix rows number -> ");
            var irrMtx = new IrrMatrix(int.Parse(Console.ReadLine()));

            irrMtx.InitRows();
            irrMtx.Fill();
            irrMtx.Show();
        }
    }
}
