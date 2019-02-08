using System;

namespace task2 {
    class Student {
        private string name;
        private int id;
        private int yos = 1;
        public Student(string name,int id) {
            this.name = name;
            this.id = id;
        }
        public int getId() {
            return id;
        }
        public string getName() {
            return name;
        }
        public void setName(string name) {
            this.name = name;
        }
        public void setId(int id) {
            this.id = id;
        }

        public void IncYos() {
            yos++;
        }
        public int getYos() {
            return yos;
        }
        //public string toString() {
        //    return "Name: " + name + ", ID: " + id + ", Years od study: " + yos + "\n"; 
        //}

        class MainClass {
        public static void Main(string[] args) {
                //Student s1 = new Student("Elibay", 111222);
                //s1.IncYos();
                //Student s2 = new Student("BIba", 08);
                //Console.WriteLine(s2.toString());
                //Console.WriteLine(s1.toString());
            }
        }
    }
}
