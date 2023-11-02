using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeLancingWebApp.Models;
using FreeLancingWebApp.Models.ViewModels;
using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;

namespace FreeLancingWebApp;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Service> services { get; set; }
    public DbSet<Job> jobs { get; set; }
    public DbSet<profileViewModels> profileViewModels { get; set; }
    public DbSet<FreeLancingWebApp.Models.ViewModels.RegisterViewModel> RegisterViewModel { get; set; } = default!;
    public DbSet<FreeLancingWebApp.Models.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
    public DbSet<FreeLancingWebApp.Models.ViewModels.CreateRoleViewModel> CreateRoleViewModel { get; set; } = default!;


  
}






