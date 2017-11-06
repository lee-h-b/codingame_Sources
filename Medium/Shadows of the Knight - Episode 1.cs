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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        int sx = -1;
        int sy = -1;
                    int gx = X0;
            int gy = Y0;
        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            for(int i = 0; i < bombDir.Length; i++)
            {

                if(bombDir[i] == 'U')
                {
                    H = gy;
                    gy = (gy - ((H- sy) /2 ) );
//                    sy = gy ;
                }
                if(bombDir[i] == 'D')
                {
                    sy = gy;
                     //�� �������� or �������� ����� �����ν� ��������
                    gy = (gy + ((H- sy) /2 ) );
//                    H = gy ;                    
                }
                if(bombDir[i] == 'L')
                {
                    W = gx;
                    gx = gx -( (W -sx ) /2) ;
                    
                }
                if(bombDir[i] == 'R')
                {
                    sx = gx;
                    gx = gx + ( ( W - sx ) /2 );
                }                

            }
            Console.WriteLine(gx + " " + gy);



            // the location of the next window Batman should jump to.
//            Console.WriteLine(answer[1] + " " + answer[0] );
        }
    }
}
/* ���ѵ� �����̼Ǿȿ� ��ǥ�� �����ϱ� ��ź���Ῠ ���� U UR R DR D R DL L UL������ �̵��ؾ��ϸ�
���� ��ǥ�� ��ź��ġ���� ���°��� < �����ϸ� �ѹ濡 ���°� ������
��ġ�´翬 0,0���� W,H���� ���ǰ���
���� �����ϱ��� �ʱⵥ���͸� �а� �׸����ѷ������� �Է°��� �а� ��¿� ���� �̵����� �����ϰԵ�
1. W H�� �ǹ��� ����,���̸� ��Ÿ��
N�� ��Ʈ���� �Ҽ��ִ� ������ Ƚ����
3��° XY�� ��Ʈ���� ������ġ��
���� ���۽� ��ź�� ��� ���⿡ �ִ����� �˷���
��µǴ� ���� ��Ʈ���� ��������� �پ�� �������� �������� �˷��ְ���
���׷��ٸ� 1/2 1/2��ġ�� ���� ~�ϰ�~�ϵ��� �ؾ��ҵ�

*/
/*
���� 1 : 2 ���� W H. (W, H) ���� �ǹ��� �ʺ�� ���̸� ���� â���� ��Ÿ���ϴ�.
2 �� : 1 ���� N�� ��ź�� ������ ���� ��Ʈ���� �� ���ִ� ���� Ƚ���� ��Ÿ���ϴ�.
3 �� : ��Ʈ���� ���� ��ġ�� ��Ÿ���� 2 ���� ���� X0 Y0.
*/