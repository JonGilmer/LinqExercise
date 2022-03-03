using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {

            //Print the Sum and Average of numbers
            Console.WriteLine("Sum:");
            var sum = numbers.Sum();
            Console.WriteLine(sum);

            Console.WriteLine("\nAverage:");
            var avg = numbers.Average();
            Console.WriteLine(avg);

            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("\nAscending");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.Write($"{x}\t"));

            Console.WriteLine("\n\nDescending");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.Write($"{x}\t"));

            //Print to the console only the numbers greater than 6
            Console.WriteLine("\n\nNumbers Greater Than 6:");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.Write($"{x}\t"));

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("\n\nOnly Print 4 Numbers:");
            numbers.OrderByDescending(x => x).Take(4).ToList().ForEach(x => Console.Write($"{x}\t"));

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("\n\nChange index 4 to age, then order in descending:");
            numbers[3] = 27;
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.Write($"{x}\t"));

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("\n\nOrder names by C and S:");
            employees.Where(x => x.FirstName[0] == 'C' || x.FirstName[0] == 'S').OrderBy(x => x.FirstName).ToList().ForEach(x =>
            {
                Console.Write(x.FirstName);
                Console.Write($" {x.LastName}\n");
            });

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("\nEmployees over age of 26 by full name:");
            employees.Where(x => x.Age >= 26).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList().ForEach(x =>
            {
                Console.Write($"{x.FullName}\t");
                Console.Write($"Age: {x.Age}\n");
            });


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var over10YOE_over35Age = employees.Where(x => x.Age > 35 && x.YearsOfExperience <= 10);
            var answerSum = over10YOE_over35Age.Sum(x => x.YearsOfExperience);

            Console.WriteLine($"\nSum of employees Years of Experience if YOE is <= 10\nand Age is greater than 35:\n{answerSum}");
            var answerAverage = over10YOE_over35Age.Average(x => x.YearsOfExperience);
            Console.WriteLine($"Average:\n{answerAverage}");

            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("\n--------New List of Employees--------");
            employees.Append(new Employee("Marcus", "Fenix", 36, 10)).ToList().ForEach(x =>
                Console.WriteLine($"{x.FullName}\t{x.Age}\t{x.YearsOfExperience}"));

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
