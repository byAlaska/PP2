using System;

namespace task1 {
    class MainClass {
        public static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine()); //вводим число n, размер массива
            int cnt = 0;
            string s = ""; //создаем s, что бы сохранить там prime numbers
            for(int i = 0; i < n; i++) {
                int x = int.Parse(Console.ReadLine()); // заполняем массив
                int cnt2 = 0;
                for(int j = 1; j <= Math.Sqrt(x); j++) {
                    if (x % j == 0) {
                        cnt2++;
                    }
                }
                if (cnt2 < 3) {
                    cnt++; // если число делить только на себя и на 1, то он prime number
                    s = s + x + " "; // сохраняем число 
                }
            }
            Console.WriteLine(cnt); // выводим количество prime numbers
            Console.WriteLine(s); // выводим самих prime numbers
        }
    }
}
