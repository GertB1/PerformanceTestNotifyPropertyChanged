namespace Performance.Test.NotifyPropertyChanged
{
    using BenchmarkDotNet.Attributes;
    using System;

    public class TestPerformance
    {
        private ITestProperty UpdateData(ITestProperty data)
        {
            DateTime date = new DateTime(2018, 05, 12);

            data.Id = 1;
            data.Name = "Test";
            data.Date = date;
            data.Amount = 500.23M;
            data.AmountNull = null;
            data.NameNull = null;

            data.Id = data.Id + 1;
            data.Name = data.Name + " Test";
            data.Date = date;
            data.Amount = data.Amount / 2.0M;
            data.AmountNull = null;
            data.NameNull = null;

            return data;
        }

        private ITestProperty UpdateData(ITestProperty poco, ITestProperty data)
        {
            DateTime date = new DateTime(2018, 05, 12);

            poco.Id = 1;
            poco.Name = "Test";
            poco.Date = date;
            poco.Amount = 500.23M;
            poco.AmountNull = null;
            poco.NameNull = null;

            data.Id = data.Id + 1;
            data.Name = data.Name + " Test";
            data.Date = date;
            data.Amount = data.Amount / 2.0M;
            data.AmountNull = null;
            data.NameNull = null;

            return data;
        }

        [Benchmark(Baseline = true)]
        public ITestProperty POCONoBinding()
        {
            TestPOCO data = new TestPOCO();
            return UpdateData(data);
        }

        [Benchmark]
        public ITestProperty Bindable()
        {
            TestBindable data = new TestBindable();
            return UpdateData(data);
        }

        [Benchmark]
        public ITestProperty BindableDictionary()
        {
            TestBindableDictionary data = new TestBindableDictionary();
            return UpdateData(data);
        }

        [Benchmark]
        public ITestProperty BindableConcurrentDictionary()
        {
            TestBindableSafeDictionary data = new TestBindableSafeDictionary();
            return UpdateData(data);
        }

        [Benchmark]
        public ITestProperty BindableObjectReflection()
        {
            TestPOCO data = new TestPOCO();
            TestBindableObject dataBindable = new TestBindableObject(data);
            return UpdateData(data, dataBindable);
        }

        [Benchmark]
        public ITestProperty TestPOCO6()
        {
            TestPOCO data = new TestPOCO();
            TestObject dataBindable = new TestObject(data);
            return UpdateData(data, dataBindable);
        }

        [Benchmark]
        public TestBindableDynamic BindableDynamic()
        {
            dynamic data = new TestBindableDynamic();
            DateTime date = new DateTime(2018, 05, 12);

            data.Id = 1;
            data.Name = "Test";
            data.Date = date;
            data.Amount = 500.23M;
            data.AmountNull = null;
            data.NameNull = null;

            data.Id = data.Id + 1;
            data.Name = data.Name + " Test";
            data.Date = date;
            data.Amount = data.Amount / 2.0M;
            data.AmountNull = null;
            data.NameNull = null;

            return data;
        }
    }
}

