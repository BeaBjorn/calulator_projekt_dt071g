// // Including namespaces
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Text.RegularExpressions;

// // Namespace for BeasCalculator
// namespace BeasCalculator
// {
//     // Class Calculator
//     class Calculator
//     {
//         // Creates a new instance of the class List and stored ResultItem in a variable named "history"
//         // Stores the json-file "result.json" in a variable named "jsonfile"
//         private List<ResultItem> history = new List<ResultItem>();
//         private const string jsonFile = "results.json";

//         // Run function using Console.WriteLine to print information to user
//         public void Run()
//         {
//             Console.WriteLine("-------------------------------");
//             Console.WriteLine("B E A S   M I N I R Ä K N A R E");
//             Console.WriteLine("-------------------------------");
//             Console.WriteLine("Den här miniräknaren hanterar plus, minus, gånger och delat.");

//             // A while loop is used to keep app running
//             // Instructions are being printed to the screen and user input is compared to "stop" and "rensa"
//             // If user types "stop" the loop breaks and te app stops running
//             // If user types "rensa" the function "emptyJson" is run and the loop continues after printing a message to user
//             while (true)
//             {
//                 Console.Write("Skriv in det tal du vill räkna ut, 'rensa' för att rensa historiken, eller 'stop' för att avsluta: ");
//                 string input = Console.ReadLine();

//                 if (input.ToLower() == "stop")
//                 {
//                     break;
//                 }
//                 else if (input.ToLower() == "rensa")
//                 {
//                     emptyJson();
//                     Console.WriteLine("Historiken har rensats.");
//                     continue;
//                 }

//                 // A try catch block is used to run the function "Evaluate" if input is fornatted correclty
//                 // The result gets printed to the screen and "Add" is used to store the expression and the result in the json-file by running the function "SaveHistoryToJson"
//                 // Catch is used if the expression entered is formatted incorrectly and then prints a message about this to the screen
//                 try
//                 {
//                     double result = Evaluate(input);
//                     Console.WriteLine($"Resultat: {result}");

//                     history.Add(new ResultItem { Tal = input, Resultat = result });
//                     SaveHistoryToJson();
//                 }
//                 catch (Exception)
//                 {
//                    Console.WriteLine($"Fel: Talet du försöker räkna ut " + "(" + input + ")" + " är felformatterat, prova igen.");
//                 }
//             }
//         }

//         // The "EmptyJson" function clears history and sets the data in the json-file to an empty array
//         private void emptyJson()
//         {
//             history.Clear();
//             File.WriteAllText(jsonFile, "[]");
//         }

//         // The function "Evaluate" takes an argument of "expression" and uses regular expression to split the expression into elements in an array
//         // An if-statement checks if the elemets in the array is an even number and returns an error message if true
//         // The first element is converted to a "Double" and stored in a variable named "result"
//         static double Evaluate(string expression)
//         {
//             string[] elements = Regex.Split(expression, @"([+\-*/])").Select(e => e.Trim()).ToArray();

//             if (elements.Length % 2 == 0)
//             {
//                 throw new ArgumentException("Talet du försöker räkna ut är felformatterat, prova igen.");
//             }

//             double result = Convert.ToDouble(elements[0]);

//             // For-loop looping through elements and picking every second element
//             // The characters (+, -, * and /) is stored in a variable named "operation"
//             // All numbers are being converted to "Double" and stored in a variable named "operand"
//             // A switch-statement is used to loop through "operation" and calculate according to match
//             // If operand is = to 0 when trying to devide a number an error is returned to user
//             for (int i = 1; i < elements.Length; i += 2)
//             {
//                 string operation = elements[i];
//                 double operand = Convert.ToDouble(elements[i + 1]);

