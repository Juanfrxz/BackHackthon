using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "emotionals_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emotionals_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "habits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persons_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "priority_levels",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priority_levels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "risk_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specialtys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialtys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "support_networks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_support_networks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_relations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_relations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usermembers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usermembers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.id);
                    table.ForeignKey(
                        name: "FK_regions_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emotionals_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EmotionalCategoryId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emotionals_types", x => x.id);
                    table.ForeignKey(
                        name: "FK_emotionals_types_emotionals_categories_EmotionalCategoryId",
                        column: x => x.EmotionalCategoryId,
                        principalTable: "emotionals_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "text", nullable: true),
                    expire = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    revoked = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_refresh_tokens_usermembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "usermembers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usermembers_roles",
                columns: table => new
                {
                    memberId = table.Column<int>(type: "integer", nullable: false),
                    roleId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usermembers_roles", x => new { x.memberId, x.roleId });
                    table.ForeignKey(
                        name: "FK_usermembers_roles_roles_roleId",
                        column: x => x.roleId,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usermembers_roles_usermembers_memberId",
                        column: x => x.memberId,
                        principalTable: "usermembers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_cities_regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "persons_profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    PersonTypeId = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons_profiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_profiles_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persons_profiles_persons_types_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "persons_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persons_profiles_usermembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "usermembers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    summary = table.Column<string>(type: "text", nullable: true),
                    logDate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    transcription = table.Column<string>(type: "text", nullable: true),
                    perceptionAnalysis = table.Column<string>(type: "text", nullable: true),
                    PersonProfileId = table.Column<int>(type: "integer", nullable: false),
                    RiskTypeId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_blogs_persons_profiles_PersonProfileId",
                        column: x => x.PersonProfileId,
                        principalTable: "persons_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blogs_risk_types_RiskTypeId",
                        column: x => x.RiskTypeId,
                        principalTable: "risk_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "constituents",
                columns: table => new
                {
                    supportnetworkId = table.Column<int>(type: "integer", nullable: false),
                    PriorityLevelId = table.Column<int>(type: "integer", nullable: false),
                    typeRelationId = table.Column<int>(type: "integer", nullable: false),
                    memberName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    PersonprofileId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_constituents", x => new { x.supportnetworkId, x.typeRelationId, x.PriorityLevelId });
                    table.ForeignKey(
                        name: "FK_constituents_persons_profiles_PersonprofileId",
                        column: x => x.PersonprofileId,
                        principalTable: "persons_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_constituents_priority_levels_PriorityLevelId",
                        column: x => x.PriorityLevelId,
                        principalTable: "priority_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_constituents_support_networks_supportnetworkId",
                        column: x => x.supportnetworkId,
                        principalTable: "support_networks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_constituents_type_relations_typeRelationId",
                        column: x => x.typeRelationId,
                        principalTable: "type_relations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "persons_habits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    registrationDate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    PersonProfileId = table.Column<int>(type: "integer", nullable: false),
                    HabitId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons_habits", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_habits_habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "habits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persons_habits_persons_profiles_PersonProfileId",
                        column: x => x.PersonProfileId,
                        principalTable: "persons_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phones_persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ContactTypeId = table.Column<int>(type: "integer", nullable: false),
                    PersonProfileId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phones_persons", x => x.id);
                    table.ForeignKey(
                        name: "FK_phones_persons_contact_types_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "contact_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phones_persons_persons_profiles_PersonProfileId",
                        column: x => x.PersonProfileId,
                        principalTable: "persons_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professionals",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfessionId = table.Column<int>(type: "integer", nullable: false),
                    PersonProfileId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professionals", x => x.id);
                    table.ForeignKey(
                        name: "FK_professionals_persons_profiles_PersonProfileId",
                        column: x => x.PersonProfileId,
                        principalTable: "persons_profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professionals_professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "professions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emotionals_blogs",
                columns: table => new
                {
                    emotionalTypeId = table.Column<int>(type: "integer", nullable: false),
                    blogId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emotionals_blogs", x => new { x.emotionalTypeId, x.blogId });
                    table.ForeignKey(
                        name: "FK_emotionals_blogs_blogs_blogId",
                        column: x => x.blogId,
                        principalTable: "blogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emotionals_blogs_emotionals_types_emotionalTypeId",
                        column: x => x.emotionalTypeId,
                        principalTable: "emotionals_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specialties",
                columns: table => new
                {
                    professionalId = table.Column<int>(type: "integer", nullable: false),
                    specialtyId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialties", x => new { x.professionalId, x.specialtyId });
                    table.ForeignKey(
                        name: "FK_specialties_professionals_professionalId",
                        column: x => x.professionalId,
                        principalTable: "professionals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specialties_specialtys_specialtyId",
                        column: x => x.specialtyId,
                        principalTable: "specialtys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogs_PersonProfileId",
                table: "blogs",
                column: "PersonProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_RiskTypeId",
                table: "blogs",
                column: "RiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cities_RegionId",
                table: "cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_constituents_PersonprofileId",
                table: "constituents",
                column: "PersonprofileId");

            migrationBuilder.CreateIndex(
                name: "IX_constituents_PriorityLevelId",
                table: "constituents",
                column: "PriorityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_constituents_typeRelationId",
                table: "constituents",
                column: "typeRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_emotionals_blogs_blogId",
                table: "emotionals_blogs",
                column: "blogId");

            migrationBuilder.CreateIndex(
                name: "IX_emotionals_types_EmotionalCategoryId",
                table: "emotionals_types",
                column: "EmotionalCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_persons_habits_HabitId",
                table: "persons_habits",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_persons_habits_PersonProfileId",
                table: "persons_habits",
                column: "PersonProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_persons_profiles_CityId",
                table: "persons_profiles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_persons_profiles_MemberId",
                table: "persons_profiles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_persons_profiles_PersonTypeId",
                table: "persons_profiles",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_phones_persons_ContactTypeId",
                table: "phones_persons",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_phones_persons_PersonProfileId",
                table: "phones_persons",
                column: "PersonProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_professionals_PersonProfileId",
                table: "professionals",
                column: "PersonProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_professionals_ProfessionId",
                table: "professionals",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_MemberId",
                table: "refresh_tokens",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_regions_CountryId",
                table: "regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_specialties_specialtyId",
                table: "specialties",
                column: "specialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_usermembers_roles_roleId",
                table: "usermembers_roles",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "constituents");

            migrationBuilder.DropTable(
                name: "emotionals_blogs");

            migrationBuilder.DropTable(
                name: "persons_habits");

            migrationBuilder.DropTable(
                name: "phones_persons");

            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.DropTable(
                name: "specialties");

            migrationBuilder.DropTable(
                name: "usermembers_roles");

            migrationBuilder.DropTable(
                name: "priority_levels");

            migrationBuilder.DropTable(
                name: "support_networks");

            migrationBuilder.DropTable(
                name: "type_relations");

            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "emotionals_types");

            migrationBuilder.DropTable(
                name: "habits");

            migrationBuilder.DropTable(
                name: "contact_types");

            migrationBuilder.DropTable(
                name: "professionals");

            migrationBuilder.DropTable(
                name: "specialtys");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "risk_types");

            migrationBuilder.DropTable(
                name: "emotionals_categories");

            migrationBuilder.DropTable(
                name: "persons_profiles");

            migrationBuilder.DropTable(
                name: "professions");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "persons_types");

            migrationBuilder.DropTable(
                name: "usermembers");

            migrationBuilder.DropTable(
                name: "regions");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
