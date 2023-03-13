﻿namespace BeyazEsyaServisSatis.DAL.Migrations
{
    using BeyazEsyaServisSatis.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeyazEsyaServisSatis.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            if (!context.Kullanicilar.Any())
            {
                var rol = context.Roller.Add(new Rol() 
                {
                    Adi = "Admin"
                });

                context.Kullanicilar.Add(new Kullanici()
                {
                    Adi = "Admin",
                    AktifMi = true,
                    EklenmeTarihi = DateTime.Now,
                    Email = "admin@otoservissatis.tc",
                    KullaniciAdi = "admin",
                    Sifre = "123456",
                    Rol = rol,
                    RolId = rol.Id
                });
                context.SaveChanges();
            }
            base.Seed(context);
        }
    }
}
