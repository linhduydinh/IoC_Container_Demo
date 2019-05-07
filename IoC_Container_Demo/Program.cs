using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Container_Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			IPersonReader personReader = new DocumentReader();
			var person = new Person(personReader);
			person.GetPeople();

			Console.Read();
		}
	}
}
