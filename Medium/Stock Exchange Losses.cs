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
        int n = int.Parse(Console.ReadLine());//얼마나 입력 받을수 있는가
        
        string[] inputs = Console.ReadLine().Split(' ');//그 입력 수만큼의 가치들 
        int[] minusStore = new int[n];
        int max = 0;
        int min = 0;
        int storeCount = 0;
        for (int i = 0; i < n; i++)
        {
            int v = int.Parse(inputs[i]);
            if(max < v)
            {
            max = v;
                if(minusStore[storeCount] != 0)
                {
                    minusStore[storeCount] = min;
                storeCount ++;
                }
            
            }
            else if(v - max < min)
            {
                min = v - max;
            }            
        }
                minusStore[storeCount] = min;
                storeCount ++;

        int cur = 0;
        for(int i = 1; i < storeCount; i++)
        {
            if(minusStore[i] < minusStore[cur])
            cur = i;
        }
        


        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(minusStore[cur]);
        //손실이 생기면 나올 최대손실을 출력함
        //걍최대값과 최소가밧아닌가?
        //ㄴno 해당 순서대로가야함 즉 맨나중 값은 필요가 없음 
        //제일 큰값이나오면 최소값을 초기화 시키고 하는식으로 하게 될거같음
    }
}

/*
금융 회사는 최악의 주식 투자에 관한 연구를 수행하고 있으며이를 위해 프로그램을 취득하기를 원합니다. 
이 프로그램은 주어진 시간 t0에 주식을 구입하고 나중에 t1에 그것을 팔아서 가능한 가장 큰 손실을 보여주기 위해 일련의 주식 값을 분석 할 수 있어야합니다. 
손실은 t0와 t1 사이의 값의 차이로 표현됩니다. 손실이 없다면 손실은 0이됩니다

즉 t0때 사서 t1때 팔때 가장 큰 손실을 보여주기? 손실이 없다면 그값은 0
*/