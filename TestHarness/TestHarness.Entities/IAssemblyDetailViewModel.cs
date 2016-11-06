using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness.Entities
{
    public interface IAssemblyDetailViewModel
    {
        string AssemblyFileName { get; set; }
        string Header { get;  }
        string XmlHelpFile { get; set; }
        IEnumerable<Type> DefinedTypes { get; set; }
        Type SelectedType { get; set; }
        object CreatedInstance { get; set; }

        event EventHandler<EventArgs> SelectedTypeUpdated;
    }
}
