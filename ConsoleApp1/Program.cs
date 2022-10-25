
//using ConsoleApp1;
//using System.Text.Json;

//var person = new Person
//{
//    FirstName = "Ashe",
//    LastName = "H"
//};

//var ashleyHText = JsonSerializer.Serialize(person, PersonJsonContext.Default.Person);

//Console.WriteLine(ashleyHText);

using BenchmarkDotNet.Running;
using ConsoleApp1;

BenchmarkRunner.Run<SerializationBenchmarks>();
BenchmarkRunner.Run<DeserializationBenchmarks>();


