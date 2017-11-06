using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // x��
        int height = int.Parse(Console.ReadLine()); // y��
        char[,] array = new char[height, width];
        int[,] neighbors = new int[3,2];
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .'
 
            for(int j = 0; j < width; j++)
            {
                array[i,j] = line[j];
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // Three coordinates: a node, its right neighbor, its bottom neighbor
        for(int i = 0; i < height; i ++)
        {
            neighbors = new int[3,2];
            for(int j = 0; j < width; j++)
            {
                if(array[i,j] == '0')
                {
                    neighbors[0,0] = i;
                    neighbors[0,1] = j;

                    Player.NBCalc(i, j,width,height,neighbors,array);
                }
                
            }
        }

        //���⼭ x1 y1 x2 y2 �������� ����̵ȴ�
        //x1 y1�� ����ġ�� -1�̶��ϸ� �̿����� ���ٴ°���
    }
    public static void NBCalc(int i, int j,int width, int height,int[,] nb,char[,] field)
    {
        for(int h = i+1; h <= height; h++)
        {
            if(h == height)
            {
                nb[2,0] = -1;
                nb[2,1] = -1;
                break;
            }
            if(field[h,j] == '0')
            {
                nb[2,0] = h;
                nb[2,1] = j;
                break;
            }


        }
        for(int w = j+1; w<= width; w++)
        {
            if(w == width )
            {
                nb[1,0] = -1;
                nb[1,1] = -1;
                break;
            }
            if(field[i,w] == '0')
            {
                nb[1,0] = i;
                nb[1,1] = w;
                break;
            }

        }
        
        Console.WriteLine(nb[0,1] + " " + nb[0,0] + " " +
                        nb[1,1] + " " + nb[1,0] + " " +
                        nb[2,1] + " " + nb[2,0] );
    }
}
/*�̿��ϴ� ��带 ã�Ƽ� �̾��شٴ� ���� 
���� �־��ָ� �ȵ�
��尡 �ߺ��Ǽ� ���� �ȵ�(0,0) (1,0) (0,0) x

�׷��ٸ� x,y���� �ݺ����Ѽ� �ε����� �ߴ��ϰ�, �ش���ġ�� ����� �����½����� �ϰԵǰڴ�
������ġ�� �ش� ������� ��ġ��
*/