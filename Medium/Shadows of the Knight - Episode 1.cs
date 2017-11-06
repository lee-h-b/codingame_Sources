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
                     //이 시작지점 or 끝지점을 현재로 함으로써 보정을함
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
/* 제한된 점프미션안에 목표에 도달하기 폭탄방햐엥 따라 U UR R DR D R DL L UL식으로 이동해야하며
나의 목표는 폭탄위치까지 가는것임 < 가능하면 한방에 가는게 좋을듯
위치는당연 0,0부터 W,H까지 가되겠음
먼저 시작하기전 초기데이터를 읽고 그리고무한루프에서 입력값을 읽고 출력에 다음 이동값을 제공하게됨
1. W H는 건물의 넓이,높이를 나타냄
N은 배트맨이 할수있는 점프의 횟수임
3번째 XY는 배트맨의 시작위치임
게임 시작시 폭탄이 어느 방향에 있는지를 알려줌
출력되는 값은 배트맨이 어느곳으로 뛰어야 정답으로 가는지를 알려주게함
ㄴ그렇다면 1/2 1/2위치로 가고 ~하고~하도록 해야할듯

*/
/*
라인 1 : 2 정수 W H. (W, H) 쌍은 건물의 너비와 높이를 여러 창으로 나타냅니다.
2 행 : 1 정수 N은 폭탄이 터지기 전에 배트맨이 할 수있는 점프 횟수를 나타냅니다.
3 행 : 배트맨의 시작 위치를 나타내는 2 개의 정수 X0 Y0.
*/