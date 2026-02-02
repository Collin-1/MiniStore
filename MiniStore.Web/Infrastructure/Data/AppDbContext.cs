using Microsoft.EntityFrameworkCore;
using MiniStore.Web.Domain.Entities;

namespace MiniStore.Web.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}