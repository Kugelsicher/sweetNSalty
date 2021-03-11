using System;
using System.Collections.Generic;

namespace SNS.Client
{
    /// <summary>
    /// The data and functionality that is associated with a phrase/factor(s) pair
    /// </summary>
    internal class PhraseData : IComparable<PhraseData>
    {
        private string _phrase;
        private int _factor;
        private int _usageCount;

        /// <summary>
        /// The only constructor for PhraseData. Initializes all values.
        /// </summary>
        /// <param name="phrase">A word or phrase</param>
        /// <param name="factors">All of the factors associated with this phrase</param>
        public PhraseData(string phrase, List<int> factors)
        {
            this._phrase = phrase;
            // Combine all of the factors by multiplying them
            _factor = 1;
            foreach(var x in factors)
            {
                _factor *= x;
            }
            // Initialize the usage counter to zero
            _usageCount = 0;
        }

        // Part of the IComparable Interface. For sorting a List of PhraseData objects
        public int CompareTo(PhraseData other)
        {
            return other._factor.CompareTo(this._factor);
        }

        /// <summary>
        /// Returns the associated phrase if and only if the value of _factor is
        /// a factor of the argument number. If not, returns an empty string.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string GetPhrase(int number)
        {
            if(number % _factor == 0)
            {
                _usageCount += 1;
                return _phrase;
            }
            return "";
        }

        public void PrintUsage()
        {
            Console.WriteLine(_phrase + ": " + _usageCount);
        }
    }
}