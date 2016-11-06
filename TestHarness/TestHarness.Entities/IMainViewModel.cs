using System;
using System.Collections.Generic;

namespace TestHarness.Entities
{
    public interface IMainViewModel
    {
        IAssemblyDetailViewModel AssemblyDetailViewModel { get;  }
        IConstructorDetailViewModel ConstructorDetailViewModel { get; }
        IMethodDetailViewModel MethodDetailViewModel { get; }
    }
}
