using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook disckBook=new DiskBook("nofar interface grade book");
            var book = new InMemoryBook("Nofar's garde book");
            var bookNoMoreNull = new InMemoryBook("No More Null");
      
          

            //EnterGrades(book);
            //EnterGrades(disckBook);
            EnterGrades(bookNoMoreNull);
            //var stst= book.GetStatistics();
            //var stst= disckBook.GetStatistics();
            var stst= bookNoMoreNull.GetStatistics();

            Console.WriteLine($"For the Book named:\"{bookNoMoreNull.name}\"");
            Console.WriteLine($"The lowest grade is {stst.Low}");
            Console.WriteLine($"The highest grade is {stst.High}");
            Console.WriteLine($"The average grade is {stst.Average}");
            // Console.WriteLine($"The letter grade is {stst.Letter}");


        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");

                var input = Console.ReadLine();

                if (input != "q")
                {
                    try
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static void OnGradeAdded (object sender , EventArgs e)
        {
         Console.WriteLine("A grade was added"); 
        }
    }
}
