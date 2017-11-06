using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
당신은 컨 웨이 시퀀스의 특정 라인을 인쇄하는 임무를 가지고 있습니다
경고! 이 순서는 당신을 아프게 할 수 있습니다. 추측은 간단하지만 특이합니다 : 
위의 줄을 보면서 줄을 크게 읽으면 첫 줄을 제외한 각 줄이 이전 줄의 인벤토리를 만듭니다

윗줄을 보면서 줄을 크게보면 첫줄을 죄한 각줄이 이전줄의 인벤토리를 만든다는데?

- 3 행은 2 행 1에 2가 1을 포함하기 때문에 2 1을 표시합니다.
//3행은 2행에 2개의 1이 있기때문에 2/1 이라는건가?

- 4 행에는 1 2 1이 표시됩니다. 3 행에는 1 2와 1이 포함되어 있기 때문입니다.
//4행은 1 2 1 1 3행에 1개의 2와 1개의 1이 있기 때문 ?

- 라인 5에는 1 1 1 2 2 1이 표시됩니다. 그 이유는 라인 4에는 1이 1 개 포함되어 있고 그 다음에 2가오고 2 다음에 1이 있기 때문입니다.

이 시퀀스는 정보를 잃지 않고 동일한 값을 압축하기 위해 범위를 인코딩하는 데 사용되는 기술을 나타냅니다.
이 유형의 메소드는 특히 이미지를 압축하는 데 사용됩니다.
당신의 임무는 원래의 숫자 R (이 예에서는 R = 1)을 기준으로이 시리즈의 라인 L을 표시하는 프로그램을 작성하는 것입니다.

읽고말하기 수열임 위의 저건 시작1
그다음 1개의 1 = 1 1
그다음 위의값이 2개의 1 /2 1
그다음 위의값이 1개의 2 1개의 1 /1 2 1 1
그다음 위의 값이 1개의 1 1개의 2 2개의 1 / 1 1 1 2 2 1
그다음 위의 값이 3개의 1 2개의 2 1개의 1 / 3 1 2 2 1 1
이런식으로 아래의 값은 위의 값의 갯수등을 내놓는다고 보면될듯

해당 시퀀스방식은 정보를 잃지 않고 값을 압축해내는방식이라함
여기서 원하는건 R 을 기준으로 여기에서 L번째 값을 내는것
. **/
class Solution
{
    static void Main(string[] args)
    {
        //리스트를 갖는 배열이 좋을듯

        int R = int.Parse(Console.ReadLine());//시작값R
        int L = int.Parse(Console.ReadLine());//라인값 L
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
//L번째의 값이 나와야함
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