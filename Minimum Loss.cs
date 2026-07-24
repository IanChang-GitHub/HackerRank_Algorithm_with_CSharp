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
     * Complete the 'minimumLoss' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts LONG_INTEGER_ARRAY price as parameter.
     * 
     * 解題策略:
     * 1.排序後差值最小的兩數必相鄰
     * 2.只能先買後賣，故買的年份需小於賣的年份
     */

    public static int minimumLoss(List<long> price)
    {
        long minLoss = long.MaxValue;
        var priceData = new (long price, int year)[price.Count];
        for (int year=0;year<price.Count;year++) //使用ValueTuple將價錢與購買年份綁定
        {
            priceData[year] = (price[year], year);
        }
        Array.Sort(priceData, (x,y)=>y.price.CompareTo(x.price)); //由大到小排列
        
        for(int i=1;i<price.Count;i++)
        {
            if(priceData[i-1].year<priceData[i].year)
            {
                if(priceData[i-1].price-priceData[i].price < minLoss)
                {
                    minLoss = priceData[i-1].price-priceData[i].price;
                }
            }
        }
        return (int)minLoss;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> price = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(priceTemp => Convert.ToInt64(priceTemp)).ToList();

        int result = Result.minimumLoss(price);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
