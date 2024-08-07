﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Simplz.Europa.SafetyGateAlerts.Data;

#nullable disable

namespace Simplz.Europa.SafetyGateAlerts.Migrations
{
    [DbContext(typeof(HistoryContext))]
    [Migration("20240807111541_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Simplz.Europa.SafetyGateAlerts.Models.Result", b =>
                {
                    b.Property<string>("RapexUrl")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "rapex_url");

                    b.Property<string>("AlertCountry")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "alert_country");

                    b.Property<string>("AlertDate")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "alert_date");

                    b.Property<string>("AlertDescription")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "alert_description");

                    b.Property<string>("AlertGroup")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "alert_group");

                    b.Property<string>("AlertLevel")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "alert_level");

                    b.Property<string>("AlertNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "alert_number");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "modification_date");

                    b.Property<string>("OecdPortalCategory")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "oecd_portal_category");

                    b.Property<string>("ProductBarcode")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_barcode");

                    b.Property<string>("ProductBatchNumber")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_batch_number");

                    b.Property<string>("ProductBrand")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_brand");

                    b.Property<string>("ProductCategory")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_category");

                    b.Property<string>("ProductCounterfeit")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_counterfeit");

                    b.Property<string>("ProductCountry")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_country");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_description");

                    b.Property<string>("ProductImage")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_image");

                    b.Property<string>("ProductModelType")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_model_type");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_name");

                    b.Property<string>("ProductPackagingDescription")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_packaging_description");

                    b.Property<string>("ProductRecallUrl")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_recall_url");

                    b.Property<string>("ProductType")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "product_type");

                    b.Property<string>("RiskLegalProvision")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "risk_legal_provision");

                    b.Property<string>("TechnicalDefect")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "technical_defect");

                    b.HasKey("RapexUrl");

                    b.ToTable("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
