using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Container_Demo
{
	public class DocumentReader : IPersonReader
	{
		public string GetPeople()
		{
			return "Document database return !!!";
		}
	}
}
