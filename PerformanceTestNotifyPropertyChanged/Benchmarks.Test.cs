namespace Performance.Test.NotifyPropertyChanged
{
    using System;

    public class TestPOCO : BenchmarkBase, ITestProperty
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string NameNull { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountNull { get; set; }
    }
}
