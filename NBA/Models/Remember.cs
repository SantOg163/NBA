using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NBA.Models
{
    public partial class Remember : DbContext
    {
        private static Remember _context;
        public static Remember GetContext()
        {
            if (_context == null)
                _context = new Remember();
            return _context;
        }
        public Remember()
            : base("name=Remember")
        {
        }

        public virtual DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
