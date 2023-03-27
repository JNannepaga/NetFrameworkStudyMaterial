using System.ComponentModel;

namespace AOPFramework.INotifyChange
{
    public class Person  : INotifyPropertyChanged
    {
        private int _PId;

        public int PId {
            set 
            {
                this._PId = value;
                PropertChangedHandler("PId");
            }
            get { return _PId; }
        }
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void PropertChangedHandler(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
