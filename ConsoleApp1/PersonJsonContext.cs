using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [JsonSerializable(typeof(IEnumerable<Person>))]
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
    public partial class PersonJsonContext : JsonSerializerContext
    {

    }
}
