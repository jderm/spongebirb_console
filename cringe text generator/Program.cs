using System;
using System.Text.RegularExpressions;

namespace cringe_text_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (args.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Enter your text: ");
                string input = Console.ReadLine();
                SpongebobBirdText(input);
            }

            else
            {
                string input = "";
                foreach(string s in args)
                {
                    input += s + " ";
                }
                
                SpongebobBirdText(input);
            }
        }

        static void SpongebobBirdText(string input)
        {
            string[] textChars = Regex.Split(input, string.Empty);
            int charSize = 0; //0=even, 1=odd
            for(int a = 0; a < textChars.Length; a++)
            {
                if(Regex.IsMatch(textChars[a], @"^[a-zA-Z\p{L}]+$"))
                {
                    if(charSize == 1)
                    {
                        textChars[a] = textChars[a].ToLower();
                        charSize = 0;
                    }

                    else
                    {
                        textChars[a] = textChars[a].ToUpper();
                        charSize = 1;
                    }
                }
            }

            string output = string.Join("", textChars);
            Console.Clear();
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine();
            Console.WriteLine("Output:");
            Console.WriteLine(output);
            Console.WriteLine();
            
            EndApp();
        }

        static void EndApp()
        {
            Console.WriteLine("Wanna see me do it again? (Y/N):");
            string input = Console.ReadLine();
            if (input == "Y" || input == "y")
            {
                Main(new string[0]);
            }

            else if(input == "N" || input == "n")
            {
                Environment.Exit(0);
            }

            else
            {
                EndApp();
            }
        }
    }
}
