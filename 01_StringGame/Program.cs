using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StringGame
{
    class Program
    {
/*
Create a program that executes changes over a string. On the first line, you are going to receive the string. On the following lines, you will be receiving commands until the "Done" command. There are six possible commands:
•	"Change {char} {replacement}"
o	Replace all occurrences of the char with the given replacement, then print the string.

•	"Includes {substring}"
o	Check if the string includes the given substring with and print "True" or "False".

•	"End {substring}"
o	Check if the string ends with the given substring and print "True" or "False".

•	"Uppercase"
o	Make the whole string uppercased, then print it.

•	"FindIndex {char}"
o	Find the index of the first occurrence of the given char, then print it.


•	"Cut {startIndex} {count}"
o	Remove all characters from the string, except those starting from the given start index and the next count of characters. Print only the cut chars.

Input
•	On the first line, you are going to receive the string.
•	On the following lines, until the "Done" command is received, you will be receiving commands.
•	All commands are case-sensitive.
•	The input will always be valid.
Output
•	Print the output of every command in the format described above.

        */


        public static string input = null;
        static void Main(string[] args)
        {
            //input = @"//Th1s 1s my str1ng!//";
            input = Console.ReadLine();

            while (true)
            {
                string commandLine = Console.ReadLine();

                if (Equals(commandLine, "Done"))
                {
                    break;
                }

                var commands = commandLine.Split().ToList();

                string command = commands[0];

                switch (command)
                {
                    case "Change":
                        char charToReplace = commands[1][0]; // !!
                        char replacement = commands[2][0]; // !!
                        input = Change(charToReplace, replacement);
                        PrintInput();
                        break;

                    case "Includes":
                        string includedString = commands[1];
                        Console.WriteLine(Includes(includedString));
                        break;

                    case "End":
                        string endString = commands[1];
                        Console.WriteLine(End(endString));
                        break;

                    case "Uppercase":
                        input = Uppercase();
                        PrintInput();
                        break;

                    case "FindIndex":
                        char charToFind = commands[1][0];
                        Console.WriteLine(FindIndex(charToFind));
                        break;

                    case "Cut":
                        int index = int.Parse(commands[1]);
                        int count = int.Parse(commands[2]);
                        input = Cut(index, count);
                        PrintInput();

                        break;
                }


            }
            
        }

        public static string Change(char charToReplace, char replacement) => input.Replace(charToReplace, replacement); // mozda ce da bude potrebno da se zameni karakter sa sekvencom
        
        public static bool Includes(string includedString) => input.Contains(includedString);

        public static string Uppercase() => input.ToUpper();

        public static int FindIndex(char charToFind) => input.IndexOf(charToFind);

        public static bool End(string endingStringTest) => input.EndsWith(endingStringTest);

        public static string Cut(int index, int count) => input.Substring(index, count);
        
        public static void PrintInput()
        {
            Console.WriteLine(input);
        }
    }
}
