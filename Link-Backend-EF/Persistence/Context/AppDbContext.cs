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
        public DbSet<IllnessesList> IllnessList { get; set; }
        public DbSet<FallRecord> FallRecord { get; set; }
        [NotMapped]
        public DbSet<Friendship> Friendship { get; set; }
        public DbSet<HeartIssuesRecord> HeartIssuesRecord { get; set; }
        public DbSet<HeartRhythmRecord> HeartRhythmRecord { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<UserDevice> UserDevice { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // FallRecord
            builder.Entity<FallRecord>().ToTable("fall_records");
            builder.Entity<FallRecord>().HasKey(p => p.Id);
            builder.Entity<FallRecord>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<FallRecord>().Property(p => p.LectureDate).IsRequired();
            builder.Entity<FallRecord>().Property(p => p.Severity).IsRequired();
            builder.Entity<FallRecord>().Property(p => p.PatientId).IsRequired();
            builder.Entity<FallRecord>()
                .HasOne(f => f.Patient)
                .WithMany(p => p.FallRecords)
                .HasForeignKey(f => f.PatientId);

            // Friendship
            builder.Entity<Friendship>().ToTable("friendship");
            builder.Entity<Friendship>().HasKey(p => new { p.User1Code, p.User2Code });
            builder.Entity<Friendship>().Property(p => p.State).IsRequired();
            builder.Entity<Friendship>().Property(p => p.User1Code).IsRequired().HasMaxLength(40);
            builder.Entity<Friendship>().Property(p => p.User2Code).IsRequired().HasMaxLength(40);
            builder.Entity<Friendship>()
                .HasOne(f => f.User1)
                .WithMany()
                .HasForeignKey(f => f.User1Code)
                .HasPrincipalKey(u => u.Code);
            builder.Entity<Friendship>()
                .HasOne(f => f.User2)
                .WithMany(u => u.Friendships)
                .HasForeignKey(f => f.User2Code)
                .HasPrincipalKey(u => u.Code);



            // HeartIssuesRecord
            builder.Entity<HeartIssuesRecord>().ToTable("heart_issue_records");
            builder.Entity<HeartIssuesRecord>().HasKey(p => p.Id);
            builder.Entity<HeartIssuesRecord>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HeartIssuesRecord>().Property(p => p.LectureDate).IsRequired();
            builder.Entity<HeartIssuesRecord>().Property(p => p.Severity).IsRequired();
            builder.Entity<HeartIssuesRecord>().Property(p => p.PatientId).IsRequired();
            builder.Entity<HeartIssuesRecord>()
                .HasOne(h => h.Patient)
                .WithMany(p => p.HeartIssuesRecords)
                .HasForeignKey(h => h.PatientId);

            // HeartRhythmRecord
            builder.Entity<HeartRhythmRecord>().ToTable("heart_rhythm_records");
            builder.Entity<HeartRhythmRecord>().HasKey(p => p.Id);
            builder.Entity<HeartRhythmRecord>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HeartRhythmRecord>().Property(p => p.LectureDate).IsRequired();
            builder.Entity<HeartRhythmRecord>().Property(p => p.Bpm).IsRequired();
            builder.Entity<HeartRhythmRecord>().Property(p => p.PatientId).IsRequired();
            builder.Entity<HeartRhythmRecord>()
                .HasOne(h => h.Patient)
                .WithMany(p => p.HeartRhythmRecords)
                .HasForeignKey(h => h.PatientId);

            // Illness
            builder.Entity<Illness>().ToTable("illnesses");
            builder.Entity<Illness>().HasKey(p => p.Id);
            builder.Entity<Illness>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Illness>().Property(p => p.Name).IsRequired();
            builder.Entity<Illness>().Property(p => p.Description).IsRequired();

            // Illnessses List
            builder.Entity<IllnessesList>().ToTable("illnesses_list");
            builder.Entity<IllnessesList>().HasKey(p => p.Id);
            builder.Entity<IllnessesList>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<IllnessesList>().Property(p => p.UserDataId).IsRequired();
            builder.Entity<IllnessesList>().Property(p => p.IllnessId).IsRequired();
            builder.Entity<IllnessesList>()
                .HasOne(il => il.UserData)
                .WithOne(ud => ud.IllnessesList)
                .HasForeignKey<IllnessesList>(il =>il.UserDataId);
            builder.Entity<IllnessesList>()
                .HasOne(il => il.Illness)
                .WithOne(i => i.IllnessesList)
                .HasForeignKey<IllnessesList>(il => il.IllnessId);

            // Patient
            builder.Entity<Patient>().ToTable("patients");
            builder.Entity<Patient>().HasKey(p => p.Id);
            builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Patient>().Property(p => p.State).IsRequired();
            builder.Entity<Patient>().Property(p => p.Weight).IsRequired();
            builder.Entity<Patient>().Property(p => p.Height).IsRequired();
            builder.Entity<Patient>().Property(p => p.Country).IsRequired();
            builder.Entity<Patient>().Property(p => p.UserDataId).IsRequired();
            builder.Entity<Patient>()
                .HasOne(p => p.UserData)
                .WithOne(ud => ud.Patient)
                .HasForeignKey<Patient>(p => p.UserDataId);

            // User
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Code).IsRequired();
            builder.Entity<User>().Property(p => p.Username).IsRequired();
            builder.Entity<User>().Property(p => p.Token).IsRequired();

            // UserData
            builder.Entity<UserData>().ToTable("users_data");
            builder.Entity<UserData>().HasKey(p => p.Id);
            builder.Entity<UserData>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserData>().Property(p => p.State).IsRequired();
            builder.Entity<UserData>().Property(p => p.Email).IsRequired();
            builder.Entity<UserData>().Property(p => p.Name).IsRequired();
            builder.Entity<UserData>().Property(p => p.Lastname).IsRequired();
            builder.Entity<UserData>().Property(p => p.UserId).IsRequired();
            builder.Entity<UserData>()
                .HasOne(u => u.User)
                .WithOne(ud => ud.UserData)
                .HasForeignKey<UserData>(u => u.UserId)
                .HasPrincipalKey<User>(u => u.Id);

            // UserDevice
            builder.Entity<UserDevice>().ToTable("users_devices");
            builder.Entity<UserDevice>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserDevice>().Property(p => p.State).IsRequired();
            builder.Entity<UserDevice>().Property(p => p.UserDataId).IsRequired();
            builder.Entity<UserDevice>().Property(p => p.DeviceId).IsRequired();
            builder.Entity<UserDevice>()
                .HasOne(f => f.UserData)
                .WithOne(ud => ud.UserDevice)
                .HasForeignKey<UserDevice>(f => f.UserDataId);
            builder.Entity<UserDevice>()
                .HasOne(f => f.Device)
                .WithOne(d => d.UserDevice)
                .HasForeignKey<UserDevice>(f => f.DeviceId);



            builder.UseSnakeCaseNamingConvention();
        }
    }
}
