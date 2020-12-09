using HotChocolateDependencyResolutionBug.Resolvers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateDependencyResolutionBug
{
	internal class Startup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.UseRouting();
			app.UseEndpoints(x => x.MapGraphQL());
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ITestClassResolver, TestClassResolver>();

			var requestExecutorBuilder = services
				.AddGraphQLServer()
				.AddDocumentFromFile("./schema.graphql")
				.BindComplexType<TestClass>(b => b.To("TestClass"));

			// binding a concrete resolver instance works
			/*
			requestExecutorBuilder
				.BindResolver<TestClassResolver>(resolver =>
					resolver.To("Query")
						.Resolve("testClasses").With(x => x.Resolve()));
			*/

			// binding a resolver interface does not
			requestExecutorBuilder
				.BindResolver<ITestClassResolver>(resolver =>
					resolver.To("Query")
						.Resolve("testClasses").With(x => x.Resolve()));
		}
	}
}