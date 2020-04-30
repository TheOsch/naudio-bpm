using System;
using System.Text;

namespace NAudioBPM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("NAudio BPM demo");
            Console.WriteLine("Usage: NAudioBPM <Audio file path or URI> [<start(sec)> [<length(sec)>]]");
            if (args.Length == 0)
            {
                return;
            }
            string file = args[0];
            int start = 0, length = 0;
            if (args.Length > 1) Int32.TryParse(args[1], out start);
            if (args.Length > 2) Int32.TryParse(args[2], out length);

            BPMDetector bpmDetector = new BPMDetector(file, start, length);

            if (bpmDetector.Groups.Length > 0)
            {
                if (bpmDetector.Groups.Length > 1)
                {
                    Console.WriteLine("Other options are:");
                    for (int i = 1; i < bpmDetector.Groups.Length; ++i)
                    {
                        Console.WriteLine(String.Format("{0} BPM ({1} samples)", bpmDetector.Groups[0].Tempo, bpmDetector.Groups[0].Count));
                    }
                }
            }
        }
    }
}
