﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Container_Demo
{
	public class Resolver
	{
		private Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();

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

			var firstConstructor = resolveType.GetConstructors().First();
			var constructorParameters = firstConstructor.GetParameters();
			if (constructorParameters.Count() == 0)
				return Activator.CreateInstance(resolveType);

			IList<object> parameters = new List<object>();
			foreach (var parameterToResolve in constructorParameters)
			{
				parameters.Add(Resolve(parameterToResolve.ParameterType));
			}
			return firstConstructor.Invoke(parameters.ToArray());
		}
	}
}
