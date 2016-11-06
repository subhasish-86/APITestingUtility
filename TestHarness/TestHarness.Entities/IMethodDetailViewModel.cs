using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace TestHarness.Entities
{
    public interface IMethodDetailViewModel
    {
        Type SelectedType { get; set; }
       string Header { get; }
       MethodInfo[] MethodList { get; }
       MethodInfo SelectedMethod { get; set; }
        List<ParamInfo> MethodParams { get; }
        object Instance { get; set; }
        void InvokeMethod();
        event EventHandler InvokedMethodResultAvailable;
    }

    public class MethodInformation
    {
        private readonly MethodInfo _methodInfo;

        public MethodInformation(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
        }

        public string DisplayName
        {
            get
            {
                return _methodInfo.ReturnParameter != null
                           ? string.Format("{0} {1}", _methodInfo.ReturnParameter.Name, _methodInfo.Name)
                           : string.Empty;
            }
        }

        public string Name
        {
            get { return _methodInfo.Name; }
        }


        public ParameterInfo[] GetParameters()
        {
            return _methodInfo.GetParameters();
        }
    }

    public class ResultInfo
    {
        private readonly object _returnValue;

        public ResultInfo(object returnValue)
        {
            _returnValue = returnValue;
        }

        public string Name
        {
            get { return "Result"; }
        }

        public object Value
        {
            get { return _returnValue; }
        }

        public IEnumerable<KeyValuePair<string,object>> Properties
        {
            get
            {
                var props = new List<KeyValuePair<string, object>>();
                foreach (var propInfo in _returnValue.GetType().GetProperties())
                {
                    if (propInfo.GetIndexParameters().Any()) continue;

                    props.Add(new KeyValuePair<string, object>(propInfo.Name,
                                                               propInfo.GetValue(_returnValue, BindingFlags.GetProperty,
                                                                                 null, null, CultureInfo.CurrentCulture)));
                }

                return props;
            }
        }
    }
}