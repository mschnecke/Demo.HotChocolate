// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
	using Demo.HotChocolate.Server.Data;
	using Microsoft.EntityFrameworkCore;

	public static class ServiceBuilderExtension
	{
		public static IServiceCollection ConfigureDatabase(this IServiceCollection services, string connectionString)
		{
			return services.AddDbContext<UserDbContext>(options =>
				                                            options.UseSqlite(
					                                            connectionString,
					                                            b =>
						                                            b.MigrationsAssembly(Contants.MigrationsAssembly)),
				ServiceLifetime.Transient,
				ServiceLifetime.Transient);
		}
	}
}
