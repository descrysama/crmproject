-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:8889
-- Généré le : lun. 17 juil. 2023 à 14:04
-- Version du serveur : 5.7.39
-- Version de PHP : 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bluepillcrm`
--

-- --------------------------------------------------------

--
-- Structure de la table `accounts`
--
CREATE DATABASE bluepillcrm;
USE bluepillcrm;

CREATE TABLE `accounts` (
  `id` int(11) NOT NULL,
  `company_name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `siret` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `main_email` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone_number` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tva_number` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `website_url` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `account_type` int(11) DEFAULT NULL,
  `payment_method_id` int(11) DEFAULT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `delivery_address_id` int(11) DEFAULT NULL,
  `billing_address_id` int(11) DEFAULT NULL,
  `owner_id` int(11) NOT NULL,
  `description` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `access_level` int(11) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `last_modified_by` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `accounts`
--

INSERT INTO `accounts` (`id`, `company_name`, `siret`, `main_email`, `phone_number`, `tva_number`, `website_url`, `account_type`, `payment_method_id`, `is_deleted`, `delivery_address_id`, `billing_address_id`, `owner_id`, `description`, `access_level`, `created_at`, `updated_at`, `created_by`, `last_modified_by`) VALUES
(1, 'XEFI', '412 378 895 00053', 'xefi@shit.fr', '0473384473', 'FR59809977887', 'www.xefi.fr', 1, 1, 0, 10, 10, 4, 'string', 3, '2023-06-20 13:49:14', NULL, 3, NULL),
(2, 'Simplon', '203 322 895 00053', 'xefi@shit.fr', '0473384473', 'FR59809977887', 'www.xefi.fr', 1, 1, 0, NULL, NULL, 3, 'string', 2, '2023-06-20 13:50:23', NULL, 3, NULL),
(24, 'ArcelorMittal', '56209442500427', 'xefi@shit.fr', '0473384473', 'FR76562094425', 'https://france.arcelormittal.com/', 1, 1, 0, NULL, NULL, 4, 'string', 2, '2023-06-20 15:33:33', NULL, 3, NULL),
(25, 'AMAZON FRANCE LOGISTIQUE SAS', '42878504200105', 'xefi@shit.fr', '0473384473', 'FR17428785042', 'https://france.arcelormittal.com/', 1, 1, 0, NULL, NULL, 3, 'string', 2, '2023-06-20 15:34:43', NULL, 3, NULL),
(32, 'XEFI3', '1223', 'johann.fdp@gmail.com', '06514416969', 'tesst', 'xefi.fr', 1, 1, 0, NULL, NULL, 3, 'test', 2, '2023-06-23 16:52:23', NULL, 3, NULL);

-- --------------------------------------------------------

--
-- Structure de la table `account_types`
--

CREATE TABLE `account_types` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `account_types`
--

INSERT INTO `account_types` (`id`, `name`) VALUES
(1, 'Entreprise');

-- --------------------------------------------------------

--
-- Structure de la table `address`
--

