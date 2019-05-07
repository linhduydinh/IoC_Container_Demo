using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Container_Demo
{
	public class SQLReader : IPersonReader
	{
		public string GetPeople()
		{
			return "SQL database return !!!";
		}
	}
}
