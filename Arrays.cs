using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    class Program
    {
        static void Main()
        {

            // Arrays Array and LINQ methods

            int[] numbers = new int[] { 6, 9, 13, 0, 4, 32, 89, 15, 1, 13, 45 };
            int[] oddNumbers = new int[] { 3, 7, 11, 9, 45, 13 };
            Array.Sort(numbers);
            Array.Reverse(numbers);
            Array.BinarySearch(numbers, 9);
            Array.ForEach(numbers, n => Console.WriteLine(n));

            var max = numbers.Max();
            var sum = numbers.Sum();
            var avg = numbers.Average();
            int first = numbers.First(n => n > 20);
            Console.WriteLine("Max: {0}, Sum: {1}, Average: {2}, Greater that 20: {3}", max, sum, avg, first);


            // Coma separated string from array
            var str = String.Join(", ", numbers);
            Console.WriteLine("String from array: {0}", str);

            //Removing duplicate values from the array
            int[] nums = { 0, 3, 5, 1, 3 };
            int[] dist = nums.Distinct().ToArray();

            //Removing duplicates from the object array
            Person[] people =
            {
                new Person() { FirstName = "Bruce", LastName = "Wayne"},
                new Person() { FirstName = "Walter", LastName = "White"},
                new Person() { FirstName = "Bruce", LastName = "Wayne"}
            };

            var diff = people.Distinct(new PersonNameComparer()).ToArray();
            foreach(var d in diff)
            {
                Console.WriteLine("{0} {1}", d.FirstName, d.LastName);
            }

            // Searching for common values in two arrays
            IEnumerable<int> common = numbers.Intersect(oddNumbers);
            common.ToList().ForEach(c => Console.WriteLine(c));


            // Passing array as an argument to a method
            UpdateArray(oddNumbers);
            Console.WriteLine("\n Updated array: ");
            foreach(var odd in oddNumbers)
            {
                Console.WriteLine(odd);
            }

			Console.ReadKey();
		}

        public static void UpdateArray(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * 2;
            }
        }

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class PersonNameComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            { 
                    return x.FirstName == y.FirstName && x.LastName == y.LastName;  
            }

            public int GetHashCode(Person obj)
            {
                return (obj.FirstName == null ? 0 : obj.FirstName.GetHashCode()) ^ (obj.LastName == null ? 0 : obj.LastName.GetHashCode());
            }
        }
    }
}
