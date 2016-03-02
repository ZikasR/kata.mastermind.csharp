using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Mastermind.Models;

namespace Mastermind.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mastermind.Models.Codepeg", b =>
                {
                    b.Property<int>("CodepegId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<int?>("GameGameId");

                    b.Property<int>("Location");

                    b.HasKey("CodepegId");
                });

            modelBuilder.Entity("Mastermind.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<string>("PlayerName");

                    b.Property<DateTime>("Start");

                    b.Property<Guid>("Token");

                    b.HasKey("GameId");
                });

            modelBuilder.Entity("Mastermind.Models.Codepeg", b =>
                {
                    b.HasOne("Mastermind.Models.Game")
                        .WithMany()
                        .HasForeignKey("GameGameId");
                });
        }
    }
}
