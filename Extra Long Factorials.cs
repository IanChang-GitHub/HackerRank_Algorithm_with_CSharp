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

    public static void extraLongFactorials(int n)
    {
        List<int> invert = new List<int>(); //反向儲存數值每一個位數
        invert.Add(1);
        for (int i=2; i<=n; i++) //模擬手動乘法直式計算
        {
            for(int j=0;j < invert.Count();j++)
            invert[j] = invert[j] * i;
            
            for (int k=0;k<invert.Count();k++)
            {
                if(invert[k] < 10) //不進位
                    continue;
                else //需進位
                {
                    if (k == (invert.Count()-1))
                        invert.Add(0);
                    invert[k+1] = invert[k+1] + (invert[k]/10);
                    invert[k] = invert[k] % 10;
                }
            }
        }
        
        invert.Reverse(); //恢復原本數值排列
        for (int k=0;k<invert.Count();k++)
            Console.Write($"{invert[k]}");
        
    }
}


class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.extraLongFactorials(n);
    }
}
