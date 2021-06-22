using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBook.Lib.Models
{
	[Table("users")]
	public class User
    {
		public int id { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public DateTime? email_verified_at { get; set; }
		public string password { get; set; }
		public string remember_token { get; set; }

		public string api_token { get; set; }
		public string access_token { get; set; }
		
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }

    }
}
