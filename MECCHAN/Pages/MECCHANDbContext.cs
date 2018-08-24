using MECCHAN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MECCHAN.Pages
{
    public class MECCHANDbContext : IdentityDbContext<IdentityUser>
    {
        public MECCHANDbContext(DbContextOptions<MECCHANDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Message> Message { get; set; }
    }
}
