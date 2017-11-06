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
        Queue<int> p1 = new Queue<int>();
        Queue<int> p2 = new Queue<int>();
        Queue<int> p1field = new Queue<int>();
        Queue<int> p2field = new Queue<int>();

        int p1Card;
        int p2Card;
        int round = 0;
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            int result = 0;
            string cardp1 = Console.ReadLine(); // the n cards of player 1
            cardp1 = cardp1.Substring(0, cardp1.Length -1);
            
            if(cardp1[0] > 64) 
            result = Solution.Convert(cardp1[0]);
            else
            result = int.Parse(cardp1);
            p1.Enqueue(result);

        }
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
                int result = 0;
            string cardp2 = Console.ReadLine(); // the m cards of player 2
            cardp2 = cardp2.Substring(0, cardp2.Length -1);
            if(cardp2[0] > 64) 
            result = Solution.Convert(cardp2[0]);
            else 
            result = int.Parse(cardp2);
            p2.Enqueue(result);

            
        }
        
        while(true)
        {
            if(p1.Count == 0 || p2.Count == 0)
            {
                if(p2.Count == 0)
                Console.WriteLine("1 " + round);
                else if( p1.Count == 0)
                Console.WriteLine("2 " + round);
                break;
            }
            
            p1Card = p1.Dequeue();
            p2Card = p2.Dequeue();
            p1field.Enqueue(p1Card);
            p2field.Enqueue(p2Card);
            //무승부면 3개의 카드를 넣음)
            if(p1Card > p2Card)
            {
                Solution.DrainQueue(p1,p1field);
                Solution.DrainQueue(p1,p2field);

            }
            else if(p1Card < p2Card)
            {
                Solution.DrainQueue(p2,p1field);
                Solution.DrainQueue(p2,p2field);                
            }
            else if (p1Card == p2Card)
            {
                Console.Error.WriteLine(p1Card + "vs " + p2Card + " p1Count : " + p1.Count + " p2Count : " + p2.Count + "Round : " + round);

                for(int i = 0; i <3; i++)
                {
                    if(p1.Count == 0 || p2.Count == 0) 
                    {
                        Console.WriteLine("PAT");
                        return;
                    }
                    p1field.Enqueue(p1.Dequeue() );
                    p2field.Enqueue(p2.Dequeue() );
                    
                }
                continue;
            }
            round ++;
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


    }
    static public void DrainQueue(Queue<int> player, Queue<int> field)
    {
        for(int i = 0; field.Count != 0; i++)
        {
            player.Enqueue(field.Dequeue() );
        }
    }
    static public int Convert(char c)
    {
        switch (c)
        {
            case 'A' : return 14; break;
            case 'K' : return 13; break;
            case 'Q' : return 12; break;            
            case 'J' : return 11; break;
            default : return 11; break;
        }
    }
}
/*
1.각 라운드마다 덱의 맨위 카드를 보여줌 이게 더높은 사람이 2장을 뺏어감
2.만약 두 카드가 똑같다면 전쟁임 먼저 3개의 카드를 아래에 놓음 그리고 1단계로 돌아감
즉1. 맨위카드깜 -> 둘다 같다면 3개의 카드를 빼고 다시 카드를깜 -> 이기면 가져감
만약 플레이어가 포기하면(?)똑같이 먼저 배치됨
DHCS는 사실상 더미니깐 신경 x
이기면 그카드들을 정확한 순서로 가져감
플레이어로부터 나온 카드먼저 들어가고 뺏은카드를 2번째로 가져가고
승리조건 : 당근 카드 다털기이
입력방식 1. 플레이어의 카드갯수n
//n만큼의 카드값
ㄴ2번반복
출력값: 똑같은값의 카드면 PAT
아니라면 플레이어 번호 뒤에 진행한 턴의 수
*/