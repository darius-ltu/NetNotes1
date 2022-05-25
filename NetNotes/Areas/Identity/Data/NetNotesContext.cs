using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetNotes.Areas.Identity.Data;
using NetNotes.Book;

namespace NetNotes.Areas.Identity.Data;

public class NetNotesContext : IdentityDbContext<NetNotesUser>
{
    public NetNotesContext(DbContextOptions<NetNotesContext> options)
        : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
