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
        int nbFloors = int.Parse(inputs[0]); // 플로어의 수 1 ~ 15 사이 이동가능
        int width = int.Parse(inputs[1]); // 넓이 0과 width 사이에서 이동가능        
        int nbRounds = int.Parse(inputs[2]); // 종료전 최종 라운드의 수
        int exitFloor = int.Parse(inputs[3]); // 출구가 있는 층
        int exitPos = int.Parse(inputs[4]); // 출구의 위치
        int nbTotalClones = int.Parse(inputs[5]); // 클론수
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        
        int nbElevators = int.Parse(inputs[7]); // 엘레베이터의 갯수
        int[] elevatorFloor = new int[nbElevators];
        int[] elevatorPos = new int[nbElevators];

        for (int i = 0; i < nbElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            elevatorFloor[i] = int.Parse(inputs[0]); //엘베층
            elevatorPos[i] = int.Parse(inputs[1]); // 엘베위치
        }
        //엘베 층 스왑
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
            int cloneFloor = int.Parse(inputs[0]); // 리딩클론이 있는 층
            int clonePos = int.Parse(inputs[1]); // 리딩클론위치(수일듯(
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
            int curExit = exitPos;
            //ㄴ 이동방향 LEFT면 왼쪽 RIGHT면 오른쪽으로 이동함
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
    만약 탈출구가 나랑 같은 층계가 아닐경우 elevators를 찾으러 갈것임
    그 엘레베이터를 찾은다음 그엘레베이터의 위치에 따른 이동을 행함
    같은층계면 해당 엘레베이터의 방향을 향해감
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
    /* 0은 가장 오른쪽이고 -1은 가장 왼쪽
    목표는 적어도 1개의 복제품을 살리는것임
    
   발전기는 바닥 0에 있습니다. 클론은 발전기 머리글을 오른쪽으로 빠져 나갑니다.
클론은 한 방향으로 한 위치를 직선으로 움직여 현재 방향으로 움직입니다.
클론은 위치 0 이하 또는 위치 너비 -1 이상으로 이동하면 레이저에 의해 파괴됩니다
목표는 적어도 하나의 클론이 탈출(네모난 원통)하는것
    */
}