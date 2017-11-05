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
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
//        string[,] extension = new string[N,2];
        Dictionary<string, string> extension = new Dictionary<string, string>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            extension.Add(inputs[0].ToUpper(),inputs[1]);
//            extension[i,0] = inputs[0].ToUpper(); // file extension
  //          extension[i,1] = inputs[1]; // MIME type.

        }
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine(); // One file name per line.
//                        Console.WriteLine(FNAME);
            
            string[] checker = FNAME.Split('.');  
            if(checker.Length <= 1)
            {
                        Console.WriteLine("UNKNOWN");
                        continue;
            }

                if(extension.ContainsKey(checker[checker.Length-1].ToUpper() ) )
                {
                    Console.WriteLine(extension[checker[checker.Length-1].ToUpper()] );
                    
                }
              else  Console.WriteLine("UNKNOWN") ;
            
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
    }
}

/*
MIME ������ �پ��� ���ͳ� �������ݿ��� �̵�� ���� (HTML, �̹���, ���� ...)�� ���� �� �������� ������Ű�� �� ���˴ϴ�. MIME ������ �Ϲ������� ������ ������ Ȯ���ڿ��� ���ߵ˴ϴ�.

�̸��� ������� ������ MIME ������ �˻� �� ���ִ� ���α׷��� �ۼ��ؾ��մϴ�.

��Ģ
MIME ������ ���� Ȯ���ڿ� ������Ű�� ���̺��� �����˴ϴ�. ������ ������ �̸� ����� �����Ǹ��� ���� ������ ���� ����� MIME ������ ã�ƾ��մϴ�.

������ Ȯ���ڴ� ���� �̸� ������ �� ������ ������ �߻� (�ִ� ���) ������ ���� �μ� ���ڿ��� ���ǵ˴ϴ�.
������ ������ Ȯ���ڰ� ���� ���̺��� �߰� �� ���ִ� ��� (��� ���ڸ� �������� ����, ���� ��� TXT�� txt�� ������ ������� ó����) �ش� MIME ������ �μ��Ͻʽÿ�. ���Ͽ� �ش��ϴ� MIME ������ ã�� �� ���ų� ���Ͽ� Ȯ���ڰ����� ��� UNKNOWN�� �μ��Ͻʽÿ�.
*/