using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace accountmanager
{
	public class Account
	{
		//this is just a container for all info related
		//to an account.  We'll simply create public class-level
		//variables representing each piece of information!
		public int id;
		public string userId;
		public string password;
		public string firstName;
		public string lastName;
		public string email;
	}
}