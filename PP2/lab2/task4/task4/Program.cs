using System;
using System.IO;

namespace task4 {
    class MainClass {
        public static void Main(string[] args) {
            string source = @"/Users/marcus/Documents/FallSem/PP1/text.txt";
            string destination = @"/Users/marcus/Documents/wallpapers/text.txt";
            File.Create(source);
            File.Copy(source,destination,true);
            File.Delete(source);
        }
    }
}
