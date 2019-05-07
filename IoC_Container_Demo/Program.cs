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
			Resolver resolver = new Resolver();

			resolver.Register<Person, Person>();
			//resolver.Register<IPersonReader, SQLReader>();
			resolver.Register<IPersonReader, DocumentReader>();

			var person = resolver.Resolve<Person>();
			person.GetPeople();

			Console.Read();
		}
	}
}
