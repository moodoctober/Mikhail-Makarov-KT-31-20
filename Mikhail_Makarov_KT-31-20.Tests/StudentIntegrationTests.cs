using Makarov_Mikhail_Kt_31_20_Lab1.Database;
using Makarov_Mikhail_Kt_31_20_Lab1.interfaces.StudentInterfaces;
using Makarov_Mikhail_Kt_31_20_Lab1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mikhail_Makarov_KT_31_20.Tests.GroupTests;
using Group = Makarov_Mikhail_Kt_31_20_Lab1.Models.Group;

namespace Mikhail_Makarov_KT_31_20.Tests
{
    public class TestClass
    {
        public async Task GetStudentsByGroupAsync_KT3120_TwoObjects()
        {
            // Arrange
            var _dbContextOptions = new DbContextOptionsBuilder<MakarovDbContext>().Options;

            var ctx = new MakarovDbContext(_dbContextOptions);
          //  var ctx = new MakarovDbContext(_dbContextOptions);

            // var studentService = new IStudentService(ctx);
            var studentService = new StudentFilterService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-20"
                },
                new Group
                {
                    GroupName = "KT-41-20"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Makarov_Mikhail_Kt_31_20_Lab1.Filters.StudentFilters.StudentGroupFilter
            {
                GroupName = "KT-31-20"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }
    }
}