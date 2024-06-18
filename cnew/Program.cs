using System;
using Hellow;
using System.IO;
using QuickGraph;
using Microsoft.VisualBasic;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;


namespace Hello
{
    class CsvParser
    {
        static void Main(String[] args)
        {
            List<string> listA = new List<string>();
            List<string> listB = new();
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

                    List<string> classes = new List<string>();
                    for (int i = 3; i < values.Length; i++) {
                        classes.Add(values[i].Trim());
                    }
                    listC.Add(classes);
                }
            }
            AdjacencyGraph<string, Edge<string>> myGraph = new AdjacencyGraph<string, Edge<string>>();
            for(int i = 0; i<listB.Count; i++){
                //Console.WriteLine($"Student: {listB[i]} takes the following classes:");
                foreach(var className in listC[i]){
                    //Console.WriteLine(className);
                    if(className[0]=='\"'){
                        string x = className.Remove(0,1);
                        // Console.WriteLine(x);
                    }
                    
                    if(className[className.Length-1]=='\"'){
                        string x = className.Remove(className.Length-1);
                        //Console.WriteLine(x);
                    }
                    myGraph.AddVertex(className);
                    
                }
                for(int j = 0; j<listC[i].Count;j++ ){
                    for(int k = j+1; k<listC[i].Count; k++){
                        var edgemy = new Edge<string>(listC[i][j],listC[i][k]);
                    }
                }
            }
        }
    }
    public class FileDotEngine : IDotEngine
{    
    public string Run(GraphvizImageType imageType, string dot, string outputFileName)
    {
        using (StreamWriter writer = new StreamWriter(outputFileName))
        {
            writer.Write(dot);    
        }

        return System.IO.Path.GetFileName(outputFileName);
    }
}
}

 