using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP
{
    class NumericalExpression
    {
        public long Num { private get; set; }

        public NumericalExpression(long number) 
        {
            Num = number;
        }

        private static string ConvertThreeDigitsToWords(long number)
        {
            string[] numbers = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                "Eleven", "Twelve" , "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number == 0)
            {
                return "Zero";
            }

            Stack<string> sentence = new Stack<string>();
            string text = "";
            string str = "";
            long mid = number / 10 % 10;

            for (int i = 1; i <= Convert.ToString(number).Length; i++)
            {
                switch (i)
                {
                    case 1:
                        if (mid == 1)
                        {
                            sentence.Push(numbers[number % 100]);
                        }

                        else
                        {
                            sentence.Push(numbers[number % 10]);
                        }
                        break;

                    case 2:
                        sentence.Push(tens[mid]);
                        break;

                    case 3:
                        str = $"{numbers[number / 100]} Hundred";

                        if ((mid == 1) || ((mid == 0) && (number % 10 != 0)))
                        {
                            str += " and";
                        }

                        sentence.Push(str);
                        break;
                }
            }

            List<string> lst = new List<string>();
            while (sentence.Count != 0)
            {
                str = sentence.Pop();
                if (!str.Equals(""))
                {
                    lst.Add(str);
                }
            }

            text = string.Join(" ", lst);
            return text;
        }

        private static string ConvertToExpression(long number)
        {
            string[] suffixes = {"", "Thousand", "Million", "Billion"};
            Stack<string> sentence = new Stack<string>();

            if (number == 0)
            {
                return ConvertThreeDigitsToWords(number);
            }

            while (number != 0)
            {
                sentence.Push(ConvertThreeDigitsToWords(number % 1000));
                number = number / 1000;
            }

            string expression = "";
            for (int i = sentence.Count; i > 0; i--)
            {
                expression += $"{sentence.Pop()} {suffixes[i - 1]} ";
            }

            return expression;
        }

        public string ToString()
        {
            return ConvertToExpression(Num);
        }   

        public long GetValue()
        {
            return Num;
        }

        public static long SumLetters(long number)
        {
            long sumLetters = 0;

            for(long i = 0; i <= number; i++)
            {
                sumLetters += ConvertToExpression(i).Replace(" ", "").Length;
            }

            return sumLetters;
        }

        public static long SumLetters(NumericalExpression ne)
        {
            long sumLetters = 0;
            long number = ne.GetValue();

            for (long i = 0; i <= number; i++)
            {
                ne.Num = i;
                sumLetters += ne.ToString().Replace(" ", "").Length;
            }

            return sumLetters;
        }
    }
}




















