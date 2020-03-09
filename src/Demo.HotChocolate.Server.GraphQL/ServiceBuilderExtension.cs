// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
	using Demo.HotChocolate.Server.GraphQL;
	using HotChocolate;
	using HotChocolate.AspNetCore;
	using HotChocolate.AspNetCore.Voyager;
	using HotChocolate.Execution.Configuration;
	using Microsoft.AspNetCore.Builder;

	public static class ServiceBuilderExtension
	{
		public static IServiceCollection ConfigureGraphQL(this IServiceCollection services)
		{
			//services.AddDataLoaderRegistry();

			services.AddGraphQL(serviceProvider => SchemaBuilder.New()
				                    .AddServices(serviceProvider)
				                    .AddQueryType<Query>()
				                    .AddMutationType<Mutation>()
				                    .Create(),
					new QueryExecutionOptions {
						                          TracingPreference = TracingPreference.OnDemand,
						                          IncludeExceptionDetails = true
					                          })
				;

			return services;
		}

		public static IApplicationBuilder UseCustomGraphQL(this IApplicationBuilder app)
		{
			app.UseGraphQL("/graphql");
			app.UsePlayground("/graphql", "/playground");
			
			return app;
		}
	}
}
