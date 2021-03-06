﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Foundation.Extensibility
{
	/// <summary>
	/// Registry for API existensibility providers, used to provide optional
	/// implementations for compatible parts of WinUI and WinRT APIs.
	/// </summary>
	public static class ApiExtensibility
	{
		private static object _gate = new object();
		private static Dictionary<Type, Func<object, object>> _registrations = new Dictionary<Type, Func<object, object>>();

		/// <summary>
		/// Registers an extension instance builder for the specified type
		/// </summary>
		/// <param name="type">The type to register</param>
		/// <param name="builder">A builder that will be provided an optional owner, and returns an instance of the extension</param>
		/// <remarks>This method is generally called automatically when the <see cref="ApiExtensionAttribute"/> has been defined in an assembly.</remarks>
		public static void Register(Type type, Func<object, object> builder)
		{
			type = type ?? throw new ArgumentNullException(nameof(type));
			builder = builder ?? throw new ArgumentNullException(nameof(type));

			lock (_gate)
			{
				_registrations.Add(type, builder);
			}
		}

		/// <summary>
		/// Creates an instance of an extension of the specified <typeparamref name="T"/> type
		/// </summary>
		/// <typeparam name="T">A registered type</typeparam>
		/// <param name="owner">An optional owner to be passed to the extension constructor</param>
		/// <param name="instance">The instance if the creation was successful</param>
		/// <returns>True if the creation suceeded, otherwise False.</returns>
		public static bool CreateInstance<T>(object owner, out T instance) where T : class
		{
			lock (_gate)
			{
				if (_registrations.TryGetValue(typeof(T), out var builder))
				{
					instance = (T)builder(owner);
					return true;
				}
			}

			instance = null;

			return false;
		}
	}
}
