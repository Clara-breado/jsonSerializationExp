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
public class DeserializationBenchmarks
{
    private List<Person> _people = new();
    string _peopleText = "f";

    [GlobalSetup]
    public void Setup()
    {
        Faker<Person> faker = new();
        Randomizer.Seed = new Random(777);
        _people = faker
            .RuleFor(x => x.FirstName, x => x.Name.FirstName())
            .RuleFor(x => x.LastName, x => x.Name.LastName())
            .Generate(1000);
        _peopleText = JsonConvert.SerializeObject(_people);
    }

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public List<Person>? CurrenDeserializer()
    {
        return JsonConvert.DeserializeObject<List<Person>>(_peopleText);
    }

    [BenchmarkCategory("String"), Benchmark]
    public List<Person>? ClassicDeSerializer()
    {
        return JsonSerializer.Deserialize<List<Person>>(_peopleText)!;
    }

    [BenchmarkCategory("String"), Benchmark]
    public List<Person>? GeneratedDeserializer()
    {
        return JsonSerializer.Deserialize(
            _peopleText, typeof(IEnumerable<Person>), PersonJsonContext.Default)
            as List<Person>;
    }

    [BenchmarkCategory("String"), Benchmark]
    public List<Person>? GenerateMetadataDeserializer()
    {
        return JsonSerializer.Deserialize(
            _peopleText, typeof(IEnumerable<Person>), MetaDataPersonJsonContext.Default)
            as List<Person>;
    }

    [BenchmarkCategory("String"), Benchmark]
    public List<Person>? GeneratedSerializationDeserializer()
    {
        return JsonSerializer.Deserialize(
            _peopleText, typeof(IEnumerable<Person>), SerializationPersonJsonContext.Default)
            as List<Person>;
    }
}