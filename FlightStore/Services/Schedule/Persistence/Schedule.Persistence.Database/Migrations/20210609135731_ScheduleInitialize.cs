﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Persistence.Database.Migrations
{
    public partial class ScheduleInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Schedule");

            migrationBuilder.CreateTable(
                name: "Flights",
                schema: "Schedule",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                schema: "Schedule",
                columns: table => new
                {
                    TransportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.TransportId);
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Flights",
                columns: new[] { "FlightId", "ArrivalStation", "Currency", "DepartureDate", "DepartureStation", "Price" },
                values: new object[,]
                {
                    { 1, "BAQ", "$", new DateTime(2021, 6, 9, 9, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 745m },
                    { 72, "BOG", "$", new DateTime(2021, 6, 12, 8, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 342m },
                    { 71, "BAQ", "$", new DateTime(2021, 6, 12, 7, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 256m },
                    { 70, "AXM", "$", new DateTime(2021, 6, 12, 6, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 478m },
                    { 69, "PEI", "$", new DateTime(2021, 6, 12, 5, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 279m },
                    { 68, "MDE", "$", new DateTime(2021, 6, 12, 4, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 608m },
                    { 67, "LET", "$", new DateTime(2021, 6, 12, 3, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 629m },
                    { 65, "CUC", "$", new DateTime(2021, 6, 12, 1, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 986m },
                    { 64, "CLO", "$", new DateTime(2021, 6, 12, 0, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 371m },
                    { 63, "BGA", "$", new DateTime(2021, 6, 11, 23, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 375m },
                    { 62, "BOG", "$", new DateTime(2021, 6, 11, 22, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 845m },
                    { 61, "BAQ", "$", new DateTime(2021, 6, 11, 21, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 567m },
                    { 60, "AXM", "$", new DateTime(2021, 6, 11, 20, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CTG", 422m },
                    { 59, "PEI", "$", new DateTime(2021, 6, 11, 19, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 959m },
                    { 58, "MDE", "$", new DateTime(2021, 6, 11, 18, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 782m },
                    { 57, "LET", "$", new DateTime(2021, 6, 11, 17, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 948m },
                    { 56, "CTG", "$", new DateTime(2021, 6, 11, 16, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 968m },
                    { 54, "CLO", "$", new DateTime(2021, 6, 11, 14, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 962m },
                    { 53, "BGA", "$", new DateTime(2021, 6, 11, 13, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 602m },
                    { 52, "BOG", "$", new DateTime(2021, 6, 11, 12, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 282m },
                    { 73, "BGA", "$", new DateTime(2021, 6, 12, 9, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 957m },
                    { 51, "BAQ", "$", new DateTime(2021, 6, 11, 11, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 297m },
                    { 74, "CLO", "$", new DateTime(2021, 6, 12, 10, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 491m },
                    { 78, "MDE", "$", new DateTime(2021, 6, 12, 14, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 731m },
                    { 98, "MDE", "$", new DateTime(2021, 6, 13, 10, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 980m },
                    { 97, "LET", "$", new DateTime(2021, 6, 13, 9, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 865m },
                    { 96, "CTG", "$", new DateTime(2021, 6, 13, 8, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 734m },
                    { 95, "CUC", "$", new DateTime(2021, 6, 13, 7, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 495m },
                    { 94, "CLO", "$", new DateTime(2021, 6, 13, 6, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 870m },
                    { 93, "BGA", "$", new DateTime(2021, 6, 13, 5, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 518m },
                    { 92, "BOG", "$", new DateTime(2021, 6, 13, 4, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 288m },
                    { 91, "BAQ", "$", new DateTime(2021, 6, 13, 3, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 536m },
                    { 90, "AXM", "$", new DateTime(2021, 6, 13, 2, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "PEI", 298m },
                    { 89, "PEI", "$", new DateTime(2021, 6, 13, 1, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 439m },
                    { 87, "LET", "$", new DateTime(2021, 6, 12, 23, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 458m },
                    { 86, "CTG", "$", new DateTime(2021, 6, 12, 22, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 446m },
                    { 85, "CUC", "$", new DateTime(2021, 6, 12, 21, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 318m },
                    { 84, "CLO", "$", new DateTime(2021, 6, 12, 20, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 662m },
                    { 83, "BGA", "$", new DateTime(2021, 6, 12, 19, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 332m },
                    { 82, "BOG", "$", new DateTime(2021, 6, 12, 18, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 402m },
                    { 81, "BAQ", "$", new DateTime(2021, 6, 12, 17, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 546m },
                    { 80, "AXM", "$", new DateTime(2021, 6, 12, 16, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "MDE", 438m }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Flights",
                columns: new[] { "FlightId", "ArrivalStation", "Currency", "DepartureDate", "DepartureStation", "Price" },
                values: new object[,]
                {
                    { 79, "PEI", "$", new DateTime(2021, 6, 12, 15, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 573m },
                    { 76, "CTG", "$", new DateTime(2021, 6, 12, 12, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 865m },
                    { 50, "AXM", "$", new DateTime(2021, 6, 11, 10, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CUC", 740m },
                    { 75, "CUC", "$", new DateTime(2021, 6, 12, 11, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "LET", 537m },
                    { 48, "MDE", "$", new DateTime(2021, 6, 11, 8, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 754m },
                    { 21, "BAQ", "$", new DateTime(2021, 6, 10, 5, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 926m },
                    { 20, "AXM", "$", new DateTime(2021, 6, 10, 4, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 922m },
                    { 19, "PEI", "$", new DateTime(2021, 6, 10, 3, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 725m },
                    { 18, "MDE", "$", new DateTime(2021, 6, 10, 2, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 203m },
                    { 17, "LET", "$", new DateTime(2021, 6, 10, 1, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 904m },
                    { 16, "CTG", "$", new DateTime(2021, 6, 10, 0, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 463m },
                    { 15, "CUC", "$", new DateTime(2021, 6, 9, 23, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 886m },
                    { 14, "CLO", "$", new DateTime(2021, 6, 9, 22, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 579m },
                    { 12, "BOG", "$", new DateTime(2021, 6, 9, 20, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 419m },
                    { 10, "AXM", "$", new DateTime(2021, 6, 9, 18, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 874m },
                    { 9, "PEI", "$", new DateTime(2021, 6, 9, 17, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 766m },
                    { 8, "MDE", "$", new DateTime(2021, 6, 9, 16, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 330m },
                    { 7, "LET", "$", new DateTime(2021, 6, 9, 15, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 546m },
                    { 6, "CTG", "$", new DateTime(2021, 6, 9, 14, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 810m },
                    { 5, "CUC", "$", new DateTime(2021, 6, 9, 13, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 524m },
                    { 4, "CLO", "$", new DateTime(2021, 6, 9, 12, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 370m },
                    { 3, "BGA", "$", new DateTime(2021, 6, 9, 11, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 687m },
                    { 2, "BOG", "$", new DateTime(2021, 6, 9, 10, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "AXM", 718m },
                    { 49, "PEI", "$", new DateTime(2021, 6, 11, 9, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 265m },
                    { 23, "BGA", "$", new DateTime(2021, 6, 10, 7, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 612m },
                    { 24, "CLO", "$", new DateTime(2021, 6, 10, 8, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 377m },
                    { 13, "BGA", "$", new DateTime(2021, 6, 9, 21, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BAQ", 651m },
                    { 25, "CUC", "$", new DateTime(2021, 6, 10, 9, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 873m },
                    { 47, "LET", "$", new DateTime(2021, 6, 11, 7, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 715m },
                    { 46, "CTG", "$", new DateTime(2021, 6, 11, 6, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 480m },
                    { 45, "CUC", "$", new DateTime(2021, 6, 11, 5, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 723m },
                    { 43, "BGA", "$", new DateTime(2021, 6, 11, 3, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 575m },
                    { 42, "BOG", "$", new DateTime(2021, 6, 11, 2, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 487m },
                    { 41, "BAQ", "$", new DateTime(2021, 6, 11, 1, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 629m },
                    { 39, "PEI", "$", new DateTime(2021, 6, 10, 23, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 597m },
                    { 38, "MDE", "$", new DateTime(2021, 6, 10, 22, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 548m },
                    { 37, "LET", "$", new DateTime(2021, 6, 10, 21, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 287m },
                    { 36, "CTG", "$", new DateTime(2021, 6, 10, 20, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 693m },
                    { 40, "AXM", "$", new DateTime(2021, 6, 11, 0, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "CLO", 373m },
                    { 35, "CUC", "$", new DateTime(2021, 6, 10, 19, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 277m },
                    { 34, "CLO", "$", new DateTime(2021, 6, 10, 18, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 818m },
                    { 32, "BOG", "$", new DateTime(2021, 6, 10, 16, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 487m }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Flights",
                columns: new[] { "FlightId", "ArrivalStation", "Currency", "DepartureDate", "DepartureStation", "Price" },
                values: new object[,]
                {
                    { 31, "BAQ", "$", new DateTime(2021, 6, 10, 15, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 251m },
                    { 30, "AXM", "$", new DateTime(2021, 6, 10, 14, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BGA", 938m },
                    { 29, "PEI", "$", new DateTime(2021, 6, 10, 13, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 381m },
                    { 28, "MDE", "$", new DateTime(2021, 6, 10, 12, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 537m },
                    { 27, "LET", "$", new DateTime(2021, 6, 10, 11, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 999m },
                    { 26, "CTG", "$", new DateTime(2021, 6, 10, 10, 57, 31, 62, DateTimeKind.Local).AddTicks(9093), "BOG", 511m }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 265, 73, "b9jfhr" },
                    { 266, 93, "dkxf14" },
                    { 267, 23, "7sdco1" },
                    { 268, 76, "obo99i" },
                    { 271, 66, "zh2wjt" },
                    { 270, 18, "d6hbsq" },
                    { 272, 2, "hi9qvb" },
                    { 264, 64, "7e66lb" },
                    { 269, 92, "3d7zpj" },
                    { 263, 24, "qdagez" },
                    { 253, 52, "5rq13b" },
                    { 261, 13, "4tlwdi" },
                    { 260, 25, "36p9a4" },
                    { 259, 58, "e3p2ai" },
                    { 258, 51, "22s8wo" },
                    { 257, 19, "k4l19z" },
                    { 256, 43, "n0c8hq" },
                    { 255, 50, "0e9l1x" },
                    { 254, 69, "09gvdo" },
                    { 252, 1, "otre0y" },
                    { 273, 44, "q9tic1" },
                    { 262, 49, "5cvrfn" },
                    { 274, 57, "5glyw2" },
                    { 296, 80, "xpfac5" },
                    { 276, 66, "9ici3c" },
                    { 251, 22, "zakig4" },
                    { 297, 48, "hyszlw" },
                    { 295, 91, "d9hyt5" },
                    { 294, 32, "plifq5" },
                    { 293, 81, "1s36yj" },
                    { 292, 31, "n7d4ws" },
                    { 291, 83, "1q969b" },
                    { 290, 15, "3tswxw" },
                    { 289, 45, "uv4g6t" },
                    { 288, 96, "l7kzlz" },
                    { 287, 26, "b2x3wj" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 286, 20, "kuc7zh" },
                    { 285, 57, "s7tvnq" },
                    { 284, 21, "023gt3" },
                    { 283, 53, "si7t1b" },
                    { 282, 99, "j9lpq7" },
                    { 281, 6, "hinl49" },
                    { 280, 27, "aqr8xj" },
                    { 279, 71, "18xtei" },
                    { 278, 35, "vqugq3" },
                    { 277, 34, "6vpdkj" },
                    { 275, 52, "yvbcg4" },
                    { 250, 36, "dtes00" },
                    { 205, 30, "kvzpfx" },
                    { 248, 8, "0a2rvz" },
                    { 222, 52, "v4hcd1" },
                    { 221, 57, "jgi2xf" },
                    { 220, 10, "q5nsor" },
                    { 219, 91, "ndhxkl" },
                    { 218, 63, "3pxk5o" },
                    { 217, 86, "8iust1" },
                    { 216, 86, "byxifw" },
                    { 215, 64, "8j05kz" },
                    { 214, 54, "jypeqf" },
                    { 213, 26, "o7a1h8" },
                    { 212, 45, "w3t4te" },
                    { 211, 8, "ft747u" },
                    { 210, 29, "606xie" },
                    { 209, 79, "7qva2k" },
                    { 208, 92, "ordnf5" },
                    { 207, 95, "kiv6d6" },
                    { 206, 99, "h2e5t4" },
                    { 298, 5, "ko7yai" },
                    { 204, 42, "9lnaja" },
                    { 203, 35, "lgkwi0" },
                    { 202, 8, "335hpe" },
                    { 223, 14, "7tedqb" },
                    { 249, 31, "g8i60g" },
                    { 224, 96, "k5scoj" },
                    { 226, 32, "zeh0zr" },
                    { 247, 87, "5ggx4q" },
                    { 246, 27, "tuhx8e" },
                    { 245, 53, "lgtfvv" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 244, 98, "5850ya" },
                    { 243, 56, "swwdg3" },
                    { 242, 24, "6wz2p8" },
                    { 241, 83, "yvwjsz" },
                    { 240, 86, "gscg3n" },
                    { 239, 59, "2yojtq" },
                    { 238, 75, "gwliu3" },
                    { 237, 44, "9ts4jv" },
                    { 236, 66, "1ajxgh" },
                    { 235, 95, "0b5z5j" },
                    { 234, 29, "uavvli" },
                    { 233, 64, "z1f8ye" },
                    { 232, 24, "5fjhlz" },
                    { 231, 34, "3srupc" },
                    { 230, 57, "sh11bl" },
                    { 229, 97, "ac6wva" },
                    { 228, 10, "hdb8ys" },
                    { 227, 6, "p1b5kb" },
                    { 225, 92, "eincd2" },
                    { 299, 47, "ihuvzr" },
                    { 344, 87, "zzdoc7" },
                    { 301, 14, "2tposz" },
                    { 373, 42, "v296h9" },
                    { 372, 55, "7h48c0" },
                    { 371, 29, "80f55i" },
                    { 370, 62, "27gxeq" },
                    { 369, 52, "b1j53p" },
                    { 368, 28, "thudil" },
                    { 367, 45, "zt6ftx" },
                    { 366, 75, "4o8knn" },
                    { 365, 54, "zdicdp" },
                    { 364, 95, "rscksk" },
                    { 363, 5, "rjuu55" },
                    { 362, 10, "uffaov" },
                    { 361, 78, "vpcohz" },
                    { 360, 92, "f78vks" },
                    { 359, 9, "co4j7w" },
                    { 358, 34, "fdyjoz" },
                    { 357, 69, "71zyf0" },
                    { 356, 22, "xvgdbb" },
                    { 355, 27, "g2781n" },
                    { 354, 55, "quo50k" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 353, 83, "dz0pig" },
                    { 374, 15, "oyfvyz" },
                    { 352, 60, "dgeybj" },
                    { 375, 81, "9ul2an" },
                    { 377, 77, "0fc7q8" },
                    { 398, 16, "jar8z6" },
                    { 397, 69, "26xpt7" },
                    { 396, 96, "d2rf9b" },
                    { 395, 16, "dtt1sz" },
                    { 394, 20, "huj88d" },
                    { 393, 21, "c4p0lr" },
                    { 392, 53, "k4s7nl" },
                    { 391, 37, "86h32a" },
                    { 390, 40, "3x5d28" },
                    { 389, 50, "u6j2p8" },
                    { 388, 21, "7kkyhz" },
                    { 387, 5, "9ip22z" },
                    { 386, 87, "fc9kky" },
                    { 385, 3, "rgx1nf" },
                    { 384, 63, "j0dd8z" },
                    { 383, 10, "24rozi" },
                    { 382, 25, "kkh6sg" },
                    { 381, 46, "0jlt0r" },
                    { 380, 93, "907q08" },
                    { 379, 69, "l18gfh" },
                    { 378, 12, "5ygd26" },
                    { 376, 20, "ykiewb" },
                    { 351, 40, "rr281n" },
                    { 350, 11, "nicn98" },
                    { 349, 55, "wcr0ry" },
                    { 322, 4, "ntx6he" },
                    { 321, 80, "dpfd09" },
                    { 320, 81, "vyd9vk" },
                    { 319, 24, "gjn3c1" },
                    { 318, 58, "2fllaf" },
                    { 317, 66, "fyf3us" },
                    { 316, 40, "o8cni0" },
                    { 315, 94, "hqaprd" },
                    { 314, 92, "gt4bsw" },
                    { 313, 20, "wzud6o" },
                    { 312, 96, "p818dp" },
                    { 311, 58, "b5xbg9" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 310, 80, "cc6yb4" },
                    { 309, 23, "8cuxg2" },
                    { 308, 22, "ed3xfj" },
                    { 307, 15, "xdy2oi" },
                    { 306, 74, "5scbfd" },
                    { 305, 79, "obvwwc" },
                    { 304, 39, "l7f3h5" },
                    { 303, 85, "hp1zsw" },
                    { 302, 82, "exzikx" },
                    { 323, 68, "skjkn6" },
                    { 324, 82, "yccs9z" },
                    { 325, 75, "11zolk" },
                    { 326, 43, "456wt8" },
                    { 348, 38, "a0nvfb" },
                    { 347, 89, "98v6u9" },
                    { 346, 24, "x7xlig" },
                    { 345, 15, "ycl78y" },
                    { 201, 55, "210iws" },
                    { 343, 46, "0p0xhh" },
                    { 342, 58, "pcw47g" },
                    { 341, 81, "t7ov7p" },
                    { 340, 69, "d6ozdr" },
                    { 339, 28, "y5p2w6" },
                    { 300, 35, "vcdcu1" },
                    { 338, 26, "d2gk13" },
                    { 336, 99, "qnrfx3" },
                    { 335, 95, "4w03xk" },
                    { 334, 44, "r5w1vj" },
                    { 333, 37, "5rp7k9" },
                    { 332, 11, "kbyahy" },
                    { 331, 52, "daupb4" },
                    { 330, 95, "r2sca9" },
                    { 329, 18, "fj21t0" },
                    { 328, 31, "dcybsn" },
                    { 327, 72, "e5v7d5" },
                    { 337, 87, "kayfza" },
                    { 200, 50, "h87buv" },
                    { 155, 21, "dhxl0y" },
                    { 198, 42, "2hqxy2" },
                    { 71, 39, "jq0sk9" },
                    { 70, 50, "cw255i" },
                    { 69, 89, "ii8zi4" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 68, 92, "lsnc0k" },
                    { 67, 84, "ck841x" },
                    { 66, 53, "l7qs1e" },
                    { 65, 52, "0giheu" },
                    { 64, 8, "1u3f7w" },
                    { 63, 4, "7vaxd5" },
                    { 62, 63, "jszkis" },
                    { 61, 85, "vbpc1z" },
                    { 60, 90, "4h8xor" },
                    { 59, 97, "sisnss" },
                    { 58, 34, "yjj7dx" },
                    { 57, 24, "d1vr9j" },
                    { 56, 10, "go43ql" },
                    { 55, 94, "ibfkoi" },
                    { 54, 9, "0ko810" },
                    { 53, 48, "py3s7z" },
                    { 52, 57, "t3t1r1" },
                    { 51, 95, "9r2znx" },
                    { 72, 14, "gxp7ua" },
                    { 50, 24, "cclrru" },
                    { 73, 45, "4oz4gd" },
                    { 75, 98, "u6bxeo" },
                    { 96, 17, "g4jwqh" },
                    { 95, 63, "3onzzp" },
                    { 94, 33, "jkhdlt" },
                    { 93, 41, "iqlwtr" },
                    { 92, 85, "a53d23" },
                    { 91, 24, "i6ix2e" },
                    { 90, 36, "hp0s5g" },
                    { 89, 59, "efu0v7" },
                    { 88, 80, "fzssed" },
                    { 87, 77, "rslsnp" },
                    { 86, 96, "fy0nan" },
                    { 85, 89, "3evyf2" },
                    { 84, 13, "87bfsa" },
                    { 83, 67, "vvyiy1" },
                    { 82, 8, "t4uhq6" },
                    { 81, 76, "lps6xi" },
                    { 80, 23, "haq43r" },
                    { 79, 6, "8i4oc6" },
                    { 78, 81, "k82yx3" },
                    { 77, 80, "sff2i3" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 76, 8, "wh0ipj" },
                    { 74, 31, "g4ki9e" },
                    { 97, 78, "otdc4b" },
                    { 49, 37, "dgtvj0" },
                    { 47, 50, "ztk261" },
                    { 21, 50, "bx951t" },
                    { 20, 31, "0bcptg" },
                    { 19, 33, "yd7prj" },
                    { 18, 64, "di87tz" },
                    { 17, 37, "0792aq" },
                    { 16, 43, "83f6c7" },
                    { 15, 28, "4io71g" },
                    { 14, 78, "dnb2ot" },
                    { 13, 12, "h1or27" },
                    { 12, 4, "tki3p5" },
                    { 11, 62, "bta83k" },
                    { 10, 41, "ef2a8s" },
                    { 9, 21, "j2fwsg" },
                    { 8, 32, "rddc9f" },
                    { 7, 82, "djo5rs" },
                    { 6, 39, "pfd0f9" },
                    { 5, 44, "irfydg" },
                    { 4, 61, "f6qsu7" },
                    { 3, 99, "7d3zcq" },
                    { 2, 16, "vjwu8v" },
                    { 1, 29, "cveqkk" },
                    { 22, 38, "lg1v5d" },
                    { 48, 46, "w3av26" },
                    { 23, 45, "nw1az4" },
                    { 25, 97, "8ei6a6" },
                    { 46, 20, "hb7un0" },
                    { 45, 48, "ld2nfw" },
                    { 44, 38, "tlzy7r" },
                    { 43, 67, "f8aol0" },
                    { 42, 73, "2ovl2g" },
                    { 41, 54, "kypx46" },
                    { 40, 68, "5of4hw" },
                    { 39, 1, "peea4x" },
                    { 38, 88, "n7o3a5" },
                    { 37, 8, "seq5hn" },
                    { 36, 27, "vj6yp2" },
                    { 35, 59, "dzhd4v" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 34, 23, "etl3p2" },
                    { 33, 59, "upa1y6" },
                    { 32, 48, "wn0q8f" },
                    { 31, 36, "eb7t66" },
                    { 30, 58, "eojoij" },
                    { 29, 53, "rssaet" },
                    { 28, 30, "dcbaag" },
                    { 27, 63, "b6s95z" },
                    { 26, 70, "sb2ttb" },
                    { 24, 78, "tisot3" },
                    { 98, 23, "9u0hwv" },
                    { 99, 73, "ek89v8" },
                    { 100, 50, "a3k7o9" },
                    { 172, 63, "l5u8d3" },
                    { 171, 29, "iwi6qc" },
                    { 170, 6, "8ln2yt" },
                    { 169, 75, "e3jf9u" },
                    { 168, 39, "bedfoj" },
                    { 167, 54, "c5y8kj" },
                    { 166, 96, "pr12wu" },
                    { 165, 47, "hoqa10" },
                    { 164, 45, "obpf1r" },
                    { 163, 39, "zxepik" },
                    { 162, 95, "kh4a2h" },
                    { 161, 21, "qqsyfs" },
                    { 160, 15, "9zh76w" },
                    { 159, 44, "wd910i" },
                    { 158, 48, "9xnygb" },
                    { 157, 53, "gp9ijw" },
                    { 156, 22, "k77pbi" },
                    { 399, 47, "gnzzvr" },
                    { 154, 16, "fwnawe" },
                    { 153, 54, "nui7r6" },
                    { 152, 71, "kbgous" },
                    { 173, 77, "6fvuo8" },
                    { 151, 11, "4fdzed" },
                    { 174, 20, "q0r41u" },
                    { 176, 45, "25i9x5" },
                    { 197, 8, "1n4k2s" },
                    { 196, 42, "y5ydqj" },
                    { 195, 78, "ro1fko" },
                    { 194, 70, "436ck6" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 193, 35, "n6yck3" },
                    { 192, 79, "x98zj1" },
                    { 191, 73, "942otx" },
                    { 190, 95, "t778fo" },
                    { 189, 55, "b08vp3" },
                    { 188, 27, "fo6n36" },
                    { 187, 11, "7pg8ww" },
                    { 186, 62, "de04uz" },
                    { 185, 29, "1oqtnb" },
                    { 184, 96, "nyby63" },
                    { 183, 16, "rsr510" },
                    { 182, 36, "bvia7s" },
                    { 181, 12, "ot8f4d" },
                    { 180, 48, "f0cqnw" },
                    { 179, 20, "353qtb" },
                    { 178, 7, "63av84" },
                    { 177, 56, "bqystq" },
                    { 175, 68, "wy7ww4" },
                    { 150, 86, "yhr7zx" },
                    { 149, 22, "wf0kbe" },
                    { 148, 55, "wyl2va" },
                    { 121, 15, "453hcu" },
                    { 120, 71, "78cgo2" },
                    { 119, 2, "g77jr4" },
                    { 118, 97, "3tz4sj" },
                    { 117, 42, "qzrfc2" },
                    { 116, 93, "4caz60" },
                    { 115, 50, "rtglcx" },
                    { 114, 90, "tzs47b" },
                    { 113, 99, "9ngvc6" },
                    { 112, 60, "4achst" },
                    { 111, 65, "tok0bw" },
                    { 110, 3, "835j1k" },
                    { 109, 87, "icj40q" },
                    { 108, 53, "edgxki" },
                    { 107, 98, "hyoylf" },
                    { 106, 5, "tqagei" },
                    { 105, 93, "exgagt" },
                    { 104, 33, "wp4eo0" },
                    { 103, 83, "3g5idy" },
                    { 102, 24, "r3jgut" },
                    { 101, 82, "72n5dp" }
                });

            migrationBuilder.InsertData(
                schema: "Schedule",
                table: "Transports",
                columns: new[] { "TransportId", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { 122, 10, "n8yqvo" },
                    { 123, 30, "nzg05v" },
                    { 124, 39, "gt4k6g" },
                    { 125, 14, "dubrnz" },
                    { 147, 23, "fe42d6" },
                    { 146, 39, "uwsjpg" },
                    { 145, 16, "xt0p4n" },
                    { 144, 86, "r63j7s" },
                    { 143, 27, "ay0rr3" },
                    { 142, 53, "hx1b0l" },
                    { 141, 46, "auh1bp" },
                    { 140, 42, "5kg7yn" },
                    { 139, 24, "bor2wu" },
                    { 138, 43, "nv3sg4" },
                    { 199, 16, "1xsdg1" },
                    { 137, 4, "qd5u13" },
                    { 135, 26, "9oox4i" },
                    { 134, 59, "lr1ibe" },
                    { 133, 28, "qinz3s" },
                    { 132, 73, "ffqaqb" },
                    { 131, 69, "3eox1f" },
                    { 130, 36, "huvvgw" },
                    { 129, 38, "gbbhkb" },
                    { 128, 19, "e7yr5j" },
                    { 127, 71, "nhyuat" },
                    { 126, 98, "qkeh0v" },
                    { 136, 30, "zco53d" },
                    { 400, 16, "f86rn9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FlightId",
                schema: "Schedule",
                table: "Flights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_TransportId",
                schema: "Schedule",
                table: "Transports",
                column: "TransportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights",
                schema: "Schedule");

            migrationBuilder.DropTable(
                name: "Transports",
                schema: "Schedule");
        }
    }
}
