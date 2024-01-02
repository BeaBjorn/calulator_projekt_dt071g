// // Including namespaces
// using Newtonsoft.Json;
// using NCalc;
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

//         // public Calculator()
//         // {
//         //     history = new List<ResultItem>();
//         // }

//         // Run function using Console.WriteLine to print information to user
//         public void Run()
//         {
//             Console.WriteLine("-------------------------------");
//             Console.WriteLine("B E A S   M I N I R Ä K N A R E");
//             Console.WriteLine("-------------------------------");
//             Console.WriteLine("Den här miniräknaren hanterar +, -, * och / samt parenteser");

//             // A while loop is used to keep app running
//             // Instructions are being printed to the screen and user input is compared to "stop" and "rensa"
//             // If user types "stop" the loop breaks and te app stops running
//             // If user types "rensa" the function "emptyJson" is run and the loop continues after printing a message to user
//             while (true)
//             {
//                 Console.Write("Skriv in det tal du vill räkna ut eller skriv 'stop' för att avsluta: ");
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
//             File.WriteAllText(jsonFile, "[]");
//         }

//         // The function named "Evaluate" uses NCalc to calculate the submitted expressions
//         static double Evaluate(string expression)
//         {
//             Expression expr = new Expression(expression);
//             return Convert.ToDouble(expr.Evaluate());
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
