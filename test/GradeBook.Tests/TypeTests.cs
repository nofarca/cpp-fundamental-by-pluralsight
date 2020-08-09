using System;
using Xunit;

namespace GradeBook.Tests
{
      //delegate message point to different fun to write message to filr q console
        public delegate string WriteLogDelegate (string logMessage);

    public class TypeTests
    {      
        int count =0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod(){
            
            // WriteLogDelegate log 
            //log = new WriteLogDelegate(ReturnMessage);
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello!"); 
            Assert.Equal(result,"Hello!");
            Assert.Equal(3,count);
        }

        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage (string message){
            return message;
        }



        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);

        }

        private void SetInt(ref Int32 z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetName(out InMemoryBook book, string name)
        {
            //ref out 
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");

            SetName(book1, "newName");
            Assert.Equal("Book 1", book1.Name);

        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.Equal("Book 1", book1.Name);

        }

        //    public void StringBehaveLikeValueTypes()
        // {
        //     string name="Nofar";
        //     var upper=name.makeUppercase(name);
        //     var book1 = GetBook("Book 1");

        //     book1 = GetBookSetName(book1, "New Name");
        //     Assert.Equal("New Name", book1.Name);

        // }

        public InMemoryBook GetBookSetName(InMemoryBook book, string newName)
        {
            book.Name = newName;
            return book;
        }

        public void SetName(InMemoryBook book, string newName) => book.Name = newName;

        [Fact]
        public void GetBookReturnsDifferentObkects()
        {
            //aarange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotEqual(book1.Name, book2.Name);
            Assert.NotSame(book1, book2);

        }

        public void TwoVarsCanReferenceSameObject()
        {
            //aarange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));

        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);

        }
    }
}
