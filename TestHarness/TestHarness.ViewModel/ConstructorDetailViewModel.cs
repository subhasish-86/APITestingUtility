using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TestHarness.Entities;

namespace TestHarness.ViewModel
{
    public class ConstructorDetailViewModel : ViewModelBase, IConstructorDetailViewModel
    {
        private Type _selectedType;
        private ConstructorInfo _selectedConstructor;
        private List<ParamInfo> _constructorParams;
        private object _instance;


        public Type SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged("ConstructorList");
            }
        }

        public string Header
        {
            get { return "Constructor"; }
        }

        public ConstructorInfo[] ConstructorList
        {
            get { return _selectedType != null ? _selectedType.GetConstructors() : null; }
        }

        public ConstructorInfo SelectedConstructor
        {
            get { return _selectedConstructor; }
            set
            {
                _selectedConstructor = value;
                if (_selectedConstructor == null) return;

                ConstructorParams =
                    _selectedConstructor.GetParameters().Select(constructorParam => new ParamInfo(constructorParam)).ToList();

            }
        }

        public List<ParamInfo> ConstructorParams
        {
            get { return _constructorParams; }
            private set
            {
                _constructorParams = value;
                OnPropertyChanged("ConstructorParams");
            }
        }

        public void CreateInstance()
        {
            if (ConstructorParams != null)
            {
                try
                {
                    var paramValues = ConstructorParams.Select(param => param.GetValue()).ToArray();
                    Instance = Activator.CreateInstance(SelectedType, paramValues);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
               
            }
        }

        public event EventHandler InstanceUpdated;

        public object Instance
        {
            get { return _instance; }
            set
            {
                _instance = value;
                OnPropertyChanged("Instance");
                if (InstanceUpdated != null)
                {
                    InstanceUpdated(this, EventArgs.Empty);
                }
            }
        }
    }
}
