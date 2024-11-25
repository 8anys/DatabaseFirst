using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.AirlinesModels;

public partial class ComputerStoreDataBaseContext : DbContext
{
    public ComputerStoreDataBaseContext()
    {
    }

    public ComputerStoreDataBaseContext(DbContextOptions<ComputerStoreDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<Cooler> Coolers { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<EducationLevel> EducationLevels { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Hdd> Hdds { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Motherboard> Motherboards { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonContact> PersonContacts { get; set; }

    public virtual DbSet<Processor> Processors { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Ram> Rams { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Ssd> Ssds { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<Videocard> Videocards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=Maroon52015;Database=ComputerStoreDataBase;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.HasIndex(e => e.CategoryName, "category_name").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(30)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => e.DistrictId, "district_id");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(30)
                .HasColumnName("city_name");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");

            entity.HasOne(d => d.District).WithMany(p => p.Cities)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("city_ibfk_1");
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.HasKey(e => e.ContactTypeId).HasName("PRIMARY");

            entity.ToTable("contact_type");

            entity.HasIndex(e => e.ContactType1, "contact_type").IsUnique();

            entity.Property(e => e.ContactTypeId).HasColumnName("contact_type_id");
            entity.Property(e => e.ContactType1)
                .HasMaxLength(30)
                .HasColumnName("contact_type");
        });

        modelBuilder.Entity<Cooler>(entity =>
        {
            entity.HasKey(e => e.CoolerId).HasName("PRIMARY");

            entity.ToTable("cooler");

            entity.HasIndex(e => e.CoolerName, "cooler_name").IsUnique();

            entity.Property(e => e.CoolerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("cooler_id");
            entity.Property(e => e.CoolerName)
                .HasMaxLength(30)
                .HasColumnName("cooler_name");

            entity.HasOne(d => d.CoolerNavigation).WithOne(p => p.Cooler)
                .HasForeignKey<Cooler>(d => d.CoolerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("cooler_ibfk_1");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PRIMARY");

            entity.ToTable("district");

            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(30)
                .HasColumnName("district_name");
        });

        modelBuilder.Entity<EducationLevel>(entity =>
        {
            entity.HasKey(e => e.EducationLevelId).HasName("PRIMARY");

            entity.ToTable("education_level");

            entity.HasIndex(e => e.EducationLevelFull, "education_level_full").IsUnique();

            entity.Property(e => e.EducationLevelId).HasColumnName("education_level_id");
            entity.Property(e => e.EducationLevelFull)
                .HasMaxLength(100)
                .HasColumnName("education_level_full");
            entity.Property(e => e.EducationLevelShort)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("education_level_short");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.JobId, "job_id");

            entity.HasIndex(e => e.PersonId, "person_id");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_2");

            entity.HasOne(d => d.Person).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_1");
        });

        modelBuilder.Entity<Hdd>(entity =>
        {
            entity.HasKey(e => e.HddId).HasName("PRIMARY");

            entity.ToTable("hdd");

            entity.HasIndex(e => e.HddName, "HDD_name").IsUnique();

            entity.Property(e => e.HddId)
                .ValueGeneratedOnAdd()
                .HasColumnName("HDD_id");
            entity.Property(e => e.HddMemory)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("HDD_memory");
            entity.Property(e => e.HddName)
                .HasMaxLength(30)
                .HasColumnName("HDD_name");

            entity.HasOne(d => d.HddNavigation).WithOne(p => p.Hdd)
                .HasForeignKey<Hdd>(d => d.HddId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hdd_ibfk_1");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PRIMARY");

            entity.ToTable("job");

            entity.HasIndex(e => e.JobName, "job_name").IsUnique();

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.JobName)
                .HasMaxLength(30)
                .HasColumnName("job_name");
        });

        modelBuilder.Entity<Motherboard>(entity =>
        {
            entity.HasKey(e => e.MotherboardId).HasName("PRIMARY");

            entity.ToTable("motherboard");

            entity.HasIndex(e => e.MotherboardName, "motherboard_name").IsUnique();

            entity.Property(e => e.MotherboardId)
                .ValueGeneratedOnAdd()
                .HasColumnName("motherboard_id");
            entity.Property(e => e.MotherboardName)
                .HasMaxLength(30)
                .HasColumnName("motherboard_name");

            entity.HasOne(d => d.MotherboardNavigation).WithOne(p => p.Motherboard)
                .HasForeignKey<Motherboard>(d => d.MotherboardId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("motherboard_ibfk_1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PRIMARY");

            entity.ToTable("person");

            entity.HasIndex(e => e.EducationLevelId, "education_level_id");

            entity.HasIndex(e => e.SpecialityId, "speciality_id");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.EducationLevelId).HasColumnName("education_level_id");
            entity.Property(e => e.Fname)
                .HasMaxLength(30)
                .HasColumnName("fname");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.Sname)
                .HasMaxLength(30)
                .HasColumnName("sname");
            entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");
            entity.Property(e => e.WhenBorn)
                .HasColumnType("date")
                .HasColumnName("when_born");

            entity.HasOne(d => d.EducationLevel).WithMany(p => p.People)
                .HasForeignKey(d => d.EducationLevelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("person_ibfk_1");

            entity.HasOne(d => d.Speciality).WithMany(p => p.People)
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("person_ibfk_2");
        });

        modelBuilder.Entity<PersonContact>(entity =>
        {
            entity.HasKey(e => e.PersonContactId).HasName("PRIMARY");

            entity.ToTable("person_contact");

            entity.HasIndex(e => e.ContactTypeId, "contact_type_id");

            entity.HasIndex(e => e.PersonId, "person_id");

            entity.Property(e => e.PersonContactId).HasColumnName("person_contact_id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.ContactTypeId).HasColumnName("contact_type_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.ContactType).WithMany(p => p.PersonContacts)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("person_contact_ibfk_2");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonContacts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("person_contact_ibfk_1");
        });

        modelBuilder.Entity<Processor>(entity =>
        {
            entity.HasKey(e => e.ProcessorId).HasName("PRIMARY");

            entity.ToTable("processor");

            entity.HasIndex(e => e.ProcessorName, "processor_name").IsUnique();

            entity.Property(e => e.ProcessorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("processor_id");
            entity.Property(e => e.ProcessorName)
                .HasMaxLength(30)
                .HasColumnName("processor_name");
            entity.Property(e => e.ProcessprCore)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("processpr_core");

            entity.HasOne(d => d.ProcessorNavigation).WithOne(p => p.Processor)
                .HasForeignKey<Processor>(d => d.ProcessorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("processor_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(30)
                .HasColumnName("product_name");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("product_ibfk_1");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchasesId).HasName("PRIMARY");

            entity.ToTable("purchases");

            entity.HasIndex(e => e.EmployeeId, "employee_id");

            entity.Property(e => e.PurchasesId).HasColumnName("purchases_id");
            entity.Property(e => e.DataPurchase)
                .HasColumnType("date")
                .HasColumnName("data_purchase");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("purchases_ibfk_1");
        });

        modelBuilder.Entity<Ram>(entity =>
        {
            entity.HasKey(e => e.RamId).HasName("PRIMARY");

            entity.ToTable("ram");

            entity.HasIndex(e => e.RamName, "RAM_name").IsUnique();

            entity.Property(e => e.RamId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RAM_id");
            entity.Property(e => e.RamName)
                .HasMaxLength(30)
                .HasColumnName("RAM_name");

            entity.HasOne(d => d.RamNavigation).WithOne(p => p.Ram)
                .HasForeignKey<Ram>(d => d.RamId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ram_ibfk_1");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.SpecialityId).HasName("PRIMARY");

            entity.ToTable("speciality");

            entity.HasIndex(e => e.SpecialityFullName, "speciality_full_name").IsUnique();

            entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");
            entity.Property(e => e.SpecialityFullName)
                .HasMaxLength(100)
                .HasColumnName("speciality_full_name");
            entity.Property(e => e.SpecialityShortName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("speciality_short_name");
        });

        modelBuilder.Entity<Ssd>(entity =>
        {
            entity.HasKey(e => e.SsdId).HasName("PRIMARY");

            entity.ToTable("ssd");

            entity.HasIndex(e => e.SsdName, "SSD_name").IsUnique();

            entity.Property(e => e.SsdId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SSD_id");
            entity.Property(e => e.SsdMemory)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SSD_memory");
            entity.Property(e => e.SsdName)
                .HasMaxLength(30)
                .HasColumnName("SSD_name");

            entity.HasOne(d => d.SsdNavigation).WithOne(p => p.Ssd)
                .HasForeignKey<Ssd>(d => d.SsdId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ssd_ibfk_1");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PRIMARY");

            entity.ToTable("store");

            entity.HasIndex(e => e.EmployeeId, "employee_id");

            entity.HasIndex(e => e.StoreFullName, "store_full_name").IsUnique();

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.StoreFullName)
                .HasMaxLength(100)
                .HasColumnName("store_full_name");

            entity.HasOne(d => d.Employee).WithMany(p => p.Stores)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("store_ibfk_1");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("PRIMARY");

            entity.ToTable("street");

            entity.HasIndex(e => e.CityId, "city_id");

            entity.Property(e => e.StreetId).HasColumnName("street_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Street1)
                .HasMaxLength(150)
                .HasColumnName("street");

            entity.HasOne(d => d.City).WithMany(p => p.Streets)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("street_ibfk_1");
        });

        modelBuilder.Entity<Videocard>(entity =>
        {
            entity.HasKey(e => e.VideocardId).HasName("PRIMARY");

            entity.ToTable("videocard");

            entity.HasIndex(e => e.VideocardName, "videocard_name").IsUnique();

            entity.Property(e => e.VideocardId)
                .ValueGeneratedOnAdd()
                .HasColumnName("videocard_id");
            entity.Property(e => e.VideocardName)
                .HasMaxLength(100)
                .HasColumnName("videocard_name");
            entity.Property(e => e.VideocardSeries)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("videocard_series");

            entity.HasOne(d => d.VideocardNavigation).WithOne(p => p.Videocard)
                .HasForeignKey<Videocard>(d => d.VideocardId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("videocard_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
