using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudisIm.Desktop.ViewModels
{
    public class RefereeViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private string customerName;
        public RefereeViewModel()
        {
            customerName = "alen";
        }
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
                NotifyPropertyChanged("CustomerName");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }

        public bool IsValid
        {
            get
            {
                foreach(string property in ValidatedProperties)
                {
                    if (GetValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        static readonly string[] ValidatedProperties = { "CustomerName" };
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "CustomerName":
                    error = ValidateCustomerName();
                    break;
            }

            return error;
        }

        private string ValidateCustomerName()
        {
            if (String.IsNullOrWhiteSpace(CustomerName))
            {
                return "Customer name can not be empty";
            }

            return null;
        }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

    }
}
