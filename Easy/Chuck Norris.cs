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
        //�ƽ�Ű�� �ش簪�� �޴´�, �׸���2������ �а� �������� �����Ѵ�
        //�״��� 1�̸� 0 0��, 0�̸� 00 0�� 
        //10 �̸� 0 0 00 0�� �ǰ��� 1��° 0��1?0?�� �����ϰ� 2��°�� ��Ʈ����
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
            //C�� ���� �ƽ�Ű��
        }
        for(int i =1; i< result.Length; i++)
        Console.Write(result[i]);
//        Console.WriteLine(chuck);

/*�Է� �޽����� ASCII ���� (7 ��Ʈ)
���ڵ� �� ��� �޽����� 0�� ���
����� �ٸ� ��ϰ� �������� ���е˴ϴ�.
�Ϸ��� ������ �� ��Ʈ (�� �ϳ� �Ǵ� 0 ��)�� �����ϱ� ���� �� ���� ���� ����� ���˴ϴ�.
- ù ��° ��� : �׻� 0 �Ǵ� 00�Դϴ�. 0�̸� �ø�� 1�� ���Եǰ� �׷��� ������ 0�� ���Ե˴ϴ�.
- �� ��° ��� :�� ��Ͽ��� 0�� ���� �迭�� ��Ʈ ���Դϴ�

��
�� ���ڸ����� ������ ������ ���� ��� ���ô� : Capital C. C�� �������� 1000011�� ǥ���˴ϴ�. Chuck Norris�� ����� ���� ������ �����ϴ�.
0 0 (ù ��° �ø���� �� �ϳ��� 1�� �����˴ϴ�)
00 0000 (�� ��° �ø���� 4 ���� 0���� �����˴ϴ�)
0 00 (�� ��°�� �� ���� 1�� �����˴ϴ�)
���� C�� ������ ���� �ڵ��˴ϴ� : 0 0 00 0000 0 00

�� ��° ������ �޽��� CC�� ���ڵ��Ϸ����մϴ� (��, 14 ��Ʈ 10000111000011).
0 0 (���� 1)
00 0000 (4 0)
0 000 (3 1)
00 0000 (4 0)
0 00 (2 1)
���� CC�� ������ ���� �ڵ��˴ϴ� : 0 0 00 0000 0 000 00 0000 0 00
*/
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}