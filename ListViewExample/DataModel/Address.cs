using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewExample.DataModel
{
    public class Address : INotifyPropertyChanged
    {
        private string _name;

        public string Id { get; set; }
        
        public string Name {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public string Street { get; set; }
        
        public string Number { get; set; }
        
        public string Code { get; set; }
        
        public string City { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        
    }
}
