using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
���ͳ� ����ڴ� ����Ͻ� ��ũ�� ������ ��Ʈ��ũ�� ������ ��ȹ�Դϴ�. Ŀ�� �� ������ ũ�� ��ڴ� ��� �ǹ��� �����ϴ� �� �ʿ��� 
������ ���̺��� �ּ� ���̸� ����ϴ� ���α׷��� �ۼ��ϵ��� ��û�մϴ�.
�� �ʿ��� �ǹ��� ��� �����Ҷ� �ʿ��� �ּҰ��� ã�´�

�۾� ������ ���� ��ڴ� ������ ���� ������� �����ؾ��ϴ� ����� �� ������ �ֽ��ϴ�.
1.���� ���̺��� ���ʿ��� �������� (���� ���ʿ��ִ� �ǹ��� ��ġ x���� ���� ���ʿ��ִ� �ǹ��� ��ġ x2����) ������ ���� ���� �� ���Դϴ�.
x������ 0~n���� ����������
�׸��� ���ٰ� ���� y���� �ִ°ǹ��� ������ �ּҰ�θ� ���� ��,������ �����
�׷��� �ּұ��̴� ���̺��� ��ġ�� ���� �޶�����(?)

��� �ǹ��� �����ϴ� �� �ʿ��� ���̺��� �ּ� ���� L. ��, �� ���̺� ���̿� ��� �ǹ� ���� ���̺� ���̸� ���� ���Դϴ�.

���� : ������ ��ġ x���ִ� �ǹ��� � ��쿡�� ������ ���� ���̺��� �������� �ʾƾ��մϴ�.

�׷��� ������ �� L�� ��� �ű⿡ ����� �ǹ��� �� ��� �ǹ��� y�� ���̸� �褵���ؼ� ������ �ɱ�?
if L- buildY != 0 total += Math.abs(L-buildY)
L�� ���� �ʹ�ũ�� ������ �������� �׷� ��� Y�� ���밪���� ���ϰ� ���������?
**/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());//������ �ǹ��� ��
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
//����� L�� ��� �ǹ��� ������ ���̺��� ������
//������ X�࿡ �ִ� �ǹ��� � ���̺� ������ ����
        Console.WriteLine(total );
    }
}