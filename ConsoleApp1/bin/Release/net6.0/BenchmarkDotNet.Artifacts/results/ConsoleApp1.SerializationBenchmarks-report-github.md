``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.674)
Intel Core i9-10900X CPU 3.70GHz, 1 CPU, 20 logical and 10 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2

Categories=String  

```
|                          Method |     Mean |     Error |    StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|-------------------------------- |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
|                CurrenSerializer | 3.893 μs | 0.0719 μs | 0.0637 μs |  1.00 |    0.00 | 0.2899 |    2.9 KB |        1.00 |
|               ClassicSerializer | 2.049 μs | 0.0402 μs | 0.0463 μs |  0.53 |    0.02 | 0.1373 |   1.38 KB |        0.47 |
|      GeneratedDefaultSerializer | 1.074 μs | 0.0171 μs | 0.0160 μs |  0.28 |    0.01 | 0.1087 |   1.08 KB |        0.37 |
|      GenerateMetadataSerializer | 2.196 μs | 0.0380 μs | 0.0355 μs |  0.56 |    0.01 | 0.1411 |   1.41 KB |        0.49 |
| GenerateSerializationSerializer | 1.055 μs | 0.0133 μs | 0.0111 μs |  0.27 |    0.01 | 0.1087 |   1.08 KB |        0.37 |
