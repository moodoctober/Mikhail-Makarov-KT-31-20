using Makarov_Mikhail_Kt_31_20_Lab1.Database.Helpers;
using Makarov_Mikhail_Kt_31_20_Lab1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makarov_Mikhail_Kt_31_20_Lab1.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "ct_student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.StudentId).HasName($"pk_{TableName}_student_id");
            builder.Property(p => p.StudentId).ValueGeneratedOnAdd();
            builder.Property(p => p.StudentId).HasColumnName("student_id").HasComment("Идентификатор записи студента");

            builder.Property(s => s.FirstName).IsRequired().HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Имя студента");

            builder.Property(s => s.LastName).IsRequired().HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Фамилия студента");

            builder.Property(s => s.MiddleName).IsRequired().HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100).HasComment("Отчество студента");

            builder.Property(s => s.GroupId).IsRequired().HasColumnName("c_student_group_id")
               .HasColumnType(ColumnType.Int).HasComment("Идентификатор группы");

            builder.HasOne(s => s.Group)
                   .WithMany()
                   .HasForeignKey(s => s.GroupId).HasConstraintName("fk_f_group_id").OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(TableName).HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");
            builder.Navigation(p => p.Group).AutoInclude();

        }
    }
}
