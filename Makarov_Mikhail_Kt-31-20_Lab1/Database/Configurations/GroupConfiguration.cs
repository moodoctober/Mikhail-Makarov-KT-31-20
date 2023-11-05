using Makarov_Mikhail_Kt_31_20_Lab1.Database.Helpers;
using Makarov_Mikhail_Kt_31_20_Lab1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Makarov_Mikhail_Kt_31_20_Lab1.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {

        private const string TableName = "ct_group";
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(p => p.GroupId).HasName($"pk_{TableName}_group_id");
            builder.Property(p => p.GroupId).ValueGeneratedOnAdd();
            builder.Property(p => p.GroupId).HasColumnName("group_id").HasComment("Идентификатор записи группы");

            builder.Property(s => s.GroupName).IsRequired().HasColumnName("c_group_groupname")
               .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Название группы");

            builder.ToTable(TableName);
        }
       
    }
}
