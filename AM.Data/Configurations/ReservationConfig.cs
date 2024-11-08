using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Configurations
{
    internal class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(r => r.MyPassenger)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.PassengerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.MyFlight)
                .WithMany(f => f.Reservations)
                .HasForeignKey(r => r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(r => new { r.FlightId, r.PassengerId });
        }

    }
}