using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate (object sender, EventArgs args);
    public class InMemoryBook:Book 
    {
        private string name;
        private List<double> grades;

        public string Name { get => name; set{ if(!String.IsNullOrEmpty(value)){name = value; }}}

        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name):base(name) 
        {
           grades = new List<double>();
            this.Name = name;
        }

    
        // public void AddLetterGrade(char letter)
        // {
        //     switch (letter)
        //     {
        //         case 'A':
        //             AddGrade(90);
        //             break;
        //         case 'B':
        //             AddGrade(80);
        //             break;
        //         case 'C':
        //             AddGrade(70);
        //             break;
        //         default:
        //             AddGrade(0);
        //             break;
        //     }

        // }
        public override void AddGrade(double _grade)
        {
            if (_grade >= 0 && _grade <= 100)
            {
                this.grades.Add(_grade);
                if (GradeAdded != null){
                    GradeAdded(this,new EventArgs());
                }
            }
            else {
                throw new ArgumentException($"Invalide {nameof(_grade)}");
            }

        }
        public override Statistics GetStatistics()
        {
            //var gardes = new List<double>() { 12.7, 10.3, 6.11, 4.1 };  //gardes.Add(56.1);    //var result = 0.0;
            var result = new Statistics();
           
            //var result.High  =       //var result.Low  = ;
            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }

    }
}