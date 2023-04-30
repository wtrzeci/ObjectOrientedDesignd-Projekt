using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.classes_Base
{
    internal interface InterfaceBasse
    {
        Dictionary<string, object> Properties();
    }
    internal interface ListInnitializable
    {
        public void SetValuesWithList(List<string> values,Bitflix bitflix);
    }
}
