using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Link_Backend_EF.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Illness> Illness { get; set; }
        public DbSet<FallRecord> FallRecord { get; set; }
        [NotMapped]
        public DbSet<Friendship> Friendship { get; set; }
        public DbSet<HeartIssuesRecord> HeartIssuesRecord { get; set; }
        public DbSet<HeartRhythmRecord> HeartRhythmRecord { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserData> UserData { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //FallRecord
            builder.Entity<FallRecord>().ToTable("FallRecords");    
            builder.Entity<FallRecord>().HasKey(p => p.Id);
            builder.Entity<FallRecord>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<FallRecord>().Property(p => p.LectureDate).IsRequired();
            builder.Entity<FallRecord>().Property(p => p.Severity).IsRequired();
            builder.Entity<FallRecord>().Property(p => p.PatientId).IsRequired();
            builder.Entity<FallRecord>()
                .HasOne(f => f.Patient)
                .WithMany(ud => ud.FallRecords)
                .HasForeignKey(f => f.PatientId);

            //Friendship
            builder.Entity<Friendship>().ToTable("Friendship");
            builder.Entity<Friendship>().HasKey(p => new { p.User1Code, p.User2Code });
            builder.Entity<Friendship>().Property(p => p.Active).IsRequired();
            builder.Entity<Friendship>().Property(p => p.User1Code).IsRequired();
            builder.Entity<Friendship>().Property(p => p.User2Code).IsRequired();
            builder.Entity<Friendship>()
                .HasOne(f => f.User1)
                .WithMany()
                .HasForeignKey(f => f.User1Code);
            builder.Entity<Friendship>()
                .HasOne(f => f.User2)
                .WithMany(u => u.Friendships)
                .HasForeignKey(f => f.User2Code);

            //HeartIssuesRecord
            builder.Entity<HeartIssuesRecord>().ToTable("HeartIssueRecords");
            builder.Entity<HeartIssuesRecord>().HasKey(p => p.Id);
            builder.Entity<HeartIssuesRecord>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HeartIssuesRecord>().Property(p => p.LectureDate).IsRequired();
            builder.Entity<HeartIssuesRecord>().Property(p => p.Severity).IsRequired();
            builder.Entity<HeartIssuesRecord>().Property(p => p.PatientId).IsRequired();
            builder.Entity<HeartIssuesRecord>()
                .HasOne(h => h.Patient)
                .WithMany(u => u.HeartIssuesRecords)
                .HasForeignKey(h => h.PatientId);

            //HeartRhythmRecord
            builder.Entity<HeartRhythmRecord>().ToTable("HeartRhythmRecords");
            builder.Entity<HeartRhythmRecord>().HasKey(p => p.Id);
            builder.Entity<HeartRhythmRecord>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HeartRhythmRecord>().Property(p => p.LectureDate).IsRequired();
            builder.Entity<HeartRhythmRecord>().Property(p => p.Bpm).IsRequired();
            builder.Entity<HeartRhythmRecord>().Property(p => p.PatientId).IsRequired();
            builder.Entity<HeartRhythmRecord>()
                .HasOne(h => h.Patient)
                .WithMany(u => u.HeartRhythmRecords)
                .HasForeignKey(h => h.PatientId);

            // Illness
            builder.Entity<Illness>().ToTable("Illnesses");
            builder.Entity<Illness>().HasKey(p => p.Id);
            builder.Entity<Illness>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Illness>().Property(p => p.Name).IsRequired();
            builder.Entity<Illness>().Property(p => p.Description).IsRequired();

            //Patient
            builder.Entity<Patient>().ToTable("Patients");
            builder.Entity<Patient>().HasKey(p => p.Id);
            builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Patient>().Property(p => p.Active).IsRequired();
            builder.Entity<Patient>().Property(p => p.Weight).IsRequired();
            builder.Entity<Patient>().Property(p => p.Height).IsRequired();
            builder.Entity<Patient>().Property(p => p.Country).IsRequired();
            builder.Entity<Patient>().Property(p => p.UserDataId).IsRequired();

            /*Un Patient tiene un UserData*/
            builder.Entity<Patient>()
                .HasOne(p => p.UserData)
                .WithOne(ud => ud.Patient)
                .HasForeignKey<Patient>(p => p.UserDataId);

            //User
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().HasKey(p => p.Code);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Code).IsRequired();
            builder.Entity<User>().Property(p => p.Username).IsRequired();
            builder.Entity<User>().Property(p => p.Password).IsRequired();

            //UserData
            builder.Entity<UserData>().ToTable("UsersData");
            builder.Entity<UserData>().HasKey(p => p.Id);
            builder.Entity<UserData>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserData>().Property(p => p.Active).IsRequired();
            builder.Entity<UserData>().Property(p => p.Email).IsRequired();
            builder.Entity<UserData>().Property(p => p.Name).IsRequired();
            builder.Entity<UserData>().Property(p => p.Lastname).IsRequired();
            builder.Entity<UserData>().Property(p => p.UserId).IsRequired();


            /*Un UserData tiene un User*/
            builder.Entity<UserData>()
                .HasOne(u => u.User)
                .WithOne(ud => ud.UserData)
                .HasForeignKey<UserData>(u => u.UserId);


            builder.UseSnakeCaseNamingConvention();
        }
    }
}
