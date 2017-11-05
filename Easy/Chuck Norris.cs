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
        //아스키로 해당값을 받는다, 그리고2진수로 읽고 공백으로 구분한다
        //그다음 1이면 0 0을, 0이면 00 0임 
        //10 이면 0 0 00 0이 되겠음 1번째 0은1?0?을 구분하고 2번째는 비트수임
        string MESSAGE = Console.ReadLine();
        string result = "";
        
        char beforeValue = '2';
        foreach(char c in MESSAGE)
        {
            string val = Convert.ToString((int)c,2);
            Console.Error.WriteLine(val);
//1 00 1 0 1
//0 0 00 00 0 0 00 0 0 
//0 0 00 00 0 0 00 0 0 
//1 00 1 0 1 
            if((int)c < 64)
            {
                if( beforeValue != '0')
                {
                    result += " 00 0";
                    beforeValue = '0';
                }
                else
                    result+= "0";
            }


            for(int i = 0; i< val.Length; i++)
            {
                if(val[i] != beforeValue)
                {
                    beforeValue = val[i];
                    if(val[i] == '0' ) result += " 00 0";
                    else if(val[i] == '1') result += " 0 0";
                }
                else result += "0";
            }
//            Console.WriteLine(val);
            //C의 값을 아스키로
        }
        for(int i =1; i< result.Length; i++)
        Console.Write(result[i]);
//        Console.WriteLine(chuck);

/*입력 메시지는 ASCII 문자 (7 비트)
인코딩 된 출력 메시지는 0의 블록
블록은 다른 블록과 공백으로 구분됩니다.
일련의 동일한 값 비트 (단 하나 또는 0 값)를 생성하기 위해 두 개의 연속 블록이 사용됩니다.
- 첫 번째 블록 : 항상 0 또는 00입니다. 0이면 시리즈에 1이 포함되고 그렇지 않으면 0이 포함됩니다.
- 두 번째 블록 :이 블록에서 0의 수는 계열의 비트 수입니다

예
한 문자만으로 구성된 간단한 예를 들어 봅시다 : Capital C. C는 이진수로 1000011로 표현됩니다. Chuck Norris의 기술을 통해 다음과 같습니다.
0 0 (첫 번째 시리즈는 단 하나의 1로 구성됩니다)
00 0000 (두 번째 시리즈는 4 개의 0으로 구성됩니다)
0 00 (세 번째는 두 개의 1로 구성됩니다)
따라서 C는 다음과 같이 코딩됩니다 : 0 0 00 0000 0 00

두 번째 예에서 메시지 CC를 인코딩하려고합니다 (즉, 14 비트 10000111000011).
0 0 (단일 1)
00 0000 (4 0)
0 000 (3 1)
00 0000 (4 0)
0 00 (2 1)
따라서 CC는 다음과 같이 코딩됩니다 : 0 0 00 0000 0 000 00 0000 0 00
*/
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}