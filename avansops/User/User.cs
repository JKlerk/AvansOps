using System;

namespace AvansOps {
	public class User {
		private string FirstName { get; }
		private string LastName { get; }
		private string Email { get; }

		public User(string firstName, string lastName, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}
	}

}
