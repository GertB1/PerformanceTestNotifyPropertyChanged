namespace Performance.Test.NotifyPropertyChanged
{
    using System;

    public class TestBindableObject : BindableObject, ITestProperty
    {
        private ITestProperty data;

        public TestBindableObject(ITestProperty data)
        {
            this.data = data;
        }

        public ITestProperty Data
        {
            get => this.data;
        }

        public decimal? Amount
        {
            get => this.data.Amount;
            set => Set<decimal?>(data, value);
        }
        public decimal? AmountNull
        {
            get => this.data.AmountNull;
            set => Set<decimal?>(data, value);
        }
        public DateTime? Date
        {
            get => this.data.Date;
            set => Set<DateTime?>(data, value);
        }
        public int? Id
        {
            get => this.data.Id;
            set => Set<int?>(data, value);
        }
        public string Name
        {
            get => this.data.Name;
            set => Set<string>(data, value);
        }
        public string NameNull
        {
            get => this.data.NameNull;
            set => Set<string>(data, value);
        }
    }
}
