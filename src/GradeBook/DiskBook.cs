using System;
using System.IO;
namespace GradeBook
{
    public class DiskBook : Book
    {
        //File fileName= new FileAccess(3);


        public DiskBook(string name) : base(name)
        {
           
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
             using (var writer = File.AppendText($"{Name}.txt"))
             {
                 writer.WriteLine(grade);
                 if (GradeAdded != null)
                 {
                     GradeAdded(this, new EventArgs());
                 }
             }//using statment is for garbeg collector           writer.Close();
            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(double.Parse(line));
                    line= reader.ReadLine();
                }
            }//using is for closing file

            return result;
        }
    }
}