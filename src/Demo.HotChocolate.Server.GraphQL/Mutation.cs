namespace Demo.HotChocolate.Server.GraphQL
{
	using System;
	using System.Linq;
	using Demo.HotChocolate.Server.Domain;
	using global::HotChocolate;

	public class Mutation
	{
		[GraphQLDescription("Deletes an user by ID.")]
		public string DeleteUserById(Guid id, [Service] IUserRepository repository)
		{
			repository.DeleteUser(id);
			return "Resource deleted.";
		}

		[GraphQLDescription("Deletes an user by email.")]
		public string DeleteUserByEmail(string email, [Service] IUserRepository repository)
		{
			var user = repository.GetUsers().FirstOrDefault(x => x.Email == email);

			if (user != null)
			{
				repository.DeleteUser(user.Id);
			}

			return "Resource deleted.";
		}
	}
}
