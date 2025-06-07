using D2R.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace D2R.Models;

public partial class DisasterReliefContext : DbContext
{
    public DisasterReliefContext()
    {
    }

    public DisasterReliefContext(DbContextOptions<DisasterReliefContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<CampaignItem> CampaignItems { get; set; }

    public virtual DbSet<DisasterLevel> DisasterLevels { get; set; }

    public virtual DbSet<DisasterType> DisasterTypes { get; set; }

    public virtual DbSet<DistributionLog> DistributionLogs { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<DonationItem> DonationItems { get; set; }

    public virtual DbSet<Donor> Donors { get; set; }

    public virtual DbSet<ItemCategory> ItemCategories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SyncLog> SyncLogs { get; set; }

    public virtual DbSet<SyncLogItem> SyncLogItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseItem> WarehouseItems { get; set; }

    public virtual DbSet<WarehouseStock> WarehouseStocks { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = AppConfig.Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PRIMARY");

            entity.ToTable("Area");

            entity.Property(e => e.District).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Province).HasMaxLength(100);
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasKey(e => e.CampaignId).HasName("PRIMARY");

            entity.ToTable("Campaign");

            entity.HasIndex(e => e.AreaId, "AreaId");

            entity.HasIndex(e => e.DisasterLevelId, "DisasterLevelId");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Area).WithMany(p => p.Campaigns)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("Campaign_ibfk_1");

            entity.HasOne(d => d.DisasterLevel).WithMany(p => p.Campaigns)
                .HasForeignKey(d => d.DisasterLevelId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Campaign_ibfk_2");
        });

        modelBuilder.Entity<CampaignItem>(entity =>
        {
            entity.HasKey(e => new { e.CampaignId, e.ItemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("CampaignItem");

            entity.HasIndex(e => e.ItemId, "ItemId");

            entity.HasOne(d => d.Campaign).WithMany(p => p.CampaignItems)
                .HasForeignKey(d => d.CampaignId)
                .HasConstraintName("CampaignItem_ibfk_1");

            entity.HasOne(d => d.Item).WithMany(p => p.CampaignItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("CampaignItem_ibfk_2");
        });

        modelBuilder.Entity<DisasterLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PRIMARY");

            entity.ToTable("DisasterLevel");

            entity.HasIndex(e => e.DisasterTypeId, "DisasterTypeId");

            entity.Property(e => e.Level).HasMaxLength(50);

            entity.HasOne(d => d.DisasterType).WithMany(p => p.DisasterLevels)
                .HasForeignKey(d => d.DisasterTypeId)
                .HasConstraintName("DisasterLevel_ibfk_1");
        });

        modelBuilder.Entity<DisasterType>(entity =>
        {
            entity.HasKey(e => e.DisasterTypeId).HasName("PRIMARY");

            entity.ToTable("DisasterType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DistributionLog>(entity =>
        {
            entity.HasKey(e => e.DistributionId).HasName("PRIMARY");

            entity.ToTable("DistributionLog");

            entity.HasIndex(e => e.AreaId, "AreaId");

            entity.HasIndex(e => e.CampaignId, "CampaignId");

            entity.HasIndex(e => e.ItemId, "ItemId");

            entity.Property(e => e.DistributionDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Area).WithMany(p => p.DistributionLogs)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("DistributionLog_ibfk_3");

            entity.HasOne(d => d.Campaign).WithMany(p => p.DistributionLogs)
                .HasForeignKey(d => d.CampaignId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("DistributionLog_ibfk_1");

            entity.HasOne(d => d.Item).WithMany(p => p.DistributionLogs)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("DistributionLog_ibfk_2");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PRIMARY");

            entity.ToTable("Donation");

            entity.HasIndex(e => e.AreaId, "AreaId");

            entity.HasIndex(e => e.DonorId, "DonorId");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Area).WithMany(p => p.Donations)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("Donation_ibfk_2");

            entity.HasOne(d => d.Donor).WithMany(p => p.Donations)
                .HasForeignKey(d => d.DonorId)
                .HasConstraintName("Donation_ibfk_1");
        });

        modelBuilder.Entity<DonationItem>(entity =>
        {
            entity.HasKey(e => e.DonationItemId).HasName("PRIMARY");

            entity.ToTable("DonationItem");

            entity.HasIndex(e => e.DonationId, "DonationId");

            entity.HasIndex(e => e.ItemId, "ItemId");

            entity.Property(e => e.Unit).HasMaxLength(50);

            entity.HasOne(d => d.Donation).WithMany(p => p.DonationItems)
                .HasForeignKey(d => d.DonationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("DonationItem_ibfk_1");

            entity.HasOne(d => d.Item).WithMany(p => p.DonationItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("DonationItem_ibfk_2");
        });

        modelBuilder.Entity<Donor>(entity =>
        {
            entity.HasKey(e => e.DonorId).HasName("PRIMARY");

            entity.ToTable("Donor");

            entity.HasIndex(e => e.Cccd, "CCCD").IsUnique();

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.Phone, "Phone").IsUnique();

            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<ItemCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("ItemCategory");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "RoleName").IsUnique();

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<SyncLog>(entity =>
        {
            entity.HasKey(e => e.SyncId).HasName("PRIMARY");

            entity.ToTable("SyncLog");

            entity.HasIndex(e => e.WarehouseId, "WarehouseId");

            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SyncDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.SyncLogs)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SyncLog_ibfk_1");
        });

        modelBuilder.Entity<SyncLogItem>(entity =>
        {
            entity.HasKey(e => e.SyncLogItemId).HasName("PRIMARY");

            entity.ToTable("SyncLogItem");

            entity.HasIndex(e => e.ItemId, "ItemId");

            entity.HasIndex(e => e.SyncId, "SyncId");


            entity.HasOne(d => d.Item).WithMany(p => p.SyncLogItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SyncLogItem_ibfk_2");

            entity.HasOne(d => d.Sync).WithMany(p => p.SyncLogItems)
                .HasForeignKey(d => d.SyncId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SyncLogItem_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("User");

            entity.HasIndex(e => e.AreaId, "AreaId");

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.HasIndex(e => e.WarehouseId, "WarehouseId");

            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Salt).HasMaxLength(256);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Area).WithMany(p => p.Users)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("User_ibfk_2");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("User_ibfk_1");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Users)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("User_ibfk_3");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("PRIMARY");

            entity.ToTable("Warehouse");

            entity.HasIndex(e => e.AreaId, "AreaId");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.Area).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Warehouse_ibfk_1");
        });

        modelBuilder.Entity<WarehouseItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.ToTable("WarehouseItem");

            entity.HasIndex(e => e.CategoryId, "CategoryId");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Unit).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.WarehouseItems)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("WarehouseItem_ibfk_1");
        });

        modelBuilder.Entity<WarehouseStock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PRIMARY");

            entity.ToTable("WarehouseStock");

            entity.HasIndex(e => e.ItemId, "ItemId");

            entity.HasIndex(e => e.WarehouseId, "WarehouseId");

            entity.Property(e => e.LastUpdated)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.Item).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("WarehouseStock_ibfk_2");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("WarehouseStock_ibfk_1");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");
            entity.HasKey(e => e.NotificationId);

            entity.Property(e => e.Content).HasMaxLength(255).IsRequired();
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.User)
            .WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Notification_User");


            entity.HasOne(d => d.Campaign)
                .WithMany()
                .HasForeignKey(d => d.CampaignId)
                .HasConstraintName("FK_Notification_Campaign");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
