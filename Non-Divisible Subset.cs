using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     解題想法:
     兩數之和(x+y)能被k整除，必滿足下列其一條件
     1.(a mod k) + (b mod k) = k
     2.(a mod k) = 0 && (b mod k) = 0
     
     挑子集數量特例:
     Case 1:餘數0，最多只能挑一個
     Case 2:k為偶數時，餘數=k/2，最多只能挑一個
     其他取餘數為r與k-r數量較多的那一邊全部加入子集合
     */ 

    public static int nonDivisibleSubset(int k, List<int> s)
    {
        int maxLength = 0;
        int[] remainder = new int[k]; //計算餘數出現次數
        foreach(int number in s)
        {
            remainder[number % k]++;
        }
        
        if (remainder[0] > 0) //case 1
            maxLength++;
            
        for(int i=1; i<=k/2;i++) //i與k-i互補，只需驗證一邊
        {
            if (i == k-i)
            {
                if(remainder[i] > 0) //case 2
                    maxLength++;
            }
            else
            {
             maxLength += Math.Max(remainder[i], remainder[k-i]);   
            }
        }
        return maxLength;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}