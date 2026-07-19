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


    public static string encryption(string s)
    {
        s = s.Replace(" ", ""); //刪除句中空格
        List<char> sentense = s.ToList();
        int listPoint = 0;
        int row = (int)Math.Floor(Math.Sqrt(s.Length));;
        int colume = (int)Math.Ceiling(Math.Sqrt(s.Length));
        Console.WriteLine($"{row} {colume}");
        if(row*colume<s.Count()) //處理二維陣列空間不足
            row = colume;
        char[,] grid = new char[row, colume];
        string result = "";
        
        for(int i=0;i<row;i++) //句子轉成二維陣列
        {
            for(int j=0;j<colume;j++)
            {
                if(listPoint != sentense.Count())
                {
                    grid[i,j] = sentense[listPoint];
                    listPoint++;
                }
            }
        }
        
        for (int j=0;j<colume;j++) //依照加密方式印出
        {
            for (int i=0;i<row;i++)
            {
                if (grid[i,j] != '\0') 
                result += grid[i,j];
            }
            result += " ";
        }
        return result;
        
        
	/*改良版
        s = s.Replace(" ", "");
        int col = (int)Math.Ceiling(Math.Sqrt(s.Length));
        StringBuilder result = new System.Text.StringBuilder();
        
        for (int i = 0; i < col; i++)
        {
            for (int j = i; j < s.Length; j += col) //每次移動colume的長度來取得該直行的字母
            {
                result.Append(s[j]);
            }
            result.Append(" ");
        }
        return result.ToString();
	*/
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
