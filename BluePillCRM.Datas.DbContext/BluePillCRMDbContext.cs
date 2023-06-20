using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BluePillCRM.Datas.Entities;

namespace BluePillCRM.Datas;

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

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoicesProduct> InvoicesProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersProduct> OrdersProducts { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<QuotesProduct> QuotesProducts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SendMethod> SendMethods { get; set; }

    public virtual DbSet<Taxis> Taxes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=bluepillcrm;port=8889;User=root;Password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.AccessLevel, "access_level");

            entity.HasIndex(e => e.AccountType, "account_type");

            entity.HasIndex(e => e.BillingAddressId, "billing_address_id");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.DeliveryAddressId, "delivery_address_id");

            entity.HasIndex(e => e.LastModifiedBy, "last_modified_by");

            entity.HasIndex(e => e.OwnerId, "owner_id");

            entity.HasIndex(e => e.PaymentMethodId, "payment_method_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.AccountType).HasColumnName("account_type");
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
                .HasConstraintName("accounts_ibfk_6");

            entity.HasOne(d => d.AccountTypeNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountType)
                .HasConstraintName("accounts_ibfk_1");

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.AccountBillingAddresses)
                .HasForeignKey(d => d.BillingAddressId)
                .HasConstraintName("accounts_ibfk_4");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AccountCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accounts_ibfk_8");

            entity.HasOne(d => d.DeliveryAddress).WithMany(p => p.AccountDeliveryAddresses)
                .HasForeignKey(d => d.DeliveryAddressId)
                .HasConstraintName("accounts_ibfk_3");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AccountLastModifiedByNavigations)
                .HasForeignKey(d => d.LastModifiedBy)
                .HasConstraintName("accounts_ibfk_7");

            entity.HasOne(d => d.Owner).WithMany(p => p.AccountOwners)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accounts_ibfk_5");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("accounts_ibfk_2");
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

            entity.HasIndex(e => e.CountryId, "address");

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

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_ibfk_1");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.AccessLevel, "access_level");

            entity.HasIndex(e => e.AccountId, "account_id");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.ModifiedBy, "modified_by");

            entity.HasIndex(e => e.OwnerId, "owner_id");

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
                .HasConstraintName("contacts_ibfk_3");

            entity.HasOne(d => d.Account).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contacts_ibfk_1");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ContactCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contacts_ibfk_4");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ContactModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("contacts_ibfk_5");

            entity.HasOne(d => d.Owner).WithMany(p => p.ContactOwners)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contacts_ibfk_2");
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
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
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

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoices");

            entity.HasIndex(e => e.AccessLevel, "access_level");

            entity.HasIndex(e => e.AccountId, "account_id");

            entity.HasIndex(e => e.ContactId, "contact_id");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.OrdersId, "orders_id");

            entity.HasIndex(e => e.PaymentMethod, "payment_method");

            entity.HasIndex(e => e.SendMethodId, "send_method_id");

            entity.HasIndex(e => e.UpdatedBy, "updated_by");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DiscountPercentage)
                .HasPrecision(10)
                .HasColumnName("discount_percentage");
            entity.Property(e => e.EmailToSendAt)
                .HasMaxLength(256)
                .HasColumnName("email_to_send_at");
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("invoice_date");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(256)
                .HasColumnName("invoice_number");
            entity.Property(e => e.InvoiceStatus).HasColumnName("invoice_status");
            entity.Property(e => e.OrdersId).HasColumnName("orders_id");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.SendMethodId).HasColumnName("send_method_id");
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
            entity.Property(e => e.TransactionCurrency)
                .HasMaxLength(64)
                .HasColumnName("transaction_currency");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.AccessLevelNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AccessLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_ibfk_5");

            entity.HasOne(d => d.Account).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("invoices_ibfk_2");

            entity.HasOne(d => d.Contact).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("invoices_ibfk_3");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InvoiceCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_ibfk_6");

            entity.HasOne(d => d.Orders).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_ibfk_1");

            entity.HasOne(d => d.PaymentMethodNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_ibfk_4");

            entity.HasOne(d => d.SendMethod).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.SendMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_ibfk_8");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InvoiceUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_ibfk_7");
        });

        modelBuilder.Entity<InvoicesProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("invoices_products");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.InvoicesId, "invoices_id");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.TaxesId, "taxes_id");

            entity.HasIndex(e => e.UpdatedBy, "updated_by");

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
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InvoicesId).HasColumnName("invoices_id");
            entity.Property(e => e.OutOfCatalogProduct)
                .HasMaxLength(256)
                .HasColumnName("out_of_catalog_product");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
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

            entity.HasOne(d => d.CreatedByNavigation).WithMany()
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_products_ibfk_4");

            entity.HasOne(d => d.Invoices).WithMany()
                .HasForeignKey(d => d.InvoicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_products_ibfk_1");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("invoices_products_ibfk_2");

            entity.HasOne(d => d.Taxes).WithMany()
                .HasForeignKey(d => d.TaxesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoices_products_ibfk_3");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany()
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("invoices_products_ibfk_5");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.AccessLevel, "access_level");

            entity.HasIndex(e => e.AccountId, "account_id");

            entity.HasIndex(e => e.ContactId, "contact_id");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.ModifiedBy, "modified_by");

            entity.HasIndex(e => e.PaymentMethod, "payment_method");

            entity.HasIndex(e => e.QuoteId, "quote_id");

            entity.HasIndex(e => e.SendMethodId, "send_method_id");

            entity.HasIndex(e => e.TaxesId, "taxes_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.EmailToSendAt)
                .HasMaxLength(256)
                .HasColumnName("email_to_send_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(256)
                .HasColumnName("order_number");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            entity.Property(e => e.SendMethodId).HasColumnName("send_method_id");
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
            entity.Property(e => e.TransactionCurrency)
                .HasMaxLength(256)
                .HasColumnName("transaction_currency");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AccessLevelNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccessLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_8");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("orders_ibfk_2");

            entity.HasOne(d => d.Contact).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("orders_ibfk_3");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrderCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_10");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.OrderModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("orders_ibfk_9");

            entity.HasOne(d => d.PaymentMethodNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_6");

            entity.HasOne(d => d.Quote).WithMany(p => p.Orders)
                .HasForeignKey(d => d.QuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_1");

            entity.HasOne(d => d.SendMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SendMethodId)
                .HasConstraintName("orders_ibfk_11");

            entity.HasOne(d => d.Taxes).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TaxesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_5");
        });

        modelBuilder.Entity<OrdersProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("orders_products");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.OrdersId, "orders_id");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.TaxesId, "taxes_id");

            entity.HasIndex(e => e.UpdatedBy, "updated_by");

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
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrdersId).HasColumnName("orders_id");
            entity.Property(e => e.OutOfCatalogProduct)
                .HasMaxLength(256)
                .HasColumnName("out_of_catalog_product");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
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

            entity.HasOne(d => d.CreatedByNavigation).WithMany()
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_products_ibfk_4");

            entity.HasOne(d => d.Orders).WithMany()
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_products_ibfk_1");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("orders_products_ibfk_2");

            entity.HasOne(d => d.Taxes).WithMany()
                .HasForeignKey(d => d.TaxesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_products_ibfk_3");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany()
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("orders_products_ibfk_5");
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

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.UpdatedBy, "updated_by");

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

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_2");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProductUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("products_ibfk_1");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("quotes");

            entity.HasIndex(e => e.AccessLevel, "access_level");

            entity.HasIndex(e => e.AccountId, "account_id");

            entity.HasIndex(e => e.ContactId, "contact_id");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.PaymentMethod, "payment_method");

            entity.HasIndex(e => e.SendMethodId, "send_method_id");

            entity.HasIndex(e => e.TaxesId, "taxes_id");

            entity.HasIndex(e => e.UpdatedBy, "updated_by");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessLevel).HasColumnName("access_level");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EmailSendTo).HasColumnName("email_send_to");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
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
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.AccessLevelNavigation).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.AccessLevel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_ibfk_5");

            entity.HasOne(d => d.Account).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_ibfk_1");

            entity.HasOne(d => d.Contact).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("quotes_ibfk_2");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.QuoteCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_ibfk_6");

            entity.HasOne(d => d.PaymentMethodNavigation).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.PaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_ibfk_4");

            entity.HasOne(d => d.SendMethod).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.SendMethodId)
                .HasConstraintName("quotes_ibfk_8");

            entity.HasOne(d => d.Taxes).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.TaxesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_ibfk_3");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.QuoteUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("quotes_ibfk_7");
        });

        modelBuilder.Entity<QuotesProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("quotes_products");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.QuoteId, "quote_id");

            entity.HasIndex(e => e.TaxesId, "taxes_id");

            entity.HasIndex(e => e.UpdatedBy, "updated_by");

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

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.QuotesProductCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_products_ibfk_6");

            entity.HasOne(d => d.Product).WithMany(p => p.QuotesProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("quotes_products_ibfk_2");

            entity.HasOne(d => d.Quote).WithMany(p => p.QuotesProducts)
                .HasForeignKey(d => d.QuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_products_ibfk_1");

            entity.HasOne(d => d.Taxes).WithMany(p => p.QuotesProducts)
                .HasForeignKey(d => d.TaxesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quotes_products_ibfk_5");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.QuotesProductUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("quotes_products_ibfk_7");
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

        modelBuilder.Entity<SendMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("send_method");

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

            entity.HasIndex(e => e.RoleId, "role_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");
            entity.Property(e => e.LastName)
                .HasMaxLength(256)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasColumnName("password");
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
                .HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
