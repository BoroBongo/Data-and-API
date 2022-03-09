
// See https://aka.ms/new-console-template for more information
using LambdaApp;

Console.WriteLine("Hello, World!");

List<int> nums = new List<int>() { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

var count = nums.Count(n=>n%2==0);

//count even ints

////var countEven = 0;

////foreach (var num in nums)
////{
////    if(num%2==0) countEven++;
////}

//var allEven = from number in nums
//                where number % 2 == 0
//                select number;

Console.WriteLine(count);

List<Person> people = new List<Person>()
{
    new Person {Name = "Cathy", Age = 40},
    new Person {Name ="Nish", Age = 55},
    new Person {Name ="Martin", Age = 20}
};

int ageAbove25 = people.Count(n=>n.Age>25);

Console.WriteLine(ageAbove25);


