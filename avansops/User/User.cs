namespace AvansOps.User {
	public class User {
		public string FirstName { get; }
		public string LastName { get; }
		public string Email { get; }

		public User(string firstName, string lastName, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}
	}

}
