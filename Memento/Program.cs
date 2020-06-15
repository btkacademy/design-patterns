using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book()
            {
                Isbn = "12345",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "54321";
            book.Title = "SEFİLLER";
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

            Console.ReadKey();
        }
    }
    class Book
    {
        string _title, _author, _isbn;
        DateTime _lastEdited;
        public string Title { get { return _title; } set { _title = value; SetLastEdited(); } }
        public string Author { get { return _author; } set { _author = value; SetLastEdited(); } }
        public string Isbn { get { return _isbn; } set { _isbn = value; SetLastEdited(); } }
        void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }
        public Memonto CreateUndo()
        {
            return new Memonto(_isbn, _title, _author, _lastEdited);
        }
        public void RestoreFromUndo(Memonto memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2}, edited : {3}",Isbn,Title,Author,_lastEdited);
        }
    }
    class Memonto
    {
        public string Title { get; set;  }
        public string Author { get; set;  }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }
        public Memonto(string isbn,string title,string author,DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }
    class CareTaker
    {
        public Memonto Memento { get; set; }
    }
}
