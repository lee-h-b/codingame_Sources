{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // ����� ��(0,1,2,3�� ����� ����, ������ġ�� ����
        int L = int.Parse(inputs[1]); // �� ��ũ����(���� ����)
        int E = int.Parse(inputs[2]); // ������ �ִ� ����Ʈ����(�Ķ���)�� ��
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
            //n1�� n2�� �ѻ��̸� �������ִ� ��������
        }
        for (int i = 0; i < E; i++)
        {
//            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gates[i] = int.Parse(Console.ReadLine());
            //����Ʈ���� �����
        }

/* ���� : ���� ��ġ�� ��������� Ȯ���ϰ�,�ش���ġ���� ������ ������ ��尡 �ִٸ�
//�׳�带 ������ ����°� �����ϰŶ��
            //�ű⿡ �����ư� ������� �������� ���Ƴ����ϴµ�(�ӽ�)

*/
        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
            string blockCode = "";
            int matchGate = 501;
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

//Gate�� ���ַ� �����ٰ� �ش���ġ�� SI�ִٸ� �¸� ��´�������            
//���̷����� ���ַ�
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
                            break;//�������ؼ� ���翡�� ���̻� ���׸��� �ϴ°� �ٽ�
                    }
                    
                }
                Console.WriteLine(blockCode);
      
        }
    }
}