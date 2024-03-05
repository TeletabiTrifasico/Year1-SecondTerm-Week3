namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
        void Start()
        {
            List<Course> gradelist = new List<Course>();
            gradelist = ReadGradeList(3);
            DisplayGradeList(gradelist);

        }
        PracticalGrade ReadPracticalGrade(string question)
        {
            PracticalGrade practicalGrade = new PracticalGrade();
            DisplayPracticalGrade(practicalGrade);
            Console.Write(question);  
            int input = Convert.ToInt32(Console.ReadLine());
            practicalGrade = (PracticalGrade)input;
            return practicalGrade;
        }
        void DisplayPracticalGrade(PracticalGrade practical)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{i}. {(PracticalGrade)i} ");
            }
            Console.WriteLine();
        }
        Course ReadCourse(string question)
        {
            Course course = new Course();
            Console.WriteLine(question);
            Console.Write("Name of the course: ");
            course.Name = Console.ReadLine();
            Console.Write($"Theory grade for {course.Name}: ");
            course.TheoryGrade = Convert.ToInt32(Console.ReadLine());
            course.PracticalGrade = ReadPracticalGrade($"Practical grade for {course.Name}: ");
            return course;
        }
        void DisplayCourse(Course course)
        {
            Console.WriteLine($"{course.Name} : {course.TheoryGrade} {course.PracticalGrade}");
        }
        int CountRetakes(Course course)
        {
            return 1;
        }
        List<Course> ReadGradeList(int nrOfCourses)
        {
            List<Course> gradeList = new List<Course>();
            for (int i = 0; i < nrOfCourses; i++)
            {
                gradeList.Add(ReadCourse("Enter a course."));
            }
            return gradeList;
        }
        void DisplayGradeList(List<Course> gradeList)
        {
            int cumlaude = 0;
            int retakes = 0;
            int courses = 0;
            foreach (Course course in gradeList)
            {
                courses++;
                DisplayCourse(course);
                if (!course.Passed())
                {
                    retakes++;
                }
                else
                if (course.CumLaude())
                {
                    cumlaude++;
                }
            }
            if (retakes > 0)
            {
                Console.WriteLine($"Too bad, you did not graduate, you got {retakes} retakes.");
            }
            else
            {
                if (cumlaude == courses)
                {
                    Console.WriteLine("Congratulations, you graduated Cum Laude!");
                }
                else
                {
                    Console.WriteLine("Congratulations, you graduated!");
                }
            }
        }
    }
}