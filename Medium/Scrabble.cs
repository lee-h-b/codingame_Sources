using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
스크래블 을 할 때, 각 플레이어는 7 개의 글자를 뽑고이 글자를 사용하여 가장 많은 점수를 얻은 단어를 찾아야합니다.

플레이어가 반드시 7 글자 단어를 작성할 필요는 없습니다. 그 단어는 더 짧을 수 있습니다. 유일한 제한은 단어가 플레이어가 그린 7 개의 글자를 사용해야한다는 것입니다.

예를 들어, etaenhs라는 글자로 가능한 단어는 에탄, 증오, 제정신, 개미입니다.
귀하의 목표는 사용 가능한 문자 (1 ~ 7 글자)를 사용하여 가장 많은 점수를 얻은 단어를 찾는 것입니다. **/

/*
스크래블을 만들때 플레이어들은 7개의 글자를 써서 가장 많은 점수를 얻을 단어를 만들어야함
반드시 7개는 아니어도됨 즉 최대7문자
넣은 글자마다 점수가 달라지고 그 글자들마다 점수를 주는 값이 다다름
점수표는 좌측 참고
banjo라는 단어를 쓰면 b = 3 a = 1 n =1 j = 8 o =1해서 총 14점임

인증 된 단어 사전이 프로그램의 입력으로 제공됩니다. 프로그램은 주어진 7 개의 문자 (문자는 한 번만 사용할 수 있음)에 대해 가장 많은 점수를 얻는 단어를 사전에서 
찾아야합니다. 두 단어가 같은 수의 점수를 얻는다면, 주어진 사전의 순서대로 처음 나타나는 단어가 선택되어야합니다.

모든 단어는 소문자로만 알파벳 문자로 구성됩니다. 가능한 한 적어도 하나의 단어가있을 것입니다.

우리가 할건 주어진 사전단어에서 가장 많은 점수를 얻을수 있는 단어를 찾아서 출력해야함 만약 2개이상이면 가장 앞에 발견된 단어가 골라져야함
모두소문자임

사전의 단어 수 N
다음의 N 행 : 사전의 단어. 한 줄에 한 단어 씩.
마지막 줄 : 7 글자를 사용할 수 있습니다.
*/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());//단어수 N
        List<string> book = new List<string>();
        
        for (int i = 0; i < N; i++)
        {
            string W = Console.ReadLine();//사전단어 W
            if(W.Length <= 7)
            {
                book.Add(W);
            }                
        }
        string LETTERS = Console.ReadLine();//내가 받은 글자7개

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
                    Console.Error.WriteLine("i " + i + "j + 레터 " + j +" " +LETTERS[j]);
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