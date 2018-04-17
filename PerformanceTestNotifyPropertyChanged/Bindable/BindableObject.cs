namespace Performance.Test.NotifyPropertyChanged
{
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     Implementation of <see cref="INotifyPropertyChanged" /> to simplify models.
    /// </summary>
    public abstract class BindableObject : INotifyPropertyChanged
    {
        /// <summary>
        ///     Multicast event for property change notifications.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Checks if a property already matches a desired value.  Sets the property and
        ///     notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners.  This
        ///     value is optional and can be provided automatically when invoked from compilers that
        ///     support CallerMemberName.
        /// </param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the
        ///     desired value.
        /// </returns>
        protected bool Set<T>(object data, T value, [CallerMemberName] string propertyName = null)
        {
            PropertyInfo propertyInfo = data.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                T storage = (T)propertyInfo.GetValue(data);
                if (Equals(storage, value))
                {
                    return false;
                }

                propertyInfo.SetValue(data, value);
                this.OnPropertyChanged(propertyName);
            }

            return true;
        }

        /// <summary>
        ///     Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners.  This
        ///     value is optional and can be provided automatically when invoked from compilers
        ///     that support <see cref="CallerMemberNameAttribute" />.
        /// </param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
