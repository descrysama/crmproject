using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BluePillCRM.Datas;

#nullable disable

namespace BluePillCRM.Datas.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "account_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country_code = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "crm_config",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    max_users = table.Column<int>(type: "int", nullable: false),
                    max_accounts = table.Column<int>(type: "int", nullable: false),
                    max_contacts = table.Column<int>(type: "int", nullable: false),
                    monthly_cost = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    title = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "payment_methods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "send_method",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "taxes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    percentage = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    street = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    postal_code = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    access_level = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "address_ibfk_1",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    is_disabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "users_ibfk_1",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    company_name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    siret = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    main_email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tva_number = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    website_url = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    account_type = table.Column<int>(type: "int", nullable: true),
                    payment_method_id = table.Column<int>(type: "int", nullable: true),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    delivery_address_id = table.Column<int>(type: "int", nullable: true),
                    billing_address_id = table.Column<int>(type: "int", nullable: true),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_level = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    last_modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "accounts_ibfk_1",
                        column: x => x.account_type,
                        principalTable: "account_types",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "accounts_ibfk_2",
                        column: x => x.payment_method_id,
                        principalTable: "payment_methods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "accounts_ibfk_3",
                        column: x => x.delivery_address_id,
                        principalTable: "address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "accounts_ibfk_4",
                        column: x => x.billing_address_id,
                        principalTable: "address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "accounts_ibfk_5",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "accounts_ibfk_6",
                        column: x => x.access_level,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "accounts_ibfk_7",
                        column: x => x.last_modified_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "accounts_ibfk_8",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    serial_number = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_disabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "products_ibfk_1",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "products_ibfk_2",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mobile_phone = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    enterprise_phone = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_deactivated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_level = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "contacts_ibfk_1",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contacts_ibfk_2",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contacts_ibfk_3",
                        column: x => x.access_level,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contacts_ibfk_4",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contacts_ibfk_5",
                        column: x => x.modified_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "quotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quote_number = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    transaction_curency = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_id = table.Column<int>(type: "int", nullable: true),
                    send_method_id = table.Column<int>(type: "int", nullable: true),
                    email_send_to = table.Column<int>(type: "int", nullable: true),
                    send_quote_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    taxes_id = table.Column<int>(type: "int", nullable: false),
                    payment_method = table.Column<int>(type: "int", nullable: false),
                    total_without_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    total_tax_amount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    total_with_tax_with_discount = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quote_status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    access_level = table.Column<int>(type: "int", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "quotes_ibfk_1",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_ibfk_2",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_ibfk_3",
                        column: x => x.taxes_id,
                        principalTable: "taxes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_ibfk_4",
                        column: x => x.payment_method,
                        principalTable: "payment_methods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_ibfk_5",
                        column: x => x.access_level,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_ibfk_6",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_ibfk_7",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_ibfk_8",
                        column: x => x.send_method_id,
                        principalTable: "send_method",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    order_number = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quote_id = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    transaction_currency = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_id = table.Column<int>(type: "int", nullable: true),
                    send_method_id = table.Column<int>(type: "int", nullable: true),
                    email_to_send_at = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    order_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    taxes_id = table.Column<int>(type: "int", nullable: false),
                    payment_method = table.Column<int>(type: "int", nullable: false),
                    total_amount_without_tax = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    discount_percentage = table.Column<float>(type: "float", nullable: false),
                    total_amount_without_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    total_tax_amount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    total_amount_with_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_level = table.Column<int>(type: "int", nullable: false),
                    order_status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "orders_ibfk_1",
                        column: x => x.quote_id,
                        principalTable: "quotes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_10",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_11",
                        column: x => x.send_method_id,
                        principalTable: "send_method",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_2",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_3",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_5",
                        column: x => x.taxes_id,
                        principalTable: "taxes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_6",
                        column: x => x.payment_method,
                        principalTable: "payment_methods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_8",
                        column: x => x.access_level,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_9",
                        column: x => x.modified_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "quotes_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quote_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    out_of_catalog_product = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    taxes_id = table.Column<int>(type: "int", nullable: false),
                    total_amount_without_tax = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    discount_percentage = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_amount_without_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_tax_amount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_amount_with_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "quotes_products_ibfk_1",
                        column: x => x.quote_id,
                        principalTable: "quotes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_products_ibfk_2",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_products_ibfk_5",
                        column: x => x.taxes_id,
                        principalTable: "taxes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_products_ibfk_6",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "quotes_products_ibfk_7",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    invoice_number = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    orders_id = table.Column<int>(type: "int", nullable: false),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    transaction_currency = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_id = table.Column<int>(type: "int", nullable: true),
                    send_method_id = table.Column<int>(type: "int", nullable: false),
                    email_to_send_at = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    invoice_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    payment_method = table.Column<int>(type: "int", nullable: false),
                    total_amount_without_tax = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    discount_percentage = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    total_amount_without_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    total_tax_amount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    total_amount_with_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_level = table.Column<int>(type: "int", nullable: false),
                    invoice_status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "invoices_ibfk_1",
                        column: x => x.orders_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_ibfk_2",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_ibfk_3",
                        column: x => x.contact_id,
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_ibfk_4",
                        column: x => x.payment_method,
                        principalTable: "payment_methods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_ibfk_5",
                        column: x => x.access_level,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_ibfk_6",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_ibfk_7",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_ibfk_8",
                        column: x => x.send_method_id,
                        principalTable: "send_method",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "orders_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    orders_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    out_of_catalog_product = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    taxes_id = table.Column<int>(type: "int", nullable: false),
                    total_amount_without_tax = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    discount_percentage = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_amount_without_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_tax_amount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_amount_with_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "orders_products_ibfk_1",
                        column: x => x.orders_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_products_ibfk_2",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_products_ibfk_3",
                        column: x => x.taxes_id,
                        principalTable: "taxes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_products_ibfk_4",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_products_ibfk_5",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "invoices_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    invoices_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    out_of_catalog_product = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    taxes_id = table.Column<int>(type: "int", nullable: false),
                    total_amount_without_tax = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    discount_percentage = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_amount_without_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_tax_amount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    total_amount_with_tax_with_discount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "invoices_products_ibfk_1",
                        column: x => x.invoices_id,
                        principalTable: "invoices",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_products_ibfk_2",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_products_ibfk_3",
                        column: x => x.taxes_id,
                        principalTable: "taxes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_products_ibfk_4",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "invoices_products_ibfk_5",
                        column: x => x.updated_by,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "access_level",
                table: "accounts",
                column: "access_level");

            migrationBuilder.CreateIndex(
                name: "account_type",
                table: "accounts",
                column: "account_type");

            migrationBuilder.CreateIndex(
                name: "billing_address_id",
                table: "accounts",
                column: "billing_address_id");

            migrationBuilder.CreateIndex(
                name: "created_by",
                table: "accounts",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "delivery_address_id",
                table: "accounts",
                column: "delivery_address_id");

            migrationBuilder.CreateIndex(
                name: "last_modified_by",
                table: "accounts",
                column: "last_modified_by");

            migrationBuilder.CreateIndex(
                name: "owner_id",
                table: "accounts",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "payment_method_id",
                table: "accounts",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "address",
                table: "address",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "access_level1",
                table: "contacts",
                column: "access_level");

            migrationBuilder.CreateIndex(
                name: "account_id",
                table: "contacts",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "created_by1",
                table: "contacts",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "modified_by",
                table: "contacts",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "owner_id1",
                table: "contacts",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "access_level2",
                table: "invoices",
                column: "access_level");

            migrationBuilder.CreateIndex(
                name: "account_id1",
                table: "invoices",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "contact_id",
                table: "invoices",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "created_by2",
                table: "invoices",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "orders_id",
                table: "invoices",
                column: "orders_id");

            migrationBuilder.CreateIndex(
                name: "payment_method",
                table: "invoices",
                column: "payment_method");

            migrationBuilder.CreateIndex(
                name: "send_method_id",
                table: "invoices",
                column: "send_method_id");

            migrationBuilder.CreateIndex(
                name: "updated_by",
                table: "invoices",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "created_by",
                table: "invoices_products",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "invoices_id",
                table: "invoices_products",
                column: "invoices_id");

            migrationBuilder.CreateIndex(
                name: "product_id",
                table: "invoices_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "taxes_id",
                table: "invoices_products",
                column: "taxes_id");

            migrationBuilder.CreateIndex(
                name: "updated_by",
                table: "invoices_products",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "access_level3",
                table: "orders",
                column: "access_level");

            migrationBuilder.CreateIndex(
                name: "account_id2",
                table: "orders",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "contact_id1",
                table: "orders",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "created_by3",
                table: "orders",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "modified_by1",
                table: "orders",
                column: "modified_by");

            migrationBuilder.CreateIndex(
                name: "payment_method1",
                table: "orders",
                column: "payment_method");

            migrationBuilder.CreateIndex(
                name: "quote_id",
                table: "orders",
                column: "quote_id");

            migrationBuilder.CreateIndex(
                name: "send_method_id1",
                table: "orders",
                column: "send_method_id");

            migrationBuilder.CreateIndex(
                name: "taxes_id",
                table: "orders",
                column: "taxes_id");

            migrationBuilder.CreateIndex(
                name: "created_by",
                table: "orders_products",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "orders_id",
                table: "orders_products",
                column: "orders_id");

            migrationBuilder.CreateIndex(
                name: "product_id",
                table: "orders_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "taxes_id",
                table: "orders_products",
                column: "taxes_id");

            migrationBuilder.CreateIndex(
                name: "updated_by",
                table: "orders_products",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "created_by4",
                table: "products",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "updated_by1",
                table: "products",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "access_level4",
                table: "quotes",
                column: "access_level");

            migrationBuilder.CreateIndex(
                name: "account_id3",
                table: "quotes",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "contact_id2",
                table: "quotes",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "created_by5",
                table: "quotes",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "payment_method2",
                table: "quotes",
                column: "payment_method");

            migrationBuilder.CreateIndex(
                name: "send_method_id2",
                table: "quotes",
                column: "send_method_id");

            migrationBuilder.CreateIndex(
                name: "taxes_id1",
                table: "quotes",
                column: "taxes_id");

            migrationBuilder.CreateIndex(
                name: "updated_by2",
                table: "quotes",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "created_by6",
                table: "quotes_products",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "product_id",
                table: "quotes_products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "quote_id1",
                table: "quotes_products",
                column: "quote_id");

            migrationBuilder.CreateIndex(
                name: "taxes_id2",
                table: "quotes_products",
                column: "taxes_id");

            migrationBuilder.CreateIndex(
                name: "updated_by3",
                table: "quotes_products",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "role_id",
                table: "users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crm_config");

            migrationBuilder.DropTable(
                name: "invoices_products");

            migrationBuilder.DropTable(
                name: "orders_products");

            migrationBuilder.DropTable(
                name: "quotes_products");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "quotes");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "taxes");

            migrationBuilder.DropTable(
                name: "send_method");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "account_types");

            migrationBuilder.DropTable(
                name: "payment_methods");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
