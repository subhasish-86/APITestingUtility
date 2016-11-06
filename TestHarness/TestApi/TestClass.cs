using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi
{
    public class TestClass
    {
        private string _paramType;
        public TestClass()
        {
            _paramType = null;
        }
        public TestClass(string s)
        {
            _paramType = "string : " + s;
        }

        public TestClass(int i)
        {
            _paramType = "int : " + i;
        }

        public string GetResult(string input)
        {
            return _paramType + " : " + input;
        }
    }
}
