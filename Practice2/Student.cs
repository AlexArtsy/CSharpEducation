using System;

namespace Practice2
{
	internal class Student
	{
		private string name;
		private int age;
		public Student(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		public void PrintStudentInfo()
		{
            Console.WriteLine($"��� ��������: {this.name}, ������� ��������: {this.age}");
        }
	}
}