CREATE TABLE `address` (
  `id` int(11) NOT NULL,
  `street` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `postal_code` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `city` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `country_id` int(11) NOT NULL,
  `access_level` int(11) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `address`
--

INSERT INTO `address` (`id`, `street`, `postal_code`, `city`, `country_id`, `access_level`, `created_at`, `updated_at`, `modified_by`, `created_by`) VALUES
(10, '21 avenue de l\'europe', '69140', 'Rilleux-la-Pape', 1, 4, '2023-06-23 14:49:55', NULL, 4, 4);

-- --------------------------------------------------------

--
-- Structure de la table `contacts`
--

CREATE TABLE `contacts` (
  `id` int(11) NOT NULL,
  `account_id` int(11) NOT NULL,
  `email` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mobile_phone` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `enterprise_phone` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `is_deleted` tinyint(1) NOT NULL,
  `is_deactivated` tinyint(1) NOT NULL,
  `owner_id` int(11) NOT NULL,
  `description` varchar(512) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `access_level` int(11) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created_by` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `contacts`
--

INSERT INTO `contacts` (`id`, `account_id`, `email`, `mobile_phone`, `enterprise_phone`, `is_deleted`, `is_deactivated`, `owner_id`, `description`, `access_level`, `created_at`, `updated_at`, `modified_by`, `created_by`) VALUES
(4434, 1, 'test@mathi.com', '0555305324', '35350993535', 0, 0, 4, 'un gentil contact', 4, '2023-06-23 14:40:38', NULL, NULL, 4);

-- --------------------------------------------------------

--
-- Structure de la table `country`
--

CREATE TABLE `country` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `country_code` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `country`
--

INSERT INTO `country` (`id`, `name`, `country_code`) VALUES
(1, 'France', '1');

-- --------------------------------------------------------

--
-- Structure de la table `crm_config`
--

CREATE TABLE `crm_config` (
  `id` int(11) NOT NULL,
  `max_users` int(11) NOT NULL,
  `max_accounts` int(11) NOT NULL,
  `max_contacts` int(11) NOT NULL,
  `monthly_cost` decimal(10,0) NOT NULL,
  `title` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `role_id` int(11) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `invoices`
--

CREATE TABLE `invoices` (
  `id` int(11) NOT NULL,
  `invoice_number` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `orders_id` int(11) NOT NULL,
  `account_id` int(11) DEFAULT NULL,
  `transaction_currency` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `contact_id` int(11) DEFAULT NULL,
  `send_method_id` int(11) NOT NULL,
  `email_to_send_at` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `invoice_date` datetime DEFAULT NULL,
  `payment_method` int(11) NOT NULL,
  `total_amount_without_tax` decimal(10,0) NOT NULL,
  `discount_percentage` decimal(10,0) NOT NULL,
  `total_amount_without_tax_with_discount` decimal(10,0) NOT NULL,
  `total_tax_amount` decimal(10,0) NOT NULL,
  `total_amount_with_tax_with_discount` decimal(10,0) NOT NULL,
  `description` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `access_level` int(11) NOT NULL,
  `invoice_status` tinyint(1) NOT NULL,
  `updated_by` int(11) NOT NULL,
  `created_by` int(11) NOT NULL,
  `updated_at` int(11) NOT NULL,
  `created_at` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `invoices_products`
--

CREATE TABLE `invoices_products` (
  `id` int(11) NOT NULL,
  `invoices_id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `out_of_catalog_product` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `taxes_id` int(11) NOT NULL,
  `total_amount_without_tax` decimal(10,0) DEFAULT NULL,
  `discount_percentage` decimal(10,0) DEFAULT NULL,
  `total_amount_without_tax_with_discount` decimal(10,0) DEFAULT NULL,
  `total_tax_amount` decimal(10,0) DEFAULT NULL,
  `total_amount_with_tax_with_discount` decimal(10,0) DEFAULT NULL,
  `description` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `updated_by` int(11) DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `order_number` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `quote_id` int(11) NOT NULL,
  `account_id` int(11) DEFAULT NULL,
  `transaction_currency` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `contact_id` int(11) DEFAULT NULL,
  `send_method_id` int(11) DEFAULT NULL,
  `email_to_send_at` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `order_date` datetime DEFAULT NULL,
  `taxes_id` int(11) NOT NULL,
  `payment_method` int(11) NOT NULL,
  `total_amount_without_tax` decimal(10,0) NOT NULL,
  `discount_percentage` float NOT NULL,
  `total_amount_without_tax_with_discount` decimal(10,0) NOT NULL,
  `total_tax_amount` decimal(10,0) NOT NULL,
  `total_amount_with_tax_with_discount` decimal(10,0) NOT NULL,
  `description` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `access_level` int(11) NOT NULL,
  `order_status` tinyint(1) NOT NULL,
  `modified_by` int(11) DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `orders_products`
--

CREATE TABLE `orders_products` (
  `id` int(11) NOT NULL,
  `orders_id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `out_of_catalog_product` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `taxes_id` int(11) NOT NULL,
  `total_amount_without_tax` decimal(10,0) DEFAULT NULL,
  `discount_percentage` decimal(10,0) DEFAULT NULL,
  `total_amount_without_tax_with_discount` decimal(10,0) DEFAULT NULL,
  `total_tax_amount` decimal(10,0) DEFAULT NULL,
  `total_amount_with_tax_with_discount` decimal(10,0) DEFAULT NULL,
  `description` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `updated_by` int(11) DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `payment_methods`
--

CREATE TABLE `payment_methods` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `payment_methods`
--

INSERT INTO `payment_methods` (`id`, `name`) VALUES
(1, 'Credit Card');

-- --------------------------------------------------------

--
-- Structure de la table `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `product_name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `serial_number` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `price` decimal(10,0) NOT NULL,
  `description` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `is_disabled` tinyint(1) NOT NULL,
  `updated_by` int(11) DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `quotes`
--

CREATE TABLE `quotes` (
  `id` int(11) NOT NULL,
  `quote_number` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `account_id` int(11) NOT NULL,
  `transaction_curency` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `contact_id` int(11) DEFAULT NULL,
  `send_method_id` int(11) DEFAULT NULL,
  `email_send_to` int(11) DEFAULT NULL,
  `send_quote_date` datetime DEFAULT NULL,
  `taxes_id` int(11) NOT NULL,
  `payment_method` int(11) NOT NULL,
  `total_without_tax_with_discount` decimal(10,0) NOT NULL,
  `total_tax_amount` decimal(10,0) NOT NULL,
  `total_with_tax_with_discount` int(11) NOT NULL,
  `description` text COLLATE utf8mb4_unicode_ci,
  `quote_status` tinyint(1) NOT NULL,
  `access_level` int(11) NOT NULL,
  `updated_by` int(11) DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `quotes_products`
--

CREATE TABLE `quotes_products` (
  `id` int(11) NOT NULL,
  `quote_id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `out_of_catalog_product` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `taxes_id` int(11) NOT NULL,
  `total_amount_without_tax` decimal(10,0) DEFAULT NULL,
  `discount_percentage` decimal(10,0) DEFAULT NULL,
  `total_amount_without_tax_with_discount` decimal(10,0) DEFAULT NULL,
  `total_tax_amount` decimal(10,0) DEFAULT NULL,
  `total_amount_with_tax_with_discount` decimal(10,0) DEFAULT NULL,
  `description` varchar(256) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `updated_by` int(11) DEFAULT NULL,
  `created_by` int(11) NOT NULL,
  `updated_at` datetime DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `roles`
--

CREATE TABLE `roles` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `roles`
--

INSERT INTO `roles` (`id`, `name`) VALUES
(1, 'SuperAdmin'),
(2, 'Administrateur'),
(3, 'Moderateur'),
(4, 'User');

-- --------------------------------------------------------

--
-- Structure de la table `send_method`
--

CREATE TABLE `send_method` (
  `id` int(11) NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `taxes`
--

CREATE TABLE `taxes` (
  `id` int(11) NOT NULL,
  `percentage` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `last_name` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `title` varchar(256) COLLATE utf8mb4_unicode_ci NOT NULL,
  `role_id` int(11) NOT NULL,
  `is_disabled` tinyint(1) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `password`, `name`, `last_name`, `title`, `role_id`, `is_disabled`, `created_at`, `updated_at`) VALUES
(3, 'descry', 'descry@gmail.com', '$2a$11$Usis5IwB8g6q6jZAgaqlgeExoeMITYQkgYiTGlThEa2NVDHt/60lW', 'erwin', 'Gossin', 'SuperAdmin', 1, 0, '2023-06-20 10:32:28', NULL),
(4, 'bob', 'bobbystyle333492@gmail.com', '$2a$11$76Db3FKPZEW8e0dyFGT5lOBNJb1VCRIteHU5BSJ2DLhH2c1oHkxcW', 'axel', 'Van Heckeux', 'Responsable des stocks', 3, 0, '2023-06-23 10:09:54', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20230614225902_InitialMigrations', '7.0.2'),
('20230620100348_InitialMigration', '7.0.2');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `access_level` (`access_level`),
  ADD KEY `account_type` (`account_type`),
  ADD KEY `billing_address_id` (`billing_address_id`),
  ADD KEY `created_by` (`created_by`),
  ADD KEY `delivery_address_id` (`delivery_address_id`),
  ADD KEY `last_modified_by` (`last_modified_by`),
  ADD KEY `owner_id` (`owner_id`),
  ADD KEY `payment_method_id` (`payment_method_id`);

--
-- Index pour la table `account_types`
--
ALTER TABLE `account_types`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`id`),
  ADD KEY `address` (`country_id`);

--
-- Index pour la table `contacts`
--
ALTER TABLE `contacts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `access_level1` (`access_level`),
  ADD KEY `account_id` (`account_id`),
  ADD KEY `created_by1` (`created_by`),
  ADD KEY `modified_by` (`modified_by`),
  ADD KEY `owner_id1` (`owner_id`);

--
-- Index pour la table `country`
--
ALTER TABLE `country`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `crm_config`
--
ALTER TABLE `crm_config`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `invoices`
--
ALTER TABLE `invoices`
  ADD PRIMARY KEY (`id`),
  ADD KEY `access_level2` (`access_level`),
  ADD KEY `account_id1` (`account_id`),
  ADD KEY `contact_id` (`contact_id`),
  ADD KEY `created_by2` (`created_by`),
  ADD KEY `orders_id` (`orders_id`),
  ADD KEY `payment_method` (`payment_method`),
  ADD KEY `send_method_id` (`send_method_id`),
  ADD KEY `updated_by` (`updated_by`);

--
-- Index pour la table `invoices_products`
--
ALTER TABLE `invoices_products`
  ADD KEY `created_by` (`created_by`),
  ADD KEY `invoices_id` (`invoices_id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `taxes_id` (`taxes_id`),
  ADD KEY `updated_by` (`updated_by`);

--
-- Index pour la table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`),
  ADD KEY `access_level3` (`access_level`),
  ADD KEY `account_id2` (`account_id`),
  ADD KEY `contact_id1` (`contact_id`),
  ADD KEY `created_by3` (`created_by`),
  ADD KEY `modified_by1` (`modified_by`),
  ADD KEY `payment_method1` (`payment_method`),
  ADD KEY `quote_id` (`quote_id`),
  ADD KEY `send_method_id1` (`send_method_id`),
  ADD KEY `taxes_id` (`taxes_id`);

--
-- Index pour la table `orders_products`
--
ALTER TABLE `orders_products`
  ADD KEY `created_by` (`created_by`),
  ADD KEY `orders_id` (`orders_id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `taxes_id` (`taxes_id`),
  ADD KEY `updated_by` (`updated_by`);

--
-- Index pour la table `payment_methods`
--
ALTER TABLE `payment_methods`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `created_by4` (`created_by`),
  ADD KEY `updated_by1` (`updated_by`);

--
-- Index pour la table `quotes`
--
ALTER TABLE `quotes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `access_level4` (`access_level`),
  ADD KEY `account_id3` (`account_id`),
  ADD KEY `contact_id2` (`contact_id`),
  ADD KEY `created_by5` (`created_by`),
  ADD KEY `payment_method2` (`payment_method`),
  ADD KEY `send_method_id2` (`send_method_id`),
  ADD KEY `taxes_id1` (`taxes_id`),
  ADD KEY `updated_by2` (`updated_by`);

--
-- Index pour la table `quotes_products`
--
ALTER TABLE `quotes_products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `created_by6` (`created_by`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `quote_id1` (`quote_id`),
  ADD KEY `taxes_id2` (`taxes_id`),
  ADD KEY `updated_by3` (`updated_by`);

--
-- Index pour la table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `send_method`
--
ALTER TABLE `send_method`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `taxes`
--
ALTER TABLE `taxes`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `role_id` (`role_id`);

--
-- Index pour la table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT pour la table `account_types`
--
ALTER TABLE `account_types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `address`
--
ALTER TABLE `address`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pour la table `contacts`
--
ALTER TABLE `contacts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4435;

--
-- AUTO_INCREMENT pour la table `country`
--
ALTER TABLE `country`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `crm_config`
--
ALTER TABLE `crm_config`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `invoices`
--
ALTER TABLE `invoices`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `payment_methods`
--
ALTER TABLE `payment_methods`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `quotes`
--
ALTER TABLE `quotes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `quotes_products`
--
ALTER TABLE `quotes_products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table `send_method`
--
ALTER TABLE `send_method`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `taxes`
--
ALTER TABLE `taxes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `accounts`
--
ALTER TABLE `accounts`
  ADD CONSTRAINT `accounts_ibfk_1` FOREIGN KEY (`account_type`) REFERENCES `account_types` (`id`),
  ADD CONSTRAINT `accounts_ibfk_2` FOREIGN KEY (`payment_method_id`) REFERENCES `payment_methods` (`id`),
  ADD CONSTRAINT `accounts_ibfk_3` FOREIGN KEY (`delivery_address_id`) REFERENCES `address` (`id`),
  ADD CONSTRAINT `accounts_ibfk_4` FOREIGN KEY (`billing_address_id`) REFERENCES `address` (`id`),
  ADD CONSTRAINT `accounts_ibfk_5` FOREIGN KEY (`owner_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `accounts_ibfk_6` FOREIGN KEY (`access_level`) REFERENCES `roles` (`id`),
  ADD CONSTRAINT `accounts_ibfk_7` FOREIGN KEY (`last_modified_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `accounts_ibfk_8` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`);

--
-- Contraintes pour la table `address`
--
ALTER TABLE `address`
  ADD CONSTRAINT `address_ibfk_1` FOREIGN KEY (`country_id`) REFERENCES `country` (`id`);

--
-- Contraintes pour la table `contacts`
--
ALTER TABLE `contacts`
  ADD CONSTRAINT `contacts_ibfk_1` FOREIGN KEY (`account_id`) REFERENCES `accounts` (`id`),
  ADD CONSTRAINT `contacts_ibfk_2` FOREIGN KEY (`owner_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `contacts_ibfk_3` FOREIGN KEY (`access_level`) REFERENCES `roles` (`id`),
  ADD CONSTRAINT `contacts_ibfk_4` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `contacts_ibfk_5` FOREIGN KEY (`modified_by`) REFERENCES `users` (`id`);

--
-- Contraintes pour la table `invoices`
--
ALTER TABLE `invoices`
  ADD CONSTRAINT `invoices_ibfk_1` FOREIGN KEY (`orders_id`) REFERENCES `orders` (`id`),
  ADD CONSTRAINT `invoices_ibfk_2` FOREIGN KEY (`account_id`) REFERENCES `accounts` (`id`),
  ADD CONSTRAINT `invoices_ibfk_3` FOREIGN KEY (`contact_id`) REFERENCES `contacts` (`id`),
  ADD CONSTRAINT `invoices_ibfk_4` FOREIGN KEY (`payment_method`) REFERENCES `payment_methods` (`id`),
  ADD CONSTRAINT `invoices_ibfk_5` FOREIGN KEY (`access_level`) REFERENCES `roles` (`id`),
  ADD CONSTRAINT `invoices_ibfk_6` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `invoices_ibfk_7` FOREIGN KEY (`updated_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `invoices_ibfk_8` FOREIGN KEY (`send_method_id`) REFERENCES `send_method` (`id`);

--
-- Contraintes pour la table `invoices_products`
--
ALTER TABLE `invoices_products`
  ADD CONSTRAINT `invoices_products_ibfk_1` FOREIGN KEY (`invoices_id`) REFERENCES `invoices` (`id`),
  ADD CONSTRAINT `invoices_products_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `invoices_products_ibfk_3` FOREIGN KEY (`taxes_id`) REFERENCES `taxes` (`id`),
  ADD CONSTRAINT `invoices_products_ibfk_4` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `invoices_products_ibfk_5` FOREIGN KEY (`updated_by`) REFERENCES `users` (`id`);

--
-- Contraintes pour la table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`quote_id`) REFERENCES `quotes` (`id`),
  ADD CONSTRAINT `orders_ibfk_10` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `orders_ibfk_11` FOREIGN KEY (`send_method_id`) REFERENCES `send_method` (`id`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`account_id`) REFERENCES `accounts` (`id`),
  ADD CONSTRAINT `orders_ibfk_3` FOREIGN KEY (`contact_id`) REFERENCES `contacts` (`id`),
  ADD CONSTRAINT `orders_ibfk_5` FOREIGN KEY (`taxes_id`) REFERENCES `taxes` (`id`),
  ADD CONSTRAINT `orders_ibfk_6` FOREIGN KEY (`payment_method`) REFERENCES `payment_methods` (`id`),
  ADD CONSTRAINT `orders_ibfk_8` FOREIGN KEY (`access_level`) REFERENCES `roles` (`id`),
  ADD CONSTRAINT `orders_ibfk_9` FOREIGN KEY (`modified_by`) REFERENCES `users` (`id`);

--
-- Contraintes pour la table `orders_products`
--
ALTER TABLE `orders_products`
  ADD CONSTRAINT `orders_products_ibfk_1` FOREIGN KEY (`orders_id`) REFERENCES `orders` (`id`),
  ADD CONSTRAINT `orders_products_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `orders_products_ibfk_3` FOREIGN KEY (`taxes_id`) REFERENCES `taxes` (`id`),
  ADD CONSTRAINT `orders_products_ibfk_4` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `orders_products_ibfk_5` FOREIGN KEY (`updated_by`) REFERENCES `users` (`id`);

--
-- Contraintes pour la table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`updated_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `products_ibfk_2` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`);

--
-- Contraintes pour la table `quotes`
--
ALTER TABLE `quotes`
  ADD CONSTRAINT `quotes_ibfk_1` FOREIGN KEY (`account_id`) REFERENCES `accounts` (`id`),
  ADD CONSTRAINT `quotes_ibfk_2` FOREIGN KEY (`contact_id`) REFERENCES `contacts` (`id`),
  ADD CONSTRAINT `quotes_ibfk_3` FOREIGN KEY (`taxes_id`) REFERENCES `taxes` (`id`),
  ADD CONSTRAINT `quotes_ibfk_4` FOREIGN KEY (`payment_method`) REFERENCES `payment_methods` (`id`),
  ADD CONSTRAINT `quotes_ibfk_5` FOREIGN KEY (`access_level`) REFERENCES `roles` (`id`),
  ADD CONSTRAINT `quotes_ibfk_6` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `quotes_ibfk_7` FOREIGN KEY (`updated_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `quotes_ibfk_8` FOREIGN KEY (`send_method_id`) REFERENCES `send_method` (`id`);

--
-- Contraintes pour la table `quotes_products`
--
ALTER TABLE `quotes_products`
  ADD CONSTRAINT `quotes_products_ibfk_1` FOREIGN KEY (`quote_id`) REFERENCES `quotes` (`id`),
  ADD CONSTRAINT `quotes_products_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `quotes_products_ibfk_5` FOREIGN KEY (`taxes_id`) REFERENCES `taxes` (`id`),
  ADD CONSTRAINT `quotes_products_ibfk_6` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `quotes_products_ibfk_7` FOREIGN KEY (`updated_by`) REFERENCES `users` (`id`);

--
-- Contraintes pour la table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
