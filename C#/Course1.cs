using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Runtime.InteropServices;

namespace Exercises{
    class Program{
        static bool IsInputValid(string inputStr){
            string pattern = @"(\d{1,}\-){2,}\d";
            var regex = new Regex(pattern);
            return regex.IsMatch(inputStr);
        }
        static bool AreConsecutives(string toComprobate){
            var numbersList = toComprobate.Split("-");
            int[] numbers = Array.ConvertAll(numbersList, int.Parse);

            bool ascending = true; bool descending = true;
            int firstElement = numbers[0];

            for (int i = 1; i < numbersList.Length; i++){
                if (firstElement + i != numbers[i]){ ascending = false; }
                if (firstElement - i != numbers[i]){ descending = false; }
            }
            return ascending || descending;
        }
        static void Exercise1() {
            /*1.Write a program and ask the user to enter a few numbers separated by 
              a hyphen.Work out if the numbers are consecutive. For example,
              if the input is "5-6-7-8-9" or "20-19-18-17-16", display
              a message: "Consecutive"; otherwise, display "Not Consecutive".*/

            bool isValid, consecutives;
            string hyphenNumbers;
            do {
                isValid = true;
                Console.Write("Type 5 numbers separated by a hyphen (-) -> ");
                hyphenNumbers = Console.ReadLine();
                if (!IsInputValid(hyphenNumbers)){
                    Console.WriteLine("It must have minimum 3 numbers (#-#-#...)");
                    isValid = false;
                } 
            } while (!isValid);

            consecutives = AreConsecutives(hyphenNumbers);
            if (consecutives){ Console.WriteLine("Numbers are consecutives!"); }
            else { Console.WriteLine("Numbers are not consecutives!"); }

        }

        static bool VerifyTimeFormat(string userTime){
            string pattern = @"\d{2,2}\:\d{2,2}";
            var regex = new Regex(pattern);
            return regex.IsMatch(userTime);
        }
        static bool VerifyTime(string userTime){
            var time = Array.ConvertAll(userTime.Split(":"), int.Parse);
            if ((time[0] > 23 || time[0] < 0) || (time[1] > 59 || time[1] < 0)){
                return false;
            }
            return true;
        }
        static void Exercise2(){
            /*2.Write a program and ask the user to enter a time value in the 24-hour
            time format(e.g. 19:00). If the time is valid, display "Ok"; otherwise, 
            display "Invalid Time". If the user doesn't provide any values, 
            consider it as invalid time.*/

            Console.Write("Type a time value in 24-hour format -> ");
            string userTime = Console.ReadLine();

            if (!VerifyTimeFormat(userTime)){
                Console.WriteLine("Invalid time format");
                return;
            }

            if (VerifyTime(userTime)){ Console.WriteLine("Ok, valid time"); }
            else { Console.WriteLine("Invalid time"); }
        }

        static StringBuilder ToPascalCase(string strToConvert){
            var separatedStr = Array.ConvertAll(strToConvert.Split(), str => str.ToLower());
            string neWord;
            char firstChar;
            var result = new StringBuilder();
            foreach (var word in separatedStr){
                firstChar = word[0];
                neWord = $"{Char.ToUpper(firstChar)}{word.Substring(1)}";
                result.Append(neWord);
            }
            return result;
        }

        static void Exercise3(){
            /*3.Write a program and ask the user to enter a few words separated by a space. 
             Use the words to create a variable name with PascalCase. For example: 
            "number of students"-->"NumberOfStudents". Make sure that the program is not 
            dependent on the input case.*/
            Console.Write("Type words separated by a space to convert a PascalCase\n\t");
            string variableName = Console.ReadLine();
            Console.WriteLine($"The new PascualCase name: {ToPascalCase(variableName)}");
        }

        static int CountVowels(string word){
            var vowels = new List<char> { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
            int vowelsCount = 0;

            for (int i = 0; i < word.Length; i++){
                if (vowels.Contains(word[i])){
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }

        static void Exercise4(){
            /*4.Write a program and ask the user to enter an English word. Count the 
            number of vowels (a, e, o, u, i) in the word.*/
            Console.Write("Type a word to count the vowels -> ");
            string word = Console.ReadLine();
            Console.WriteLine($"The word {word} has {CountVowels(word)} vowels");
        }

        static void WriteIn(string path, string text) {
            if (File.Exists(path)){
                File.AppendAllText(path, $"\n{text}");
                Console.WriteLine("Text added successfully");
            } else {
                //Using works like a kind of "with open" (python)
                using (FileStream fs = File.Create(path)){
                    byte[] data = new UTF8Encoding(true).GetBytes(text);
                    fs.Write(data, 0, data.Length);
                    Console.WriteLine("File created and text inserted successfully");
                }
            }
        }

        static void ReadContent(string path) {
            if (!Path.Exists(path)){
                Console.WriteLine("File in path not found");
                return;
            }
            Console.Write(File.ReadAllText(path));
        }

        static void Exercise5(){
            const string file1Path = @"..\..\..\..\myFile.txt";
            /*5.Create a file and write into it the user input, then read the file
                and show the content*/
            Console.WriteLine("Type the text to copy in the file");
            string text = Console.ReadLine();
            WriteIn(file1Path, text);
            Console.WriteLine("-----------------");
            ReadContent(file1Path);
            Console.WriteLine("\n-----------------");
        }

        static int CountWords(string path){
            if (!Path.Exists(path)){
                Console.WriteLine("File not found in path");
                return -1;
            }
            var words = File.ReadAllText(path).Split();
            int wordsNum = 0;
            foreach (string word in words){ wordsNum++; }
            return wordsNum;
        }

        const string file2Path = @"..\..\..\..\words.txt";
        static void Exercise6(){
            /*6.Count the words' number in a file (no whitespaces)*/            
            int wordsNum = CountWords(file2Path);
            Console.WriteLine($"It has {wordsNum} words:");
            Console.Write(File.ReadAllText(file2Path));
            Console.WriteLine("\n-----------------");
        }

        static (string, string) LargestSmallest(string path){
            if (!Path.Exists(path)){
                Console.WriteLine("File not found in path");
                return ("-1", "-1");
            }
            var words = File.ReadAllText(file2Path).Split();
            string largest = words[0];
            string smallest = words[0];
            foreach (string word in words){
                if (word.Length > largest.Length){ largest = word; }
                if (word.Length < smallest.Length){ smallest = word; }
            }
            return (largest, smallest);
        }
        static void Exercise7(){
            /*7.Show the largest and smallest word in a text file*/
            (string, string) words = LargestSmallest(file2Path);
            Console.WriteLine($"Largest word: {words.Item1}-Smallest word: {words.Item2}");
            Console.Write(File.ReadAllText(file2Path));
            Console.WriteLine("\n-----------------");
        }

        static void Main(string[] args) {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
            Exercise5();
            Exercise6();
            Exercise7();
        }
    }
}