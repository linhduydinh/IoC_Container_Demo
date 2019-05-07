using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Container_Demo
{
	public class Resolver
	{
		//Dictionary để chứa các interface và module tương ứng
		private Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();

		//Hai hàm cơ bản, ở đây mình chuyển <T> thành 
		//dạng Type trong C# để dễ viết code
		public T Resolve<T>()
		{
			return (T)Resolve(typeof(T));
		}

		public void Register<TFrom, TTo>()
		{
			dependencyMap.Add(typeof(TFrom), typeof(TTo));
		}

		private object Resolve(Type typeToResolve)
		{
			Type resolveType = null;
			try
			{
				resolveType = dependencyMap[typeToResolve];
			}
			catch
			{
				throw new Exception(string.Format("Could not resolve type {0}", typeToResolve));
			}
			//Tìm constructor đầu tiên
			var firstConstructor = resolveType.GetConstructors().First();
			//Lấy các tham số của constructor
			var constructorParameters = firstConstructor.GetParameters();
			//Nếu như không có tham số
			if (constructorParameters.Count() == 0)
				//Khởi tạo module
				return Activator.CreateInstance(resolveType);

			IList<object> parameters = new List<object>();
			foreach (var parameterToResolve in constructorParameters)
			{
				parameters.Add(Resolve(parameterToResolve.ParameterType));
			}
			//Inject các dependency vào constructor của module
			return firstConstructor.Invoke(parameters.ToArray());
		}
	}
}
