using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data.Models;

namespace VideoGameApi.Data.DataBase;

public class VideoGameDbContext : DbContext
{
    public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VideoGame> VideoGames { get; set;}
}