using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace task1 {

    [Serializable]
    class Complex {
        public string a;
        public string b;
        public Complex(string a, string b) {
            this.a = a;
            this.b = b;
        }
        public string s;
        public void Comp() {
            s = " " + a + " + " + b + "i";
        }
        override
            public string ToString() {
            return s;
        }
    }
    class MainClass {
        public static void Ser() {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Complex complex = new Complex(a, b);
            complex.Comp();
            FileStream fs = new FileStream("Complex.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, complex);
            fs.Close();
        }

        public static void DeSer() {
            FileStream fs = new FileStream("Complex.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Complex complex = bf.Deserialize(fs) as Complex;
            Console.WriteLine(complex);
        }

        public static void Main(string[] args) {
            Ser();
            DeSer();
        }
    }
}
