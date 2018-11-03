using System;
using NumberParser.ServiceClass.Interface;

namespace NumberParser.ServiceClass
{
    public class NumberToWordsService: INumberToWordsService
    {
        /// <summary>
        /// Function that converts amount into strings
        /// </summary>
        /// <param name="doubleNumber">Passed number</param>
        /// <returns>Return the parsed string</returns>
        public string ConvertNumberToString(double doubleNumber)
        {
            // Negative Number not handling now
            if (doubleNumber < 0)
                return "NEGATIVE";

            // Getting integer part of the amount
            int amountInDollars = (int)Math.Floor(doubleNumber);
            // Getting decimal part of the amount
            int amountInCents = (int)((doubleNumber - amountInDollars) * 100);

            // Getting string of integer part  
            string amountInDollarsString = ConvertNumberToString(amountInDollars);
            amountInDollarsString += " DOLLARS";
            // Checking whether the decimal part is present before processing
            if (amountInCents != 0)
            {
                // Getting string of decimal part  
                string amountInCentsString = TwoDigitNumberToString(amountInCents);
                amountInCentsString += " CENTS";    
                amountInDollarsString += $" AND {amountInCentsString}";
            }
            return amountInDollarsString;
        }

        private string ConvertNumberToString(int number)
        {
            // Checking whether number is zero
            if (number == 0)
                return "ZERO";

            var words = "";

            // Breaking number into the parts
            if (number / 1000000000 > 0)
            {
                words += ConvertNumberToString(number / 1000000000) + " BILLION ";
                number %= 1000000000;
            }

            if (number / 1000000 > 0)
            {
                words += ConvertNumberToString(number / 1000000) + " MILLION ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += ConvertNumberToString(number / 1000) + " THOUSAND ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += ConvertNumberToString(number / 100) + " HUNDRED ";
                number %= 100;
                if (number > 0)
                {
                    words += "AND";
                }
            }

            // Treating two digit number as the string format is different
            words = TwoDigitNumberToString(number, words);

            return words;
        }

        private string TwoDigitNumberToString(int number, string words = "")
        {
            if (number <= 0)
                return words;

            if (words != "")
                words += " ";
            // Mapping each digits to each strings based in the array value
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
            return words;
        }
    }
}