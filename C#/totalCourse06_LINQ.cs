using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace LinqBasis{
    /*LINQ (Language Integrated Query) es una forma de consultar y manipular colecciones de datos 
     (como arrays, listas, XML, bases de datos, etc.) con una sintaxis parecida a SQL o con expresiones lambda.*/
    internal class LinqObje{
        // Fix for the CS0019 error: Replace the invalid string multiplication with a valid string constructor.
        public static string StraigthLines = new string('-', 30);
        public static void LinqMain() {
            List<Game> store1Games = new List<Game>{
                new Game("God of War", 2018, 8.5f, 1),
                new Game("Biomutant", 2015, 3.5f, 1),
                new Game("Fifa", 2022, 7.5f, 1),
                new Game("Hollow Knight", 2018, 9.5f, 1),
                new Game("Ceci's Adventures", 2024, 5.5f, 1)
            };
            Store store1 = new Store(1, "Xtream", store1Games);

            List<Game> store2Games = new List<Game>{
                new Game("Battlefield 5018", 2021, 8.0f, 2),
                new Game("GTA V", 2015, 9.8f, 2),
                new Game("Just Cause", 2020, 7.0f, 2),
                new Game("CupHead", 2019, 10.0f, 2),
                new Game("Far cry", 2013, 9.6f, 2),
                new Game("Eric Cartaman's Adventures", 2010, 5.0f, 2)
            };
            Store store2 = new Store(2, "Awful Games", store2Games);

            List<Game> store3Games = new List<Game>{
                new Game("Pro Evolution", 2012, 9.0f, 3),
                new Game("Venezoland", 2015, 2.1f, 3),
                new Game("Red Dead", 2009, 8.8f, 3),
                new Game("Days Gone", 2018, 8.1f, 3),
                new Game("Suck Dicks", 2016, 3.0f, 3)
            };
            Store store3 = new Store(3, "Fake Play", store3Games);

            ManagStore managment = new ManagStore(new List<Store> { store1, store2, store3 });

            //Obtener todos los juegos con score mayor a x.
            float x = 9.0f;
            Console.WriteLine($"Games score greater than {x}:");
            managment.ScoreGreaterThan(x);

            Console.WriteLine(StraigthLines);

            //Convertir todos los juegos con Score menor a 50 en una nueva lista.
            x = 5.0f;
            Console.WriteLine($"Games score less than {x}");
            List<Game> list = managment.LessThanToList(x);
            list.ForEach(g => g.GameInfo());

            Console.WriteLine(StraigthLines);

            //Obtener el primer juego que tenga el título que comience con "A" o "a".
            string starts = "a";
            Game? first = managment.FirstWithName(starts);

            if (first == null) { Console.WriteLine($"There's not game starting with {starts}"); }
            else { first.GameInfo(); }

            Console.WriteLine(StraigthLines);

            //Verificar si hay algún juego con Score perfecto(10).
            Game? perfect = managment.PerfectGame();

            if (perfect == null) { Console.WriteLine("There's not game with score perfect"); }
            else { perfect.GameInfo(); }

            Console.WriteLine(StraigthLines);

            //Contar cuántos juegos se lanzaron después del año 2015.
            int year = 2015;
            Console.WriteLine($"They have been released {managment.CountAfter(year)} games since {year}");

            Console.WriteLine(StraigthLines);

            Main.Program.CleanWait();

            //Comprobar si todos los juegos de una tienda tienen un Score mayor a 5.0.
            float score = 5.0f;
            managment.AllStoreGamesGreater(score);

            Console.WriteLine(StraigthLines);

            //Ordenar los juegos por año, y luego por título alfabéticamente.
            bool ascending = true;
            List<Game> asc = managment.OrderYearTit(ascending);
            Console.WriteLine("Ascending Order: ");
            foreach (Game game in asc) { game.GameInfo(); }

            Console.WriteLine(StraigthLines);

            List<Game> desc = managment.OrderYearTit(!ascending);
            Console.WriteLine("Descending Order: ");
            foreach (Game game in desc) { game.GameInfo(); }

            Console.WriteLine(StraigthLines);
            Main.Program.CleanWait();

            //Calcular la suma total de los puntajes(Score) de todos los juegos por tienda.
            managment.SumByStore();

            Console.WriteLine(StraigthLines);

            //Calcular el puntaje promedio de todos los juegos lanzados en 2018.
            year = 2018;
            Console.WriteLine($"Year {year} average: {managment.AvgByYear(year)}");

            Console.WriteLine(StraigthLines);

            //Obtener una lista de los únicos años en los que se han lanzado juegos.
            Console.WriteLine("Years with games: ");
            List<int> yearsG = managment.GamesYear();
            foreach (int yearG in yearsG) { Console.WriteLine(yearG); }

            Console.WriteLine(StraigthLines);
            Main.Program.CleanWait();

            //Obtener una lista de objetos anónimos que contengan el nombre del Store y el título de cada juego.
            List<dynamic> names = managment.StoreNameGame();
            Console.WriteLine("Store Name\tGame Name");
            foreach (var item in names) {
                Console.WriteLine($"{item.Store}\t{item.Game}");
            }

            Console.WriteLine(StraigthLines);

            //Agrupar los juegos por Year y mostrar cuántos juegos se lanzaron por año.
            List<dynamic> agroupY = managment.GamesByYear();
            Console.WriteLine("Year\tAmount");
            foreach (var item in agroupY) {
                Console.WriteLine($"{item.Year}\t{item.Amount}");
            }

            Console.WriteLine(StraigthLines);

            //Obtener una lista de algun atributo de todos los juegos.
            string attr = "Title";
            List<dynamic> attrs = managment.GetAttr(attr);
            if (attrs != null) {
                Console.WriteLine($"{attr} Properties:");
                foreach (var item in attrs) {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();
            }

            attr = "Xd";
            attrs = managment.GetAttr(attr);
            if (attrs != null) {
                Console.WriteLine($"{attr} Properties:");
                foreach (var item in attrs) {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();
            }

            attr = "Score";
            attrs = managment.GetAttr(attr);
            if (attrs != null) {
                Console.WriteLine($"{attr} Properties:");
                foreach (var item in attrs) {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(StraigthLines);
            Main.Program.CleanWait();
            Console.WriteLine(StraigthLines);

            //Ordenar los juegos por algun atributo de forma asc/des
            attr = "Title";
            List<Game> games = managment.OrderBy(attr, true);
            if (games != null){
                Console.WriteLine($"Order by {attr} ASC");
                foreach (Game game in games){
                    game.GameInfo();
                }
            }

            Console.WriteLine(StraigthLines);

            games = managment.OrderBy(attr, false);
            if (games != null) {
                Console.WriteLine($"Order by {attr} DESC");
                foreach (Game game in games){
                    game.GameInfo();
                }
            }

            Console.WriteLine(StraigthLines);
            Main.Program.CleanWait();

            //Saltar los 3 primeros juegos y obtener los siguientes 3 con menor Score.
            Console.WriteLine("Next 3 worst:");
            managment.Skip3WorstScore();

            Console.WriteLine(StraigthLines);

            //Obtener los n primeros juegos con mayor atributo especifo.
            attr = "Score";
            x = 5; 
            games = managment.GetXBy(attr, (int)x);
            if (games != null){
                Console.WriteLine($"Get {x} by {attr}");
                foreach (Game game in games){
                    game.GameInfo();
                }
            }
        }
    }

    internal class ManagStore {
        private readonly List<Store> stores;
        private List<Game> AllGames;
        private Type gameType = typeof(Game);
        public ManagStore(List<Store> stores) {
            this.stores = stores;
            this.AllGames = new List<Game>() { };
            foreach (Store store in this.stores) {
                this.AllGames.AddRange(store.games);
            }
        }

        public void ScoreGreaterThan(float x) {
            IEnumerable<Game> newList;
            foreach (Store sto in this.stores) {
                newList = sto.games.Where(g => g.Score > x);
                foreach (Game item in newList) {
                    item.GameInfo();
                }
            }
        }
        public List<Game> LessThanToList(float x) {
            var newList = new List<Game>() { };
            foreach (Store store in this.stores) {
                newList.AddRange(store.games.Where(g => g.Score < x));
            }
            return newList;
        }
        public Game? FirstWithName(string looFor) {
            return this.AllGames.FirstOrDefault(g => g.Title.ToLower().StartsWith(looFor.ToLower()));
        }
        public Game? PerfectGame() {
            return this.AllGames.FirstOrDefault(g => g.Score == 10.0);
        }
        public int CountAfter(int x) {
            return this.AllGames.Where(g => g.Year > x).Count();
        }
        public void AllStoreGamesGreater(float x) {
            bool allGames;
            foreach (Store store in this.stores) {
                allGames = store.games.All(g => g.Score > x);
                Console.WriteLine($"Store {store.StoreId} {allGames}");
            }
        }
        public List<Game> OrderYearTit(bool asc) {
            var newList = new List<Game>() { };
            if (asc) {
                newList = [.. this.AllGames.OrderBy(g => g.Year).ThenBy(g => g.Title)];
            } else {
                newList = [.. this.AllGames.OrderByDescending(g => g.Year).ThenByDescending(g => g.Title)];
            }
            return newList;
        }
        public void SumByStore() {
            foreach (Store store in this.stores) {
                Console.WriteLine($"Store {store.StoreId} Sum Scores {store.games.Sum(g => g.Score)}");
            }
        }
        public decimal AvgByYear(int x) {
            return (decimal)this.AllGames.Where(g => g.Year == x).Average(g => g.Score);
        }
        public List<int> GamesYear() {
            return [.. this.AllGames.Select(g => g.Year).Distinct().Order()];
        }
        public List<dynamic> StoreNameGame() {
            var newList = from g in this.AllGames
                          join s in this.stores 
                          on g.StoreID equals s.StoreId
                          select new { Store = s.StoreName, Game = g.Title };
            return newList.ToList<dynamic>();
        }
        public List<dynamic> GamesByYear(){
            var newList = this.AllGames.GroupBy(g => g.Year).
                          Select(g => new { Year = g.Key, Amount = g.Count() }).
                          OrderBy(g => g.Year);
            return newList.ToList<dynamic>();
        }
        public List<dynamic>? GetAttr(string attrName){
            PropertyInfo attr = this.gameType.GetProperty(attrName);
            if (attr == null){ 
                Console.WriteLine($"{attrName} doesnt exist");
                return null;
            }
            return [.. this.AllGames.Select(g => attr.GetValue(g))];
        }
        public List<Game>? OrderBy(string attr, bool asc){
            PropertyInfo property = this.gameType.GetProperty(attr);
            if (property == null){
                Console.WriteLine($"{attr} doesnt exist");
                return null;
            }
            if (asc){
                return [.. this.AllGames.OrderBy(g => property.GetValue(g))];
            } else {
                return [.. this.AllGames.OrderByDescending(g => property.GetValue(g))];
            }
        }
        public void Skip3WorstScore(){
            List<Game> newList = [.. this.AllGames.OrderBy(g => g.Score).Take(6).Skip(3)];
            foreach (Game game in newList){
                game.GameInfo();
            }
        }
        public List<Game>? GetXBy(string attr, int x){
            PropertyInfo property = this.gameType.GetProperty(attr);
            if (property == null){
                Console.WriteLine($"{attr} doesnt exist");
                return null;
            }
            return [.. this.AllGames.OrderByDescending(g => property.GetValue(g)).Take(x)];
        }
    }

    internal class Game{
        public string Title { get; set; }
        public int Year { get; set; }
        public float Score { get; set; }
        public int StoreID { get; set; }
        public Game(string title, int year, float score, int storeID){
            Title = title;
            Year = year;
            Score = score;
            StoreID = storeID;
        }
        public void GameInfo() { Console.WriteLine($"Store {this.StoreID}-{this.Title}: {this.Score} ({this.Year})"); }
    }
    internal class Store{
        public string StoreName { get; set; }
        public int StoreId { get; set; }
        public int AmountGames { get; set; }
        public List<Game> games { get; set; }
        public Store(int storeId, string stName, List<Game> games){
            StoreName = stName;
            StoreId = storeId;
            this.games = games;
            AmountGames = games.Count();
        }
        public void ShowGames(){
            foreach (Game game in this.games) { game.GameInfo(); }
        }
    }
}