{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // 노드의 수(0,1,2,3저 원모양 저거, 적의위치도 가능
        int L = int.Parse(inputs[1]); // 총 링크갯수(빨간 저거)
        int E = int.Parse(inputs[2]); // 나갈수 있는 게이트웨이(파란거)의 수
        int[] gates = new int[E];
        int[,] link= new int[L,2];
        int curGate = 0;
        
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            link[i,0] = N1;
            link[i,1] = N2;
            //n1과 n2는 둘사이를 연결해주는 선을뜻함
        }
        for (int i = 0; i < E; i++)
        {
//            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gates[i] = int.Parse(Console.ReadLine());
            //게이트웨이 노드임
        }

/* 구상 : 적의 위치가 어디인지를 확인하고,해당위치에서 접근이 가능한 노드가 있다면
//그노드를 못쓰게 만드는게 정답일거라고봄
            //거기에 더나아가 다음길로 못가도록 막아내야하는듯(임시)

*/
        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
            string blockCode = "";
            int matchGate = 501;
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

//Gate를 위주로 돌리다가 해당위치가 SI있다면 걔를 잡는느낌으로            
//바이러스를 위주로
                for(int i = 0; i <L; i++)
                {

                    if(link[i, 0] == SI || link[i,1] == SI )
                    {
                            blockCode = link[i,0].ToString() + " " + link[i,1].ToString();
                            for(int j = 0; j <E; j++)
                            {
                                if(link[i,1] == gates[j] || link[i,0] == gates[j])
                                {
                                    matchGate = gates[j];
                                    break;                                    
                                }

                            }
                            if(link[i, 1] == matchGate || link[i,0] == matchGate)
                            break;//나가게해서 현재에서 더이상 못그리게 하는게 핵심
                    }
                    
                }
                Console.WriteLine(blockCode);
      
        }
    }
}