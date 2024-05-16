using E_Commerce.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repositry.DataContext
{
    public class E_commIdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public E_commIdentityDataContext(DbContextOptions<E_commIdentityDataContext> options) : base(options)
        {
        }
    }
}
