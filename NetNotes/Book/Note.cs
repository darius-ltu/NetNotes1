using System.ComponentModel.DataAnnotations;

namespace NetNotes.Book
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string NetNotesUserId { get; set; }
    }
}
