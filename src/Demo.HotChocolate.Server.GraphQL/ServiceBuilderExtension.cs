// ----------------------------------------------------------------------------------------
//  <copyright file="ServiceBuilderExtension.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
	using Demo.HotChocolate.Server.GraphQL.Types;
	using HotChocolate;
	using HotChocolate.AspNetCore;
	using HotChocolate.Execution.Configuration;
	using Microsoft.AspNetCore.Builder;

	public static class ServiceBuilderExtension
	{
		public static IServiceCollection ConfigureGraphQL(this IServiceCollection services)
		{
			services.AddGraphQL(serviceProvider => SchemaBuilder.New()
				                    .AddServices(serviceProvider)
				                    .AddQueryType<QueryType>()
				                    .AddType<UserType>()
				                    .AddType<UserListType>()
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
