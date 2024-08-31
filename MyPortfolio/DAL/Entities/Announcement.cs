using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.DAL.Entities
{
	public class Announcement
	{
        [Key]
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
