using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MethodCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path to the .cs file: ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                int methodCount = CountMethods(fileContent);
                Console.WriteLine($"Number of methods in the file: {methodCount}\n");
                ListMethods(fileContent);

                int classCount = CountClasses(fileContent);

                Console.WriteLine($"Number of classes in the file: {classCount}\n");
                ListClasses(fileContent);

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("File not found. Please provide a valid .cs file path.");
            }
        }

        static int CountMethods(string content)
        {
            string pattern = @"(public|private|protected|internal|static|bool|void|PatentData|TrademarkData|DataScrapping|string|T|List|XmlNode|IWebElement|PatentApplicationData|ErrorResponse)\s+\w+\s*\([^)]*\)\s*{";
            return Regex.Matches(content, pattern, RegexOptions.Singleline).Count;
        }

        static void ListMethods(string content)
        {
            string pattern = @"(public|private|protected|internal|static|bool|void|PatentData|TrademarkData|DataScrapping|string|T|List|XmlNode|IWebElement|PatentApplicationData|ErrorResponse)\s+(\w+)\s*\([^)]*\)\s*{";
            var matches = Regex.Matches(content, pattern, RegexOptions.Singleline);

            Console.WriteLine("List of methods:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }

        static int CountClasses(string content)
        {
            // Regular expression to match class declarations
            string pattern = @"class\s+\w+";
            return Regex.Matches(content, pattern).Count;
        }
        static void ListClasses(string content)
        {
            // Regular expression to extract class names
            string pattern = @"class\s+(\w+)";
            var matches = Regex.Matches(content, pattern);

            Console.WriteLine("List of classes:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1].Value);
            }
        }


        
    }
}
