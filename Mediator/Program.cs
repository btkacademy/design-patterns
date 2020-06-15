using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator);
            mediator.Teacher = teacher;

            Student student = new Student(mediator);
            student.Name = "Leyla";

            Student student2 = new Student(mediator);
            student2.Name = "Ayşe";

            mediator.Students = new List<Student>()
            {
                student,
                student2
            };

            teacher.SendNewImageUrl("yeni resim urlsi");

            teacher.ReceiveQuestion("Doğru mu", student);
            student2.ReceiveAnswer("Doğru");

            Console.ReadKey();
        }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;
        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator) { }
        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine(string.Format("Soru={0} Soran={1}", question, student.Name));
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Öğretmen slaytı değiştirdi.Url:" + url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Öğretmen soruyu cevapladı.Öğrenci:" + student.Name);
            Mediator.SendAnswer(answer, student);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator) { }
        public string Name { get; set; }
        public void ReceiveImage(string url)
        {
            Console.WriteLine("Öğrenci resmi aldı url:" + url);
        }
        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Öğrenci alınan cevap:" + answer);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }
        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }
        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}
