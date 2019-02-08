using System;
using System.IO;

namespace task2 {
    class MainClass {
        public static void Main(string[] args) {
            FileStream fs = new FileStream(@"/Users/marcus/Documents/Week2/lab2/task2/task2/input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string text = sr.ReadLine();
            string primes = "";
            string[] parts = text.Split();
            foreach (string x in parts) {
                int t = int.Parse(x);
                int cnt = 0;
                for(int i = 1; i <= t; i++) {
                    if (t % i == 0) {
                        cnt++;
                    }
                }
                if (cnt < 3 && t!=1) {
                    primes += t + " ";
                }
            }
            sr.Close();
            fs.Close();
            FileStream fs2 = new FileStream(@"/Users/marcus/Documents/Week2/lab2/task2/task2/output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            sw.WriteLine(primes);
            sw.Close();
            fs2.Close();
        }
    }
}
