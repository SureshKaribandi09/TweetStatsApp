﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TweetStats.Data;

namespace TweetStats.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201219214842_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TweetStats.Data.Models.Stat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumOfTweetsRecieved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PercentOfTweetsWithEmojis")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PercentOfTweetsWithUrl")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PercentofTweetWithImageUrl")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeRecieved")
                        .HasColumnType("TEXT");

                    b.Property<string>("TopDomains")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TopHashtags")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
