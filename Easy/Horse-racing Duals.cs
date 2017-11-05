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
        int N = int.Parse(Console.ReadLine());
        int answer = int.MaxValue;
        List<int> li = new List<int>();
        for (int i = 0; i < N; i++)
        {
//            int pi = int.Parse(Console.ReadLine());
            li.Add(int.Parse(Console.ReadLine() ) );            
        }
        li.Sort();

        for(int i = 0; i < N - 1; i++)
        {
            if(answer > li[i+1] - li[i])
            answer = li[i+1] - li[i];
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(answer);
    }
}
/*
카사 블랑카 (Casablanca)의 경마장은 새로운 유형의 경마 인 듀얼 (duals)을 조직하고 있습니다.
듀얼 동안 2 마리의 말만 경주에 참가할 것입니다. 경주가 재미 있으려면 비슷한 강도의 두 마리를 선택해야합니다.

주어진 수의 강점을 사용하여 가장 가까운 두 강점을 식별하고 그 차이를 정수 (≥ 0)로 표시하는 프로그램을 작성하십시오.
//가장 근접한 수 2개와 그차이를 구하라는것
//입력 데이터를 수정한다면 N-1만으로 충분하다
//가장큰 맥스치, 두번째 맥스치 가장 작은 MIN치,두번째 MIN치 이렇게 들고 다니는거임
*/