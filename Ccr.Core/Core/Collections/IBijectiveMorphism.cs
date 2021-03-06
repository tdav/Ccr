﻿namespace Ccr.Core.Collections
{
	public interface IBijectiveMorphism<TA, TB>
		: IIsomorphicMorphism<TA, TB>
	{
		IBijectiveMorphism<TB, TA> BijectiveInverse { get; }
	}
}