using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
����� �� ���� �������� Ư�� ������ �μ��ϴ� �ӹ��� ������ �ֽ��ϴ�
���! �� ������ ����� ������ �� �� �ֽ��ϴ�. ������ ���������� Ư���մϴ� : 
���� ���� ���鼭 ���� ũ�� ������ ù ���� ������ �� ���� ���� ���� �κ��丮�� ����ϴ�

������ ���鼭 ���� ũ�Ժ��� ù���� ���� ������ �������� �κ��丮�� ����ٴµ�?

- 3 ���� 2 �� 1�� 2�� 1�� �����ϱ� ������ 2 1�� ǥ���մϴ�.
//3���� 2�࿡ 2���� 1�� �ֱ⶧���� 2/1 �̶�°ǰ�?

- 4 �࿡�� 1 2 1�� ǥ�õ˴ϴ�. 3 �࿡�� 1 2�� 1�� ���ԵǾ� �ֱ� �����Դϴ�.
//4���� 1 2 1 1 3�࿡ 1���� 2�� 1���� 1�� �ֱ� ���� ?

- ���� 5���� 1 1 1 2 2 1�� ǥ�õ˴ϴ�. �� ������ ���� 4���� 1�� 1 �� ���ԵǾ� �ְ� �� ������ 2������ 2 ������ 1�� �ֱ� �����Դϴ�.

�� �������� ������ ���� �ʰ� ������ ���� �����ϱ� ���� ������ ���ڵ��ϴ� �� ���Ǵ� ����� ��Ÿ���ϴ�.
�� ������ �޼ҵ�� Ư�� �̹����� �����ϴ� �� ���˴ϴ�.
����� �ӹ��� ������ ���� R (�� �������� R = 1)�� ���������� �ø����� ���� L�� ǥ���ϴ� ���α׷��� �ۼ��ϴ� ���Դϴ�.

�а��ϱ� ������ ���� ���� ����1
�״��� 1���� 1 = 1 1
�״��� ���ǰ��� 2���� 1 /2 1
�״��� ���ǰ��� 1���� 2 1���� 1 /1 2 1 1
�״��� ���� ���� 1���� 1 1���� 2 2���� 1 / 1 1 1 2 2 1
�״��� ���� ���� 3���� 1 2���� 2 1���� 1 / 3 1 2 2 1 1
�̷������� �Ʒ��� ���� ���� ���� �������� �����´ٰ� ����ɵ�

�ش� ����������� ������ ���� �ʰ� ���� �����س��¹���̶���
���⼭ ���ϴ°� R �� �������� ���⿡�� L��° ���� ���°�
. **/
class Solution
{
    static void Main(string[] args)
    {
        //����Ʈ�� ���� �迭�� ������

        int R = int.Parse(Console.ReadLine());//���۰�R
        int L = int.Parse(Console.ReadLine());//���ΰ� L
        List<int>[] listArray = new List<int>[L];
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        listArray[0] = new List<int>();
        listArray[0].Add(R);
        for(int i = 1; i < L; i++)
        {
            listArray[i] = new List<int>();

            List<int>temp = listArray[i - 1];
                        Console.Error.WriteLine("temp : "+ temp.Count);

            Console.Error.WriteLine(temp.Count);
            int cur = temp[0];
            int count = 0;

            for(int j = 0; j < temp.Count; j++)
            {
                if(cur == temp[j] )
                {
                    count ++;
                }
                else
                {
                    listArray[i].Add(count);
                    listArray[i].Add(cur);
                    cur = temp[j];
                    count = 1;
                }
            }
                                listArray[i].Add(count);
                    listArray[i].Add(cur);

            
        }
//L��°�� ���� ���;���
/*
foreach(var val in listArray[L -1])
{
    if(val != listArray[L-1])
    Console.Write(val + " " );
    else
    Console.Write(val);
    
}*/
for(int i = 0; i < listArray[L -1].Count; i++)
{
    if(i < listArray[L-1].Count-1)
        Console.Write(listArray[L-1][i] + " ");
        else
        Console.Write(listArray[L-1][i]);
        
}

    }
}