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
        int n = int.Parse(Console.ReadLine());//�󸶳� �Է� ������ �ִ°�
        
        string[] inputs = Console.ReadLine().Split(' ');//�� �Է� ����ŭ�� ��ġ�� 
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
        //�ս��� ����� ���� �ִ�ս��� �����
        //���ִ밪�� �ּҰ���ƴѰ�?
        //��no �ش� ������ΰ����� �� �ǳ��� ���� �ʿ䰡 ���� 
        //���� ū���̳����� �ּҰ��� �ʱ�ȭ ��Ű�� �ϴ½����� �ϰ� �ɰŰ���
    }
}

/*
���� ȸ��� �־��� �ֽ� ���ڿ� ���� ������ �����ϰ� �������̸� ���� ���α׷��� ����ϱ⸦ ���մϴ�. 
�� ���α׷��� �־��� �ð� t0�� �ֽ��� �����ϰ� ���߿� t1�� �װ��� �ȾƼ� ������ ���� ū �ս��� �����ֱ� ���� �Ϸ��� �ֽ� ���� �м� �� �� �־���մϴ�. 
�ս��� t0�� t1 ������ ���� ���̷� ǥ���˴ϴ�. �ս��� ���ٸ� �ս��� 0�̵˴ϴ�

�� t0�� �缭 t1�� �ȶ� ���� ū �ս��� �����ֱ�? �ս��� ���ٸ� �װ��� 0
*/