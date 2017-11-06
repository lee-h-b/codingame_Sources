using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
"거인의 어깨에 서있는 난장이"라는 말은 우리의 전임자들의 작업을 기반으로 할 수 있다는 것의 중요성을 나타냅니다.

우리가 텍스트를 읽을 때, 우리는 종종이 의존의 작은 눈길을 얻습니다 :이 사람은 그 사람에게 영향을 미쳤습니다. 
그 후, 우리는 두 번째 사람이 차례로 세 번째 등등에 영향을 미친다는 것을 알게됩니다. 
이 실습에서 우리는 영향력 체인에 관심이 있고 가능한 한 가장 긴 체인을 찾는 데 더 자세히 관심이 있습니다.

즉 가장긴 영향을 찾아라
**/
class Solution
{//시작지점은 어떻게 찾기? 딕셔너리를 통해서 valuefind(key)를 하는거임 그 key를 ㅊㅈ게되면 < key중복 안됨
//1차원배열 + keyfairvalue를 하고 findkey(value)를 하는거임
//null(?)이 된다면 그값은 시작값ㅇ되고 이게 시작값인 애들을(findvalue(key) 찾ㅇ서 정리를하고
//다시 그애들을 findvalue를하고.. 반복 하다가 null이도면 사라짐 여기서 그애들을 저장할게 필요함 재귀함수가 필연적일거라 예상됨

//만약 그 재귀가 싫다면 역순으로 1번째 값의 findkey(value)를 하고 그게 n-1이 될때까지 반복하면서 카운트 쌓기 <<아마 이거할듯
//아니면 2진트리를 만들고 해볼까?
//재귀를 원하니 재귀로푼다
//    static    int i= 0, j = 0;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // 총 연결트리 갯수 N
        KeyValuePair<int,int>[] semiNode = new KeyValuePair<int,int>[n];
        int affect = 1;
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            //X가 입구 Y가 출구 형태의 관계 이거의 순서는 정렬되있지 않음
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
        Console.WriteLine(affect);//가장 길게 이어진값
    }
    static public void FindDepth(KeyValuePair<int, int>[] arr,int size, int findValue,ref int maxCount,int count =2)
    {
        for(int i = 0; i<size; i++)
        {
            Console.Error.WriteLine("affect" + count + "찾는값 : " +findValue + "아이값 : " + arr[i].Key);
                if(arr[i].Key == findValue)
                {
                    Console.Error.WriteLine("위 찾음");

                    //이게 return을 하면 아래에 더 나은값이 있어도 안한다
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