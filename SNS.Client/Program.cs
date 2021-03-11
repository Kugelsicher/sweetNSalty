using System;
using System.Collections.Generic;

namespace SNS.Client
{
    /// <summary>
    /// This program prints the range of values [countStart, countEnd] to the console.
    /// If a value is divisible by a certain number, or all of a list of numbers, then
    /// a word or phrase is printed instead of the value.
    /// 
    /// The output is formatted 
    /// 
    /// Print 1 to 1000 to console (make these variables)
    ///     They should print 10 per line and be separated by spaces
    /// Print "sweet" instead of the number when it is divisible by 3
    /// Print "salty" instead of the number when it is divisible by 5
    /// Print "sweet'nSalty" when it is divisible by 3 & 5
    /// 
    /// At the end of the count print out the number of times each string was printed
    /// 
    /// Push compilable source to your p0 repo in the batch github
    /// DUE 03-10-21
    /// </summary>
    internal class Program
    {
        // These fields set the parameters of the program
        readonly int countStart = 1;
        readonly int countEnd = 1000;
        readonly int countsPerLine = 10;    // Sets the number of outputs per line
        readonly int printWidth = 14;       // Each output is padded to be this many characters
        // This list contains all of the factor/string pairs. See PhraseData.cs for its implementation
        List<PhraseData> phraseDataList = new List<PhraseData>()
        {
            new PhraseData("salty", new List<int>() { 5 } ),
            new PhraseData("sweet'nSalty", new List<int>() { 3, 5 } ),
            new PhraseData("sweet", new List<int>() { 3 } )
        };

        static void Main(string[] args)
        {
            // To avoid working in a static context, I have instantiated the Program class
            var prgm = new Program();
            prgm.SweetNSalty();
        }

        private void SweetNSalty()
        {
            // The order of the divisors must be decreasing
            phraseDataList.Sort();
            
            // This is the loop that counts from countStart to countEnd
            for(var count = countStart; count <= countEnd; count += 1)
            {
                PrintTerm(count);
                AddNewLine(count);
            }

            Console.WriteLine("\nInstances of each keyword");

            foreach(var phraseData in phraseDataList)
            {
                phraseData.PrintUsage();
            }
        }

        void PrintTerm(int count)
        {
            // Check each entry in the List of factor/phrase pairs. If a non-empty
            // string is returned by GetPhrase then the factor associated with that
            // phrase was evenly divisible by count; so, print the phrase and return.
            // If all factor/phrase pairs return an empty string, then none match; so
            // print the count number and return.
            foreach(var phraseData in phraseDataList)
            {
                var phrase = phraseData.GetPhrase(count);
                if(phrase != "")
                {
                    Console.Write(phrase.PadRight(printWidth));
                    return;
                }
            }
            Console.Write(count.ToString().PadRight(printWidth));
        }

        void AddNewLine(int count)
        {
            // This math adjusts count; so that counting in this method starts at 1 regardless
            // of countStart.
            var counterStartingAtOne = count - countStart + 1;
            if(counterStartingAtOne % countsPerLine == 0)
            {
                Console.Write("\n");
            }
        }
    }
}