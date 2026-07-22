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
     * Complete the 'surfaceArea' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY A as parameter.
     * 
     * 解題關鍵:
     * 1.因每格都有積木，故頂表面積與底表面積皆等同格子面積
     * 2.每格單獨計算表面積，扣除上下左右被遮住的部分
     */

    public static int surfaceArea(List<List<int>> A)
    {
        int row = A.Count;
        int colume = A[0].Count;
        int totalArea = row*colume*2;
        
        for (int i=0;i<row;i++)
        {
            for (int j=0;j<colume;j++)
            {
                int upHeight = (i-1<0)?0:A[i-1][j]; //計算上方高度
                totalArea += Math.Max(A[i][j]-upHeight, 0); //計算上方表面積，0表示比較對象高度比較高皆被遮住故無表面積
                
                int downHeight = (i+1>row-1)?0:A[i+1][j]; //向下方看
                totalArea += Math.Max(A[i][j]-downHeight, 0);
                
                int leftHeight = (j-1<0)?0:A[i][j-1];
                totalArea += Math.Max(A[i][j]-leftHeight, 0); //向左邊看
                
                int rightHeight = (j+1>colume-1)?0:A[i][j+1]; //向右邊看
                totalArea += Math.Max(A[i][j]-rightHeight, 0);
            }
        }
         return totalArea;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int H = Convert.ToInt32(firstMultipleInput[0]);

        int W = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
        }

        int result = Result.surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
