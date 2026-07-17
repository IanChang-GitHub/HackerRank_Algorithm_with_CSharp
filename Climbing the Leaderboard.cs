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
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {

        List<int> result = new List<int>();
        
        List<int> uniqueRanked = new List<int>(); //分數不重複排行 (題目給訂條件由高調底)
        uniqueRanked.Add(ranked[0]);
        for (int i = 1; i < ranked.Count; i++) //去除分數重複
        {
            if (ranked[i] != ranked[i-1])
                uniqueRanked.Add(ranked[i]);
        }
        
        int lastRank = uniqueRanked.Count - 1; //指向最低的分數
        int currentRank = uniqueRanked.Count + 1; //紀錄名次，從最後一名開始往上比
        foreach (int score in player) //題目給定玩家分數由低到高
        {
            while (lastRank >= 0 && score >= uniqueRanked[lastRank])
            {
                currentRank--; //名次往前一名
                lastRank--; //下一個分數更高的人
            }
            result.Add(currentRank);
        }
        
        return result;



        /* Time Limit Exceeded
        List<int> result = new List<int>();
        foreach(int score in player)
        {
            int rank=1;
            //int tempRank=int.MaxValue;
            for (int i=0;i<ranked.Count();i++)
            {
                if(i!=0 && ranked[i] != ranked[i-1])
                {
                    rank++;
                }
                
                if(score >= ranked[i])
                {
                    result.Add(rank);
                    break;
                }
                else if (i==ranked.Count()-1 )
                {
                    result.Add(rank+1);
                }
            }
        }
        return result;
        */
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}