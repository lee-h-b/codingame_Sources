using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.

/* 로봇이 갈 길을 추리할수 잇는 프로그램을 만들기
내생각엔 a*알고리즘을 그린라는 거같음<X 유한상태기계? 그거임

새로운 Bender 시스템의 9 가지 규칙 :
벤더는지도에서 @ 기호로 표시된 곳에서 출발하여 남쪽으로 향합니다.
2. 벤더는 자신의 여행을 마치고 $로 표시된 자살 부스에 도달하면 사망합니다.
3. 벤더가 직면 할 수있는 장애물은 # 또는 X로 표시됩니다.
6. 회로 인버터 (I on map)는 Bender가 장애물을 만났을 때 선택해야하는 방향을 역전시킬 자기장을 생성합니다. 우선 순위는 서쪽, 북쪽, 동쪽, 남쪽이됩니다. Bender가 인버터 I로 복귀하면 우선 순위가 원래 상태 (SOUTH, EAST, NORTH, WEST)로 재설정됩니다.
7. 벤더는 그의 경로를 따라 맥주를 몇 개 발견 할 수 있습니다 (지도상의 B). 그러면 그에게 힘을주고 "차단기"모드로 들어갈 수 있습니다. Breaker 모드는 Bender가 캐릭터 X (장애물 X 만)가 나타내는 장애물을 파괴하고 자동으로 통과시킵니다. 장애물이 파손되면 영구적으로 유지되고 Bender는 방향을 유지합니다. Bender가 Breaker 모드에 있고 맥주를 다시 통과하면 즉시 Baker 모드에서 빠져 나옵니다. Bender가 지나간 후에도 맥주는 그대로 남아 있습니다.
8.2 텔레 포터 T가 시내에있을 수있다. 벤더가 텔레 포터를 통과하면 자동으로 다른 텔레 포터의 위치로 텔레포트되며 방향 및 브레이커 모드 속성은 그대로 유지됩니다.
9. 마지막으로 공백 문자는지도의 빈 영역입니다 (위에서 지정한 것 이외의 특수 동작 없음).

프로그램은 Bender가 입력 한지도에 따라 이동 순서를 표시해야합니다.

지도는 선 (L)과 열 (C)로 나뉩니다. 지도의 윤곽선은 항상 깨지지 않는 # 장애물입니다. 지도에는 항상 출발점 @와 자살 부스 $가 있습니다.

Bender가 무한 루프로 인해 자살 부스에 도착할 수없는 경우 프로그램에 LOOP 만 표시되어야합니다.
로봇은 남쪽을 최우선으로 감 목적지는 $ 장애물은 #,X로 표시한다
장애물을 만나면 다음 우선순위로함 1.남 2.동 3.북 4.서 <<그리고 받은 방향으로감
그리고 가다가 특정 WESN)을 발견하면 해당 기호에 맞는 방향으로가게됨
회로 인버터라는게 (I)있는데 만나면 선택 우선순위가 반전됨 즉 1.서 2.북 3.동 4.남 다시I에 닿으면 복구됨
7.경로를 따라 맥주(B)를 몇개 발견할 수 있는데 이경우 'X'장애물을 영구 파괴가 가능 B를 다시 밟으면 모드가 해제가된다
8 T도 있는데 여기로 가면다른 T로 이동하고 B속성은 그대로 유지함
출력은 로봇이 @~$로 갔을때 도착한 커맨드임
만약 도착을 못한다면 LOOP를 표기함
공백은 빈공간임
*/
class Solution
{
    static void Main(string[] args)
    {
        int count = 0;
        string[] inputs = Console.ReadLine().Split(' ');        
        int L = int.Parse(inputs[0]);//가로
        int C = int.Parse(inputs[1]);//세로
        char[,] map = new char[L,C];
        Tuple<int,int> endCursor = new Tuple<int,int>(0,0);// = new Tuple<int,int>();
        Tuple<int,int> robot = new Tuple<int,int>(0,0);
        bool powermode = false;
        bool reverse = false;
        for (int i = 0; i < L; i++)
        {            
            string row = Console.ReadLine();//맵구조
            for(int j = 0; j < C; j++)
            {
                map[i,j] = row[j];
                if(row[j] == '$')
                {
                    endCursor = new Tuple<int,int>(i,j);
                }
                if(row[j] =='@')
                {
                    robot = new Tuple<int,int>(i,j);
                }                
            }
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

//결과를 반복문으로 출력하게될것
        List<string> orders = new List<String>();
        char forceDirection =' ';

        Tuple<int,int> next = new Tuple<int,int>(0,0);
        Tuple<int,int>[] direction = new Tuple<int, int>[4];
        
        int numDir = 0;
        int beforeCode = 0;
        int reverseVal = 0;
        
        if(reverse == true)
        reverseVal =3;

        direction[0] = new Tuple<int,int>(1,0);
        direction[1] = new Tuple<int,int>(0,1);
        direction[2] = new Tuple<int,int>(-1,0);
        direction[3] = new Tuple<int,int>(0,-1);        
        while(true)
        {
            var order = "";
            
            if(reverse == false)
            {
                        direction[0] = new Tuple<int,int>(1,0);
            direction[1] = new Tuple<int,int>(0,1);
            direction[2] = new Tuple<int,int>(-1,0);
            direction[3] = new Tuple<int,int>(0,-1);    
            }

            if(forceDirection != ' ')
            {
                switch (forceDirection)
                {
                    case 'S' : numDir = Math.Abs(0); break;
                    case 'E' : numDir = Math.Abs(1); break;
                    case 'N' : numDir = Math.Abs(2); break;
                    case 'W' : numDir = Math.Abs(3); break;                    
                }
            }
            var y = robot.Item1 + direction[Math.Abs( numDir)].Item1;
            var x = robot.Item2 + direction[Math.Abs( numDir)].Item2;            
//            Console.Error.WriteLine(y + " " +x);
            if(map[y,x] == '#' || map[y,x] == 'X' && powermode == false)
            {
                forceDirection = ' ';
                if(reverse == true && beforeCode == 5)
                {
                    beforeCode = 1;
                    numDir = 3;
                }
                else if(reverse == true)
                {                    
                    numDir--;
                    if(numDir < 0)
                    numDir = 3;
                }
                else if(beforeCode == 5)
                {
                    beforeCode =1;
                    numDir= 0;
                }
                else
                {
                    beforeCode++;
                numDir++;
                }
                
            continue;
            }
            else
            {
                beforeCode =5;
            robot = new Tuple<int, int>(robot.Item1 + direction[numDir].Item1, robot.Item2 +  direction[numDir].Item2);
                
            }
            
            if(map[y,x] == 'E' || map[y,x] == 'N' || map[y,x] == 'S' || map[y,x] == 'W' )
            {

                forceDirection = map[y,x];
//                Console.Error.WriteLine(forceDirection);
            }

            if(map[y,x] == 'B')
            {
//                Console.Error.WriteLine("술");
                powermode = !powermode;
            }
            if(map[y,x] == 'I')
            {//South하던건 계속 해야함 즉 numDir를 바꾸지 않고 어떤 값이 추가되고 계산되는식?
//                Console.Error.WriteLine("TuRN" + y+ " " +x);
                reverse = !reverse;
                if(reverse == true)
                reverseVal = 3;
            }
            if(map[y,x] == 'X' && powermode == true)
            {
                map[y,x] = ' ';
            }
            if(map[y,x] == 'T')
            {

                for(int i = 0; i <L; i++)
                    for(int j = 0; j <C; j++)
                    {
                        if(map[i,j] == 'T' && (y != i || x != j) )
                        {
                            Console.Error.WriteLine(i +" " +j +"vs"+ y +" " +x);
                            robot = new Tuple<int,int>(i,j);

                            break;
                            
                        }
                    }
            }
//                        robot = new Tuple<int, int>(robot.Item1 + direction[numDir].Item1, robot.Item2 +  direction[numDir].Item2);

            switch(numDir)
            {
                case 0: order = "SOUTH"; break;
                case 1: order = "EAST"; break;
                case 2: order = "NORTH"; break;
                case 3: order = "WEST"; break;        
            }
//            Console.Error.Write(robot.Item1+ " "+ robot.Item2+ " " );
            Console.Error.Write(count);
            orders.Add(order);
//            Console.WriteLine(order);
//            robot.Item2 += x;
        count++;
         if(robot.Item1 == endCursor.Item1 &&
         robot.Item2 == endCursor.Item2)
         {
         break;
         }
        if(count >= C*L)
        {
             Console.WriteLine("LOOP");
             break;
        }
         
        }
        if(count < C*L)
        {
            for(int i = 0; i <orders.Count; i++)
            {
                Console.WriteLine(orders[i]);
            }
        }
    }
}