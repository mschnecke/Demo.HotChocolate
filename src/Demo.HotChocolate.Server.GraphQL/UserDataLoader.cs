using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Demo.HotChocolate.Server.Domain;
using GreenDonut;
using Demo.HotChocolate.Server.Transport;
using Demo.HotChocolate.Server.GraphQL.Mapping;

namespace Demo.HotChocolate.Server.GraphQL
{
	public class UserDataLoader : DataLoaderBase<string, UserDto>
	{
		private readonly IUserRepository _repository;

		public UserDataLoader(IUserRepository repository)
		  : base(new DataLoaderOptions<string>())
		{
			_repository = repository;
		}

		protected override async Task<IReadOnlyList<Result<UserDto>>> FetchAsync(
			IReadOnlyList<string> keys,
			CancellationToken cancellationToken)
		{
			await Task.Yield();
			return _repository.GetUsers(keys).Select(x => Result<UserDto>.Resolve(x.ToTransport())).ToList();
		}
	}
}