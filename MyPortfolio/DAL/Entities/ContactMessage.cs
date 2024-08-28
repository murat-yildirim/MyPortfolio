using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.DAL.Entities
{
	public class ContactMessage
	{
        [Key]
        public int ContactMessageID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
		public DateTime SendDate { get; set; }
		public bool IsRead { get; set; }

	}
}
