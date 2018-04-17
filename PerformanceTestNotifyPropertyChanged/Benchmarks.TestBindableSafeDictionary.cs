namespace Performance.Test.NotifyPropertyChanged
{
    using System;

    public class TestBindableSafeDictionary : BindableSafeDictionary, ITestProperty
    {
        public int? Id
        {
            get => Get<int?>();
            set => Set<int?>(value);
        }
        public string Name
        {
            get => Get<string>();
            set => Set<string>(value);
        }
        public string NameNull
        {
            get => Get<string>();
            set => Set<string>(value);
        }
        public DateTime? Date
        {
            get => Get<DateTime?>();
            set => Set<DateTime?>(value);
        }
        public decimal? Amount
        {
            get => Get<decimal?>();
            set => Set<decimal?>(value);
        }
        public decimal? AmountNull
        {
            get => Get<decimal?>();
            set => Set<decimal?>(value);
        }
    }
}
