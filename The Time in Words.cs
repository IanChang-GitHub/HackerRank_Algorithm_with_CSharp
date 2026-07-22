using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {
        string[] number = {
            "zero", "one", "two", "three", "four",
            "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve", "thirteen", "fourteen",
            "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
            "twenty", "twenty one", "twenty two", "twenty three", "twenty four",
            "twenty five", "twenty six", "twenty seven", "twenty eight", "twenty nine"};
        int nextHour = (h != 12)?h+1:1;
        
        if (m == 0) //整點
            return $"{number[h]} o' clock";
        else if (m == 30) //半小時
            return $"half past {number[h]}";
        else if (m < 30) //1~29分
        {
            if (m == 15)
                return $"quarter past {number[h]}";
            else if (m == 1)
                return $"one minute past {number[h]}"; // minute少一個s
            else
                return $"{number[m]} minutes past {number[h]}";
        }
        else //31~59分
        {
            if (60 - m == 15)
                return $"quarter to {number[nextHour]}";
            else if (60 - m == 1)
                return $"one minute to {number[nextHour]}";
            else
                return $"{number[60 - m]} minutes to {number[nextHour]}";
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}