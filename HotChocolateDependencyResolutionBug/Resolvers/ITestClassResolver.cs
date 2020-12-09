using System.Collections.Generic;

namespace HotChocolateDependencyResolutionBug.Resolvers
{
	internal interface ITestClassResolver
	{
		IEnumerable<TestClass> Resolve();
	}
}