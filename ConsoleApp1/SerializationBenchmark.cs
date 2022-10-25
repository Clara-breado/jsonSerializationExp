using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Bogus;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.Azure.Cosmos;
using System.Text;

namespace ConsoleApp1;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class SerializationBenchmarks
{
    private List<Person> _people = new();

    [GlobalSetup]
    public void Setup()
    {
        Faker<Person> faker = new();
        Randomizer.Seed = new Random(777);
        _people = faker
            .RuleFor(x => x.FirstName, x => x.Name.FirstName())
            .RuleFor(x => x.LastName, x => x.Name.LastName())
            .Generate(10);
    }

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public string CurrenSerializer()
    {
        var str = JsonConvert.SerializeObject(_people);
        return str;
    }

    [BenchmarkCategory("String"), Benchmark]
    public string ClassicSerializer()
    {
        string jsonStr = JsonSerializer.Serialize(_people);
        return jsonStr;
    }

    [BenchmarkCategory("String"), Benchmark]
    public string GeneratedDefaultSerializer()
    {
        string jsonStr = JsonSerializer.Serialize(_people, PersonJsonContext.Default.IEnumerablePerson);
        return jsonStr;
    }

    [BenchmarkCategory("String"), Benchmark]
    public string GenerateMetadataSerializer()
    {
        string jsonStr = JsonSerializer.Serialize(_people, MetaDataPersonJsonContext.Default.IEnumerablePerson);
        return jsonStr;
    }

    [BenchmarkCategory("String"), Benchmark]
    public string GenerateSerializationSerializer()
    {
        string jsonStr = JsonSerializer.Serialize(_people, SerializationPersonJsonContext.Default.IEnumerablePerson);
        return jsonStr;
    }
}