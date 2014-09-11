using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using OnlineShop.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace OnlineShop.Data
{
    public class DbInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DbInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.CellPhones.Count()>0)
            {
                return;
            }

            Random rand = new Random();

            List<Manufacturer> sampleManufacturer = new List<Manufacturer>();
            sampleManufacturer.Add(new Manufacturer { Name = "Google"});
            sampleManufacturer.Add(new Manufacturer { Name = "HTC" });
            sampleManufacturer.Add(new Manufacturer { Name = "Google" });
            sampleManufacturer.Add(new Manufacturer { Name = "LG" });
            sampleManufacturer.Add(new Manufacturer { Name = "Samsung" });
            sampleManufacturer.Add(new Manufacturer { Name = "LG" });
            sampleManufacturer.Add(new Manufacturer { Name = "Google" });
            sampleManufacturer.Add(new Manufacturer { Name = "Samsung" });
            sampleManufacturer.Add(new Manufacturer { Name = "Iphone" });
            sampleManufacturer.Add(new Manufacturer { Name = "Google" });


            ApplicationUser user = new ApplicationUser() { UserName = "TestUser", Email = "testuser@testuser.com"};

            for (int i = 0; i < 10; i++ )
            {
                CellPhone cellPhone = new CellPhone();
                cellPhone.Storage = rand.Next(10,50);
                cellPhone.ImageUrl = "http://www.technobuffalo.com/wp-content/uploads/2013/10/Nexus-5-Press-Image-001-1280x874.jpg";
                cellPhone.Manufacturer = sampleManufacturer[i];
                cellPhone.Model = "Nexus 5";
                cellPhone.Display = 5.7;
                cellPhone.Price = rand.Next(4000,5500);
                cellPhone.Ram = rand.Next(2,8);
                cellPhone.AdditionalParts = "Bluetooth";
                
                var voteCount = rand.Next(0,10);
                for (int j = 0; j<voteCount; j++)
                {
                    cellPhone.Vote.Add(new Vote { CellPhone = cellPhone, VotedBy = user, VotedById = user.Id});
                }

                var commentsCount = rand.Next(0, 10);
                for (int j = 0; j < commentsCount; j++)
                {
                    cellPhone.Comment.Add(new Comment { Content = "Greate Phone with cool features!", Author = user, AuthorId = user.Id });
                }

                context.CellPhones.Add(cellPhone);
            }
       
        
        SaveChanges(context);
        base.Seed(context);
        }
        private void SaveChanges(ApplicationDbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
        }
    }
}
