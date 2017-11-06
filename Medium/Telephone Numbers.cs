using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
iDroid ����Ʈ �� ���� ���� �շ��ϸ� ����ó �����ڸ� ������ å���� �ֽ��ϴ�. �и���, ����� ������ ���� ���� iDroid�� ���� ����� �� ������ 
���ϴٴ� ���Դϴ� : �ý����� �޸𸮰����ξ��� ���μ����� 90 ����� Cyrix��ŭ �����ϴ�.

��翡�� Ư�����Ǹ� ����̴� �� ���� ���� �ֽ��ϴ�.

1. ���� �Է������� ������ ����
�Է� �� ù ��° ���ڿ� �ش��ϴ� ���ڰ� ���� ��� ����ڿ��� ǥ�õ˴ϴ�.
�޴��� ���� ��ȣ��ȣ �Է��Ҷ� �̸��̳� ��ȣ�ϸ� �ٷ� Ȥ�� �̹�ȣ�ΰ� �ϰ� �����? �װ��̾߱�

2. ���� ���� ����ȭ
���ڿ� ������ �� ù ��° ���ڴ� �޸𸮿� �ߺ��Ǿ�� �ȵ˴ϴ�.
//Ư�� ���ڰ� �����̵Ǹ� �̷��̷��� ���� ���´�! ��� ����� �Ǳ� ���ϳ���

����� �ӹ��� ���� ���õ� ������ ��ȭ ��ȣ ����� �����ϴ� �� �ʿ��� ���� (����)�� ǥ���ϴ� ���α׷��� �ۼ��ϴ� ���Դϴ�.
 **/
class Solution
{
    //�����ϴ� �õ��� ���� ���� ~~ �ϴ½��� �ɵ� �ѵ�
    /*
    �ϴ� ���� ���� �����ϰ� ������ ���� ���̸� ī��Ʈ�� ���ϴ� ��?
    �� �ʹ������ɸ���
    
    �����ϰ� ������
    �迭�� ���δ� ���� �׸��� �ش簪�� 1�� ������ �ɰ�
    �����ǰ� 1234�� ������ְ� 145�� �ִٸ�
    �켱 145���� 1�� �ִ� ��ġ�� �� ���� ������� ī��Ʈ���ϰ� �������� �׷� 4�� ���� > ���⼭ 1+4 �� 14�� �˻�
    14�� �����ϱ� 145�� ������ ���
    �������� 147
    1��? �ְ� 14��?�ְ� 147��? ���� 147�߰��ϰ� "14" - "147"�� ���̸�ŭ size�߰�
    �̷������� �ҰŰ���
    
    */
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());//��ȭ��ȣ�� ����
        int size = 0;
        string[] phones = new string[N];
        //�̷����ϸ� �ɱ�
        for (int i = 0; i < N; i++)
        {
            //�� ȸ���� �ִ� ���� L �� ��ȭ ��ȣ�� �����մϴ�. ��ȭ ��ȣ�� ������� 0���� 9������ ���ڸ����� �����˴ϴ�.
            
            phones[i] = Console.ReadLine();//L��ŭ�� ������ �� ������ L�� 20�̰� '-'�� '0'�� ���� ���� �̰� ����
            //���ڴ���(char)�� ���� �ʿ䰡 �ִٰ�
            
        }
    Array.Sort(phones);
    size += phones[0].Length;
    //���������� ���� ���� �ٸ��� �����ϸ� �ش� ���� ���̸�ŭ ���ϱ�
    for(int i = 1; i < phones.Length; i++)
    {
        int minLength = Math.Min(phones[i].Length, phones[i-1].Length);
        int maxLength = Math.Max(phones[i].Length, phones[i-1].Length);        
        for(int j = 0; j < minLength; j++)
        {
            if(phones[i][j] != phones[i-1][j] )
            {
//Console.Error.WriteLine("before : " + size);
                if(phones[i].Length <= phones[i-1].Length)
                size += minLength- j;
                else
                size += maxLength -j;
                break;
            }
            if( j== minLength -1)
            {
                size += maxLength -minLength;
//                size += maxLength - minLength;
//                                                Console.Error.WriteLine("c : "+ size + " " +phones[i] +" +" +phones[i-1]);

                break;

            }
        }
    }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // The number of elements (referencing a number) stored in the structure.
        Console.WriteLine(size);
        //����ü�� ����� ������ ��
    }
}