using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.DAL.Entities
{
	public class Admin 
	{
		[Key]
		public int AdminID { get; set; }
		[StringLength(20)]
        public string Username { get; set; }
		[StringLength(20)]
		public string Password { get; set; }
		[StringLength(1)]
		public string Role { get; set; }

    }
}
