using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PasswordCracker
{
    class Program
    {
        
        static void Cracker(string input)
        {
            var timer = new Stopwatch();
            timer.Start();
            int length = input.Length;
            string result = "";
            int counter = 0;
            int attempts = 0;

            List<Char> printableChars = new List<char>();
            for (int i = char.MinValue; i <= char.MaxValue; i++)
            {
                char c = Convert.ToChar(i);
                if (!char.IsControl(c))
                {
                    printableChars.Add(c);
                }
            }

                Restart:
                foreach (var item in printableChars)
                {                    
                    attempts++;
                    if (item == input[counter])
                    {
                        result += item;

                        if (counter < length - 1)
                        {
                            counter++;

                            goto Restart;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            timer.Stop();
           


            if (result == input)
            {
                Console.WriteLine($"Password was cracked! It took {attempts} attempts and {timer.Elapsed} seconds, but your password is {result}");
            }
            else
            {
                Console.WriteLine("I was not able to crack your password!");
            }



            //return result; 
            //while (counter != char.MaxValue)
            //{
            //    Enumerable.Range(char.MinValue, char.MaxValue).Select(c => (char)c).Where(
            //    c => !char.IsControl(c)).ToArray();

            //    counter++;
            //}


            //while (result[counter] != input[counter])
            //{
            //     result = char.MinValue;
            //}
        }
        static string Password()
        {
            Console.Write("Please enter your password of at least one character: ");


            string password = Console.ReadLine();

            if (password == null)
            {
                Console.WriteLine("You cannot follow the rules. Try again.");
                Password();
            }
            return password;
        }
        static void Main(string[] args)
        {
            
            
            string password = Password();
            Cracker(password);
           
        }
    }
}
