namespace Performance.Test.NotifyPropertyChanged
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Runtime.CompilerServices;

    public abstract class BindableDynamic : DynamicObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Dictionary<string, object> _properties = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (_properties.TryGetValue(binder.Name, out object value))
            {
                result = value;
                return true;
            }

            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _properties.TryGetValue(binder.Name, out object result);
            if (!Equals(value, result))
            {
                _properties[binder.Name] = value;
                OnPropertyChanged(binder.Name);
            }
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
