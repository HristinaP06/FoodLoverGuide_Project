using FoodLoverGuide.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Tests.Mock
{
    public class DbMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("FoodLoverGuideInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

                return new ApplicationDbContext(options);
            }
        }
    }
}
