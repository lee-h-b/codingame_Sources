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
 /*
 당신의 목표는 인디가 터널을 따라 내려가는 경로를 예측할 수있는 프로그램을 작성하는 것입니다. 
 인디는이 첫 번째 임무에 갇히지 않을 위험이 없습니다.
무조건 내려가는 경로를 예측할수있다

규칙
터널은 다양한 종류의 정사각형 객실로 구성되어 있고 총 14개의 유형이 있음
총 14 개의 객실 유형 (6 개의 기본 모양이 회전을 통해 14 개로 확장)이 있습니다.

방에 들어가면 방의 유형과 인디의 입구 지점 (TOP, LEFT 또는 RIGHT)에 따라 특정 출구 점을 통과하여 방을 빠져 나오거나 치명적인 충돌을 입거나 
기세를 잃어 붙어 버립니다
방에 들어갔을때 특정 출구로 나가거나 충돌하거나 둘중하나 
대체로 위에서 아래로 내려가는 하수구같음
시작할때 지도를 줌 이 지도는 그방의 유형을 표현함 

턴 . 현재 내위치를 받음 그리고 다음 위치를 지정함(내가?)
그럼 내캐릭은 방의 모양에 따라 현재에서 다음으로 이동함
인디는 끊임없이 아래쪽으로 끌어 당겨진다 : 그는 정상을 통해 방을 떠날 수 없다.

게임을 시작할 때 방의 사각형 격자 형태로 터널지도가 제공됩니다. 각 방은 그 유형으로 표현됩니다.

이 첫 번째 임무는 터널 시스템에 익숙해 질 것입니다. 객실은 인디가 출발 지점 (사원 상단)과 출구 지점 (맨 아래) 사이를 안전하게 연결하는 방식으로 배치되어 있습니다. 신전).

각 게임 턴 :
Indy의 현재 위치를받습니다.
그런 다음 인디의 위치가 다음 차례가 될 위치를 지정합니다.
Indy는 현재 방의 모양에 따라 현재 방에서 다음 방으로 이동할 것입니다.
 */
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // number of columns.
        int H = int.Parse(inputs[1]); // number of rows.
        //넓이 WH
        int[,] array = new int[H,W];
        for (int i = 0; i < H; i++)
        {
            string[] LINE = Console.ReadLine().Split(' '); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
            //격자 1줄의 방을뜻함 W간격으로 구분된 정수 T를 내포, 이 T는 방유형
            for(int j = 0; j <W; j++)
            {
                array[i,j] = int.Parse(LINE[j] );
                Console.Error.Write(array[i,j]);
            }
            Console.Error.WriteLine();
        }
        int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).
        //이건 X축을 따라 좌표를 지정함 이퍼즐의 2번째레벨에 유용(지금은 안쓸까)
//        Console.Error.WriteLine(EX);
int xpos;
int ypos;
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int XI = int.Parse(inputs[0]);
            int YI = int.Parse(inputs[1]);
            //현재 인디의 위치
            string POS = inputs[2];
            //현재 인디의 진입지점을 가리키는 단어위쪽이면 TOP 왼쪽이면 LEFT이런식
            Console.Error.WriteLine(XI + " " + YI +" " + POS);
            xpos =XI;
            ypos =YI;
/*간단하게 스위치 케이스로 해결해보자!
*/
            switch (array[ypos,xpos])
            {
                case 1:
                case 3:
                case 7:
                case 8:
                case 9:

                {

                    
                    ypos += 1;
                    break;
                }
                case 2:
                case 6:
                {
                    if(POS == "LEFT")
                    xpos+=1;
                    else
                    xpos -= 1;
                    break;
                }
                case 4:
                {
                    if(POS =="LEFT")
                    break;
                    if(POS == "TOP")
                    xpos -= 1;
                    else
                    ypos +=1;                    
                    break;
                }
                case 5:
                {
                    if(POS =="RIGHT")
                    break;
                    if(POS == "TOP")
                    xpos += 1;
                    else
                    ypos +=1;                    
                    break;                    
                }
                case 10:
                {
                    if(POS =="TOP")
                        xpos -=1;
                    else
                        break;
                    break;

                }
                case 11:
                {
                    if(POS =="TOP")
                        xpos +=1;
                    else
                        break;
                    break;
                        
                }
                case 12:
                {
                    if(POS == "RIGHT")
                    ypos +=1;
                    break;                    
                }
                case 13:
                {
                    if(POS == "LEFT")
                    ypos +=1;
                    break;                    
                }
            }

//출력은 다음 턴에 내가 있을 위치
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
            Console.WriteLine(xpos+ " " + ypos);
        }
    }
}