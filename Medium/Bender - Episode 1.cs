using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.

/* �κ��� �� ���� �߸��Ҽ� �մ� ���α׷��� �����
�������� a*�˰����� �׸���� �Ű���<X ���ѻ��±��? �װ���

���ο� Bender �ý����� 9 ���� ��Ģ :
�������������� @ ��ȣ�� ǥ�õ� ������ ����Ͽ� �������� ���մϴ�.
2. ������ �ڽ��� ������ ��ġ�� $�� ǥ�õ� �ڻ� �ν��� �����ϸ� ����մϴ�.
3. ������ ���� �� ���ִ� ��ֹ��� # �Ǵ� X�� ǥ�õ˴ϴ�.
6. ȸ�� �ι��� (I on map)�� Bender�� ��ֹ��� ������ �� �����ؾ��ϴ� ������ ������ų �ڱ����� �����մϴ�. �켱 ������ ����, ����, ����, �����̵˴ϴ�. Bender�� �ι��� I�� �����ϸ� �켱 ������ ���� ���� (SOUTH, EAST, NORTH, WEST)�� �缳���˴ϴ�.
7. ������ ���� ��θ� ���� ���ָ� �� �� �߰� �� �� �ֽ��ϴ� (�������� B). �׷��� �׿��� �����ְ� "���ܱ�"���� �� �� �ֽ��ϴ�. Breaker ���� Bender�� ĳ���� X (��ֹ� X ��)�� ��Ÿ���� ��ֹ��� �ı��ϰ� �ڵ����� �����ŵ�ϴ�. ��ֹ��� �ļյǸ� ���������� �����ǰ� Bender�� ������ �����մϴ�. Bender�� Breaker ��忡 �ְ� ���ָ� �ٽ� ����ϸ� ��� Baker ��忡�� ���� ���ɴϴ�. Bender�� ������ �Ŀ��� ���ִ� �״�� ���� �ֽ��ϴ�.
8.2 �ڷ� ���� T�� �ó������� ���ִ�. ������ �ڷ� ���͸� ����ϸ� �ڵ����� �ٸ� �ڷ� ������ ��ġ�� �ڷ���Ʈ�Ǹ� ���� �� �극��Ŀ ��� �Ӽ��� �״�� �����˴ϴ�.
9. ���������� ���� ���ڴ������� �� �����Դϴ� (������ ������ �� �̿��� Ư�� ���� ����).

���α׷��� Bender�� �Է� �������� ���� �̵� ������ ǥ���ؾ��մϴ�.

������ �� (L)�� �� (C)�� �����ϴ�. ������ �������� �׻� ������ �ʴ� # ��ֹ��Դϴ�. �������� �׻� ����� @�� �ڻ� �ν� $�� �ֽ��ϴ�.

Bender�� ���� ������ ���� �ڻ� �ν��� ������ ������ ��� ���α׷��� LOOP �� ǥ�õǾ���մϴ�.
�κ��� ������ �ֿ켱���� �� �������� $ ��ֹ��� #,X�� ǥ���Ѵ�
��ֹ��� ������ ���� �켱�������� 1.�� 2.�� 3.�� 4.�� <<�׸��� ���� �������ΰ�
�׸��� ���ٰ� Ư�� WESN)�� �߰��ϸ� �ش� ��ȣ�� �´� �������ΰ��Ե�
ȸ�� �ι��Ͷ�°� (I)�ִµ� ������ ���� �켱������ ������ �� 1.�� 2.�� 3.�� 4.�� �ٽ�I�� ������ ������
7.��θ� ���� ����(B)�� � �߰��� �� �ִµ� �̰�� 'X'��ֹ��� ���� �ı��� ���� B�� �ٽ� ������ ��尡 �������ȴ�
8 T�� �ִµ� ����� ����ٸ� T�� �̵��ϰ� B�Ӽ��� �״�� ������
����� �κ��� @~$�� ������ ������ Ŀ�ǵ���
���� ������ ���Ѵٸ� LOOP�� ǥ����
������ �������
*/
class Solution
{
    static void Main(string[] args)
    {
        int count = 0;
        string[] inputs = Console.ReadLine().Split(' ');        
        int L = int.Parse(inputs[0]);//����
        int C = int.Parse(inputs[1]);//����
        char[,] map = new char[L,C];
        Tuple<int,int> endCursor = new Tuple<int,int>(0,0);// = new Tuple<int,int>();
        Tuple<int,int> robot = new Tuple<int,int>(0,0);
        bool powermode = false;
        bool reverse = false;
        for (int i = 0; i < L; i++)
        {            
            string row = Console.ReadLine();//�ʱ���
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

//����� �ݺ������� ����ϰԵɰ�
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
//                Console.Error.WriteLine("��");
                powermode = !powermode;
            }
            if(map[y,x] == 'I')
            {//South�ϴ��� ��� �ؾ��� �� numDir�� �ٲ��� �ʰ� � ���� �߰��ǰ� ���Ǵ½�?
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