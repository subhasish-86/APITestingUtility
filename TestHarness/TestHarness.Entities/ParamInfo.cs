using System;
using System.Reflection;

namespace TestHarness.Entities
{
    public class ParamInfo
    {
        private readonly ParameterInfo _parameterInfo;
        private string _value;

        public ParamInfo(ParameterInfo parameterInfo)
        {
            _parameterInfo = parameterInfo;
        }

        public string Name
        {
            get { return _parameterInfo.Name; }
        }

        public Type ParamType
        {
            get { return _parameterInfo.ParameterType; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public object GetValue()
        {
            return Convert.ChangeType(Value, ParamType);
        }
    }
}