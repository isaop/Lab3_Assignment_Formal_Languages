using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileToRead = @"C:\Users\Isa\Desktop\h2_limbaje-formale\rules_identifier.txt";

            string[] words = System.IO.File.ReadAllLines(fileToRead).SelectMany(l => l.Split(',')).ToArray();
            List<string> states = new List<string>();
            List<string> alphabet = new List<string>();

            string initialstate ="";
            string finalState = "";

            for (var i=0;i < words.Length;i++)
            {
                if (words[i] == "initial")
                    initialstate = words[i-1];
                if (words[i] == "final")
                    finalState = words[i-1];    
            }
            Console.WriteLine("Initial state: " + initialstate);
            Console.WriteLine("Final state: " + finalState);
            foreach (string line in System.IO.File.ReadLines(fileToRead))
            {
                string[] wordList = line.Split(',');
              
                if (wordList.Length == 2)
                {
                   continue;
                }
                else
                {
                    bool alreadyInTheList1 = false;
                    bool alreadyInTheList2 = false;
                    bool alreadyInTheList3 = false;
                    for (int j = 0; j < states.Count; j++)
                    {
                        if (states[j] == wordList[0])
                            alreadyInTheList1 = true;
                        if (states[j] == wordList[2])
                            alreadyInTheList2 = true;
                        if (states[j] == wordList[1])
                            alreadyInTheList3 = true;
                    }
                    if (!alreadyInTheList1)
                        states.Add(wordList[0]);
                    if (!alreadyInTheList2)
                        states.Add(wordList[2]);
                    if (!alreadyInTheList3)
                        alphabet.Add(wordList[1]);

                    Console.WriteLine("( " + wordList[0] + " , " + wordList[1] + " ) -> " + wordList[2]);
                } 
            }
            Console.Write("List of states: ");
            foreach (var state in states)
                Console.Write(state + " ");


            Console.Write("\nAlphabet: ");
            foreach (var character in alphabet)
                Console.Write(character + " ");
            Console.ReadKey();
        }

    }
}
