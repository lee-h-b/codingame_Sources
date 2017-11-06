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
        int nbFloors = int.Parse(inputs[0]); // �÷ξ��� �� 1 ~ 15 ���� �̵�����
        int width = int.Parse(inputs[1]); // ���� 0�� width ���̿��� �̵�����        
        int nbRounds = int.Parse(inputs[2]); // ������ ���� ������ ��
        int exitFloor = int.Parse(inputs[3]); // �ⱸ�� �ִ� ��
        int exitPos = int.Parse(inputs[4]); // �ⱸ�� ��ġ
        int nbTotalClones = int.Parse(inputs[5]); // Ŭ�м�
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        
        int nbElevators = int.Parse(inputs[7]); // ������������ ����
        int[] elevatorFloor = new int[nbElevators];
        int[] elevatorPos = new int[nbElevators];

        for (int i = 0; i < nbElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            elevatorFloor[i] = int.Parse(inputs[0]); //������
            elevatorPos[i] = int.Parse(inputs[1]); // ������ġ
        }
        //���� �� ����
        for(int i = 0; i < nbElevators-1; i++)
        {
            for(int j = i+1; j < nbElevators; j++)
            if(elevatorFloor[i] > elevatorFloor[j])
            {
                int temp = elevatorFloor[i];
                elevatorFloor[i] = elevatorFloor[j];
                elevatorFloor[j] = temp;
                
                temp = elevatorPos[i];
                elevatorPos[i] = elevatorPos[j];
                elevatorPos[j] = temp;
            }
        }

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int cloneFloor = int.Parse(inputs[0]); // ����Ŭ���� �ִ� ��
            int clonePos = int.Parse(inputs[1]); // ����Ŭ����ġ(���ϵ�(
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
            int curExit = exitPos;
            //�� �̵����� LEFT�� ���� RIGHT�� ���������� �̵���
            if(exitFloor == cloneFloor)
            {
                Console.Error.WriteLine("FINISH");
                curExit = exitPos;
            }
            else if( exitFloor > cloneFloor && nbElevators > 0 && cloneFloor >= 0)
            {

                curExit = elevatorPos[cloneFloor];
            }
/*
    ���� Ż�ⱸ�� ���� ���� ���谡 �ƴҰ�� elevators�� ã���� ������
    �� ���������͸� ã������ �׿����������� ��ġ�� ���� �̵��� ����
    ��������� �ش� ������������ ������ ���ذ�
*/
            if(curExit < clonePos && direction == "RIGHT" || curExit > clonePos && direction == "LEFT")
            {
                for(int i = 0; i < nbElevators; i++)
                    Console.Error.WriteLine(elevatorPos[i]);

                Console.Error.WriteLine(clonePos);
                Console.Error.WriteLine(curExit);
                Console.WriteLine("BLOCK"); // action: WAIT or BLOCK

            }
            else
                Console.WriteLine("WAIT"); // action: WAIT or BLOCK

            
            
        }
    }
    /* 0�� ���� �������̰� -1�� ���� ����
    ��ǥ�� ��� 1���� ����ǰ�� �츮�°���
    
   ������� �ٴ� 0�� �ֽ��ϴ�. Ŭ���� ������ �Ӹ����� ���������� ���� �����ϴ�.
Ŭ���� �� �������� �� ��ġ�� �������� ������ ���� �������� �����Դϴ�.
Ŭ���� ��ġ 0 ���� �Ǵ� ��ġ �ʺ� -1 �̻����� �̵��ϸ� �������� ���� �ı��˴ϴ�
��ǥ�� ��� �ϳ��� Ŭ���� Ż��(�׸� ����)�ϴ°�
    */
}