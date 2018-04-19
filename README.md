# Performance Test NotifyPropertyChanged
Performance testing different ways to implement INotifyPropertyChanged

I have found different ways to implement INotifyPropertyChanged on the internet.

So, I wanted to see how effective they are. Here are the results of my tests:

```
BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.371 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
Frequency=2531253 Hz, Resolution=395.0613 ns, Timer=TSC
.NET Core SDK=2.1.103
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
```

|                       Method |       Mean |      Error |     StdDev | Scaled | ScaledSD |
|----------------------------: |-----------:|-----------:|-----------:|-------:|---------:|
|                POCONoBinding |   255.0 ns |  0.3881 ns |  0.3241 ns |   1.00 |     0.00 |
|                     Bindable | 1,258.2 ns | 24.2930 ns | 24.9471 ns |   4.93 |     0.10 |
|           BindableDictionary | 2,697.9 ns | 20.3978 ns | 19.0801 ns |  10.58 |     0.07 |
| BindableConcurrentDictionary | 3,731.1 ns | 41.3462 ns | 36.6524 ns |  14.63 |     0.14 |
|     BindableObjectReflection | 3,739.9 ns | 74.5249 ns | 76.5316 ns |  14.66 |     0.29 |
|                    TestPOCO6 |   853.6 ns |  2.5125 ns |  2.2273 ns |   3.35 |     0.01 |
|              BindableDynamic | 1,294.2 ns | 12.7124 ns |  9.9250 ns |   5.07 |     0.04 |
              
              
<p>
  I took POCONoBinding as the benchmark for performing the test. POCONoBinding does not implement the INotifyPropertyChanged. 
When I add the INotifyPropertyChanged then the performance changes drastically. It seems that TestPOCO6 performed the best compared to the other test.
</p>
<p>
  I also think that one should not implement INotifyPropertyChanged on objects you would like to retrieve from the database, that way it would be the fastest. Only add the INotifyPropertyChanged where you require it, like when binding to the object in an edit control.
</p>
<p>
  If anybody has a better idea please let me know. It would be appreciated.
</p>
