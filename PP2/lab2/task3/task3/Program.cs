using System;
using System.IO;

namespace task3 {
    class MainClass {
        public static void Main(string[] args) {
            DirectoryInfo di = new DirectoryInfo(@"/Users/marcus/Documents/FallSem");
            PrintToConsole(di, 0);
        }
        private static void PrintToConsole(FileSystemInfo fsi, int k) {
            string line = new string(' ', k);
            line = line + fsi.Name;
            Console.WriteLine(line);

            if (fsi is DirectoryInfo) {
                var items = (fsi as DirectoryInfo).GetFileSystemInfos();
                foreach (var i in items) {
                    PrintToConsole(i, k + 6);
                }
            }
        }
    }
}
