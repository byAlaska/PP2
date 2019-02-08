using System;

namespace task3 {
    class MainClass {
        public static int[] DoubledArray(int[] arr) { //наш метод 
            int[] arr2 = new int[arr.Length * 2]; //создаем новый массив, чей массив вдвое больше основного
            for(int i = 0; i < arr.Length; i++) {
                arr2[i * 2] = arr[i]; 
                arr2[(i * 2) + 1] = arr[i]; // вычислив нужные индексы, заполняем каждый элемент по два раза
            }
            return arr2; // возвращаем новый массив с doubled elemnts
        }
        public static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++) {
                arr[i] = int.Parse(Console.ReadLine()); // заполняем массив
            }
            int[] arr2 = DoubledArray(arr); // призываем и присваеваем полученный двойной массив на новый arr2
            for(int i = 0; i < arr2.Length; i++) {
                Console.Write(arr2[i] + " "); // выводим новый массив
            }
        }
        //0 -> 0 1
        //1 -> 2 3
        //2 -> 4 5
        //3 -> 6 7
    }
}
