using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using TestHarness.Entities;

namespace TestHarness.ViewModel
{
    public class MethodDetailViewModel : ViewModelBase, IMethodDetailViewModel
    {
        private Type _selectedType;
        private List<ParamInfo> _methodParams;
        private MethodInfo _selectedMethod;
        private object _instance;
        private IEnumerable<ResultInfo> _returnValue;

        public Type SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged("MethodList");
            }
        }
        public string Header { get; private set; }

        public MethodInfo[] MethodList
        {
            get
            {
                return _selectedType != null
                           ? _selectedType.GetMethods()
                                          .Where(
                                              m => !typeof (object).GetMethods().Select(me => me.Name).Contains(m.Name))
                                          .ToArray()
                           : null;
            }
        }

        public MethodInfo SelectedMethod
        {
            get { return _selectedMethod; }
            set
            {
                _selectedMethod = value;
                if (_selectedMethod == null) return;

                MethodParams =
                    _selectedMethod.GetParameters().Select(constructorParam => new ParamInfo(constructorParam)).ToList();

            }
        }
        public List<ParamInfo> MethodParams
        {
            get { return _methodParams; }
            private set
            {
                _methodParams = value;
                OnPropertyChanged("MethodParams");
            }
        }

        public object Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public void InvokeMethod()
        {
            var paramValues = MethodParams.Select(param => param.GetValue()).ToArray();
            object returnValue = SelectedType.InvokeMember(SelectedMethod.Name, BindingFlags.InvokeMethod, null, Instance,paramValues);

            //returnValue = new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("AAA", 1), new KeyValuePair<string, int>("BBB", 2), new KeyValuePair<string, int>("CCC", 3) };
            //returnValue = new List<string> { new KeyValuePair<string, int>("AAA", 1), new KeyValuePair<string, int>("BBB", 2), new KeyValuePair<string, int>("CCC", 3) };
            if (returnValue as IEnumerable<object> != null )
            {
                Result = (returnValue as IEnumerable<object>).Select(resultInfo => new ResultInfo(resultInfo));

            }
            else if(returnValue as IEnumerable<int> != null)
            {
                Result = (returnValue as IEnumerable<int>).Select(resultInfo => new ResultInfo(resultInfo));
            }
            else
            {
                Result = new List<ResultInfo> { new ResultInfo(returnValue) };
                
            }
        }

        public IEnumerable<ResultInfo> Result
        {
            get { return _returnValue; }
            set
            {
                _returnValue = value;
                if(_returnValue.Any())
                    OnPropertyChanged("Result");
            }
        }

        public event EventHandler InvokedMethodResultAvailable;
    }

    
}