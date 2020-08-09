namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string name { get; }
        event GradeAddedDelegate GradeAdded;


    }
}