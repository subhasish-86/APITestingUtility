using System;
using System.Collections.Generic;
using System.Reflection;
using TestHarness.Entities;

namespace TestHarness.ViewModel
{
    public class AssemblyDetailViewModel : ViewModelBase, IAssemblyDetailViewModel
    {
        private IEnumerable<Type> _definedTypes;
        private string _assemblyFileName;
        private Type _selectedType;

        public string Header 
        {
            get
            {
                return "Assembly";
            }
        }

        public string AssemblyFileName
        {
            get { return _assemblyFileName; }
            set
            {
                _assemblyFileName = value;
                if (string.IsNullOrEmpty(_assemblyFileName)) return;
                var assembly = Assembly.LoadFrom(_assemblyFileName);
                DefinedTypes = assembly.GetExportedTypes();
            }
        }

        public string XmlHelpFile { get; set; }

        public IEnumerable<Type> DefinedTypes
        {
            get { return _definedTypes; }
            set
            {
                _definedTypes = value;
                OnPropertyChanged("DefinedTypes");
            }
        }


        public Type SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged("SelectedType");

                if (SelectedTypeUpdated != null)
                {
                    SelectedTypeUpdated(this, EventArgs.Empty);
                }
            }
        }

        public object CreatedInstance { get; set; }

        public event EventHandler<EventArgs > SelectedTypeUpdated;
    }
}