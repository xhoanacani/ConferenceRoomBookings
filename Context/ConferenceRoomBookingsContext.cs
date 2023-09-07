using ConferenceRoomBookings.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ConferenceRoomBookings.Models;

namespace ConferenceRoomBookings.Context;

public partial class ConferenceRoomBookingsContext : IdentityDbContext
{
    public ConferenceRoomBookingsContext()
    {
    }

    public ConferenceRoomBookingsContext(DbContextOptions<ConferenceRoomBookingsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; } = null!;
    public virtual DbSet<ConferenceRoom> ConferenceRooms { get; set; } = null!;
    public virtual DbSet<ReservationHolder> ReservationHolders { get; set; } = null!;
    public virtual DbSet<UnavailabilityPeriod> UnavailabilityPeriods { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ConferenceRoomBookings;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.Code).HasDefaultValueSql("(newid())");

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Room)
                .WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_ConferenceRooms");
        });

        modelBuilder.Entity<ConferenceRoom>(entity =>
        {
            entity.Property(e => e.CodeRoom);
        });

        modelBuilder.Entity<ReservationHolder>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.Property(e => e.IdCardNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.SurName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Booking)
                .WithMany(p => p.ReservationHolders)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationHolders_Bookings");
        });

        modelBuilder.Entity<UnavailabilityPeriod>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.Reasons).HasMaxLength(250);

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Room)
                .WithMany(p => p.UnavailabilityPeriods)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UnavailabilityPeriods_ConferenceRooms");
        });

        base.OnModelCreating(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<ConferenceRoomBookings.Models.BookingModel>? BookingModel { get; set; }

    public DbSet<ConferenceRoomBookings.Models.ReservationHolderModel>? ReservationHolderModel { get; set; }
}
