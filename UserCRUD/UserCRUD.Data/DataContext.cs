using Microsoft.EntityFrameworkCore;
using System;

namespace UserCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {  
        }
    }
}
