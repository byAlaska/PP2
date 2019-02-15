using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace task1 {

    class Layer {
        public List<FileSystemInfo> Content;
        public int SelectedItem;
        public List<FileSystemInfo> getContent() {
            return Content;
        }
        public void SetContent(List<FileSystemInfo> Content) {
            this.Content = Content;
        }
        public int GetSelectedItem() {
            return SelectedItem;
        }
        public void SetSelectedItem(int SelectedItem) {
            if (SelectedItem < 0) {
                this.SelectedItem = Content.Count - 1;
            } else if (SelectedItem >= Content.Count) {
                this.SelectedItem = 0;
            } else {
                this.SelectedItem = SelectedItem;
            }
        }
        public Layer(List<FileSystemInfo> Content, int Si) {
            this.Content = Content;
            SelectedItem = Si;
        }
        public void Draw() {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            int x = 1;
            for (int i = 0; i < Content.Count; i++) {
                if (Content[i] is DirectoryInfo) {
                    if (i == SelectedItem) {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    } else {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(x + ". " + Content[i].Name);
                    x++;
                }
            }
            for (int i = 0; i < Content.Count; i++) {
                if (Content[i] is FileInfo) {
                    if (i == SelectedItem) {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    } else {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(x + ". " + Content[i].Name);
                    x++;
                }
            }
        }
        public void Rename() {
            if(Content[SelectedItem] is DirectoryInfo) {
                Console.WriteLine();
                Console.WriteLine("WRITE NEW NAME FOR FOLDER PLS");
                string s = Console.ReadLine();
                DirectoryInfo di = Content[SelectedItem] as DirectoryInfo;
                di.MoveTo(s);
            } else {
                Console.WriteLine();
                Console.WriteLine("WRITE NEW NAME FOR SILE PLS");
                string s = Console.ReadLine();
                FileInfo fi = Content[SelectedItem] as FileInfo;
                fi.MoveTo(s);
            }
        }
    }
    enum FarMode {
        FileView,
        DirectoryView
    }   
    class MainClass {
        public static void Main(string[] args) {
            DirectoryInfo root = new DirectoryInfo(@"/Users/marcus/Documents/keygit/PP2/PP2/lab3/test");
            Stack<Layer> layer = new Stack<Layer>();
            FarMode farMode = FarMode.DirectoryView;
            List<FileSystemInfo> fsi1 = root.GetFileSystemInfos().ToList();
            layer.Push(new Layer(fsi1, 0));
            while (true) {
                if(farMode == FarMode.DirectoryView) {
                    layer.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key) {
                    case ConsoleKey.UpArrow:
                        if (layer.Peek().SelectedItem < 0) {
                            layer.Peek().SelectedItem = layer.Peek().Content.Count - 1;
                        }else if(layer.Peek().SelectedItem >= layer.Peek().Content.Count) {
                            layer.Peek().SelectedItem = 0;
                        } else {
                            layer.Peek().SelectedItem--;
                        }
                        layer.Peek().Draw();
                        break;
                    case ConsoleKey.DownArrow:
                        if (layer.Peek().SelectedItem < 0) {
                            layer.Peek().SelectedItem = layer.Peek().Content.Count - 1;
                        } else if (layer.Peek().SelectedItem >= layer.Peek().Content.Count) {
                            layer.Peek().SelectedItem = 0;
                        } else {
                            layer.Peek().SelectedItem++;
                        }
                        layer.Peek().Draw();
                        break;
                    case ConsoleKey.Backspace:
                        if (farMode == FarMode.DirectoryView) { layer.Pop();
                            layer.Peek().SelectedItem = 0;
                            layer.Peek().Draw();
                        } else {
                            farMode = FarMode.DirectoryView;
                            layer.Peek().SelectedItem = 0;
                            layer.Peek().Draw();
                        }
                        break;
                    case ConsoleKey.Enter:
                        int x = layer.Peek().SelectedItem;
                        FileSystemInfo fsi = layer.Peek().Content[x];
                        if(fsi is DirectoryInfo) {
                            farMode = FarMode.DirectoryView;
                            DirectoryInfo d = fsi as DirectoryInfo;
                            layer.Push(new Layer(d.GetFileSystemInfos().ToList(), 0));
                            layer.Peek().Draw();
                        } else {
                            farMode = FarMode.FileView;
                            FileInfo file = fsi as FileInfo;
                            FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                            StreamReader sr = new StreamReader(fs);
                            string s = sr.ReadToEnd();
                            Console.Clear();
                            Console.Write(s);
                            fs.Close();
                            sr.Close();
                        }
                        break;
                    case ConsoleKey.D:
                        int f = layer.Peek().SelectedItem;
                        FileSystemInfo fsi2 = layer.Peek().Content[f];
                        if (fsi2 is FileInfo) {
                            layer.Peek().Content[f].Delete();
                            layer.Peek().Content = ((FileInfo)fsi2).Directory.GetFileSystemInfos().ToList();

                        } else {
                            DirectoryInfo di2 = fsi2 as DirectoryInfo; 
                            layer.Peek().Content[f].Delete();
                            layer.Peek().Content = di2.Parent.GetFileSystemInfos().ToList();

                        }
                        layer.Peek().SelectedItem--;
                        layer.Peek().Draw();
                        break;
                    case ConsoleKey.R:
                        layer.Peek().Draw();
                        layer.Peek().Rename();
                        layer.Peek().Draw();
                        break;
                }
            }
        }
    }
}
