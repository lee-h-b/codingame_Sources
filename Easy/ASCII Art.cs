using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine();
        T =T.ToUpper();
        string[,] ascii = new string[H,27];
        string[] board = new string[H];
        int count = 0;
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            for(int j = 0; j <27; j++)
            {
                ascii[i,j] = ROW.Substring( count, L);
                // 0+ 0, 4
                // 1 +4,4 
                
            count += L;
            }
            count =0;            
        }

        
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        for(int n = 0; n < H; n++)
        {

//board는 필요없을듯, 만약 쓴다면 h의 반복을 좀 늦춰야함 즉 1번째 반복과 바꿈
        for(int i = 0; i < T.Length; i++)
        {
            int cur = System.Convert.ToInt32(T[i]);

            if(cur -65 <=26 && cur-65 >=0)
            board[n] += ascii[n,cur-65];
            else
            board[n] += ascii[n,26];
        }

        }
        for(int i =0; i< H; i++)
                Console.WriteLine(board[i]);
    }
}