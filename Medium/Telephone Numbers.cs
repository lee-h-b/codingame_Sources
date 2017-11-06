using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
iDroid 스마트 폰 개발 팀에 합류하면 연락처 관리자를 개발할 책임이 있습니다. 분명히, 당신이 말하지 않은 것은 iDroid에 대한 기술적 인 제약이 
강하다는 것입니다 : 시스템은 메모리가별로없고 프로세서는 90 년대의 Cyrix만큼 빠릅니다.

사양에는 특히주의를 기울이는 두 가지 점이 있습니다.

1. 숫자 입력을위한 지능형 지원
입력 한 첫 번째 숫자에 해당하는 숫자가 거의 즉시 사용자에게 표시됩니다.
휴대폰 쓰면 전호번호 입력할때 이름이나 번호하면 바로 혹시 이번호인가 하고 띄우지? 그거이야기

2. 숫자 저장 최적화
숫자에 공통적 인 첫 번째 숫자는 메모리에 중복되어서는 안됩니다.
//특정 숫자가 조합이되면 이러이러한 것이 나온다! 라는 결과가 되길 원하나봄

당신의 임무는 위에 제시된 구조로 전화 번호 목록을 저장하는 데 필요한 숫자 (숫자)를 표시하는 프로그램을 작성하는 것입니다.
 **/
class Solution
{
    //시작하는 시드의 값은 없고 ~~ 하는식이 될듯 한데
    /*
    일단 값을 전부 저장하고 이전과 같은 값이면 카운트를 안하는 식?
    ㄴ 너무오래걸릴것
    
    무식하게 정렬후
    배열에 전부다 저장 그리고 해당값을 1의 단위로 쪼갬
    임의의값 1234가 저장되있고 145가 있다면
    우선 145에서 1이 있는 위치로 감 만약 있을경우 카운트안하고 다음으로 그럼 4가 나옴 > 여기서 1+4 즉 14를 검색
    14는 없으니깐 145의 저장을 허락
    다음값이 147
    1은? 있고 14는?있고 147은? 없고 147추가하고 "14" - "147"의 길이만큼 size추가
    이런식으로 할거같음
    
    */
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());//전화번호의 갯수
        int size = 0;
        string[] phones = new string[N];
        //이렇게하면 될까
        for (int i = 0; i < N; i++)
        {
            //각 회선은 최대 길이 L 인 전화 번호를 포함합니다. 전화 번호는 공백없이 0부터 9까지의 숫자만으로 구성됩니다.
            
            phones[i] = Console.ReadLine();//L만큼의 길이의 값 무언가임 L은 20이고 '-'나 '0'은 없음 따라서 이걸 먼저
            //문자단위(char)로 나눌 필요가 있다고봄
            
        }
    Array.Sort(phones);
    size += phones[0].Length;
    //정렬했으니 이전 값과 다르기 시작하면 해당 값의 길이만큼 더하기어떰
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
        //구조체에 저장된 숫자의 수
    }
}