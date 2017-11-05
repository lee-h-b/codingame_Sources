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
MIME 유형은 다양한 인터넷 프로토콜에서 미디어 유형 (HTML, 이미지, 비디오 ...)을 전송 된 컨텐츠와 연관시키는 데 사용됩니다. MIME 형식은 일반적으로 전송할 파일의 확장자에서 유추됩니다.

이름을 기반으로 파일의 MIME 형식을 검색 할 수있는 프로그램을 작성해야합니다.

규칙
MIME 유형을 파일 확장자와 연관시키는 테이블이 제공됩니다. 전송할 파일의 이름 목록이 제공되며이 파일 각각에 대해 사용할 MIME 유형을 찾아야합니다.

파일의 확장자는 파일 이름 내에서 점 문자의 마지막 발생 (있는 경우) 다음에 오는 부속 문자열로 정의됩니다.
지정된 파일의 확장자가 연결 테이블에서 발견 될 수있는 경우 (대소 문자를 구별하지 않음, 예를 들어 TXT가 txt와 동일한 방식으로 처리됨) 해당 MIME 유형을 인쇄하십시오. 파일에 해당하는 MIME 유형을 찾을 수 없거나 파일에 확장자가없는 경우 UNKNOWN을 인쇄하십시오.
*/