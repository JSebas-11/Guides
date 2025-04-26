using System;

/// <summary>
/// Introductory class with c#'s program stream
/// </summary>
public class streamControl
{
    public static void streamControlMain() {
        //Control flujo

        //Condicionales
        Console.Write("Temperature -> ");
        var temperature = Int32.Parse(Console.ReadLine());

        if (temperature > 25) {
            Console.WriteLine("Keep your coats in the closet");
        } else if (temperature >= 15 && temperature <= 25) {
            Console.WriteLine("Life is beautyfull");
        } else {
            Console.WriteLine("Movies' day");
        }

        //Switch (no compatible con bool, double, float y decimal)
        int option = 2;

        switch (option) {
            case 1:
                Console.WriteLine("Option 1");
                break;
            case 2:
                Console.WriteLine("Option 2");
                break;
            case 3:
                Console.WriteLine("Option 3");
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }

        //Operador ternario (if inline)
        //(variable = condition ? true block : false block (it could be another condition (kind of else if));)

        Console.Write("Type your age -> ");
        var age = int.Parse(Console.ReadLine());

        var response = (age > 18) ? "It's my moment" : (age == 18) ? "You are on thin ice" : "Look for your mommy";
        Console.WriteLine(response);

        //Bucles

        //For
        int num = 3;
        for (int i = 0; i < num; i++){
            Console.WriteLine($"This loop catch me {i+1}");
        }

        //Foreach
        var list = new List<int> {5, 55, 555};
        foreach (var item in list){
            Console.WriteLine($"I am a item of list, delete me please");
        }

        //While
        int input;
        while (true){
            Console.Write("Type a number -> ");
            bool isNumber = int.TryParse(Console.ReadLine(), out input);
            
            if (isNumber){
                Console.WriteLine("Thank you, you are a great person");
                break;
            } else {
                Console.WriteLine("I dont break until YOU type a number");
                continue;
            }
        }

        //Do while
        int number, sum = 0;
        do {
            Console.Write("Type another number (0 to exit) -> ");
            number = int.Parse(Console.ReadLine());
            sum += number;
            Console.WriteLine($"Acummulative sum: {sum}");
        } while (number != 0);

    }
}