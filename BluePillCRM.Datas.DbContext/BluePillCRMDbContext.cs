using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Datas.DbContext;

public partial class BluePillCRMDbContext : DbContext
{
    public BluePillCRMDbContext()
    {
    }

    public BluePillCRMDbContext(DbContextOptions<BluePillCRMDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CrmConfig> CrmConfigs { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<QuotesProduct> QuotesProducts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Taxis> Taxes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=bluepillcrm;Port=3306;User Id=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.AccessLevel, "access_level_roles");

            entity.HasIndex(e => e.AccountType, "accounts_account_type");

            entity.HasIndex(e => e.BillingAddressId, "accounts_billing_address");

            entity.HasIndex(e => e.DeliveryAddressId, "accounts_delivery_address");

            entity.HasIndex(e => e.PaymentMethodId, "accounts_payment_methods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.AccountType)
                .HasDefaultValueSql("'1'")
                .HasColumnName("account_type");
            entity.Property(e => e.BillingAddressId).HasColumnName("billing_address_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(256)
                .HasColumnName("company_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeliveryAddressId).HasColumnName("delivery_address_id");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.MainEmail)
                .HasMaxLength(256)
                .HasColumnName("main_email");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(64)
                .HasColumnName("phone_number");
            entity.Property(e => e.Siret)
                .HasMaxLength(256)
                .HasColumnName("siret");
            entity.Property(e => e.TvaNumber)
                .HasMaxLength(64)
                .HasColumnName("tva_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(256)
                .HasColumnName("website_url");

            entity.HasOne(d => d.AccessLevelNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccessLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("access_level_roles");

            entity.HasOne(d => d.AccountTypeNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accounts_account_type");

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.AccountBillingAddresses)
                .HasForeignKey(d => d.BillingAddressId)
                .HasConstraintName("accounts_billing_address");

            entity.HasOne(d => d.DeliveryAddress).WithMany(p => p.AccountDeliveryAddresses)
                .HasForeignKey(d => d.DeliveryAddressId)
                .HasConstraintName("accounts_delivery_address");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("accounts_payment_methods");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("account_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => e.AccessLevel, "address_access_level");

            entity.HasIndex(e => e.CountryId, "address_country_id");

            entity.HasIndex(e => e.CreatedBy, "address_created_by");

            entity.HasIndex(e => e.ModifiedBy, "address_modified_by");

            entity.HasIndex(e => e.UserId, "address_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.City)
                .HasMaxLength(256)
                .HasColumnName("city");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(256)
                .HasColumnName("postal_code");
            entity.Property(e => e.Street)
                .HasMaxLength(256)
                .HasColumnName("street");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.AccessLevelNavigation).WithMany(p => p.AddressAccessLevelNavigations)
                .HasForeignKey(d => d.AccessLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_access_level");

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_country_id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AddressCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_created_by");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.AddressModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_modified_by");

            entity.HasOne(d => d.User).WithMany(p => p.AddressUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_user_id");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.AccessLevel, "contact_access_level_roles");

            entity.HasIndex(e => e.CreatedBy, "contact_created_by");

            entity.HasIndex(e => e.OwnerId, "contact_owner_id");

            entity.HasIndex(e => e.ModifiedBy, "contact_updated_by");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(512)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.EnterprisePhone)
                .HasMaxLength(64)
                .HasColumnName("enterprise_phone");
            entity.Property(e => e.IsDeactivated).HasColumnName("is_deactivated");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(64)
                .HasColumnName("mobile_phone");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AccessLevelNavigation).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.AccessLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contact_access_level_roles");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ContactCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contact_created_by");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ContactModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("contact_updated_by");

            entity.HasOne(d => d.Owner).WithMany(p => p.ContactOwners)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contact_owner_id");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(256)
                .HasColumnName("country_code");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CrmConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("crm_config");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.MaxAccounts).HasColumnName("max_accounts");
            entity.Property(e => e.MaxContacts).HasColumnName("max_contacts");
            entity.Property(e => e.MaxUsers).HasColumnName("max_users");
            entity.Property(e => e.MonthlyCost)
                .HasPrecision(10)
                .HasColumnName("monthly_cost");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Title)
                .HasMaxLength(256)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment_methods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .HasColumnName("description");
            entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(256)
                .HasColumnName("product_name");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(256)
                .HasColumnName("serial_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("quotes");

            entity.HasIndex(e => e.AccessLevel, "quotes_access_level");

            entity.HasIndex(e => e.AccountId, "quotes_account_id");

            entity.HasIndex(e => e.ContactId, "quotes_contact_id");

            entity.HasIndex(e => e.Payment, "quotes_payment_methods");

            entity.HasIndex(e => e.TaxesId, "quotes_taxes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .HasColumnName("description");
            entity.Property(e => e.EmailSendTo).HasColumnName("email_send_to");
            entity.Property(e => e.Payment).HasColumnName("payment");
            entity.Property(e => e.QuoteNumber)
                .HasMaxLength(256)
                .HasColumnName("quote_number");
            entity.Property(e => e.QuoteStatus).HasColumnName("quote_status");
            entity.Property(e => e.SendMethodId).HasColumnName("send_method_id");
            entity.Property(e => e.SendQuoteDate)
                .HasColumnType("datetime")
                .HasColumnName("send_quote_date");
            entity.Property(e => e.TaxesId).HasColumnName("taxes_id");
            entity.Property(e => e.TotalTaxAmount)
                .HasPrecision(10)
                .HasColumnName("total_tax_amount");
            entity.Property(e => e.TotalWithTaxWithDiscount).HasColumnName("total_with_tax_with_discount");
            entity.Property(e => e.TotalWithoutTaxWithDiscount)
                .HasPrecision(10)
                .HasColumnName("total_without_tax_with_discount");
            entity.Property(e => e.TransactionCurency)
                .HasMaxLength(256)
                .HasColumnName("transaction_curency");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("datetime")
                .HasColumnName("updated_by");

            entity.HasOne(d => d.AccessLevelNavigation).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.AccessLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_access_level");

            entity.HasOne(d => d.Account).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_account_id");

            entity.HasOne(d => d.Contact).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("quotes_contact_id");

            entity.HasOne(d => d.PaymentNavigation).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.Payment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_payment_methods");

            entity.HasOne(d => d.Taxes).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.TaxesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_taxes");
        });

        modelBuilder.Entity<QuotesProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("quotes_products");

            entity.HasIndex(e => e.ProductId, "quotes_products_products");

            entity.HasIndex(e => e.QuoteId, "quotes_products_quotes");

            entity.HasIndex(e => e.TaxesId, "quotes_products_taxes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .HasColumnName("description");
            entity.Property(e => e.DiscountPercentage)
                .HasPrecision(10)
                .HasColumnName("discount_percentage");
            entity.Property(e => e.OutOfCatalogProduct)
                .HasMaxLength(256)
                .HasColumnName("out_of_catalog_product");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            entity.Property(e => e.TaxesId).HasColumnName("taxes_id");
            entity.Property(e => e.TotalAmountWithTaxWithDiscount)
                .HasPrecision(10)
                .HasColumnName("total_amount_with_tax_with_discount");
            entity.Property(e => e.TotalAmountWithoutTax)
                .HasPrecision(10)
                .HasColumnName("total_amount_without_tax");
            entity.Property(e => e.TotalAmountWithoutTaxWithDiscount)
                .HasPrecision(10)
                .HasColumnName("total_amount_without_tax_with_discount");
            entity.Property(e => e.TotalTaxAmount)
                .HasPrecision(10)
                .HasColumnName("total_tax_amount");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Product).WithMany(p => p.QuotesProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("quotes_products_products");

            entity.HasOne(d => d.Quote).WithMany(p => p.QuotesProducts)
                .HasForeignKey(d => d.QuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_products_quotes");

            entity.HasOne(d => d.Taxes).WithMany(p => p.QuotesProducts)
                .HasForeignKey(d => d.TaxesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_products_taxes");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Taxis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("taxes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.RoleId, "users_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(256)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Title)
                .HasMaxLength(256)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(256)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