//                 switch (operation)
//                 {
//                     case "+":
//                         result += operand;
//                         break;
//                     case "-":
//                         result -= operand;
//                         break;
//                     case "*":
//                         result *= operand;
//                         break;
//                     case "/":
//                         if (operand == 0)
//                         {
//                             throw new DivideByZeroException("Kan inte dela tal med 0.");
//                         }
//                         result /= operand;
//                         break;
//                     default:
//                         throw new ArgumentException($"Felaktigt tecken: {operation}");
//                 }
//             }
//             // Result is returned
//             return result;
//         }

//         // The function "SaveHistoryToJson" serializes history and writes to the json-file
//         private void SaveHistoryToJson()
//         {
//             string json = JsonConvert.SerializeObject(history);
//             File.WriteAllText(jsonFile, json);
//         }
//     }

//     // The class "ResultItem" uses get and set to set the expression and the result
//     class ResultItem
//     {
//         public string Tal { get; set; }
//         public double Resultat { get; set; }
//     }

//     // The class "Program" runs the "Main" funciton which creates an instance of the class Calculator and runs the app
//     class Program
//     {
//         static void Main()
//         {
//             Calculator calculator = new Calculator();
//             calculator.Run();
//         }
//     }
// }


// Including namespaces
using Newtonsoft.Json;
using NCalc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

// Namespace for BeasCalculator
namespace BeasCalculator
{
    // Class Calculator
    class Calculator
    {
        // Creates a new instance of the class List and stored ResultItem in a variable named "history"
        // Stores the json-file "result.json" in a variable named "jsonfile"
        private List<ResultItem> history = new List<ResultItem>();
        private const string jsonFile = "results.json";

        // public Calculator()
        // {
        //     history = new List<ResultItem>();
        // }

        // Run function using Console.WriteLine to print information to user
        public void Run()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("B E A S   M I N I R Ä K N A R E");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Den här miniräknaren hanterar +, -, * och / samt parenteser");

            // A while loop is used to keep app running
            // Instructions are being printed to the screen and user input is compared to "stop" and "rensa"
            // If user types "stop" the loop breaks and te app stops running
            // If user types "rensa" the function "emptyJson" is run and the loop continues after printing a message to user
            while (true)
            {
                Console.Write("Skriv in det tal du vill räkna ut eller skriv 'stop' för att avsluta: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "stop")
                {
                    break;
                }
                else if (input.ToLower() == "rensa")
                {
                    emptyJson();
                    Console.WriteLine("Historiken har rensats.");
                    continue;
                }

                // A try catch block is used to run the function "Evaluate" if input is fornatted correclty
                // The result gets printed to the screen and "Add" is used to store the expression and the result in the json-file by running the function "SaveHistoryToJson"
                // Catch is used if the expression entered is formatted incorrectly and then prints a message about this to the screen
                try
                {
                    double result = Evaluate(input);
                    Console.WriteLine($"Resultat: {result}");

                    history.Add(new ResultItem { Tal = input, Resultat = result });
                    SaveHistoryToJson();
                }
                catch (Exception)
                {
                   Console.WriteLine($"Fel: Talet du försöker räkna ut " + "(" + input + ")" + " är felformatterat, prova igen.");
                }
            }
        }

        // The "EmptyJson" function clears history and sets the data in the json-file to an empty array
        private void emptyJson()
        {
            history.Clear();
            File.WriteAllText(jsonFile, "[]");
        }

        // The function named "Evaluate" uses NCalc to calculate the submitted expressions
        static double Evaluate(string expression)
        {
            Expression expr = new Expression(expression);
            return Convert.ToDouble(expr.Evaluate());
        }

        // The function "SaveHistoryToJson" serializes history and writes to the json-file
        private void SaveHistoryToJson()
        {
            string json = JsonConvert.SerializeObject(history);
            File.WriteAllText(jsonFile, json);
        }
    }

    // The class "ResultItem" uses get and set to set the expression and the result
    class ResultItem
    {
        public string Tal { get; set; }
        public double Resultat { get; set; }
    }

    // The class "Program" runs the "Main" funciton which creates an instance of the class Calculator and runs the app
    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();
            calculator.Run();
        }
    }
}
