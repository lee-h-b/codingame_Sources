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
    �� �ʵ�� �����ݷ� (;)���� ���е˴ϴ�.

���� : �������� ��ǥ (,)�� �Ҽ� ���� ��ȣ�� ����մϴ�. ���α׷����� �����͸� ����Ϸ��� �ʿ��� ��� ��ǥ (,)�� �� (.)���� �ٲٽʽÿ�.

3,879483
43,608177
//�� 2���� ��ġ���� ���� ���������� ������ �� ������ ��ġ�� ���� �Ǳ⿡ ��ġ,���� �浵������ɵ�
3
1;Maison de la Prevention Sante;6 rue Maguelone 340000 Montpellier;;3,87952263361082;43,6071285339217
2;Hotel de Ville;1 place Georges Freche 34267 Montpellier;;3,89652239197876;43,5987299452849
3;Zoo de Lunaret;50 avenue Agropolis 34090 Mtp;;3,87388031141133;43,6395872778854 

    �׽�Ʈ���� ���� �� �����͸� ���� ����ڰ� �޴� ��ȭ�� ����Ͽ� ���� ����� ���� ���⸦ ã�� ���ִ� ���α׷��� �ۼ��Ͻʽÿ�.

��Ģ
���α׷��� �ʿ��� �Է� �����ʹ� �ؽ�Ʈ �������� �����˴ϴ�.
�� �����ʹ� ���� ���� ���⸦ ��Ÿ���� �������� �����˴ϴ�. �� ���� ����� ���� �ʵ�� ǥ�õ˴ϴ�.
���� ���⸦ �ĺ��ϴ� ��ȣ
�̸�
�ּ�
���� ��ȭ ��ȣ
�浵 (��)
���� (��)
*/
}