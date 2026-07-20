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
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        //計算皇后八個方向最大攻擊距離(無障礙物下)
	    int up = n-r_q;
        int down = r_q-1;
        int left = c_q-1;
        int right = n-c_q;
        int upLeft = Math.Min(n-r_q, c_q-1);
        int upRight = Math.Min(n-r_q, n-c_q);
        int downLeft = Math.Min(r_q-1, c_q-1);
        int downRight = Math.Min(r_q-1, n-c_q);
        
        foreach(List<int> obstacle in obstacles)
        {
            int row = obstacle[0];
            int colume = obstacle[1];
            
            if(colume == c_q && row > r_q) //障礙物在皇后上方
                up = Math.Min(up, row-r_q-1); //障礙物佔領格不算故減一
            else if (colume == c_q && row < r_q) //下方
                down = Math.Min(down, r_q-row-1);
            else if (row == r_q && colume < c_q) //左方
                left = Math.Min(left, c_q-colume-1);
            else if (row == r_q && colume > c_q) //右方
                right = Math.Min(right, colume-c_q-1);
            else if (Math.Abs(row-r_q) == Math.Abs(colume-c_q)) //斜對角，列距=行距
            {
                if(row > r_q && colume < c_q) //左上方
                    upLeft = Math.Min(upLeft, row-r_q-1);
                else if (row > r_q && colume > c_q) //右上方
                    upRight = Math.Min(upRight, row-r_q-1);
                else if(row < r_q && colume > c_q)
                    downRight = Math.Min(downRight, r_q-row-1); //右下方
                else if(row < r_q && colume < c_q)
                    downLeft = Math.Min(downLeft, r_q-row-1); //左下方
            }
        }
        
        return up+down+left+right+upLeft+upRight+downRight+downLeft;
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

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
