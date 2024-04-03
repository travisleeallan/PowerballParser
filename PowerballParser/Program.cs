using System;
using System.IO;
using System.Collections.Generic;


namespace PowerballParser {

    public class PowerballParser 
    {
        public static List<String> Lines = new List<string> {};
        public static List<String> LinesShort = new List<string> {};
        public static Dictionary<Int32,String> KeyValuePairs = new Dictionary<Int32,String>();
        public static void PrintLines()
        {
            foreach (string line in LinesShort)
            {
                Console.WriteLine(line);
            }
        }

        public static void CleanData()
        {
            foreach (string line in Lines)
            {
                int comma_count = 0;
                for (int i=0; i<line.Length; i++)
                {
                    if (line[i] == ',')
                    {
                        comma_count++;
                        if (comma_count == 4)
                        {
                            LinesShort.Add(line.Substring(i+1));
                        }
                    }
                }
            }
        }


        static void Main()
        {
        
            String? line;
            try 
            {
                StreamReader sr = new StreamReader("powerball.csv");
                line = sr.ReadLine();

                while (line != null)
                {
                    Lines.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();

                CleanData();
                PrintLines();

            
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Program Complete");
            }
        }
    }

}
