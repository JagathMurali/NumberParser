using System;
using NumberParser.ServiceClass.Interface;

namespace NumberParser.ServiceClass
{
    public class NumberToWordsService: INumberToWordsService
    {
        public string ConvertNumberToString(double doubleNumber)
        {
            int amountInDollars = (int)Math.Floor(doubleNumber);
            int amountInCents = (int)((doubleNumber - amountInDollars) * 100);

            string amountInDollarsString = ConvertNumberToString(amountInDollars);
            amountInDollarsString += " DOLLARS";

            if (amountInCents != 0)
            {
                string amountInCentsString = TwoDigitNumberToString(amountInCents);
                amountInCentsString += " CENTS";
                amountInDollarsString += $" AND {amountInCentsString}";
            }
            return amountInDollarsString;
        }

        private string ConvertNumberToString(int number)
        {
            if (number == 0)
                return "ZERO";

            if (number < 0)
                return "MINUS " + ConvertNumberToString(Math.Abs(number));

            var words = "";

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

            words = TwoDigitNumberToString(number, words);

            return words;
        }

        private string TwoDigitNumberToString(int number, string words = "")
        {
            if (number <= 0) return words;
            if (words != "")
                words += " ";

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