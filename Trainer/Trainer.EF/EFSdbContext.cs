using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Shared.Core.Models;

namespace Trainer.EF
{
    public partial class EFSdbContext : DbContext
    {
        public EFSdbContext()
        {
        }

        public EFSdbContext(DbContextOptions<EFSdbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-55PE9HK\MOHAMEDMAGDY;Database=EFS_Dev;Trusted_Connection=True");
            }
        }        
    }
}
