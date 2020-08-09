namespace GradeBook
{
    public abstract class Book : NameObject , IBook
    {
        protected Book(string name) : base(name)
        {
             this.name=Name;
        }

        public string name {get;set;}

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        //===

    }
}