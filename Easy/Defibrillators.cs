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
        string LON = Console.ReadLine();
        string LAT = Console.ReadLine();
        int N = int.Parse(Console.ReadLine());
        float lo = float.Parse(LON.Replace(",",".") );
        float la = float.Parse(LAT.Replace(",",".") );
        float distance = int.MaxValue;
        string answer = "";
        for (int i = 0; i < N; i++)
        {
            string[] DEFIB = Console.ReadLine().Split(';');
            float DEFLON = float.Parse(DEFIB[DEFIB.Length-2].Replace(",",".") );
            float DEFLAT = float.Parse(DEFIB[DEFIB.Length-1].Replace(",",".") );
            
            float d = (float)Math.Pow((double)DEFLON - lo ,2) + (float)Math.Pow((double)DEFLAT - la,2) ;
            if(d <distance)
            {
            distance = d;
            answer = DEFIB[1];
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

//        Console.WriteLine(lo);
//              Console.WriteLine(la);
        Console.WriteLine(answer);
    }
    /*
    이 필드는 세미콜론 (;)으로 구분됩니다.

주의 : 십진수는 쉼표 (,)를 소수 구분 기호로 사용합니다. 프로그램에서 데이터를 사용하려면 필요한 경우 쉼표 (,)를 점 (.)으로 바꾸십시오.

3,879483
43,608177
//이 2곳의 위치에서 제일 가까운곳으로 가란뜻 즉 실제로 수치만 보면 되기에 위치,위도 경도만보면될듯
3
1;Maison de la Prevention Sante;6 rue Maguelone 340000 Montpellier;;3,87952263361082;43,6071285339217
2;Hotel de Ville;1 place Georges Freche 34267 Montpellier;;3,89652239197876;43,5987299452849
3;Zoo de Lunaret;50 avenue Agropolis 34090 Mtp;;3,87388031141133;43,6395872778854 

    테스트에서 제공 한 데이터를 토대로 사용자가 휴대 전화를 사용하여 가장 가까운 제세 동기를 찾을 수있는 프로그램을 작성하십시오.

규칙
프로그램에 필요한 입력 데이터는 텍스트 형식으로 제공됩니다.
이 데이터는 각각 제세 동기를 나타내는 라인으로 구성됩니다. 각 제세 동기는 다음 필드로 표시됩니다.
제세 동기를 식별하는 번호
이름
주소
연락 전화 번호
경도 (도)
위도 (도)
*/
}