// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceType.Persistese.Database;

#nullable disable

namespace ServiceType.Persistese.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220919035128_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ServiceCategories")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServiceType.Domain.ServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategories", "ServiceCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = " Service 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = " Service 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = " Service 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = " Service 4"
                        },
                        new
                        {
                            Id = 5,
                            Name = " Service 5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
