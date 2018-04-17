namespace Performance.Test.NotifyPropertyChanged
{
    using System;
    public interface ITestProperty
    {
        decimal? Amount { get; set; }
        decimal? AmountNull { get; set; }
        DateTime? Date { get; set; }
        int? Id { get; set; }
        string Name { get; set; }
        string NameNull { get; set; }
    }
}