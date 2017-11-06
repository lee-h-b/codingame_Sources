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
 /* �̹��� �������� �������
 �����α׷� ������ �ϴ��� ������ ���� ���� 7000 ���� 3000�� ������
 �� ȭ���� ��� 1000M�� ������ ���� ����
 �ż������� ���� ������ ������ ���� �������� ���ο� ��簢, �������� �����ؾ���
 ���� 0~4�� ���� -90 -45 0 45 90 ���Ҵ�
 ȭ���� �߷��� 3.711�̹Ƿ� �ּ��� �������� 4���ʿ���
 �� ������ �����ϰ� �ʹٸ� ���� 4���� ������ �����Ұ�
 1.����������
2. ���� ��ġ�� ���� (��簢 = 0 ��)
3.���� �ӵ��� ���ѵǾ���մϴ� (��40m / s ���� ��)
4.���� �ӵ��� ���ѵǾ���Ѵ� (�� 20m / s ���� ��
 */
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); 
//        ȭ�� ǥ���� �׸��� �� ��� �� ���� �� N ǥ��.��
//���� surfaceN lines : �� ���� ������ landX�� ����˴ϴ�.
//��� ������ ���������� ���������ν� ȭ���� ǥ���� ���� �� �� �ֽ��ϴ�.
//ȭ���� ���� ���� ��ȹ���� �̷���� �ֽ��ϴ�. 
//ù ��° ���� ��� landX = 0�̰� ������ ���� ��� landX = 6999�Դϴ�.
int groundX1=0;
int groundX2=0;
int groundY=0;
int tempY = 1;
int maxH = 0;
        for (int i = 0; i < surfaceN; i++)
        {
            //�⺻���̴� 100
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point
            //������ ������ ǥ���Ѵ��� �׷��� �̰� x,y��ġ�� ����ǥ��
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
                            Console.Error.WriteLine("��" + maxH);
            Console.Error.WriteLine(landX + " + " + landY);
         //   Console.Error.WriteLine(groundY + " + " + groundX1 +" + " + groundX2);
        }

        // game loop
        int angle = 0;
        int speed = 0;
        while (true)
        {
            /*
            X, Y�� ȭ�� �������� ��ǥ�Դϴ� (���� ����).
rotate ȭ�� �������� ȸ�� ������ ������ ǥ���� ���Դϴ�.
���� ���� ���� �������̴�.
            */
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            //x,y�� ���ּ���ǥ
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            //hSpeed�� yspeed�� ����,���� �ӵ��� ���⿡ ���� ������ �ɼ��� ����
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            //
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            //���� �ܷ��� ���ᰡ �������� ���� 0�̵ɰ�
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            //�������� ȸ����
                        
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).
            //�������� ������
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
                //���� ���� ��
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
            //2���� ���� ���µ� ������ �� ȸ������ ������ �������� ������ +-15��
            //�Ŀ��� ������ 0= ���� 4�� �ִ���� ���ϸ��� ���� �Ŀ����� ������ +-1;
            
            //�켱 ���� ������ land�� �����Ѱ��� ã�ƾ��ұ�
            
            //if 3���� �ذ�ȴٴµ�?
            
            Console.WriteLine(angle+" " + speed);
        }
    }
}