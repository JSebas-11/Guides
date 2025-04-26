using System;

/// <summary>
/// Introductory class with c#'s basis
/// </summary>
public class Fundamentals{
    public static void FundamentalsMain() {
        // Variables: dynamic/type/var/object name = value;
        // Aceptar nulls: type? name = value || null;
        // Constantes: const type Name = value;

        double myDouble = 15.12;
        float myFloat = 15.12f; //Debemos agregar sufijo f-m, ya que por defecto  
        decimal myDecimal = 15.12m; //el compilador asigna double a numeros #.#

        int num1 = 15; int num2 = 30;
        Console.WriteLine($"{num1} + {num2}: {num1+num2}");

        string language = "C# men";
        Console.WriteLine(language.ToUpper());

        /* Estandares: 
            -Nombres variables razonables (no empezar con nums)
            -Nombres apropiados a funciones
            -Comentar codigo
            -PascalCase -> Clases, Metodos, constantes
            -camellCase -> parametros, variables
            -minusculas -> tipos datos
        */

        /*Tipos de datos de valor (int, char, float, etc): Guardan en memoria el valor
         Tipos de dato referencia (class, string, array): Almacena la direccion de memoria*/

        /*Conversiones:
            Desbordamiento memoria (overlflowing) <- Cuando una variable sale de su rango de valores
            Implicitas: Conversion tipo de dato menor a mayor*/
        int doubToInt = 15;
        double doub = doubToInt;

        //Explicitas(Casting): Data puede ser perdida
        double doubToCast = 18.55;
        int doubleConverted = (int)doubToCast;
        Console.WriteLine($"Implicit conversion: {doub}\nExplicit conversion: {doubleConverted}");
        //Casting nulleables
        int? intNull = null;
        int intNoNull = intNull ?? 0; // x ?? y <- si x es null, almacenara y, sino x

        //Convert.To... Method: 
        var newInt = Convert.ToInt32(doubToCast);

        //var.ToString(): other->string
        var newStr = doubToCast.ToString();

        //Parse: string->other
        string myStr = "18";
        bool done = int.TryParse(myStr, out int result);

        Console.WriteLine($"Convert method: {newInt}\nToString: {newStr}\nParsing ({done}): {result}");

        // Console Object:
        //Console.Write("Escribe texto en pantalla, dejando el cursor al final");
        //Console.WriteLine("Escribe texto en pantalla, generando un salto de linea al final");
        //Console.Read("Lee el buffer de entrada y retorna su valor ASCII");
        //Console.ReadLine("Lee el buffer de entrada y lo retorna como string");
        //Console.ReadKey("Lee el buffer de entrada y devuelve la tecla");
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("New colors");
        Console.ResetColor();
        Console.WriteLine("Default colors");
        Console.Write("Any key to continue...");
        Console.ReadKey();
        Console.Clear();

        //String Object:
        //string.ToLower()- .ToUpper()- .IndexOf(str)- .IsNullOrWhiteSpace()- .Concat(str)
        string myString = " Hi, I am a string ";
        Console.WriteLine($"Substring since [5]: {myString.Substring(5)}\nClear string: {myString.Trim()}");

        //Methods || Functions: acces return Name (parameters) { method's body; }
        /*Especificadores acceso:
            -public: Acceso desde cualquier parte del codigo
            -private: Acceso solo dentro de la misma clase
            -protected: Acceso desde la misma clase y clases derivadas
            -internal: Acceso solo desde el mismo proyecto
            -protected internal: Acceso desde el mismo proyecto y clases derivadas
            -private protected: Acceso desde la misma clase y clases derivadas del mismo proyecto
         */

        //Exceptions:
        while (true) {
            try {
                Console.Write("Type a number -> ");
                var input = int.Parse(Console.ReadLine());
            } catch (FormatException) {
                Console.WriteLine("You must type a number men");
                continue;
            } catch (Exception) {
                Console.WriteLine("What are you doing, huh?");
                continue;
            }
            finally {
                Console.WriteLine("I always will be executed"); 
            }
            break;
        }

        /*Debugging (VisualStudio):
            Breakpoint -> Punto en el que el programa se detiene al llegar alli
            F10 <- Pasar sgte linea / F11 <- Ingresar metodo en linea / Mayus+F11 <- Salir metodo
        Algunas secciones de ventana Debug\Windows\ : 
            Ctrl+alt+b <- Mostrar breakpoints / ctrl+alt+v+ a || l <- Conjunto variables proceso*/
    }
}