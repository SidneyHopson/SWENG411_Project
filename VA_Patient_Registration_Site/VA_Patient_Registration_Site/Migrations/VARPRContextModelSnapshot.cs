﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VA_Patient_Registration_Site.Models;

namespace VA_Patient_Registration_Site.Migrations
{
    [DbContext(typeof(VARPRContext))]
    partial class VARPRContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VA_Patient_Registration_Site.Models.Doctor", b =>
                {
                    b.Property<int>("Doc_id");

                    b.Property<string>("Doc_fname");

                    b.Property<string>("Doc_lname");

                    b.HasKey("Doc_id");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("VA_Patient_Registration_Site.Models.Patient", b =>
                {
                    b.Property<int>("Pat_id");

                    b.Property<DateTime>("DOB");

                    b.Property<int>("Doc_id");

                    b.Property<string>("Pat_fname");

                    b.Property<string>("Pat_lname");

                    b.HasKey("Pat_id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("VA_Patient_Registration_Site.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<bool>("IsDoc");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("VA_Patient_Registration_Site.Models.Doctor", b =>
                {
                    b.HasOne("VA_Patient_Registration_Site.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Doc_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VA_Patient_Registration_Site.Models.Patient", b =>
                {
                    b.HasOne("VA_Patient_Registration_Site.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Pat_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
