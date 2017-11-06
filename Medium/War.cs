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
            //���ºθ� 3���� ī�带 ����)
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
1.�� ���帶�� ���� ���� ī�带 ������ �̰� ������ ����� 2���� ���
2.���� �� ī�尡 �Ȱ��ٸ� ������ ���� 3���� ī�带 �Ʒ��� ���� �׸��� 1�ܰ�� ���ư�
��1. ����ī��� -> �Ѵ� ���ٸ� 3���� ī�带 ���� �ٽ� ī�带�� -> �̱�� ������
���� �÷��̾ �����ϸ�(?)�Ȱ��� ���� ��ġ��
DHCS�� ��ǻ� ���̴ϱ� �Ű� x
�̱�� ��ī����� ��Ȯ�� ������ ������
�÷��̾�κ��� ���� ī����� ���� ����ī�带 2��°�� ��������
�¸����� : ��� ī�� ���б���
�Է¹�� 1. �÷��̾��� ī�尹��n
//n��ŭ�� ī�尪
��2���ݺ�
��°�: �Ȱ������� ī��� PAT
�ƴ϶�� �÷��̾� ��ȣ �ڿ� ������ ���� ��
*/