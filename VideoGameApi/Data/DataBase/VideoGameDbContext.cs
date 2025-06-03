using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data;

public class VideoGameDbContext : DbContext
{
    public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VideoGame> VideoGames { get; set;}
}