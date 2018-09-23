﻿using System;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Std.Introspective.Infrastructure.Context
{
	public class IntrospectiveStaticContext 
	  : IntrospectiveContext
	{
		protected internal override Type TargetType { get; }

		protected internal override object TargetObject => null;


		public IntrospectiveStaticContext(
			[NotNull] Type targetType)
		{
			targetType.IsNotNull(nameof(targetType));

			TargetType = targetType;
		}
	}

	public class IntrospectiveStaticContext<TValue> 
	  : IntrospectiveStaticContext
	{
		public IntrospectiveStaticContext() : base(
			typeof(TValue))
		{
			
		}
	}
}
