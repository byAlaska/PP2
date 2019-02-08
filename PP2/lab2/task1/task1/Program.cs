using System;

using System.IO;

namespace task1 {
    class MainClass {
        public static void Main(string[] args) {
            FileStream fs = new FileStream(@"/Users/marcus/Documents/Week2/lab2/task1/task1/text6.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
             string s = sr.ReadToEnd();
             bool b = false;
             fs.Close();
             sr.Close();

            Console.WriteLine(s);

            for(int i = 0; i < s.Length; i++) {
                if (s[i] != s[s.Length - 1 - i]) {
                    b = false;
                    break;
                } else {
                    b = true;
                }
            }
            if (b) {
                Console.WriteLine("Yes");
            } else {
                Console.WriteLine("No");
            }
        }
    }
}
