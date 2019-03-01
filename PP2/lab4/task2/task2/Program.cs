using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace task2 {
    [Serializable]
    class Mark {
        public int points;
        public Mark(int points) {
            this.points = points;
        }
        public string GetLetter() {
            if (points < 50 && points>-1) {
                return "F";
            }else if(points>49 && points< 60) {
                return "C-";
            }else if(points>59 && points < 70) {
                return "C";
            }else if(points>69 && points < 75) {
                return "C+";
            }else if(points>74 && points < 80) {
                return "B-";
            }else if(points>79 && points < 85) {
                return "B";
            }else if(points>84 && points < 90) {
                return "B+";
            }else if(points>89 && points < 95) {
                return "A-";
            } else {
                return "A";
            }
        }
        override
            public string ToString() {
            return GetLetter();
        }
    }
    class MainClass {
        public static void Ser() {
            List<Mark> marks = new List<Mark>();
            for (int i = 60; i < 96; i++) {
                marks.Add(new Mark(i));
            }
            FileStream fs = new FileStream("Mark.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, marks);
            fs.Close();
        }

        public static void DeSer() {
            List<Mark> marks = new List<Mark>();
            FileStream fs = new FileStream("Mark.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            marks = bf.Deserialize(fs) as List<Mark>;
            for(int i = 0; i < marks.Count; i++) {
                Console.WriteLine(marks[i]);
            }
            fs.Close();
        }
        public static void Main(string[] args) {
            Ser();
            DeSer();
        }
    }
}
