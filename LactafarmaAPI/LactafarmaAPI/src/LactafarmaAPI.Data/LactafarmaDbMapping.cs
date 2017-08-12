﻿using LactafarmaAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LactafarmaAPI.Data
{
    public class LactafarmaDbMapping
    {
        #region Public Methods

        public static void Configure(ModelBuilder modelBuilder)
        {
            MapLanguage(modelBuilder);
            MapBrand(modelBuilder);
            MapBrandMultilingual(modelBuilder);
            MapGroup(modelBuilder);
            MapGroupMultilingual(modelBuilder);

            MapToken(modelBuilder);
            MapUser(modelBuilder);
            MapFavorite(modelBuilder);
            MapDrug(modelBuilder);
            MapDrugBrand(modelBuilder);
            MapDrugMultilingual(modelBuilder);

            MapAlert(modelBuilder);
            MapAlertMultilingual(modelBuilder);
            MapAlias(modelBuilder);
            MapAliasMultilingual(modelBuilder);

            MapDrugAlternative(modelBuilder);
        }

        #endregion

        #region Private Methods

        private static void MapBrand(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Brand>().Ignore(e => e.EntityId).HasKey(e => e.Id);
            //modelBuilder.Entity<Brand>().HasMany(d => d.BrandsMultilingual);
        }

        private static void MapBrandMultilingual(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandMultilingual>().ToTable("Brands_Multilingual");

            modelBuilder.Entity<BrandMultilingual>()
                .HasKey(bc => new {bc.BrandId, bc.LanguageId});

            //modelBuilder.Entity<BrandMultilingual>()
            //    .HasOne(bc => bc.Brand).WithMany(bc => bc.BrandsMultilingual).HasForeignKey(f => f.BrandId);                

            //modelBuilder.Entity<BrandMultilingual>()
            //    .HasOne(bc => bc.Language).WithMany(bc => bc.BrandsMultilingual).HasForeignKey(f => f.LanguageId);               
        }

        private static void MapGroup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Groups");
            modelBuilder.Entity<Group>().Ignore(e => e.EntityId).HasKey(e => e.Id);
            //modelBuilder.Entity<Group>().HasMany(d => d.GroupsMultilingual);
        }

        private static void MapGroupMultilingual(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupMultilingual>().ToTable("Groups_Multilingual");

            modelBuilder.Entity<GroupMultilingual>()
                .HasKey(bc => new {bc.GroupId, bc.LanguageId});

            //modelBuilder.Entity<GroupMultilingual>()
            //    .HasOne(bc => bc.Group);                

            //modelBuilder.Entity<GroupMultilingual>()
            //    .HasOne(bc => bc.Language);                
        }

        private static void MapLanguage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().ToTable("Languages");
            modelBuilder.Entity<Language>().Ignore(e => e.EntityId).HasKey(e => e.Id);
        }

        private static void MapToken(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>().ToTable("Tokens");
            modelBuilder.Entity<Token>().Ignore(e => e.EntityId).HasKey(e => e.Id);
            //modelBuilder.Entity<Token>().HasOne(d => d.User);
        }

        private static void MapUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().Ignore(e => e.EntityId).HasKey(e => e.Id);
            //modelBuilder.Entity<User>().HasMany(d => d.Favorites);
            //modelBuilder.Entity<User>().HasMany(d => d.Tokens);
            //modelBuilder.Entity<User>().HasOne(d => d.Language);
        }

        private static void MapFavorite(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>().ToTable("Favorites");
            modelBuilder.Entity<Favorite>().Ignore(e => e.EntityId).HasKey(e => e.Id);
            //modelBuilder.Entity<Favorite>().HasOne(d => d.Drug);
            //modelBuilder.Entity<Favorite>().HasOne(d => d.User);
        }

        private static void MapDrug(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drug>().ToTable("Drugs");
            modelBuilder.Entity<Drug>().Ignore(e => e.EntityId).HasKey(e => e.Id);
            //modelBuilder.Entity<Drug>().HasOne(d => d.Group);
            //modelBuilder.Entity<Drug>().HasMany(d => d.DrugBrands);

            //modelBuilder.Entity<Drug>().HasMany(d => d.Alerts);
            //modelBuilder.Entity<Drug>().HasMany(d => d.Aliases);
            //modelBuilder.Entity<Drug>().HasMany(d => d.DrugAlternatives);
        }

        private static void MapDrugBrand(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrugBrand>().ToTable("DrugBrands");

            modelBuilder.Entity<DrugBrand>()
                .HasKey(bc => new {bc.BrandId, bc.DrugId});

            //modelBuilder.Entity<DrugBrand>()
            //    .HasOne(bc => bc.Drug)
            //    .WithMany(b => b.DrugBrands)
            //    .HasForeignKey(bc => bc.DrugId);

            //modelBuilder.Entity<DrugBrand>()
            //    .HasOne(bc => bc.Brand)
            //    .WithMany(c => c.DrugBrands)
            //    .HasForeignKey(bc => bc.BrandId);
        }

        private static void MapDrugMultilingual(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrugMultilingual>().ToTable("Drugs_Multilingual");

            modelBuilder.Entity<DrugMultilingual>()
                .HasKey(bc => new {bc.DrugId, bc.LanguageId});

            //modelBuilder.Entity<DrugMultilingual>()
            //    .HasOne(bc => bc.Drug)
            //    .WithMany(b => b.DrugsMultilingual)
            //    .HasForeignKey(bc => bc.DrugId);

            //modelBuilder.Entity<DrugMultilingual>()
            //    .HasOne(bc => bc.Language);                
        }

        private static void MapAlert(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>().ToTable("Alerts");
            modelBuilder.Entity<Alert>().Ignore(e => e.EntityId).HasKey(e => e.Id);
            //modelBuilder.Entity<Alert>().HasOne(d => d.Drug).WithMany(d => d.Alerts);
        }

        private static void MapAlertMultilingual(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlertMultilingual>().ToTable("Alerts_Multilingual");

            modelBuilder.Entity<AlertMultilingual>()
                .HasKey(bc => new {bc.AlertId, bc.LanguageId});

            //modelBuilder.Entity<AlertMultilingual>()
            //    .HasOne(bc => bc.Alert)
            //    .WithMany(b => b.AlertsMultilingual)
            //    .HasForeignKey(bc => bc.AlertId);

            //modelBuilder.Entity<AlertMultilingual>()
            //    .HasOne(bc => bc.Language);                
        }

        private static void MapAlias(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alias>().ToTable("Aliases");
            modelBuilder.Entity<Alias>().Ignore(e => e.EntityId).HasKey(e => e.Id);
            modelBuilder.Entity<Alias>().HasOne(d => d.Drug);
            modelBuilder.Entity<Alias>().HasMany(d => d.AliasMultilingual);
        }

        private static void MapAliasMultilingual(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AliasMultilingual>().ToTable("Aliases_Multilingual");

            modelBuilder.Entity<AliasMultilingual>()
                .HasKey(bc => new {bc.AliasId, bc.LanguageId});
            //modelBuilder.Entity<AliasMultilingual>()
            //    .HasOne(bc => bc.Language);

            //modelBuilder.Entity<AliasMultilingual>()
            //    .HasOne(bc => bc.Alias)
            //    .WithMany(b => b.AliasMultilingual)
            //    .HasForeignKey(bc => bc.AliasId);                   
        }

        private static void MapDrugAlternative(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrugAlternative>().ToTable("DrugAlternatives");

            modelBuilder.Entity<DrugAlternative>()
                .HasKey(bc => new {bc.DrugId, bc.DrugAlternativeId});

            //modelBuilder.Entity<DrugAlternative>()
            //    .HasOne(bc => bc.Drug)
            //    .WithMany(b => b.DrugAlternatives)
            //    .HasForeignKey(bc => bc.DrugId);

            //modelBuilder.Entity<DrugAlternative>()
            //    .HasOne(bc => bc.DrugOption)
            //    .WithMany(c => c.DrugAlternatives)
            //    .HasForeignKey(bc => bc.DrugAlternativeId);
        }

        #endregion
    }
}