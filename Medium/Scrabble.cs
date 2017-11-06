using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
��ũ���� �� �� ��, �� �÷��̾�� 7 ���� ���ڸ� �̰��� ���ڸ� ����Ͽ� ���� ���� ������ ���� �ܾ ã�ƾ��մϴ�.

�÷��̾ �ݵ�� 7 ���� �ܾ �ۼ��� �ʿ�� �����ϴ�. �� �ܾ�� �� ª�� �� �ֽ��ϴ�. ������ ������ �ܾ �÷��̾ �׸� 7 ���� ���ڸ� ����ؾ��Ѵٴ� ���Դϴ�.

���� ���, etaenhs��� ���ڷ� ������ �ܾ�� ��ź, ����, ������, �����Դϴ�.
������ ��ǥ�� ��� ������ ���� (1 ~ 7 ����)�� ����Ͽ� ���� ���� ������ ���� �ܾ ã�� ���Դϴ�. **/

/*
��ũ������ ���鶧 �÷��̾���� 7���� ���ڸ� �Ἥ ���� ���� ������ ���� �ܾ ��������
�ݵ�� 7���� �ƴϾ�� �� �ִ�7����
���� ���ڸ��� ������ �޶����� �� ���ڵ鸶�� ������ �ִ� ���� �ٴٸ�
����ǥ�� ���� ����
banjo��� �ܾ ���� b = 3 a = 1 n =1 j = 8 o =1�ؼ� �� 14����

���� �� �ܾ� ������ ���α׷��� �Է����� �����˴ϴ�. ���α׷��� �־��� 7 ���� ���� (���ڴ� �� ���� ����� �� ����)�� ���� ���� ���� ������ ��� �ܾ �������� 
ã�ƾ��մϴ�. �� �ܾ ���� ���� ������ ��´ٸ�, �־��� ������ ������� ó�� ��Ÿ���� �ܾ ���õǾ���մϴ�.

��� �ܾ�� �ҹ��ڷθ� ���ĺ� ���ڷ� �����˴ϴ�. ������ �� ��� �ϳ��� �ܾ���� ���Դϴ�.

�츮�� �Ұ� �־��� �����ܾ�� ���� ���� ������ ������ �ִ� �ܾ ã�Ƽ� ����ؾ��� ���� 2���̻��̸� ���� �տ� �߰ߵ� �ܾ ���������
��μҹ�����

������ �ܾ� �� N
������ N �� : ������ �ܾ�. �� �ٿ� �� �ܾ� ��.
������ �� : 7 ���ڸ� ����� �� �ֽ��ϴ�.
*/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());//�ܾ�� N
        List<string> book = new List<string>();
        
        for (int i = 0; i < N; i++)
        {
            string W = Console.ReadLine();//�����ܾ� W
            if(W.Length <= 7)
            {
                book.Add(W);
            }                
        }
        string LETTERS = Console.ReadLine();//���� ���� ����7��

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        for(int i = 0; i <book.Count; i++)
        {
            Console.Error.WriteLine(book[i]);
        }
/*        for(int i = 0; i < book.Count;)
        {
            int j = 0;
            for(; j < 7; j++)
            {
                if(book[i].Length <= j)
                    break;
                    Console.Error.WriteLine(book[i].Contains(LETTERS[j]) );
                if(book[i].Contains(LETTERS[j]) == false)
                {
                    Console.Error.WriteLine("i " + i + "j + ���� " + j +" " +LETTERS[j]);
                    j=0;
                book.Remove(book[i]);
                break;
                }                
            }
            if( j != 0)
            i++;
        }
        */

           
        for(int j = 0; j < book.Count; j++)
        {
            var copy = LETTERS;
            
            for(int k = 0; k < book[j].Length; k++)
            {                
         //       if(copy.Contains(book[j][k])==false )
                   if(copy.Contains(book[j][k] )==false )
                {
                    book.Remove(book[j]);
                    j-=1;
                    break;
                }
                else
                {
                    int cur = copy.IndexOf(book[j][k]);
                    Console.Error.WriteLine("before " + copy + " delete  " + book[j][k]);                        
                    copy = copy.Remove(cur,1);
                    Console.Error.WriteLine("after " + copy);                        
                    
                }
            }
        }
        
        int maxValue = 0;
        int maxCursor = 0;
        
        if(book.Count <= 1)
        Console.WriteLine(book[0]);        
        else
        {
            for(int i = 0; i <book.Count; i++)
            {
                int result = 0;
                for(int j = 0; j < book[i].Length; j++)
                {
                   result += LetterToInt(book[i][j]);
                }
                if(result > maxValue)
                {
                    maxValue = result;
                    maxCursor = i;
                }
            }
            Console.Error.WriteLine(book.Count);
            Console.Error.WriteLine(maxValue + " " + maxCursor + " " +LETTERS);            
            Console.WriteLine(book[maxCursor]);

        }
        
    }
    static int LetterToInt(char c)
    {
        switch(c)
        {
            case 'e': 
            case 'a': 
            case 'i':   
            case 'o': 
            case 'n': 
            case 'r': 
            case 't': 
            case 'l': 
            case 's': 
            case 'u': 
            return 1;
            
            case 'd': 
            case 'g': 
            return 2;
            
            case 'b': 
            case 'c': 
            case 'm':         
            case 'p':         
            return 3;
            
            case 'f':           
            case 'h':           
            case 'v':           
            case 'w':           
            case 'y': 
            return 4;
            
            case 'k': return 5;
            
            case 'j':            
            case 'x': 
            return 8;
            
            case 'q': 
            case 'z': 
            return 10;
        }
        return 0;
    }
}