namespace Performance.Test.NotifyPropertyChanged
{
    using System;

    public class TestObject : Bindable, ITestProperty
    {
        private ITestProperty data;

        public TestObject(ITestProperty data)
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
            set
            {
                if (Equals(this.data.Amount, value))
                {
                    this.data.Amount = value;
                    OnPropertyChanged();
                }
            }
        }
        public decimal? AmountNull
        {
            get => this.data.AmountNull;
            set
            {
                if (Equals(this.data.AmountNull, value))
                {
                    this.data.AmountNull = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime? Date
        {
            get => this.data.Date;
            set
            {
                if (Equals(this.data.Date, value))
                {
                    this.data.Date = value;
                    OnPropertyChanged();
                }
            }
        }
        public int? Id
        {
            get => this.data.Id;
            set
            {
                if (Equals(this.data.Id, value))
                {
                    this.data.Id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => this.data.Name;
            set
            {
                if (Equals(this.data.Name, value))
                {
                    this.data.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string NameNull
        {
            get => this.data.NameNull;
            set
            {
                if (Equals(this.data.NameNull, value))
                {
                    this.data.NameNull = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
