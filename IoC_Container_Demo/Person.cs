using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Container_Demo
{
	public class Person
	{
		private readonly IPersonReader personReader;

		public Person(IPersonReader personReader)
		{
			this.personReader = personReader;
		}

		public void GetPeople()
		{
			var data = personReader.GetPeople();
			Console.WriteLine(data);
		}
	}
}
