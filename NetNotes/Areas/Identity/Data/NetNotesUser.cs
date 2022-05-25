using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NetNotes.Book;

namespace NetNotes.Areas.Identity.Data;

// Add profile data for application users by adding properties to the NetNotesUser class
public class NetNotesUser : IdentityUser
{
    public List<Note> Notes { get; set; }
}

