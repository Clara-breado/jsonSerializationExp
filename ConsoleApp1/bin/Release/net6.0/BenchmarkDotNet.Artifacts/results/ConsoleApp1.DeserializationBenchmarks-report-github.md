``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.674)
Intel Core i9-10900X CPU 3.70GHz, 1 CPU, 20 logical and 10 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2

Categories=String  

```
|                             Method |     Mean |   Error |  StdDev | Ratio | RatioSD |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
|----------------------------------- |---------:|--------:|--------:|------:|--------:|--------:|-------:|----------:|------------:|
|                 CurrenDeserializer | 539.7 μs | 9.59 μs | 8.50 μs |  1.00 |    0.00 | 11.7188 | 3.9063 |  125761 B |        1.00 |
|                ClassicDeSerializer | 350.4 μs | 6.23 μs | 5.83 μs |  0.65 |    0.01 | 12.2070 | 3.9063 |  123432 B |        0.98 |
|              GeneratedDeserializer | 353.2 μs | 3.62 μs | 2.83 μs |  0.66 |    0.01 | 12.2070 | 3.9063 |  123432 B |        0.98 |
|       GenerateMetadataDeserializer | 346.5 μs | 6.68 μs | 7.15 μs |  0.64 |    0.02 | 12.2070 | 3.9063 |  123432 B |        0.98 |
| GeneratedSerializationDeserializer |       NA |      NA |      NA |     ? |       ? |       - |      - |         - |           ? |

Benchmarks with issues:
  DeserializationBenchmarks.GeneratedSerializationDeserializer: DefaultJob
