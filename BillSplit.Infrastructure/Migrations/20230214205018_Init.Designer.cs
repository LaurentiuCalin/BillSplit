﻿// <auto-generated />
using System;
using BillSplit.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BillSplit.Persistence.Migrations
{
    [DbContext(typeof(BillsplitContext))]
    [Migration("20230214205018_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BillSplit.Domain.Models.Bill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(19, 4)
                        .HasColumnType("numeric(19,4)");

                    b.Property<long>("BillGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long>("PaidBy")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BillGroupId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("PaidBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Bill", "billsplit");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.BillAllocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<long>("BillId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("numeric");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("BillAllocation", "billsplit");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.BillGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("BillGroup", "billsplit");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSuperUser")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("User", "billsplit");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.UserBillGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<long>("BillGroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BillGroupId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex(new[] { "UserId", "BillGroupId" }, "UserBillGroup_UserId_BillGroupId_uindex")
                        .IsUnique();

                    b.ToTable("UserBillGroup", "billsplit");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.Bill", b =>
                {
                    b.HasOne("BillSplit.Domain.Models.BillGroup", "BillGroup")
                        .WithMany("Bills")
                        .HasForeignKey("BillGroupId")
                        .IsRequired()
                        .HasConstraintName("Bill_BillGroup_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "CreatedByNavigation")
                        .WithMany("BillCreatedByNavigations")
                        .HasForeignKey("CreatedBy")
                        .IsRequired()
                        .HasConstraintName("Bill_Created_By_User_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "DeletedByNavigation")
                        .WithMany("BillDeletedByNavigations")
                        .HasForeignKey("DeletedBy")
                        .HasConstraintName("Bill_Deleted_By_User__fk");

                    b.HasOne("BillSplit.Domain.Models.User", "PaidByNavigation")
                        .WithMany("BillPaidByNavigations")
                        .HasForeignKey("PaidBy")
                        .IsRequired()
                        .HasConstraintName("Bill_Paid_By_User_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "UpdatedByNavigation")
                        .WithMany("BillUpdatedByNavigations")
                        .HasForeignKey("UpdatedBy")
                        .HasConstraintName("Bill_Updated_By_User__fk");

                    b.Navigation("BillGroup");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("DeletedByNavigation");

                    b.Navigation("PaidByNavigation");

                    b.Navigation("UpdatedByNavigation");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.BillAllocation", b =>
                {
                    b.HasOne("BillSplit.Domain.Models.Bill", "Bill")
                        .WithMany("BillAllocations")
                        .HasForeignKey("BillId")
                        .IsRequired()
                        .HasConstraintName("BillAllocation_Bill_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "CreatedByNavigation")
                        .WithMany("BillAllocationCreatedByNavigations")
                        .HasForeignKey("CreatedBy")
                        .IsRequired()
                        .HasConstraintName("BillAllocation_Created_By_User_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "DeletedByNavigation")
                        .WithMany("BillAllocationDeletedByNavigations")
                        .HasForeignKey("DeletedBy")
                        .HasConstraintName("BillAllocation_Deleted_By_User__fk");

                    b.HasOne("BillSplit.Domain.Models.User", "UpdatedByNavigation")
                        .WithMany("BillAllocationUpdatedByNavigations")
                        .HasForeignKey("UpdatedBy")
                        .HasConstraintName("BillAllocation_Updated_By_User__fk");

                    b.HasOne("BillSplit.Domain.Models.User", "User")
                        .WithMany("BillAllocationUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("BillAllocation_User_Id_fk");

                    b.Navigation("Bill");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("DeletedByNavigation");

                    b.Navigation("UpdatedByNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.BillGroup", b =>
                {
                    b.HasOne("BillSplit.Domain.Models.User", "CreatedByNavigation")
                        .WithMany("BillGroupCreatedByNavigations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("BillGroup_Created_By_User_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "DeletedByNavigation")
                        .WithMany("BillGroupDeletedByNavigations")
                        .HasForeignKey("DeletedBy")
                        .HasConstraintName("BillGroup_Deleted_By_User_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "UpdatedByNavigation")
                        .WithMany("BillGroupUpdatedByNavigations")
                        .HasForeignKey("UpdatedBy")
                        .HasConstraintName("BillGroup_Updated_By_User_Id_fk");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("DeletedByNavigation");

                    b.Navigation("UpdatedByNavigation");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.User", b =>
                {
                    b.HasOne("BillSplit.Domain.Models.User", "CreatedByNavigation")
                        .WithMany("InverseCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("User_Created_By_User_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "DeletedByNavigation")
                        .WithMany("InverseDeletedByNavigation")
                        .HasForeignKey("DeletedBy")
                        .HasConstraintName("User_Deleted_By_User__fk");

                    b.HasOne("BillSplit.Domain.Models.User", "UpdatedByNavigation")
                        .WithMany("InverseUpdatedByNavigation")
                        .HasForeignKey("UpdatedBy")
                        .HasConstraintName("User_Updated_By_User__fk");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("DeletedByNavigation");

                    b.Navigation("UpdatedByNavigation");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.UserBillGroup", b =>
                {
                    b.HasOne("BillSplit.Domain.Models.BillGroup", "BillGroup")
                        .WithMany("UserBillGroups")
                        .HasForeignKey("BillGroupId")
                        .IsRequired()
                        .HasConstraintName("UserBillGroup_Bill_Group_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "CreatedByNavigation")
                        .WithMany("UserBillGroupCreatedByNavigations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("UserBillGroup_Created_By_User_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "DeletedByNavigation")
                        .WithMany("UserBillGroupDeletedByNavigations")
                        .HasForeignKey("DeletedBy")
                        .HasConstraintName("UserBillGroup_Deleted_By_User_Id_fk");

                    b.HasOne("BillSplit.Domain.Models.User", "User")
                        .WithMany("UserBillGroupUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("UserBillGroup_User_Id_fk");

                    b.Navigation("BillGroup");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("DeletedByNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.Bill", b =>
                {
                    b.Navigation("BillAllocations");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.BillGroup", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("UserBillGroups");
                });

            modelBuilder.Entity("BillSplit.Domain.Models.User", b =>
                {
                    b.Navigation("BillAllocationCreatedByNavigations");

                    b.Navigation("BillAllocationDeletedByNavigations");

                    b.Navigation("BillAllocationUpdatedByNavigations");

                    b.Navigation("BillAllocationUsers");

                    b.Navigation("BillCreatedByNavigations");

                    b.Navigation("BillDeletedByNavigations");

                    b.Navigation("BillGroupCreatedByNavigations");

                    b.Navigation("BillGroupDeletedByNavigations");

                    b.Navigation("BillGroupUpdatedByNavigations");

                    b.Navigation("BillPaidByNavigations");

                    b.Navigation("BillUpdatedByNavigations");

                    b.Navigation("InverseCreatedByNavigation");

                    b.Navigation("InverseDeletedByNavigation");

                    b.Navigation("InverseUpdatedByNavigation");

                    b.Navigation("UserBillGroupCreatedByNavigations");

                    b.Navigation("UserBillGroupDeletedByNavigations");

                    b.Navigation("UserBillGroupUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
