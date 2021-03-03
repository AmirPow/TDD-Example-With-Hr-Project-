using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HR.Persistence.Test
{
    [TestClass]
    public class UnitTest1 : HRDbContext
    {
        public UnitTest1() : base(new DbContextOptions<HRDbContext>())
        {
        }
        [TestMethod]
        public void TestMethod1()
        {
            var maps = DetectEntityMapping();
        }

    }
}