using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
"������ ����� ���ִ� ������"��� ���� �츮�� �����ڵ��� �۾��� ������� �� �� �ִٴ� ���� �߿伺�� ��Ÿ���ϴ�.

�츮�� �ؽ�Ʈ�� ���� ��, �츮�� ������ ������ ���� ������ ����ϴ� :�� ����� �� ������� ������ ���ƽ��ϴ�. 
�� ��, �츮�� �� ��° ����� ���ʷ� �� ��° �� ������ ��ģ�ٴ� ���� �˰Ե˴ϴ�. 
�� �ǽ����� �츮�� ����� ü�ο� ������ �ְ� ������ �� ���� �� ü���� ã�� �� �� �ڼ��� ������ �ֽ��ϴ�.

�� ����� ������ ã�ƶ�
**/
class Solution
{//���������� ��� ã��? ��ųʸ��� ���ؼ� valuefind(key)�� �ϴ°��� �� key�� �����ԵǸ� < key�ߺ� �ȵ�
//1�����迭 + keyfairvalue�� �ϰ� findkey(value)�� �ϴ°���
//null(?)�� �ȴٸ� �װ��� ���۰����ǰ� �̰� ���۰��� �ֵ���(findvalue(key) ã���� �������ϰ�
//�ٽ� �׾ֵ��� findvalue���ϰ�.. �ݺ� �ϴٰ� null�̵��� ����� ���⼭ �׾ֵ��� �����Ұ� �ʿ��� ����Լ��� �ʿ����ϰŶ� �����

//���� �� ��Ͱ� �ȴٸ� �������� 1��° ���� findkey(value)�� �ϰ� �װ� n-1�� �ɶ����� �ݺ��ϸ鼭 ī��Ʈ �ױ� <<�Ƹ� �̰��ҵ�
//�ƴϸ� 2��Ʈ���� ����� �غ���?
//��͸� ���ϴ� ��ͷ�Ǭ��
//    static    int i= 0, j = 0;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // �� ����Ʈ�� ���� N
        KeyValuePair<int,int>[] semiNode = new KeyValuePair<int,int>[n];
        int affect = 1;
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            //X�� �Ա� Y�� �ⱸ ������ ���� �̰��� ������ ���ĵ����� ����
            int x = int.Parse(inputs[0]); // a relationship of influence between two people (x influences y)
            int y = int.Parse(inputs[1]);
            semiNode[i] = new KeyValuePair<int,int>(x,y);
        
        }


        
        for(int i = 0; i< n; i++)
        {
            FindDepth(semiNode,n,semiNode[i].Value, ref affect);
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // The number of people involved in the longest succession of influences
        Console.WriteLine(affect);//���� ��� �̾�����
    }
    static public void FindDepth(KeyValuePair<int, int>[] arr,int size, int findValue,ref int maxCount,int count =2)
    {
        for(int i = 0; i<size; i++)
        {
            Console.Error.WriteLine("affect" + count + "ã�°� : " +findValue + "���̰� : " + arr[i].Key);
                if(arr[i].Key == findValue)
                {
                    Console.Error.WriteLine("�� ã��");

                    //�̰� return�� �ϸ� �Ʒ��� �� �������� �־ ���Ѵ�
                FindDepth(arr,size,arr[i].Value,ref maxCount,count+1);
                
                //return affect;
                }
        }
        if(maxCount < count)
        maxCount = count;
        Console.Error.WriteLine(maxCount);
//                return count ;
    }    
}