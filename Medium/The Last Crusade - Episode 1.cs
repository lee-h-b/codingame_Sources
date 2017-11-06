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
 ����� ��ǥ�� �ε� �ͳ��� ���� �������� ��θ� ������ ���ִ� ���α׷��� �ۼ��ϴ� ���Դϴ�. 
 �ε���� ù ��° �ӹ��� ������ ���� ������ �����ϴ�.
������ �������� ��θ� �����Ҽ��ִ�

��Ģ
�ͳ��� �پ��� ������ ���簢�� ���Ƿ� �����Ǿ� �ְ� �� 14���� ������ ����
�� 14 ���� ���� ���� (6 ���� �⺻ ����� ȸ���� ���� 14 ���� Ȯ��)�� �ֽ��ϴ�.

�濡 ���� ���� ������ �ε��� �Ա� ���� (TOP, LEFT �Ǵ� RIGHT)�� ���� Ư�� �ⱸ ���� ����Ͽ� ���� ���� �����ų� ġ������ �浹�� �԰ų� 
�⼼�� �Ҿ� �پ� �����ϴ�
�濡 ������ Ư�� �ⱸ�� �����ų� �浹�ϰų� �����ϳ� 
��ü�� ������ �Ʒ��� �������� �ϼ�������
�����Ҷ� ������ �� �� ������ �׹��� ������ ǥ���� 

�� . ���� ����ġ�� ���� �׸��� ���� ��ġ�� ������(����?)
�׷� ��ĳ���� ���� ��翡 ���� ���翡�� �������� �̵���
�ε�� ���Ӿ��� �Ʒ������� ���� ������� : �״� ������ ���� ���� ���� �� ����.

������ ������ �� ���� �簢�� ���� ���·� �ͳ������� �����˴ϴ�. �� ���� �� �������� ǥ���˴ϴ�.

�� ù ��° �ӹ��� �ͳ� �ý��ۿ� �ͼ��� �� ���Դϴ�. ������ �ε� ��� ���� (��� ���)�� �ⱸ ���� (�� �Ʒ�) ���̸� �����ϰ� �����ϴ� ������� ��ġ�Ǿ� �ֽ��ϴ�. ����).

�� ���� �� :
Indy�� ���� ��ġ���޽��ϴ�.
�׷� ���� �ε��� ��ġ�� ���� ���ʰ� �� ��ġ�� �����մϴ�.
Indy�� ���� ���� ��翡 ���� ���� �濡�� ���� ������ �̵��� ���Դϴ�.
 */
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // number of columns.
        int H = int.Parse(inputs[1]); // number of rows.
        //���� WH
        int[,] array = new int[H,W];
        for (int i = 0; i < H; i++)
        {
            string[] LINE = Console.ReadLine().Split(' '); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
            //���� 1���� �������� W�������� ���е� ���� T�� ����, �� T�� ������
            for(int j = 0; j <W; j++)
            {
                array[i,j] = int.Parse(LINE[j] );
                Console.Error.Write(array[i,j]);
            }
            Console.Error.WriteLine();
        }
        int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).
        //�̰� X���� ���� ��ǥ�� ������ �������� 2��°������ ����(������ �Ⱦ���)
//        Console.Error.WriteLine(EX);
int xpos;
int ypos;
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int XI = int.Parse(inputs[0]);
            int YI = int.Parse(inputs[1]);
            //���� �ε��� ��ġ
            string POS = inputs[2];
            //���� �ε��� ���������� ����Ű�� �ܾ������̸� TOP �����̸� LEFT�̷���
            Console.Error.WriteLine(XI + " " + YI +" " + POS);
            xpos =XI;
            ypos =YI;
/*�����ϰ� ����ġ ���̽��� �ذ��غ���!
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

//����� ���� �Ͽ� ���� ���� ��ġ
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
            Console.WriteLine(xpos+ " " + ypos);
        }
    }
}