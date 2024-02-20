using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SpeedTest.Context.Models;

public partial class SpeedTestContext : DbContext
{
    public SpeedTestContext()
    {
    }

    public SpeedTestContext(DbContextOptions<SpeedTestContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //    => optionsBuilder.UseSqlServer("Server=.;Database=SpeedTest;Trusted_Connection=True;Trust Server Certificate =Yes;");
        if (!optionsBuilder.IsConfigured)
        {
            //            builder.Services.AddDbContext<SpeedTestContext>(options =>
            //        options.UseSqlServer(builder.Configuration.GetConnectionString("SpeedTestConnection")));
            optionsBuilder.UseSqlServer("Server=.;Database=SpeedTest;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate =Yes");
        }

        base.OnConfiguring(optionsBuilder);
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleRating> ArticleRatings { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<SiteUser> SiteUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__Article__9C6270E850292229");

            entity.ToTable("Article");

            entity.Property(e => e.ArticleName).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Articles)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_Author");
        });

        modelBuilder.Entity<ArticleRating>(entity =>
        {
            entity.HasKey(e => e.ArticleRatingId).HasName("PK__ArticleR__D356E3DD4FA5BE65");

            entity.ToTable("ArticleRating");

            entity.Property(e => e.RatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticleRatings)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticleRating_Article");

            entity.HasOne(d => d.SiteUser).WithMany(p => p.ArticleRatings)
                .HasForeignKey(d => d.SiteUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticleRating_SiteUser");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__70DAFC34FF530498");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorName).HasMaxLength(100);

            entity.HasOne(d => d.Company).WithMany(p => p.Authors)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Author_Company");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC96837652");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyName).HasMaxLength(50);
        });

        modelBuilder.Entity<SiteUser>(entity =>
        {
            entity.HasKey(e => e.SiteUserId).HasName("PK__SiteUser__F099A92A8BE45F40");

            entity.ToTable("SiteUser");

            entity.Property(e => e.SiteUserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
