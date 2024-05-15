using System;
using System.Collections.Generic;

namespace ProjectOOP
{
    class NumericalExpression
    {
        private readonly long num;

        public NumericalExpression(long number) 
        {
            num = number;
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

            Stack<string> sentence = new();
            long mid = number / 10 % 10;

            string str;
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

            List<string> lst = new();
            while (sentence.Count != 0)
            {
                str = sentence.Pop();
                if (!str.Equals(""))
                {
                    lst.Add(str);
                }
            }

            string text = string.Join(" ", lst);
            return text;
        }

        private string ConvertToExpression()
        {
            string[] suffixes = {"", "Thousand", "Million", "Billion"};
            Stack<string> sentence = new();
            long number = num;

            if (number == 0)
            {
                return ConvertThreeDigitsToWords(number);
            }

            while (number != 0)
            {
                sentence.Push(ConvertThreeDigitsToWords(number % 1000));
                number /= 1000;
            }

            string expression = "";
            for (int i = sentence.Count; i > 0; i--)
            {
                expression += $"{sentence.Pop()} {suffixes[i - 1]} ";
            }

            return expression;
        }

        public override string ToString()
        {
            return ConvertToExpression();
        }   

        public long GetValue()
        {
            return num;
        }

        public static long SumLetters(long number)
        {
            long sumLetters = 0;

            for(long i = 0; i <= number; i++)
            {
                sumLetters += new NumericalExpression(i).ToString().Replace(" ", "").Length;
            }

            return sumLetters;
        }

        /* The feature of object-oriented programming that is expressed in the code here is called: Overloading (Polymorphism).
        Method overloading means having two or more methods(or functions) in a class
        with the same name and different arguments (or parameters). */
        public static long SumLetters(NumericalExpression ne)
        {
            long sumLetters = 0;
            
            for (long i = 0; i <= ne.GetValue(); i++)
            {
                sumLetters += new NumericalExpression(i).ToString().Replace(" ", "").Length;
            }

            return sumLetters;
        }
    }
}




















