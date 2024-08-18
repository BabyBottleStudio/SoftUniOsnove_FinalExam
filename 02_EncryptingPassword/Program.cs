using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_EncryptingPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(.+)[>](?<digits>[0-9]{3})[|](?<lowLetters>[a-z]{3})[|](?<upperLetters>[A-Z]{3})[|](?<signs>[^<>]{3})[<](\1)";

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string passwordAttempt = Console.ReadLine();

                Match isPasswordValid = Regex.Match(passwordAttempt, regex);

                StringBuilder output = new StringBuilder();

                if (isPasswordValid.Success)
                {
                    output.Append("Password: ");
                    output.Append(isPasswordValid.Groups["digits"].Value);
                    output.Append(isPasswordValid.Groups["lowLetters"].Value);
                    output.Append(isPasswordValid.Groups["upperLetters"].Value);
                    output.Append(isPasswordValid.Groups["signs"].Value);
                }
                else
                {
                    output.Append("Try another password!");
                }

                Console.WriteLine(output.ToString());

            }


        }
    }
}
