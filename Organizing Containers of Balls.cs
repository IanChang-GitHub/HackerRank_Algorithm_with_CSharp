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
     * Complete the 'organizingContainers' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts 2D_INTEGER_ARRAY container as parameter.
     * 
     * 解題關鍵:
     * 1.每個container內的球交換後數量不變
     * 2.每個種類的球數量不變
     * 3.每個種類的球都得找到對應數量的container
     */

    public static string organizingContainers(List<List<int>> container)
    {
        int containerNum = container.Count;
        long[] containerCapacity = new long[containerNum];
        long[] ballNum = new long[containerNum];
        
        for(int i=0;i<containerNum;i++)
            for(int j=0;j<containerNum;j++)
            {
                containerCapacity[i] += container[i][j]; //計算每個container內球的數量
                ballNum[j] += container[i][j]; //計算每個種類球的數量
            }
        
        Array.Sort(containerCapacity);
        Array.Sort(ballNum);
        
        for (int i=0;i<containerNum;i++) //檢查有無對應數量
        {
            if(containerCapacity[i] != ballNum[i])
                return "Impossible";
        }
        return "Possible";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Result.organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
