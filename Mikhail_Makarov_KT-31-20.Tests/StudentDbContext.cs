namespace Mikhail_Makarov_KT_31_20.Tests
{
    internal class StudentDbContext
    {
        private object dbContextOptions;

        public StudentDbContext(object dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }
    }
}