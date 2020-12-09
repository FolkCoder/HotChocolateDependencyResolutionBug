using System.Collections.Generic;

namespace HotChocolateDependencyResolutionBug.Resolvers
{
	internal class TestClassResolver : ITestClassResolver
	{
		private readonly IEnumerable<TestClass> sampleData = new[]
		{
			new TestClass { Id = 1, Name = "A" },
			new TestClass { Id = 2, Name = "B" },
			new TestClass { Id = 3, Name = "C" },
		};

		public IEnumerable<TestClass> Resolve()
		{
			return this.sampleData;
		}
	}
}