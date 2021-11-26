using ConsoleApp1;
using static System.Console;

Student s1 = new(1, "jon");
Student s2 = new(1, "jon");
WriteLine(s1);
WriteLine(s2);
WriteLine(s1 == s2);

WriteLine();

Person p1 = new(1, "jon");
Person p2 = new(1, "jon");
WriteLine(p1);
WriteLine(p2);
WriteLine(p1 == p2);

namespace ConsoleApp1
{
    class Student : IEquatable<Student>
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual bool Equals(Student? anotherStudent)
        {
            if (anotherStudent is null) return false;
            object obj = anotherStudent;
            return Equals(obj);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Student anotherStudent) return false;
            return Id == anotherStudent.Id && Name == anotherStudent.Name;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"Student {{ Id: {Id}, Name: {Name} }}";

        public static bool operator ==(Student firstStudent, Student secondStudent) =>
            firstStudent.Id == secondStudent.Id && firstStudent.Name == secondStudent.Name;

        public static bool operator !=(Student firstStudent, Student secondStudent) =>
            firstStudent.Id != secondStudent.Id || firstStudent.Name != secondStudent.Name;
    }

    record Person(int Id, string Name);
}


/*
Output

Student { Id: 1, Name: jon }
Student { Id: 1, Name: jon }
True

Person { Id = 1, Name = jon }
Person { Id = 1, Name = jon }
True
*/