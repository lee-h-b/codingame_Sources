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
    public static int zeroCloset = 5527;
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string temps = Console.ReadLine(); // the n temperatures expressed as integers ranging from -273 to 5526
//        int[] arr;
        string[] array = temps.Split(' ');
        
        for(int i = 0; i <array.Length; i++)
        {
 
             if(int.TryParse(array[i],out n) == false ) continue;
            if(Math.Abs( zeroCloset  ) > Math.Abs(int.Parse(array[i])) )
            {
                zeroCloset = int.Parse(array[i]);
            }
            if(Math.Abs( zeroCloset  ) == Math.Abs(int.Parse(array[i])) )
            {
                if(zeroCloset < 0) zeroCloset = int.Parse(array[i]);
            }
        }
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    if(zeroCloset != 5527)
        Console.WriteLine(zeroCloset);
        else         Console.WriteLine(0);

        
        
    }
}