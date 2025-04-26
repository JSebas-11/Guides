using System;
using System.Collections.Generic;
using System.Text;

namespace others{
    internal class Date{
        public static void DateMain(){
            DateTime date = new DateTime(2001, 09, 11);
            
            Console.WriteLine(Math.Abs(DateTime.Today.Subtract(date).Days));

            for (int i = 2020; i <= DateTime.Today.Year; i++){
                Console.WriteLine($"First day of {i} was: {new DateTime(i, 01, 01).DayOfWeek}");
            }

            Console.Write("Type year to see its days -> ");
            int year = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 12; i++){
                Console.WriteLine($"Month {i}/{year} has {DateTime.DaysInMonth(year, i)} days");
            }
        }
    }
    internal class RegExp{
        /*CLASES DE CARACTERES:
            \t -> Tab | \n -> Nueva linea | \charClass -> Cancelar metachar
            .  -> Caracter comodín: Cualquier carácter excepto \n
            \d -> Digitos. (0-9) | \D -> No digitos.
            \w -> Alfanumericos. (a-z, A-Z, 0-9, _) | \W -> No alfanumericos.
            \s -> Espacios blancos. (' ', \t, \n) | \S -> No espacios blancos. (space, tab, newline)
        DELIMITADORES:
            (RegexOptions.Multiline): ^ -> Desde comienzo linea. | $ -> Final linea.
            \A -> Inicio de cadena. | \Z -> Final de cadena.
            \b -> Coincidencia en un límite entre un alfanumerico y un caracter no alfanumerico.
            \B -> La coincidencia no se debe producir en un límite \b.
        CUANTIFICADORES:
            | -> Ya sea lo que está antes o después.
            * -> 0 o mas. | + -> 1 o  mas. | ? -> 0 o 1.
            {x} -> Coincide con el elemento anterior n veces.
            {x,y} -> Coincide con el elemento anterior al menos x veces, pero no más de y veces.
        AGRUPAMIENTO:
            [character_group - ] -> Coincide con cualquier carácter del grupo o rango.
            [^character_group] -> Coincide con cualquier carácter que no sea del grupo.
            () -> Grupo que se tratara como una unidad*/
    }
    internal class DelEve{
        //Delegado es un tipo especial que guarda referencia a un metodo al ocurrir un evento
        // += -> Agregar delegado | -= -> Quitar delegado 
        private delegate void GetName(string txt);
        public delegate bool ValidateAge(int x);

        //Sender hace referencia a objeto que genero evento, e contiene info del evento
        /*Delegado define "plantilla" del metodo que manejara evento, evento es instancia
         del delegado que permite suscribir y ejecutar metodos al ocurrir un evento
            EventName?.Invoke(this, EventArgs.Empty) <- Ejecuta todos los metodos susritos
        **Es buena pratica declarar metodos de eventos como protected virtual*/
        public delegate void Downloader(object sender, EventArgs e);
        public event Downloader Downloaded;
        //Alternativa con delegado intregrado:
        public event EventHandler<EventArgs> Downloaded2;
        public static void DelEveMain(){
            //Metodos anonimos/en linea: Metodos sin nombre ni declaracion formal definidos en un delegado   
            GetName delgt = delegate (string txt) { Console.WriteLine($"Hi {txt} from a nameless method"); };

            Console.Write("Type your name -> ");
            string name = Console.ReadLine();

            delgt(name);

            //Lambda expressions: Forma mas concisa de escribiir metodos anonimos (util con LINQ)
            // Retornos: Func<params type, result type> name = (parameters) => behavior;
            // No retornos: Action<params type, result type> name = (parameters) => behavior;
            Console.Write("Type a number -> ");
            int number = int.Parse(Console.ReadLine());

            Func<int, int> square = (x) => x * x; 
            Console.WriteLine(square(number));

            List<string> orders = new List<string> { "A-65421-ARG", "U-19551-BRA", "F-98394-COL", "O-63862-ARG", "L-59314-MEX" };
            List<string> argentina = orders.FindAll(str => str.Contains("ARG"));
            argentina.ForEach(str => Console.WriteLine(str));

            //Crear instancia del delegado con una lambda
            ValidateAge validate = new ValidateAge(x => x >= 18);
            Console.WriteLine(validate(number));
        }
    }
}