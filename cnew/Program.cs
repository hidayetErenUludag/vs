using System;
using Hellow;
using System.IO;
using QuickGraph;
using Microsoft.VisualBasic;
namespace Hello
{
    class CsvParser
    {
        static void Main(String[] args)
        {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<List<string>> listC = new List<List<string>>();
            StreamReader reader;
            using(reader = new StreamReader(@"C:\Users\HP\Desktop\vs\cnew\students_with_classes.csv"))
            {   
                reader.ReadLine();
                while(!reader.EndOfStream){
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    string fullname = values[1] + " " +values[2];
                    listA.Add(values[0]);
                    listB.Add(fullname);

                    List<string> classes = new List<string>(values[3].Split(',').Select(s => s.Trim()));
                    listC.Add(classes);
                }
            }
            
            AdjacencyGraph<string, Edge<string>> myGraph = new AdjacencyGraph<string, Edge<string>>();
            for(int i = 0; i<listB.Count; i++){
                for(int j = 0; j<listC[i].Count; j++){
                    Console.WriteLine(listB[i]);
                    Console.WriteLine(listC[i][j]);
                }
            }


        }
    }
    class Grapher
    {
        
    }
    }

