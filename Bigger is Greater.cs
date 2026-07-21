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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     * 
     * 解題關鍵:
     * 1.由大至小的排列組成會最大
     */

    public static string biggerIsGreater(string w)
    {
        char[] wordArray = w.ToCharArray();
        int wordNum = wordArray.Length;
        int pointer1 = wordNum - 2;

        while (pointer1 >= 0 && wordArray[pointer1] >= wordArray[pointer1+1]) // 從最右邊開始往左找到一個相鄰的值左<右，代表後面為由大到小排列
        {
            pointer1--;
        }
        if (pointer1 == 0) //都沒找到，代表目前的排列為由大到小最大值
        {
            return "no answer";
        }

        int pointer2 = wordNum - 1;
        while (wordArray[pointer1] >= wordArray[pointer2]) //找到後面最小的值做交換
        {
            pointer2--;
        }

        char temp = wordArray[pointer1];
        wordArray[pointer1] = wordArray[pointer2];
        wordArray[pointer2] = temp;

        Array.Reverse(wordArray, pointer1 + 1, wordNum - pointer1 - 1); //將後面調整為由小到大排列最小值
        return new string(wordArray);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
