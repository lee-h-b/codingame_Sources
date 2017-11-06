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
 /* 이번엔 각도까지 재봐야함
 이프로그램 내에선 하늘의 제약이 있음 가로 7000 세로 3000의 넓이임
 이 화성엔 적어도 1000M의 평평한 땅이 있음
 매순간마다 현재 비행의 변수에 따라 착륙선의 새로운 경사각, 추진력을 제공해야함
 각은 0~4로 각기 -90 -45 0 45 90 을할당
 화성의 중력은 3.711이므로 최소한 추진력은 4가필요함
 즉 착륙에 성공하고 싶다면 다음 4가지 조건을 만족할것
 1.평지에착륙
2. 수직 위치에 착륙 (경사각 = 0 °)
3.수직 속도는 제한되어야합니다 (≤40m / s 절대 값)
4.수평 속도는 제한되어야한다 (≤ 20m / s 절대 값
 */
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); 
//        화성 표면을 그리는 데 사용 된 점의 수 N 표면.임
//다음 surfaceN lines : 두 개의 정수가 landX로 연결됩니다.
//모든 점들을 순차적으로 연결함으로써 화성의 표면을 형성 할 수 있습니다.
//화성은 여러 개의 구획으로 이루어져 있습니다. 
//첫 번째 점의 경우 landX = 0이고 마지막 점의 경우 landX = 6999입니다.
int groundX1=0;
int groundX2=0;
int groundY=0;
int tempY = 1;
int maxH = 0;
        for (int i = 0; i < surfaceN; i++)
        {
            //기본높이는 100
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point
            //수많은 점으로 표현한댔지 그러니 이건 x,y위치의 점좌표쯤
            if(maxH < landY && groundX2 == 0)
                maxH = landY;
            if(tempY == landY)
            {
                groundX2 = landX;
                groundY = landY;
            }
            else
            {
                if(tempY != groundY)
                {
                tempY = landY;
                groundX1 = landX;
                }
            }
                            Console.Error.WriteLine("맥" + maxH);
            Console.Error.WriteLine(landX + " + " + landY);
         //   Console.Error.WriteLine(groundY + " + " + groundX1 +" + " + groundX2);
        }

        // game loop
        int angle = 0;
        int speed = 0;
        while (true)
        {
            /*
            X, Y는 화성 착륙선의 좌표입니다 (미터 단위).
rotate 화성 착륙선의 회전 각을도 단위로 표현한 것입니다.
힘은 착륙 함의 추진력이다.
            */
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            //x,y는 우주선좌표
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            //hSpeed와 yspeed는 수평,수직 속도임 방향에 따라 음수가 될수도 있음
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            //
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            //연료 잔량임 연료가 없어지면 힘은 0이될것
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            //착륙선의 회전각
                        
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).
            //착륙선의 추진력
            if(X > (groundX2 + groundX1) /2 + 400)
            {
                if(hSpeed > -20)
                angle = 20;
                
                if(hSpeed >= 20)
                angle = 30;
                else if(hSpeed <= -20)
                angle = -30;
                
                if(( vSpeed  < 0 ) && ( 10 * vSpeed < Y - groundY) )
                speed = 4;
                else
                
                speed = Math.Min(Math.Max(-vSpeed - 36, 0 ) , 4);
                if( (Y- vSpeed * vSpeed <= maxH) && (X  >  (groundX2 + groundX1) /2 + 1500   ) )
                {
                    speed =4;
                    angle = Math.Min(Math.Max(angle, -3), 3);
                }
            }
            else if(X < (groundX2 + groundX1) /2  -400)
            {
                Console.Error.WriteLine(maxH);

                if(hSpeed < 20)
                angle = -20;
                
                if(hSpeed >= 20)
                angle = 30;
                else if(hSpeed <= -20)
                angle = -30;
//                 if(  vSpeed < 0 && 10*vSpeed < Y - groundY)
                   if(Y +10 *vSpeed <Y - groundY)
                    speed =4;
                else
                    speed = Math.Min(Math.Max(-vSpeed - 36, 0 ) , 4);
                    
                if( (Y- vSpeed * vSpeed <= maxH) && (X  < (groundX2 + groundX1) /2 - 2500 ) )
                {
                    speed =4;
                    angle = Math.Min(Math.Max(angle, -3), 3);
                }
                /*
                if(( vSpeed  < 0 ) && ( 10 * vSpeed < Y - groundX2) )
                speed = 4;
                else
                
                speed = Math.Min(Math.Max(-vSpeed - 36, 0 ) , 4);
                */
            }
            else
            {
                //안전 공간 내
                angle = Math.Min(Math.Max( (int) (hSpeed/ 30.0 * 45.0), -90 ) , 90);
                
                speed = Math.Min(Math.Max( -vSpeed - 30, Math.Max(Math.Abs ((int) ((angle/45.0) * 4 )), 0)) , 4);
            }
            if( Y - groundY <= ((Math.Abs( 2 * angle / 15) + 1 ) * -vSpeed))
            angle = 0;
            
             if( ( (angle / 15) + 1)  * speed >= fuel)
               angle = 0;
Console.Error.WriteLine(X + " + " + Y);
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            // rotate power. rotate is the desired rotation angle. power is the desired thrust power.
            //2개의 값을 갖는데 각도는 각 회전마다 각도의 실제값은 이전턴 +-15임
            //파워는 추진력 0= 꺼짐 4는 최대출력 각턴마다 실제 파워값은 이전턴 +-1;
            
            //우선 값을 읽을때 land가 동일한것을 찾아야할까
            
            //if 3개로 해결된다는데?
            
            Console.WriteLine(angle+" " + speed);
        }
    }
}