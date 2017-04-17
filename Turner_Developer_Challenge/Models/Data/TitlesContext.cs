namespace Turner_Developer_Challenge.Models.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TitlesContext : DbContext
    {
        public TitlesContext()
            : base("name=TitlesConnectionString")
        {
        }

        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<OtherName> OtherNames { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<StoryLine> StoryLines { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<TitleGenre> TitleGenres { get; set; }
        public virtual DbSet<TitleParticipant> TitleParticipants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.TitleGenres)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Participant>()
                .HasMany(e => e.TitleParticipants)
                .WithRequired(e => e.Participant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.Awards)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.StoryLines)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.TitleGenres)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.TitleParticipants)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);
        }
    }
}
