using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestHarness.Entities
{
    public interface IConstructorDetailViewModel
    {
        Type SelectedType { get; set; }
        string Header { get; }
        ConstructorInfo[] ConstructorList { get; }
        ConstructorInfo SelectedConstructor { get; set; }
        List<ParamInfo> ConstructorParams { get; }
        object Instance { get; set; }
        void CreateInstance();
        event EventHandler InstanceUpdated;
    }
}
