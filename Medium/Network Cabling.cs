using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
인터넷 사업자는 비즈니스 파크를 광섬유 네트워크에 연결할 계획입니다. 커버 할 영역이 크고 운영자는 모든 건물을 연결하는 데 필요한 
광섬유 케이블의 최소 길이를 계산하는 프로그램을 작성하도록 요청합니다.
즉 필요한 건물을 모두 연결할때 필요한 최소값을 찾는다

작업 수행을 위해 운영자는 다음과 같은 방식으로 진행해야하는 기술적 인 제약이 있습니다.
1.메인 케이블은 서쪽에서 동쪽으로 (가장 서쪽에있는 건물의 위치 x에서 가장 동쪽에있는 건물의 위치 x2까지) 공원을 가로 질러 갈 것입니다.
x축으로 0~n까지 가로질러감
그리고 가다가 같은 y선상에 있는건물이 있으면 최소경로를 위해 북,남으로 연결됨
그러니 최소길이는 케이블의 위치에 따라 달라질것(?)

모든 건물을 연결하는 데 필요한 케이블의 최소 길이 L. 즉, 주 케이블 길이와 모든 건물 전용 케이블 길이를 합한 것입니다.

참고 : 동일한 위치 x가있는 건물은 어떤 경우에도 동일한 전용 케이블을 공유하지 않아야합니다.

그러면 가상의 선 L을 깔고 거기에 연결된 건물을 뺀 모든 건물의 y축 차이를 계ㅅㄴ해서 넣으면 될까?
if L- buildY != 0 total += Math.abs(L-buildY)
L의 폭이 너무크면 문제가 생길지도 그럼 모든 Y를 절대값으로 더하고 평균을내면?
**/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());//연결할 건물의 수
//        int[] buildX = new int[N];
        int[] buildX = new int[N];
        long total = 0;
        int centerLine;
        
        int median;
        int farX = int.MinValue;
        int shortX = int.MaxValue;
        List<int> listY = new List<int>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
//            buildX[i] = int.Parse(inputs[0]);
            buildX[i] = int.Parse(inputs[0]);
            listY.Add(int.Parse(inputs[1]) );

            if(farX < buildX[i])            
            farX = buildX[i];
            if(shortX > buildX[i])
            shortX = buildX[i];
        }
        
        listY.Sort();
        if(N %2 == 1)
        median = listY[N/2];
        else
        median = (listY[N/2] + listY[N/2 -1]) /2;
        
        farX -= shortX;
        centerLine = median;
        
        total += farX;

        for(int i = 0 ; i < N; i++)
        {
            long result = Math.Abs(listY[i] - centerLine);
            Console.Error.WriteLine(i +" : " + total + " , " +result);
            total += result;
        }        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
//결과인 L은 모든 건물을 연결한 케이블의 길이임
//동일한 X축에 있는 건물은 어떤 케이블도 공유를 안함
        Console.WriteLine(total );
    }
}