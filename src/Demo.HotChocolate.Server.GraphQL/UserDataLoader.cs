namespace Demo.HotChocolate.Server.GraphQL
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.GraphQL.Mapping;
	using Demo.HotChocolate.Server.Transport;
	using GreenDonut;

	public class UserDataLoader : DataLoaderBase<string, UserDto>
	{
		private readonly IUserRepository _repository;

		public UserDataLoader(IUserRepository repository)
			: base(new DataLoaderOptions<string>())
		{
			this._repository = repository;
		}

		protected override async Task<IReadOnlyList<Result<UserDto>>> FetchAsync(
			IReadOnlyList<string> keys,
			CancellationToken cancellationToken)
		{
			await Task.Yield();
			return this._repository.GetUsers(keys).Select(x => Result<UserDto>.Resolve(x.ToTransport())).ToList();
		}
	}
}
