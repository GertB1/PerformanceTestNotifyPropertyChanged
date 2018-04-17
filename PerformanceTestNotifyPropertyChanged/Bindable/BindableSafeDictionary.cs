namespace Performance.Test.NotifyPropertyChanged
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class BindableSafeDictionary : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SafeDictionary<string, object> _properties = new SafeDictionary<string, object>();

        /// <summary>
        /// Gets the value of a property
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        protected T Get<T>([CallerMemberName] string name = null)
        {
            if (_properties.TryGetValue(name, out object value))
            {
                return value == null ? default(T) : (T)value;
            }
            return default(T);
        }

        /// <summary>
        /// Sets the value of a property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        protected bool Set<T>(T value, [CallerMemberName] string name = null)
        {
            if (Equals(value, Get<T>(name)))
            {
                return false;
            }
            _properties[name] = value;
            OnPropertyChanged(name);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
