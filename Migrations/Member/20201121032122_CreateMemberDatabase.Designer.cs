﻿// <auto-generated />
using CfpgFamilyTree.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CfpgFamilyTree.Migrations.Member
{
    [DbContext(typeof(MemberContext))]
    [Migration("20201121032122_CreateMemberDatabase")]
    partial class CreateMemberDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CfpgFamilyTree.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BirthDay")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int>("BirthMonth")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int>("BirthYear")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<int>("DeathDay")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int>("DeathMonth")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<int>("DeathYear")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasSpouse")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActiveUser")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreferredName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryParent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryParent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spouse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
