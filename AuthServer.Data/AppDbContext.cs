using AuthServer.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data
{
    //models deki entityleri identity üyelik sisteminde tabloları oluşturduğu veri tabanında kullanmak istiyorum
    //identity api ile beraber üyelik sistemiyle ilgili tablolara ulaş
    //modeldeki 2 tabloyu da aynı dbcontext içinde tutmak istiyorum.
    //sqlserver daki veri tabanına karşılık gelecek.
    public class AppDbContext:IdentityDbContext<UserApp,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)//dbcontextoptions startup tarafında dolacak.
                                                                                //AppDbContext üzerinden options ekleyeceğim
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)//product ve refreshtoken ayarı
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);//verilen assembly ile assembly içindeki tüm configuration 
                                                                        //dosyalarını ekleyeceğim.
            base.OnModelCreating(builder);
        }
    }
}
