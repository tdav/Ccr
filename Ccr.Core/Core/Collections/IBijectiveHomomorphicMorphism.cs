﻿namespace Ccr.Core.Collections
{
	public interface IBijectiveHomomorphicMorphism<T>
		: IBijectiveMorphism<T, T>
	{
		IBijectiveHomomorphicMorphism<T> BijectiveHomomorphicInverse { get; }
	}
}