using System.Data.Entity.ModelConfiguration;
using Shindy.Model;

namespace Shindy.Data.Sql.Mapping
{
    public class AttendeeMap : EntityTypeConfiguration<Attendee>
    {
        public AttendeeMap()
        {
            // Primary Key
            HasKey(t => t.AttendeeID);

            // Properties
            Property(t => t.CreatedUser)
                .HasMaxLength(50);

            Property(t => t.LastUpdatedUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Attendee");
            Property(t => t.AttendeeID).HasColumnName("Attendee_ID");
            Property(t => t.EventID).HasColumnName("EventID");
            Property(t => t.PersonID).HasColumnName("PersonID");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            Property(t => t.LastUpdatedDate).HasColumnName("LastUpdatedDate");
            Property(t => t.LastUpdatedUser).HasColumnName("LastUpdatedUser");

            // Relationships
            HasRequired(t => t.Event)
                .WithMany(t => t.Attendees)
                .HasForeignKey(d => d.EventID);
            HasRequired(t => t.Person)
                .WithMany(t => t.Attendees)
                .HasForeignKey(d => d.PersonID);

        }
    }
}
