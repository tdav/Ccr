﻿using System;
using Ccr.Std.Introspective.Infrastructure.Context;

namespace Ccr.Std.Extensions
{
	public static class IntrospectiveExtensions
	{
		public static IntrospectiveContext Reflect(
			this object @this)
		{
			if (@this is Type context)
				return new IntrospectiveStaticContext(
				    context);

			return new IntrospectiveInstanceContext(
			  @this);
		}

		public static IntrospectiveStaticContext Reflect(
			this Type @this)
		{
				return new IntrospectiveStaticContext(
				  @this);
		}


		//public static IntrospectiveStaticContext<TValue> Reflect<TValue>(
		//	this TValue @this)
		//{
		//	return new IntrospectiveStaticContext<TValue>();
		//}




	}
}
