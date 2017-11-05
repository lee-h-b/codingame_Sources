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
ī�� ���ī (Casablanca)�� �渶���� ���ο� ������ �渶 �� ��� (duals)�� �����ϰ� �ֽ��ϴ�.
��� ���� 2 ������ ���� ���ֿ� ������ ���Դϴ�. ���ְ� ��� �������� ����� ������ �� ������ �����ؾ��մϴ�.

�־��� ���� ������ ����Ͽ� ���� ����� �� ������ �ĺ��ϰ� �� ���̸� ���� (�� 0)�� ǥ���ϴ� ���α׷��� �ۼ��Ͻʽÿ�.
//���� ������ �� 2���� �����̸� ���϶�°�
//�Է� �����͸� �����Ѵٸ� N-1������ ����ϴ�
//����ū �ƽ�ġ, �ι�° �ƽ�ġ ���� ���� MINġ,�ι�° MINġ �̷��� ��� �ٴϴ°���
*/