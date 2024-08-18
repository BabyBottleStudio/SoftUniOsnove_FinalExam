using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extra02_EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"([@|#]+)(?<color>[a-z]{3,})([@|#]+)(?<optionalStuff>[^0-9a-zA-Z]*)[\/]+(?<broj>[0-9]+)[/]+";

            /*
             ([@|#]+) - jedan ili vise @ ili # znakova
            (?<color>[a-z]{3,}) - 3 ili vise lower case slova - grupisano u grupu "color"
            ([@|#]+) - jedan ili vise @ ili # znakova, ali ne mora da se povalja patern kao u prvi put
            (?<optionalStuff>[^0-9a-zA-Z]*) - opcione zvrljotine koje se nalaze izmedju boje i broja. Mogu da postoje ili ne. Ukoliko postoje zadatak trazi da ne budu slova ili brojevi, jer onda input se smatra nevazecim. Grupisano u grupu "optional stuff", ali bespotrebno.
            [\/]+(?<broj>[0-9]+)[/]+  - broj koji je okruzen jednim ili vise /, grupisan u grupu "broj"
             */

            // string input = "@@@@green@*/10/@yel0w@*26*#red#####//8//@limon*@*23*@@@red#*/%^&/6/@gree_een@/notnumber/###purple@@@@@*$%^&*/5/";
            //string input = "#@##@red@#/8/@rEd@/2/#@purple@////10/";

            string input = Console.ReadLine();

            MatchCollection easterEggs = Regex.Matches(input, regex);

            foreach(Match match in easterEggs)
            {
                Console.WriteLine($"You found {match.Groups["broj"].Value} {match.Groups["color"].Value} eggs!");
            }

        }
    }
}
