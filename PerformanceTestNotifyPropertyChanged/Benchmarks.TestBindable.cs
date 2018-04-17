namespace Performance.Test.NotifyPropertyChanged
{
    using System;

    public class TestBindable : Bindable, ITestProperty
    {
        private int? _id;
        public int? Id
        {
            get => _id;
            set => Set<int?>(ref _id, value);
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => Set<string>(ref _name, value);
        }
        private string _nameNull;
        public string NameNull
        {
            get => _nameNull;
            set => Set<string>(ref _nameNull, value);
        }
        private DateTime? _date;
        public DateTime? Date
        {
            get => _date;
            set => Set<DateTime?>(ref _date, value);
        }
        private decimal? _amount;
        public decimal? Amount
        {
            get => _amount;
            set => Set<decimal?>(ref _amount, value);
        }
        private decimal? _amountNull;
        public decimal? AmountNull
        {
            get => _amountNull;
            set => Set<decimal?>(ref _amountNull, value);
        }
    }
}
