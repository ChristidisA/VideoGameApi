using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data.Models;

namespace VideoGameApi.Data.DataBase;

public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
{
    public virtual DbSet<VideoGame> VideoGames { get; set;}
}