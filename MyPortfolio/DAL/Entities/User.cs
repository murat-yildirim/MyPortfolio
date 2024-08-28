using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.DAL.Entities
{
	public class User
	{

		[Key]
		public int ID { get; set; }
		[StringLength(20)]
		public string Name { get; set; }
		[StringLength(20)]
		public string Surname { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(50)]
		public string Mail { get; set; }
		
		[Required]
		[StringLength(20)]
		public string UserName { get; set; }
		[StringLength(20)]
		public string Password { get; set; }
		[StringLength(20)]
		public string PasswordAgain { get; set; }
		[StringLength(1)]
		public string Role { get; set; }
	}
}
