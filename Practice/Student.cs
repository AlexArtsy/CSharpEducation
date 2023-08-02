namespace Practice
{
	public class Student
	{
		private string name;
		private int age;
		private double averageScore;
		public double AverageScore 
		{
			get
			{
				return averageScore;
			}
			set
			{
				if (value >= 0 && value <= 5) 
				{
					averageScore = value;
				}
			}
		}
		public Student(string name, int age)
		{
			this.name = name;
			this.age = age;
		}

		public void PrintStudentInfo()
		{
            Console.WriteLine($"Имя студента: {this.name}, возраст студента: {this.age}");
        }
	}
}