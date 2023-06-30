using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessCenterFrameworkControllers.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendance_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentClass",
                columns: table => new
                {
                    EquipmentClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentClass", x => x.EquipmentClassId);
                    table.ForeignKey(
                        name: "FK_EquipmentClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentClass_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("0aca32ea-ffea-4f49-8d03-4cb7a5395919"), "2873 Wiza Shoals, Port Adalbertobury, Liechtenstein", "Tamara29@gmail.com", "Tamara", "Mante", "21 (436) 97-60" },
                    { new Guid("124c5327-ecf3-4935-b9fd-c5ed4160391d"), "92959 Halvorson Isle, Amosside, Spain", "Abraham_Rempel91@hotmail.com", "Abraham", "Rempel", "39 (492) 19-57" },
                    { new Guid("176d9a75-94a8-4205-91f7-73905d6c9f74"), "658 Ankunding Ranch, Raynormouth, Morocco", "Chaim_Stamm54@yahoo.com", "Chaim", "Stamm", "55 (369) 88-15" },
                    { new Guid("17c77a46-da2c-4b96-8388-fe64f151404e"), "256 Brittany Views, Port Christelle, Venezuela", "Brittany.Ryan85@yahoo.com", "Brittany", "Ryan", "75 (039) 83-87" },
                    { new Guid("18f25cb0-a878-40d8-8d59-d4ffece01897"), "8334 Greg Lodge, Erikamouth, Latvia", "Garland.Labadie@yahoo.com", "Garland", "Labadie", "17 (280) 94-97" },
                    { new Guid("1cafab03-1491-4d63-9ef3-24d48ef65d44"), "0895 Bahringer Gateway, Adellaview, Turkey", "Stephanie_Morissette@yahoo.com", "Stephanie", "Morissette", "55 (927) 19-12" },
                    { new Guid("1e5b278c-1fed-4cc2-a48b-cf1e4979c735"), "582 Immanuel Coves, Swiftchester, Guyana", "Marcelino.Christiansen@yahoo.com", "Marcelino", "Christiansen", "09 (732) 87-52" },
                    { new Guid("24f0d318-55eb-47d8-8925-70ef553d4745"), "81332 Kutch Valleys, West Preciousberg, Macao", "Milo36@hotmail.com", "Milo", "Russel", "31 (771) 06-69" },
                    { new Guid("2764ffa2-fcc6-4f3e-b65e-fd14a5d04700"), "107 Davin Parks, Binsmouth, Rwanda", "Herbert76@gmail.com", "Herbert", "Trantow", "04 (529) 64-21" },
                    { new Guid("32cf5e73-fd17-42c2-a41d-ba21ac44f81b"), "5740 Orn Ridge, Lake Modestashire, Cayman Islands", "Kaela.Nikolaus@yahoo.com", "Kaela", "Nikolaus", "08 (367) 74-05" },
                    { new Guid("34b43989-b439-4d5e-9c31-2a4bee9ec55e"), "815 Hand Glens, Destineebury, Lebanon", "Josie52@hotmail.com", "Josie", "Little", "20 (491) 45-75" },
                    { new Guid("3eeb28c3-deb2-4934-8bc3-c9678b02c4e7"), "0719 Rodolfo Flat, Dorismouth, Azerbaijan", "Maude.Parker36@yahoo.com", "Maude", "Parker", "39 (613) 92-51" },
                    { new Guid("44659a54-101a-4243-98e3-928f906d93a2"), "389 Walter Fields, Antoniotown, Honduras", "Lina_Boyer@yahoo.com", "Lina", "Boyer", "50 (654) 40-47" },
                    { new Guid("448bd6f0-7281-4759-8e99-6aa40b8c2ee1"), "026 Maynard Points, North Berthaburgh, Kyrgyz Republic", "Lawrence.Veum75@hotmail.com", "Lawrence", "Veum", "45 (342) 47-15" },
                    { new Guid("451640a5-0dff-4ff9-8b15-51be9fee5746"), "7453 Shields Shores, Friedaton, Mexico", "Noemy52@hotmail.com", "Noemy", "Kerluke", "29 (569) 18-67" },
                    { new Guid("4d66d0ee-947e-4579-be7a-3e3d6ec73768"), "5000 Carlos Road, North Rebekafurt, Benin", "Shaniya_Gaylord64@yahoo.com", "Shaniya", "Gaylord", "02 (191) 96-53" },
                    { new Guid("5145e1e5-754f-456e-ab12-380e46cd25c9"), "39362 Osbaldo Cliff, West Quentinchester, Republic of Korea", "Ibrahim_DuBuque@yahoo.com", "Ibrahim", "DuBuque", "02 (416) 36-59" },
                    { new Guid("5fb63832-6bac-4e71-90ad-b24ad67461b8"), "9909 Lind Meadows, Abigayleberg, Israel", "Jed34@gmail.com", "Jed", "Cronin", "09 (377) 62-54" },
                    { new Guid("60cf6a5c-80ee-4a3a-8803-06b66c66e36c"), "4774 Jennifer Cliff, East Antwonburgh, Kuwait", "Mya.Kuphal20@gmail.com", "Mya", "Kuphal", "78 (105) 05-75" },
                    { new Guid("635f4f32-50e8-47eb-b1fb-e22bdb82e028"), "6763 Witting Courts, North Litzy, Iran", "Taurean33@hotmail.com", "Taurean", "Johns", "72 (394) 15-11" },
                    { new Guid("63abc1d4-127d-4575-a7fd-3606ef1e724a"), "671 Altenwerth Canyon, Lake Demarioshire, Jersey", "Lucile.Emard28@yahoo.com", "Lucile", "Emard", "36 (866) 57-46" },
                    { new Guid("649ce298-629b-4846-bc8c-1bb0ff6aaff3"), "80503 Emory Divide, Port Kelli, Ghana", "Emelie_Huels@yahoo.com", "Emelie", "Huels", "69 (013) 73-45" },
                    { new Guid("64da1a27-bc10-4bf1-bc47-526a488cbe7d"), "39401 Swift Route, Mosciskihaven, Tajikistan", "Montana85@gmail.com", "Montana", "Aufderhar", "87 (986) 09-10" },
                    { new Guid("6c041b84-d055-4227-94a5-f2f7ef5d60de"), "04045 Domenico Garden, South Muhammad, Democratic People's Republic of Korea", "Hobart_Dare73@gmail.com", "Hobart", "Dare", "07 (628) 31-11" },
                    { new Guid("730f8a97-cf99-4215-ba82-cd2fb3351ba1"), "93154 Kuhic Burgs, South Sonnyside, Algeria", "Fredrick_Moen3@gmail.com", "Fredrick", "Moen", "81 (510) 99-08" },
                    { new Guid("7aa6fcc6-25e8-4f79-b7fe-d053e1e20e78"), "58341 Macejkovic Highway, Waltershire, Maldives", "Lily.Predovic@hotmail.com", "Lily", "Predovic", "72 (942) 79-52" },
                    { new Guid("7aaf255d-aad0-4d4a-bfc9-6a7cffbc3b43"), "04358 Crona Crescent, Port Kenna, Saint Vincent and the Grenadines", "Gregorio_Kuvalis@hotmail.com", "Gregorio", "Kuvalis", "67 (701) 67-28" },
                    { new Guid("83b19798-1176-44e8-a717-b9ed4ac23cb7"), "04846 Bradtke Stravenue, East Laishaton, Senegal", "Earline64@gmail.com", "Earline", "Weimann", "01 (380) 56-66" },
                    { new Guid("88af0a21-835e-4861-89e8-4c0dcfadae4a"), "46473 Brekke Rapid, Williamsonland, Belize", "Ladarius93@gmail.com", "Ladarius", "Bartoletti", "03 (536) 00-37" },
                    { new Guid("904ecce7-a25a-4c37-b3fa-b14c71b55e14"), "5217 Santina Springs, East Grayceshire, Spain", "Oceane20@gmail.com", "Oceane", "Bernhard", "14 (825) 65-30" },
                    { new Guid("90567b15-12de-431d-8c18-2597ef948af6"), "6197 Swift Islands, Chloefurt, Benin", "Candido.Torphy41@yahoo.com", "Candido", "Torphy", "20 (823) 47-92" },
                    { new Guid("926211e8-fa2b-41c3-ad8b-8da4d6c76518"), "742 Anastasia Well, Ankundingborough, Philippines", "Pattie84@gmail.com", "Pattie", "Gusikowski", "70 (407) 45-83" },
                    { new Guid("941803f4-8e93-46c8-a97c-fc3896a630f0"), "79641 Laila Roads, Dooleystad, Montenegro", "Marcella.Altenwerth@gmail.com", "Marcella", "Altenwerth", "74 (407) 43-25" },
                    { new Guid("967fc6d2-34a7-4ece-b0dd-361a7264b0d8"), "0881 Larson Meadow, Ernserside, Bahrain", "Clair.Leannon77@yahoo.com", "Clair", "Leannon", "40 (419) 08-89" },
                    { new Guid("9b576549-29ef-4b08-aa38-9b8ffc45f5a9"), "34009 Valentin Island, Roobton, Jordan", "Loyal47@gmail.com", "Loyal", "Herman", "84 (345) 08-65" },
                    { new Guid("a02ee119-bbf8-4615-9ca3-f6bd40723c5f"), "2802 Toby Mountains, Lake Alfredo, Bulgaria", "Violet98@hotmail.com", "Violet", "Welch", "89 (166) 54-15" },
                    { new Guid("a6afe325-3ee2-4803-b067-88fec590968e"), "7375 Sabina Wall, Hammesside, Cayman Islands", "Hardy36@gmail.com", "Hardy", "Krajcik", "87 (731) 99-13" },
                    { new Guid("ae7f4b25-f70b-4b3d-92a0-fdec6669464b"), "62574 Morissette Mill, Lake Regan, Mayotte", "Clinton.Wilkinson@yahoo.com", "Clinton", "Wilkinson", "86 (566) 37-96" },
                    { new Guid("ae92defd-67aa-482d-baa8-27f05f1cbff5"), "474 Lavonne Well, Christatown, Bouvet Island (Bouvetoya)", "Wendell_Lind@hotmail.com", "Wendell", "Lind", "38 (323) 01-64" },
                    { new Guid("b5d9db3c-0f34-4717-bf2a-c341a2e967ee"), "97803 Ortiz Trace, Lorenachester, Iraq", "Nico.Schultz@hotmail.com", "Nico", "Schultz", "84 (235) 66-85" },
                    { new Guid("b8ad88ca-2ed1-4f91-9269-2c90f8844049"), "593 Barrows Center, East Lilly, Barbados", "Keeley.Wolf45@yahoo.com", "Keeley", "Wolf", "91 (856) 24-53" },
                    { new Guid("c37160a8-2223-417f-aeea-48ee0530053b"), "49962 Tony Overpass, Lake Ivory, American Samoa", "Waylon89@gmail.com", "Waylon", "Kozey", "26 (271) 97-99" },
                    { new Guid("c6c3ae61-aea9-4e5d-932e-46e883867fe5"), "5136 Reagan Mill, Hammeston, Burkina Faso", "Darrell23@yahoo.com", "Darrell", "Ryan", "98 (595) 79-40" },
                    { new Guid("c95fdcfd-ab1d-4d59-9abe-7afaa99d40d3"), "61793 Maxime Route, Tyriquefurt, Italy", "Selena_Cormier@gmail.com", "Selena", "Cormier", "03 (051) 65-70" },
                    { new Guid("ebe19982-87ae-4234-a30f-7c708523efdb"), "6576 Bernier Crossing, Eldontown, Northern Mariana Islands", "Jacquelyn29@hotmail.com", "Jacquelyn", "Mann", "12 (508) 73-97" },
                    { new Guid("f10b97f3-0e83-49a4-832f-2c15961f1fbd"), "52420 Armstrong Walk, East Van, Taiwan", "Mason_Gorczany7@gmail.com", "Mason", "Gorczany", "34 (200) 14-03" },
                    { new Guid("f2d6e6b6-33e0-4508-b1df-b3ea49c7752d"), "95623 Reese Oval, East Kristina, Pakistan", "Jimmie.Hessel7@yahoo.com", "Jimmie", "Hessel", "22 (106) 52-05" },
                    { new Guid("f35b9589-753a-48cf-809d-b99e848c01f4"), "79301 Thompson Mission, North Dario, Virgin Islands, British", "Alene_OReilly@gmail.com", "Alene", "O'Reilly", "77 (502) 61-39" },
                    { new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb"), "595 Corwin Cliff, East Vida, Moldova", "Velva44@gmail.com", "Velva", "Morar", "66 (397) 15-87" },
                    { new Guid("fb66fb6b-5bb1-495d-bd3b-7d63046777e2"), "10328 Sporer Underpass, Laceyshire, Finland", "Kurt.Keebler@hotmail.com", "Kurt", "Keebler", "02 (978) 73-77" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "EquipmentId", "EquipmentName", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00f46e44-6c28-4ef2-9fa4-c3c918f863c2"), "voluptatibus", 29 },
                    { new Guid("030f87e9-ab34-47c6-9c9a-c13281471d76"), "quis", 203 },
                    { new Guid("06926f99-872b-4bc0-a225-805123da282a"), "accusamus", 8 },
                    { new Guid("0e88b17a-8fed-4eca-bae3-9d32a36cb3c0"), "officiis", 57 },
                    { new Guid("0fd0c38f-3db9-4078-9545-8c01bd65a2ae"), "non", 478 },
                    { new Guid("152f975f-2413-497a-9f81-6956d00cb853"), "ratione", 49 },
                    { new Guid("1e365200-2c19-43b5-b424-f3954e2b8b11"), "fugiat", 394 },
                    { new Guid("2c335605-a301-432e-a10d-c04d328d2f59"), "qui", 170 },
                    { new Guid("361dcae5-4dc8-4408-8691-c9e628646c26"), "provident", 352 },
                    { new Guid("3f62f322-d818-424e-b286-73d0e28f91ac"), "et", 85 },
                    { new Guid("3f7b9cdb-88f8-442c-bf43-cf7fbe933332"), "et", 211 },
                    { new Guid("46fe3590-cc0a-48fb-9234-acbbf184f68c"), "qui", 225 },
                    { new Guid("55b9b5b1-a0b2-4fa0-962f-2787d2fd56d6"), "a", 466 },
                    { new Guid("569f8acf-91b4-4418-b310-45be65f6fd85"), "enim", 214 },
                    { new Guid("5c0100d9-5415-4ce8-b26a-457c26c2ab98"), "dolores", 85 },
                    { new Guid("6726134f-4322-41d4-85f6-4d7a882a8886"), "id", 240 },
                    { new Guid("67e6b5e3-22f3-4719-8b0a-6304ef2e7bea"), "rerum", 428 },
                    { new Guid("6db8dbde-b98f-4cc3-9a64-ddcb8aec88f5"), "fuga", 329 },
                    { new Guid("717cb3c5-9d6f-4055-ac7c-9512a9f53ecf"), "dolorem", 311 },
                    { new Guid("76e9fd1f-0316-46cd-8ef6-ded0675f14f9"), "mollitia", 490 },
                    { new Guid("7ad656da-2a38-4673-a3b6-d318776395f9"), "maiores", 317 },
                    { new Guid("7cd6423e-5a3a-4914-b3ee-81ce2b8f0065"), "repudiandae", 98 },
                    { new Guid("87ff608b-ad47-4f7d-aeb3-bfe900b08e57"), "ducimus", 86 },
                    { new Guid("904dd314-0ea9-465c-b410-ec373f397e5c"), "id", 331 },
                    { new Guid("a32b462c-9b25-446a-8e50-e1f9243cbbd1"), "vel", 489 },
                    { new Guid("a79f5e33-e531-45d1-b3bd-0e697c2e313e"), "modi", 53 },
                    { new Guid("b21475d3-d038-4347-9181-50d60ecde580"), "voluptatem", 47 },
                    { new Guid("b437fc9f-d833-4c44-8f1b-b2ef31aec01e"), "voluptas", 201 },
                    { new Guid("b5f725c7-17e7-4a26-99d3-58dee892ebc7"), "aliquid", 179 },
                    { new Guid("b965d4c9-84e1-4b91-8860-ad55ff56e962"), "laboriosam", 121 },
                    { new Guid("b9ca055c-f1ea-41a2-955e-b447f920eb29"), "fugiat", 270 },
                    { new Guid("ba868a75-b870-4b0c-8c0e-1e7cf2058f14"), "distinctio", 279 },
                    { new Guid("bafffccd-36c7-4d0e-bef0-2df5f09086e6"), "et", 286 },
                    { new Guid("bbc29662-8cc0-4751-a154-2ec1c4c0da07"), "sint", 96 },
                    { new Guid("bd83ac6b-cfea-4d0c-9a2d-7e92b85a5693"), "fuga", 449 },
                    { new Guid("c1cc939f-0ecd-4b2c-8793-2793f9d19a17"), "illum", 289 },
                    { new Guid("c2474ff4-e303-45ba-a4c9-a1f109970567"), "vel", 3 },
                    { new Guid("c3528680-cfd9-4f8a-8068-5514427dd673"), "hic", 150 },
                    { new Guid("d5d7bbee-6fbd-4491-9b34-cbf3f458a490"), "dolorem", 39 },
                    { new Guid("db26b976-6bca-4773-aff2-7bb0f99f65c1"), "cupiditate", 443 },
                    { new Guid("dbe636f5-b0f9-4c3b-af96-bd7d7402f2e4"), "nihil", 273 },
                    { new Guid("de2dbd9c-7a77-4ff1-bfde-d0806ab16dae"), "aperiam", 415 },
                    { new Guid("dfb2bce2-ed11-4324-ad54-b644f181d2d8"), "omnis", 278 },
                    { new Guid("e3213874-7860-428b-a5e7-c0296e8df6c5"), "explicabo", 222 },
                    { new Guid("ecc8d467-f969-43e6-93f1-c97e00692516"), "ipsam", 226 },
                    { new Guid("f177f9d0-49d0-4bc1-b012-e936383e2208"), "quod", 218 },
                    { new Guid("f43373c9-24b4-48be-a0fe-dab9ea5fb7cb"), "qui", 325 },
                    { new Guid("f4910bba-6ec9-445d-8a2c-55a5f095a0d1"), "quisquam", 34 },
                    { new Guid("f7032e79-d695-42da-a79c-5f8121641505"), "omnis", 451 },
                    { new Guid("ffc5258c-f792-4be0-8aac-e03d3c1cbef0"), "laudantium", 278 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Email", "FirstName", "LastName", "Phone", "Specialization" },
                values: new object[,]
                {
                    { new Guid("00df6816-2f45-4daa-afd2-7545d7be523c"), "Rafael.Lueilwitz99@hotmail.com", "Rafael", "Lueilwitz", "82 (427) 88-29", "Health coach" },
                    { new Guid("01e1c3a7-1ed6-47d7-b8da-550466221904"), "Garrick.Prosacco71@hotmail.com", "Garrick", "Prosacco", "67 (853) 96-54", "Athletic trainer" },
                    { new Guid("04d9f0d5-3bfa-4cb3-9404-43f58ffc9e6f"), "Jose_Hilll75@gmail.com", "Jose", "Hilll", "63 (927) 95-50", "Health coach" },
                    { new Guid("08354869-612c-43fb-a722-eef8c5f3e8e1"), "Bridgette9@gmail.com", "Bridgette", "Beier", "86 (219) 72-96", "Personal trainer" },
                    { new Guid("098a7c4c-5953-42c5-a501-06b268632549"), "Cooper99@yahoo.com", "Cooper", "Halvorson", "47 (115) 44-55", "Bodybuilding coach" },
                    { new Guid("0b762a37-8dd0-414c-ae95-97153c7f2458"), "Shany.Kuvalis87@hotmail.com", "Shany", "Kuvalis", "07 (692) 41-29", "Exercise specialist" },
                    { new Guid("10908efe-144f-4b2a-9f00-6b9ece948185"), "Nichole.Ebert@yahoo.com", "Nichole", "Ebert", "44 (806) 41-65", "Fitness trainer" },
                    { new Guid("1efa2292-d0ce-41b1-9cb4-d4e298dd60d8"), "Jasen0@gmail.com", "Jasen", "Emard", "06 (956) 85-58", "Lifestyle coach" },
                    { new Guid("2211d7db-e7bc-4390-a28b-2e90041e8d88"), "Alexandro.Gutkowski6@hotmail.com", "Alexandro", "Gutkowski", "91 (367) 35-38", "Health coach" },
                    { new Guid("22666d2d-d1bd-43a9-a3b1-5290800b6af4"), "Lamont51@gmail.com", "Lamont", "Braun", "05 (651) 79-96", "Personal trainer" },
                    { new Guid("2455d7d4-2cd9-4aee-9944-b986d02e4789"), "Kimberly25@hotmail.com", "Kimberly", "Ruecker", "72 (699) 25-18", "Health coach" },
                    { new Guid("2456bfdc-937c-40f5-9df2-72a56a0d6e6b"), "Deron88@yahoo.com", "Deron", "Luettgen", "69 (287) 61-59", "Exercise specialist" },
                    { new Guid("2ab585bf-2d66-4e3b-ae8e-8813e42cb692"), "Mathias11@yahoo.com", "Mathias", "Hirthe", "04 (300) 95-64", "Personal trainer" },
                    { new Guid("2c5779bb-7650-410b-a885-6aa61da73f1f"), "Jesse17@gmail.com", "Jesse", "Stoltenberg", "71 (695) 83-78", "Personal trainer" },
                    { new Guid("31301ceb-6194-4192-9af7-a16db0fdd58f"), "Penelope_Mosciski16@gmail.com", "Penelope", "Mosciski", "80 (866) 36-19", "Health coach" },
                    { new Guid("3a714c3b-3816-4f69-996b-3511e2a29921"), "Alison.Altenwerth91@hotmail.com", "Alison", "Altenwerth", "42 (366) 83-89", "Fitness trainer" },
                    { new Guid("457fd735-5264-46b3-86ea-40bddce4c93f"), "Mariana.Luettgen@hotmail.com", "Mariana", "Luettgen", "32 (705) 07-88", "Wellness specialist" },
                    { new Guid("4a633320-730c-47ff-898f-9d506b89327f"), "Baylee53@gmail.com", "Baylee", "Jast", "50 (754) 44-47", "Health coach" },
                    { new Guid("4c2295df-1cdd-4eb4-b05c-26b5ecc451c9"), "Kianna.Dooley99@yahoo.com", "Kianna", "Dooley", "44 (892) 31-69", "Exercise specialist" },
                    { new Guid("5d34d25c-b29f-4d91-8f27-b9d1f31e6352"), "Ben_Grant58@hotmail.com", "Ben", "Grant", "06 (406) 61-37", "Wellness specialist" },
                    { new Guid("6358ebbf-913c-4d1c-91e7-edfa2f5f5ae1"), "Hugh.Kling@gmail.com", "Hugh", "Kling", "71 (906) 37-89", "Bodybuilding coach" },
                    { new Guid("6753d16c-3632-4fbc-849c-1dfb563a6adb"), "Riley_Tillman@hotmail.com", "Riley", "Tillman", "01 (359) 09-45", "Personal trainer" },
                    { new Guid("6903c5b0-0408-46bf-957c-a2c0db7c4447"), "Rosa_Rolfson81@yahoo.com", "Rosa", "Rolfson", "89 (208) 75-59", "Exercise specialist" },
                    { new Guid("6d2177c2-d379-44b6-ad88-196a9256857a"), "Erick1@yahoo.com", "Erick", "Ernser", "53 (788) 00-17", "Athletic trainer" },
                    { new Guid("70c69c15-0ad0-4fd4-b223-510e597d9235"), "Jay_Dach94@gmail.com", "Jay", "Dach", "47 (225) 10-22", "Lifestyle coach" },
                    { new Guid("7158caeb-f7a7-4ad2-95ce-1d955fb78703"), "Anne.Kassulke@hotmail.com", "Anne", "Kassulke", "41 (852) 49-62", "Exercise specialist" },
                    { new Guid("7d1ee58d-b5a3-4171-a7a6-2cdeee565b4a"), "Lisa85@gmail.com", "Lisa", "Jaskolski", "73 (468) 02-57", "Wellness specialist" },
                    { new Guid("823d5aee-3b67-4001-b377-d58ee25a7275"), "Modesto.Hermiston39@yahoo.com", "Modesto", "Hermiston", "79 (117) 92-72", "Personal trainer" },
                    { new Guid("8cc03bb0-39a9-44bc-9e64-5f426f28c257"), "Jessica44@gmail.com", "Jessica", "Corkery", "65 (200) 46-80", "Fitness trainer" },
                    { new Guid("950f9804-777f-4003-9ed1-32c122d88c04"), "Ila.Gaylord14@gmail.com", "Ila", "Gaylord", "27 (640) 44-95", "Health coach" },
                    { new Guid("984ff741-7d45-4927-825d-57ad31e1b618"), "Zane_Russel24@hotmail.com", "Zane", "Russel", "10 (992) 91-32", "Fitness trainer" },
                    { new Guid("9efc3a36-9687-41bd-864b-8ead2400ae9e"), "Devante70@gmail.com", "Devante", "Dietrich", "45 (149) 71-76", "Wellness specialist" },
                    { new Guid("a816a43c-f956-400a-a1f7-5bb624870998"), "Violet2@gmail.com", "Violet", "Bins", "86 (057) 96-02", "Exercise specialist" },
                    { new Guid("ab29070f-54c7-434f-8673-887fa1e7e4ba"), "Maverick.Prosacco70@yahoo.com", "Maverick", "Prosacco", "66 (879) 75-76", "Athletic trainer" },
                    { new Guid("b19085b8-d694-41c4-b738-aaf08a9eb62f"), "Grover53@hotmail.com", "Grover", "D'Amore", "25 (015) 14-83", "Lifestyle coach" },
                    { new Guid("b3ac19b1-22da-4df4-ae4b-f6edf077f9ff"), "Lenore_Weissnat@gmail.com", "Lenore", "Weissnat", "99 (014) 41-18", "Personal trainer" },
                    { new Guid("b9f79fdb-a867-4631-a06f-c25290460a11"), "Kyle.Daugherty98@hotmail.com", "Kyle", "Daugherty", "27 (999) 49-07", "Sports coach" },
                    { new Guid("d1283b2a-a659-4977-9d52-e98d37dd7dfd"), "Lee_Mueller99@gmail.com", "Lee", "Mueller", "02 (988) 40-14", "Exercise specialist" },
                    { new Guid("d1609346-0699-4758-bc60-7268f84b18ce"), "Daryl.Kihn10@hotmail.com", "Daryl", "Kihn", "28 (962) 63-02", "Bodybuilding coach" },
                    { new Guid("d3dd3dec-cf7a-45b7-998f-b13b098d9f6c"), "Waldo.Lind@yahoo.com", "Waldo", "Lind", "53 (421) 39-06", "Health coach" },
                    { new Guid("d546852d-9916-48ad-b053-19dcba62d9f2"), "Devan.Legros64@yahoo.com", "Devan", "Legros", "57 (275) 51-82", "Wellness specialist" },
                    { new Guid("d59a9948-0f8a-43f7-bfac-a80f7dfec027"), "Leda_Kuphal88@gmail.com", "Leda", "Kuphal", "59 (838) 51-75", "Personal trainer" },
                    { new Guid("db560478-f4e5-4dc6-9bee-69eaba5ceede"), "Garfield_Heathcote@hotmail.com", "Garfield", "Heathcote", "83 (167) 89-29", "Wellness specialist" },
                    { new Guid("dcdf4f72-db9e-4554-a626-833ae4709145"), "Angelina_Flatley70@hotmail.com", "Angelina", "Flatley", "97 (855) 96-64", "Bodybuilding coach" },
                    { new Guid("de099cc4-d12d-4614-a4cf-d48d1fb3c0f0"), "Kyle.Swift82@gmail.com", "Kyle", "Swift", "56 (432) 32-35", "Wellness specialist" },
                    { new Guid("e534f00d-c6ff-4ae4-94f9-854b24e0b8d6"), "Paxton.Greenholt96@hotmail.com", "Paxton", "Greenholt", "27 (216) 00-08", "Wellness specialist" },
                    { new Guid("e62748fc-e996-4b6c-9895-e26d0206c75c"), "Aleen_Schmitt9@gmail.com", "Aleen", "Schmitt", "49 (591) 47-68", "Personal trainer" },
                    { new Guid("f95896f4-8742-4f11-bbc0-7673a4593dee"), "Domenica.Botsford91@gmail.com", "Domenica", "Botsford", "05 (595) 00-06", "Wellness specialist" },
                    { new Guid("fd96502f-1c50-4dd3-b1fe-7746d3267c2c"), "Erin.Robel75@yahoo.com", "Erin", "Robel", "74 (886) 64-56", "Sports coach" },
                    { new Guid("fe396b6d-cf2f-4a26-980c-8f1f17123e46"), "Jaron_Collins94@gmail.com", "Jaron", "Collins", "51 (415) 28-05", "Bodybuilding coach" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName", "InstructorId", "MaxCapacity", "Schedule" },
                values: new object[,]
                {
                    { new Guid("02ed211d-6417-425b-b7c4-7e22eb2a98ed"), "autem", new Guid("d1609346-0699-4758-bc60-7268f84b18ce"), 1432169210, "Vel libero sint sint." },
                    { new Guid("0f12b2b8-d06f-4d10-b5ef-1bd35e939fbd"), "excepturi", new Guid("6d2177c2-d379-44b6-ad88-196a9256857a"), 748786811, "Ut aliquid suscipit perferendis." },
                    { new Guid("1406b8ff-dc6c-42be-99b7-ba21064ec5bf"), "inventore", new Guid("4c2295df-1cdd-4eb4-b05c-26b5ecc451c9"), 341234729, "Ipsa dolores provident illum." },
                    { new Guid("17a1e1a1-1008-4747-beb0-bb90fabd35d3"), "qui", new Guid("ab29070f-54c7-434f-8673-887fa1e7e4ba"), 1347372958, "Labore eos dolore." },
                    { new Guid("1edc248a-4812-43ac-81e0-2237d0e9b33c"), "suscipit", new Guid("f95896f4-8742-4f11-bbc0-7673a4593dee"), 960432243, "Provident esse minus." },
                    { new Guid("2098392a-7c04-4fc4-b00c-3b95a279ab34"), "et", new Guid("31301ceb-6194-4192-9af7-a16db0fdd58f"), 1128350918, "Et aut occaecati consequatur voluptates." },
                    { new Guid("2504495d-5c68-4f4a-8dc2-56c324ce56d5"), "unde", new Guid("d59a9948-0f8a-43f7-bfac-a80f7dfec027"), 1338308328, "Itaque aut incidunt eius itaque." },
                    { new Guid("28f67f4d-6846-4e83-a816-334cb57ff0c0"), "inventore", new Guid("70c69c15-0ad0-4fd4-b223-510e597d9235"), 572878485, "Et modi modi beatae quisquam aspernatur." },
                    { new Guid("2a3b35d4-b5b7-452c-8751-a3dbaadc6e62"), "voluptas", new Guid("e534f00d-c6ff-4ae4-94f9-854b24e0b8d6"), 1031056819, "Sit error quaerat itaque cumque culpa voluptates et." },
                    { new Guid("2fb0e66c-8312-49d5-880a-693e2f45046c"), "sint", new Guid("8cc03bb0-39a9-44bc-9e64-5f426f28c257"), 2124863047, "Placeat omnis corrupti eligendi velit ipsa iste delectus eum." },
                    { new Guid("332f2032-533e-4698-9038-81c7e74c36d3"), "corrupti", new Guid("2456bfdc-937c-40f5-9df2-72a56a0d6e6b"), 1579265536, "Earum voluptatum omnis soluta vel molestiae." },
                    { new Guid("38bc2525-70f1-4491-93e5-36ca4a7fddfe"), "aut", new Guid("8cc03bb0-39a9-44bc-9e64-5f426f28c257"), 936948101, "Itaque eius laudantium vitae soluta ut non omnis nostrum sit." },
                    { new Guid("423c8f0a-5da7-4250-be4f-c8ac08b3fcbd"), "dolore", new Guid("7158caeb-f7a7-4ad2-95ce-1d955fb78703"), 539125056, "Accusamus vitae molestias." },
                    { new Guid("42b97a31-0634-474f-af48-42554ee91ab9"), "quaerat", new Guid("6358ebbf-913c-4d1c-91e7-edfa2f5f5ae1"), 999894024, "Iure totam ea et esse facere culpa minima in officia." },
                    { new Guid("44cbaa62-772b-4203-b5ac-6c124427fbfb"), "illo", new Guid("de099cc4-d12d-4614-a4cf-d48d1fb3c0f0"), 1785611292, "Accusamus aut distinctio dolores." },
                    { new Guid("501ff17b-16e5-4a1b-aa6d-643ca5e33d06"), "id", new Guid("b3ac19b1-22da-4df4-ae4b-f6edf077f9ff"), 1794162666, "Consequatur et sit ullam vitae est omnis nisi autem a." },
                    { new Guid("50b1c496-a52a-4f0b-9502-5cce70d30897"), "earum", new Guid("b3ac19b1-22da-4df4-ae4b-f6edf077f9ff"), 1190378440, "Voluptatum doloremque a corporis nihil sint consequatur alias." },
                    { new Guid("50e5b6a0-b2d5-4143-976b-dd3219c1f42d"), "corporis", new Guid("e62748fc-e996-4b6c-9895-e26d0206c75c"), 1904084862, "Porro laboriosam inventore assumenda id neque placeat." },
                    { new Guid("5235da63-213a-484a-a5b6-ce98b1234cf3"), "sunt", new Guid("1efa2292-d0ce-41b1-9cb4-d4e298dd60d8"), 2055680614, "Dolore officiis qui." },
                    { new Guid("5749520d-456d-4ec7-a769-e17ba22b867b"), "facere", new Guid("2456bfdc-937c-40f5-9df2-72a56a0d6e6b"), 696946977, "Sit consequatur dolorem quia culpa est incidunt." },
                    { new Guid("6ce2c9ae-a507-4bca-ae72-05e916cfc7b0"), "id", new Guid("9efc3a36-9687-41bd-864b-8ead2400ae9e"), 760698785, "Repudiandae aliquid voluptas omnis repellat et quia aut." },
                    { new Guid("6d8f5454-8ad8-4cb1-933f-e8a47e95c6e3"), "omnis", new Guid("b19085b8-d694-41c4-b738-aaf08a9eb62f"), 421880664, "A qui provident numquam deleniti nostrum." },
                    { new Guid("6de64932-7b2f-4b06-b17c-a8997eefa7fe"), "aut", new Guid("0b762a37-8dd0-414c-ae95-97153c7f2458"), 1963269227, "Cupiditate aliquid tempore repellat quasi ducimus dolor." },
                    { new Guid("71dfe563-8e10-40ce-a681-3eee12293f3f"), "recusandae", new Guid("4a633320-730c-47ff-898f-9d506b89327f"), 567849544, "Est culpa voluptatibus eos." },
                    { new Guid("727c0c10-28c8-4976-9fb7-4ba6d24d538e"), "totam", new Guid("fd96502f-1c50-4dd3-b1fe-7746d3267c2c"), 566229937, "Modi voluptatem corporis reprehenderit molestias aliquid hic ut molestias." },
                    { new Guid("7bf5c703-1f02-498c-8cdf-71cf134e9360"), "voluptatem", new Guid("457fd735-5264-46b3-86ea-40bddce4c93f"), 855800769, "Voluptatum qui soluta rerum." },
                    { new Guid("7ea297b3-8922-4878-b6b3-839a6ffd4872"), "dolore", new Guid("b3ac19b1-22da-4df4-ae4b-f6edf077f9ff"), 2049058591, "Quia maiores quas saepe quisquam assumenda." },
                    { new Guid("82e48874-81d2-4c7d-87a5-737ded184ce1"), "et", new Guid("5d34d25c-b29f-4d91-8f27-b9d1f31e6352"), 1002032903, "Iste ipsam cumque ut assumenda et." },
                    { new Guid("879a7449-1661-42e6-94ac-b8b0d920c972"), "id", new Guid("2211d7db-e7bc-4390-a28b-2e90041e8d88"), 335935864, "A voluptates nihil dolores quia eum." },
                    { new Guid("87bb5f1f-37b8-4183-bd67-17808673c870"), "ad", new Guid("7158caeb-f7a7-4ad2-95ce-1d955fb78703"), 214896159, "Laudantium minus porro et sed impedit est." },
                    { new Guid("8ed87979-b1b1-4415-9b58-6a984c4f7860"), "nobis", new Guid("dcdf4f72-db9e-4554-a626-833ae4709145"), 1447887312, "Non error incidunt est nam quisquam iusto animi." },
                    { new Guid("944fdaa2-12a2-4011-89b9-1daed9bf796a"), "corrupti", new Guid("950f9804-777f-4003-9ed1-32c122d88c04"), 1070152191, "Ut ex non ut." },
                    { new Guid("9c826928-a81b-4fa3-b4a9-18c9f54e2e8f"), "dolorum", new Guid("31301ceb-6194-4192-9af7-a16db0fdd58f"), 1922894023, "Iusto quis totam quae mollitia voluptas soluta sunt est ullam." },
                    { new Guid("a1c739fa-8b15-48e7-9a4f-4c9022474076"), "totam", new Guid("ab29070f-54c7-434f-8673-887fa1e7e4ba"), 255360619, "Odit pariatur qui dolores." },
                    { new Guid("a7d8baff-c0a7-4aaa-9ed6-ff27d114a51f"), "nihil", new Guid("457fd735-5264-46b3-86ea-40bddce4c93f"), 614860258, "Et quam quia voluptatem qui." },
                    { new Guid("b25e90ff-199e-453b-9ce7-ab904fd20489"), "et", new Guid("7d1ee58d-b5a3-4171-a7a6-2cdeee565b4a"), 1236119331, "Culpa placeat at esse ipsum autem pariatur iste dolores." },
                    { new Guid("b31cc042-0cff-4076-a784-eb9f30be8380"), "et", new Guid("b9f79fdb-a867-4631-a06f-c25290460a11"), 1394472639, "Et mollitia quod aut commodi aliquam tempore." },
                    { new Guid("c22ebf68-f4f3-48bc-8581-3d75491967af"), "esse", new Guid("d546852d-9916-48ad-b053-19dcba62d9f2"), 201448527, "Nam exercitationem est nesciunt quo." },
                    { new Guid("c262dbc1-d62d-43c8-8016-682d807a2b18"), "numquam", new Guid("31301ceb-6194-4192-9af7-a16db0fdd58f"), 226988809, "Occaecati deleniti assumenda sapiente." },
                    { new Guid("c5f8e076-a16c-4430-8bc9-a9558c1442a1"), "fugit", new Guid("d3dd3dec-cf7a-45b7-998f-b13b098d9f6c"), 429022055, "Et nihil et quae." },
                    { new Guid("cd21e82a-379f-40b6-89b3-2b94e20268cc"), "veritatis", new Guid("ab29070f-54c7-434f-8673-887fa1e7e4ba"), 74119977, "Dolorem eum architecto laborum." },
                    { new Guid("d3adfab1-7ae3-412c-802b-e6cb52fd4abf"), "blanditiis", new Guid("d1283b2a-a659-4977-9d52-e98d37dd7dfd"), 130951729, "Qui inventore quasi ipsam voluptatem impedit." },
                    { new Guid("d897b29f-e036-4b09-9b21-e591c68c740f"), "quas", new Guid("04d9f0d5-3bfa-4cb3-9404-43f58ffc9e6f"), 1125105013, "Provident et aut dolores natus voluptas." },
                    { new Guid("da56e1a9-02b6-451e-a256-e6827436bac6"), "veritatis", new Guid("6d2177c2-d379-44b6-ad88-196a9256857a"), 597949470, "Non et officia." },
                    { new Guid("e096a1aa-a656-4b07-9227-c03d7e4b870d"), "amet", new Guid("f95896f4-8742-4f11-bbc0-7673a4593dee"), 1225801316, "Dolorum et minus odit quisquam nihil optio." },
                    { new Guid("e1ec4026-76b5-42e0-8fee-70ccd481bede"), "soluta", new Guid("950f9804-777f-4003-9ed1-32c122d88c04"), 1698141939, "Quia ut consequatur." },
                    { new Guid("e347f125-2aae-4872-b6e4-69d2bc8cba9e"), "et", new Guid("db560478-f4e5-4dc6-9bee-69eaba5ceede"), 820818675, "Quia et culpa ipsa consequatur." },
                    { new Guid("ee41996c-baf6-43e7-ab2e-28ca69d3da38"), "nemo", new Guid("2ab585bf-2d66-4e3b-ae8e-8813e42cb692"), 250220264, "Molestiae fugiat est." },
                    { new Guid("ef41ff40-dfc4-480a-94a5-abaf63f7d3f2"), "deleniti", new Guid("e534f00d-c6ff-4ae4-94f9-854b24e0b8d6"), 1848041617, "Harum error quo et cum ut quaerat quos." },
                    { new Guid("f6c51653-07f6-4e33-b010-69cb5710f02e"), "sint", new Guid("31301ceb-6194-4192-9af7-a16db0fdd58f"), 189694662, "Quia eos doloremque maiores ratione praesentium." }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "CustomerId", "EndDate", "Price", "StartDate" },
                values: new object[,]
                {
                    { new Guid("035b0fba-f738-48db-9a42-aaee0e58146e"), new Guid("64da1a27-bc10-4bf1-bc47-526a488cbe7d"), new DateTime(1932, 7, 6, 8, 44, 47, 442, DateTimeKind.Utc).AddTicks(6502), 9884.194670952292900m, new DateTime(2021, 7, 17, 15, 27, 27, 423, DateTimeKind.Local).AddTicks(656) },
                    { new Guid("07e25028-b32a-41f3-adf8-6a6463c5f942"), new Guid("ae7f4b25-f70b-4b3d-92a0-fdec6669464b"), new DateTime(150, 2, 24, 23, 45, 34, 138, DateTimeKind.Utc).AddTicks(4836), 5312.201880116416800m, new DateTime(2022, 10, 16, 0, 58, 30, 288, DateTimeKind.Local).AddTicks(837) },
                    { new Guid("0fe6722c-e770-4ed3-819e-dd18d0265751"), new Guid("18f25cb0-a878-40d8-8d59-d4ffece01897"), new DateTime(1151, 4, 19, 20, 47, 58, 374, DateTimeKind.Utc).AddTicks(4685), 9064.74778336936600m, new DateTime(2021, 10, 22, 20, 27, 50, 303, DateTimeKind.Local).AddTicks(5739) },
                    { new Guid("14799bae-1e60-4f33-9b92-cbce6bccf7b8"), new Guid("f2d6e6b6-33e0-4508-b1df-b3ea49c7752d"), new DateTime(561, 2, 16, 5, 17, 0, 240, DateTimeKind.Utc).AddTicks(3655), 9729.576560259440250m, new DateTime(2023, 6, 26, 4, 9, 26, 82, DateTimeKind.Local).AddTicks(4478) },
                    { new Guid("1e7f4afa-b0be-45d5-bb54-36ebe4761c70"), new Guid("967fc6d2-34a7-4ece-b0dd-361a7264b0d8"), new DateTime(211, 9, 30, 20, 9, 29, 498, DateTimeKind.Utc).AddTicks(8664), 8742.390698394764600m, new DateTime(2023, 5, 6, 9, 40, 8, 142, DateTimeKind.Local).AddTicks(7828) },
                    { new Guid("2ba506ce-b4ef-4074-a11d-0585d70b7314"), new Guid("448bd6f0-7281-4759-8e99-6aa40b8c2ee1"), new DateTime(434, 7, 12, 19, 7, 21, 194, DateTimeKind.Utc).AddTicks(3079), 1384.941127679677800m, new DateTime(2023, 2, 6, 4, 43, 19, 364, DateTimeKind.Local).AddTicks(5775) },
                    { new Guid("2ceb7422-f520-4007-91b4-9c3db8d5f6b0"), new Guid("34b43989-b439-4d5e-9c31-2a4bee9ec55e"), new DateTime(1346, 11, 14, 17, 5, 45, 30, DateTimeKind.Utc).AddTicks(5574), 7226.994653331176700m, new DateTime(2021, 12, 12, 19, 9, 0, 907, DateTimeKind.Local).AddTicks(148) },
                    { new Guid("30e1d573-4d69-400e-bf8e-78f0f03f2683"), new Guid("451640a5-0dff-4ff9-8b15-51be9fee5746"), new DateTime(1482, 12, 6, 3, 22, 45, 406, DateTimeKind.Utc).AddTicks(8067), 9440.564430729942450m, new DateTime(2023, 4, 9, 11, 8, 46, 680, DateTimeKind.Local).AddTicks(1316) },
                    { new Guid("312f87c3-6d7e-4cf2-a8c1-59efa4a40341"), new Guid("941803f4-8e93-46c8-a97c-fc3896a630f0"), new DateTime(807, 12, 23, 8, 15, 17, 162, DateTimeKind.Utc).AddTicks(7358), 2629.90081754389900m, new DateTime(2023, 1, 16, 2, 35, 59, 212, DateTimeKind.Local).AddTicks(8509) },
                    { new Guid("38c186df-9093-438e-a4ef-bba1365e2e2c"), new Guid("5145e1e5-754f-456e-ab12-380e46cd25c9"), new DateTime(1256, 7, 28, 3, 34, 54, 326, DateTimeKind.Utc).AddTicks(8474), 3391.706766483174200m, new DateTime(2023, 4, 21, 0, 20, 59, 293, DateTimeKind.Local).AddTicks(4646) },
                    { new Guid("45b7081e-125c-49d4-b460-b243eb1060cd"), new Guid("1e5b278c-1fed-4cc2-a48b-cf1e4979c735"), new DateTime(269, 11, 16, 12, 8, 12, 622, DateTimeKind.Utc).AddTicks(2763), 8004.227244079013550m, new DateTime(2021, 11, 22, 10, 30, 16, 826, DateTimeKind.Local).AddTicks(765) },
                    { new Guid("4fa7d245-00d0-4afc-9ff1-e4bfd4787e63"), new Guid("c6c3ae61-aea9-4e5d-932e-46e883867fe5"), new DateTime(1509, 12, 5, 16, 34, 29, 853, DateTimeKind.Utc).AddTicks(7072), 9434.881181655169200m, new DateTime(2022, 10, 17, 2, 51, 3, 680, DateTimeKind.Local).AddTicks(258) },
                    { new Guid("5270db05-a8c6-4833-bcc1-bcb494567072"), new Guid("18f25cb0-a878-40d8-8d59-d4ffece01897"), new DateTime(686, 10, 28, 16, 2, 23, 364, DateTimeKind.Utc).AddTicks(7407), 2348.893795260174450m, new DateTime(2021, 8, 15, 23, 33, 0, 318, DateTimeKind.Local).AddTicks(2841) },
                    { new Guid("538299b1-bc55-4ac0-a007-21aacb69f307"), new Guid("a6afe325-3ee2-4803-b067-88fec590968e"), new DateTime(1222, 8, 3, 16, 29, 44, 935, DateTimeKind.Utc).AddTicks(7394), 9199.350036323819100m, new DateTime(2022, 11, 15, 6, 35, 19, 109, DateTimeKind.Local).AddTicks(5718) },
                    { new Guid("560aa7bd-6f33-483d-8581-51bd05258c17"), new Guid("4d66d0ee-947e-4579-be7a-3e3d6ec73768"), new DateTime(1967, 12, 16, 5, 7, 9, 393, DateTimeKind.Utc).AddTicks(9348), 3757.378581202937200m, new DateTime(2021, 11, 18, 11, 28, 31, 825, DateTimeKind.Local).AddTicks(9147) },
                    { new Guid("56f422db-7110-4a74-8ce4-e692496a3492"), new Guid("6c041b84-d055-4227-94a5-f2f7ef5d60de"), new DateTime(581, 10, 4, 2, 29, 35, 863, DateTimeKind.Utc).AddTicks(2615), 345.1916189813265900m, new DateTime(2022, 1, 22, 6, 48, 14, 761, DateTimeKind.Local).AddTicks(6436) },
                    { new Guid("60ba1454-13dd-4a84-ba58-5cb7a653cb1c"), new Guid("635f4f32-50e8-47eb-b1fb-e22bdb82e028"), new DateTime(1214, 9, 24, 18, 21, 42, 291, DateTimeKind.Utc).AddTicks(1792), 6816.165034691104200m, new DateTime(2021, 7, 19, 13, 41, 56, 987, DateTimeKind.Local).AddTicks(2105) },
                    { new Guid("670d10b9-695f-44ad-ab1b-33815c26ece4"), new Guid("ebe19982-87ae-4234-a30f-7c708523efdb"), new DateTime(1002, 12, 24, 17, 18, 49, 193, DateTimeKind.Utc).AddTicks(2220), 9119.881608184718950m, new DateTime(2022, 6, 23, 2, 41, 48, 602, DateTimeKind.Local).AddTicks(2885) },
                    { new Guid("6ae992fe-b107-448f-8140-8fe040cd7ed3"), new Guid("649ce298-629b-4846-bc8c-1bb0ff6aaff3"), new DateTime(1280, 4, 9, 16, 32, 47, 529, DateTimeKind.Utc).AddTicks(3054), 7763.486715588015800m, new DateTime(2022, 10, 19, 15, 17, 19, 475, DateTimeKind.Local).AddTicks(5824) },
                    { new Guid("6ca735a7-9721-4c14-b565-85880c45aefe"), new Guid("5fb63832-6bac-4e71-90ad-b24ad67461b8"), new DateTime(574, 10, 14, 13, 3, 50, 679, DateTimeKind.Utc).AddTicks(2696), 773.9380268820205450m, new DateTime(2022, 5, 14, 9, 36, 13, 736, DateTimeKind.Local).AddTicks(7186) },
                    { new Guid("738f642a-7ab1-429d-9da7-e9e8ea2493c0"), new Guid("649ce298-629b-4846-bc8c-1bb0ff6aaff3"), new DateTime(926, 4, 29, 16, 6, 48, 868, DateTimeKind.Utc).AddTicks(8952), 4828.563609212256950m, new DateTime(2022, 7, 16, 2, 3, 17, 680, DateTimeKind.Local).AddTicks(5896) },
                    { new Guid("78b40964-18a8-4d51-8da3-904244cc9f62"), new Guid("a02ee119-bbf8-4615-9ca3-f6bd40723c5f"), new DateTime(1361, 3, 21, 19, 37, 9, 871, DateTimeKind.Utc).AddTicks(9230), 3220.592895910797800m, new DateTime(2023, 6, 14, 0, 36, 25, 734, DateTimeKind.Local).AddTicks(1088) },
                    { new Guid("7d9f8e47-0229-4e57-bcd2-bba5804fd3cf"), new Guid("5fb63832-6bac-4e71-90ad-b24ad67461b8"), new DateTime(674, 8, 18, 17, 9, 28, 875, DateTimeKind.Utc).AddTicks(8409), 8177.281856990563750m, new DateTime(2022, 3, 13, 18, 57, 13, 441, DateTimeKind.Local).AddTicks(6619) },
                    { new Guid("7e77b33b-4515-4932-869c-a10a84c5264a"), new Guid("9b576549-29ef-4b08-aa38-9b8ffc45f5a9"), new DateTime(1784, 11, 24, 13, 12, 20, 945, DateTimeKind.Utc).AddTicks(1788), 6550.796424728750100m, new DateTime(2022, 6, 14, 22, 28, 28, 290, DateTimeKind.Local).AddTicks(3429) },
                    { new Guid("7fce520c-99e1-4ceb-b43d-813d03b3b324"), new Guid("c6c3ae61-aea9-4e5d-932e-46e883867fe5"), new DateTime(184, 8, 19, 9, 2, 54, 183, DateTimeKind.Utc).AddTicks(5037), 5418.096378089672300m, new DateTime(2021, 11, 19, 2, 26, 40, 999, DateTimeKind.Local).AddTicks(9846) },
                    { new Guid("8091c749-4e98-4ebe-a470-28e2a2b377f4"), new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb"), new DateTime(1430, 12, 2, 11, 20, 1, 679, DateTimeKind.Utc).AddTicks(9220), 9316.168537092455650m, new DateTime(2023, 4, 23, 13, 42, 41, 95, DateTimeKind.Local).AddTicks(7962) },
                    { new Guid("81079fc2-1cd1-4b6c-bfe5-5186e98be57d"), new Guid("18f25cb0-a878-40d8-8d59-d4ffece01897"), new DateTime(1490, 4, 15, 6, 27, 50, 547, DateTimeKind.Utc).AddTicks(2376), 6693.032542721935300m, new DateTime(2022, 10, 14, 15, 11, 56, 75, DateTimeKind.Local).AddTicks(5260) },
                    { new Guid("8199c7a5-5908-41d1-8eb5-a7234f80e43a"), new Guid("32cf5e73-fd17-42c2-a41d-ba21ac44f81b"), new DateTime(376, 10, 19, 23, 10, 22, 729, DateTimeKind.Utc).AddTicks(2577), 3572.62079077873650m, new DateTime(2022, 4, 26, 13, 0, 40, 311, DateTimeKind.Local).AddTicks(1105) },
                    { new Guid("81b0bc48-259e-409d-8282-367260136067"), new Guid("4d66d0ee-947e-4579-be7a-3e3d6ec73768"), new DateTime(1246, 5, 28, 5, 23, 15, 407, DateTimeKind.Utc).AddTicks(3682), 6454.79248458449150m, new DateTime(2022, 11, 18, 3, 7, 3, 51, DateTimeKind.Local).AddTicks(2782) },
                    { new Guid("9485df62-61df-4ae5-ad4b-81c1b961f6e4"), new Guid("649ce298-629b-4846-bc8c-1bb0ff6aaff3"), new DateTime(322, 7, 15, 6, 34, 20, 703, DateTimeKind.Utc).AddTicks(9433), 5576.674055266480100m, new DateTime(2022, 10, 30, 9, 59, 53, 165, DateTimeKind.Local).AddTicks(3446) },
                    { new Guid("98277d6f-6c05-4556-a665-2e5d5b01c767"), new Guid("fb66fb6b-5bb1-495d-bd3b-7d63046777e2"), new DateTime(164, 1, 20, 23, 8, 14, 677, DateTimeKind.Utc).AddTicks(1446), 3000.352884859463850m, new DateTime(2022, 4, 5, 16, 50, 18, 613, DateTimeKind.Local).AddTicks(973) },
                    { new Guid("991abbdb-74d5-4fea-9bb7-820c6c338345"), new Guid("3eeb28c3-deb2-4934-8bc3-c9678b02c4e7"), new DateTime(1036, 11, 12, 4, 40, 26, 105, DateTimeKind.Utc).AddTicks(6259), 1908.620093341044650m, new DateTime(2021, 8, 7, 23, 33, 8, 368, DateTimeKind.Local).AddTicks(3466) },
                    { new Guid("99f65943-f8cf-4636-baf2-dcdc2550788b"), new Guid("60cf6a5c-80ee-4a3a-8803-06b66c66e36c"), new DateTime(775, 9, 25, 9, 40, 28, 248, DateTimeKind.Utc).AddTicks(6389), 8680.617625459291650m, new DateTime(2023, 2, 3, 11, 21, 24, 267, DateTimeKind.Local).AddTicks(5828) },
                    { new Guid("9f45a99a-7788-4024-8547-fd94bbdeaa8b"), new Guid("60cf6a5c-80ee-4a3a-8803-06b66c66e36c"), new DateTime(1135, 10, 10, 12, 21, 13, 576, DateTimeKind.Utc).AddTicks(8472), 7308.687889302471600m, new DateTime(2022, 9, 2, 5, 44, 45, 621, DateTimeKind.Local).AddTicks(2137) },
                    { new Guid("a4e477c6-984c-41db-ab7a-b757bebf9ea5"), new Guid("649ce298-629b-4846-bc8c-1bb0ff6aaff3"), new DateTime(1858, 9, 23, 21, 47, 3, 679, DateTimeKind.Utc).AddTicks(8833), 3732.126626454155950m, new DateTime(2023, 2, 26, 22, 13, 16, 165, DateTimeKind.Local).AddTicks(7285) },
                    { new Guid("a85707c3-0c83-4e20-b4d9-9c6f33d10a8f"), new Guid("44659a54-101a-4243-98e3-928f906d93a2"), new DateTime(1191, 3, 21, 22, 10, 44, 448, DateTimeKind.Utc).AddTicks(3391), 4534.697697796618600m, new DateTime(2022, 7, 4, 19, 34, 46, 298, DateTimeKind.Local).AddTicks(841) },
                    { new Guid("b0e6fe1d-0841-4c5b-b930-46ecefd39020"), new Guid("6c041b84-d055-4227-94a5-f2f7ef5d60de"), new DateTime(1539, 9, 30, 17, 25, 37, 995, DateTimeKind.Utc).AddTicks(901), 6249.50354315514200m, new DateTime(2021, 12, 30, 20, 20, 45, 806, DateTimeKind.Local).AddTicks(3156) },
                    { new Guid("be612a96-ee21-40c2-bd2d-db2410784de3"), new Guid("b5d9db3c-0f34-4717-bf2a-c341a2e967ee"), new DateTime(482, 10, 28, 11, 53, 16, 929, DateTimeKind.Utc).AddTicks(2552), 8476.947089103878400m, new DateTime(2021, 12, 13, 8, 28, 7, 888, DateTimeKind.Local).AddTicks(335) },
                    { new Guid("c45cff6e-29eb-49ba-98b7-183d4654dea6"), new Guid("967fc6d2-34a7-4ece-b0dd-361a7264b0d8"), new DateTime(1232, 11, 2, 3, 4, 35, 492, DateTimeKind.Utc).AddTicks(5210), 5327.582116329266750m, new DateTime(2022, 2, 8, 10, 34, 7, 413, DateTimeKind.Local).AddTicks(1157) },
                    { new Guid("c52f6a01-e7cd-4785-8136-64f5eb373c3c"), new Guid("c6c3ae61-aea9-4e5d-932e-46e883867fe5"), new DateTime(1163, 6, 6, 4, 55, 40, 637, DateTimeKind.Utc).AddTicks(9693), 3672.926552427136950m, new DateTime(2022, 8, 4, 6, 32, 41, 223, DateTimeKind.Local).AddTicks(6737) },
                    { new Guid("cb01d625-de2b-4b43-a08e-c1633163b71c"), new Guid("44659a54-101a-4243-98e3-928f906d93a2"), new DateTime(1015, 9, 7, 10, 47, 9, 947, DateTimeKind.Utc).AddTicks(605), 7986.641452339295950m, new DateTime(2022, 7, 31, 10, 2, 27, 940, DateTimeKind.Local).AddTicks(2184) },
                    { new Guid("cd54c521-2fa1-42c0-9f3a-a5a884c72ce2"), new Guid("5fb63832-6bac-4e71-90ad-b24ad67461b8"), new DateTime(1588, 5, 20, 23, 30, 38, 507, DateTimeKind.Utc).AddTicks(9102), 9237.250377259468100m, new DateTime(2021, 9, 10, 15, 18, 33, 233, DateTimeKind.Local).AddTicks(756) },
                    { new Guid("d80ecdbd-8f28-445d-9cb2-74549c9a3bee"), new Guid("4d66d0ee-947e-4579-be7a-3e3d6ec73768"), new DateTime(838, 9, 1, 4, 53, 5, 681, DateTimeKind.Utc).AddTicks(5780), 2872.338052587684900m, new DateTime(2021, 8, 13, 1, 51, 12, 56, DateTimeKind.Local).AddTicks(7917) },
                    { new Guid("e54ff9ed-dadd-4e08-9b3c-5f6c8eefb6e4"), new Guid("17c77a46-da2c-4b96-8388-fe64f151404e"), new DateTime(1674, 2, 4, 4, 7, 11, 407, DateTimeKind.Utc).AddTicks(217), 1749.651061692940250m, new DateTime(2022, 10, 28, 20, 6, 20, 878, DateTimeKind.Local).AddTicks(8352) },
                    { new Guid("e9d47654-e932-47b6-9e33-994325c28e91"), new Guid("f10b97f3-0e83-49a4-832f-2c15961f1fbd"), new DateTime(1598, 11, 7, 23, 21, 51, 598, DateTimeKind.Utc).AddTicks(7280), 2523.73633236586550m, new DateTime(2022, 11, 3, 1, 53, 5, 904, DateTimeKind.Local).AddTicks(4628) },
                    { new Guid("eead0dff-6965-49cc-a884-ed9bfe3caf1e"), new Guid("176d9a75-94a8-4205-91f7-73905d6c9f74"), new DateTime(712, 12, 29, 12, 19, 35, 912, DateTimeKind.Utc).AddTicks(2785), 327.033728392714400m, new DateTime(2023, 2, 14, 13, 54, 15, 447, DateTimeKind.Local).AddTicks(2785) },
                    { new Guid("f179d87f-2fac-44d5-bac7-5e16a0f36e7c"), new Guid("64da1a27-bc10-4bf1-bc47-526a488cbe7d"), new DateTime(967, 9, 17, 13, 10, 10, 337, DateTimeKind.Utc).AddTicks(6367), 1370.840324985871800m, new DateTime(2021, 8, 31, 1, 45, 13, 93, DateTimeKind.Local).AddTicks(3226) },
                    { new Guid("f2f4a4a5-b9d8-4906-bd4a-c54314784ae9"), new Guid("1cafab03-1491-4d63-9ef3-24d48ef65d44"), new DateTime(1000, 1, 1, 23, 21, 59, 977, DateTimeKind.Utc).AddTicks(5185), 8130.582880858035250m, new DateTime(2023, 2, 5, 7, 44, 45, 452, DateTimeKind.Local).AddTicks(9573) },
                    { new Guid("fa738e6e-4fdb-4494-810e-37b4eb9d3651"), new Guid("124c5327-ecf3-4935-b9fd-c5ed4160391d"), new DateTime(1341, 1, 30, 21, 11, 18, 655, DateTimeKind.Utc).AddTicks(2220), 5009.809744181620950m, new DateTime(2022, 8, 19, 18, 27, 19, 50, DateTimeKind.Local).AddTicks(7446) },
                    { new Guid("fd41f3c9-db86-41f9-a231-70046c0fdb7d"), new Guid("18f25cb0-a878-40d8-8d59-d4ffece01897"), new DateTime(745, 1, 23, 15, 56, 14, 76, DateTimeKind.Utc).AddTicks(3745), 9881.486799855678200m, new DateTime(2021, 10, 19, 2, 32, 45, 919, DateTimeKind.Local).AddTicks(724) }
                });

            migrationBuilder.InsertData(
                table: "Attendance",
                columns: new[] { "AttendanceId", "AttendanceDate", "ClassId", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("0357f17b-9a43-40bc-af97-85ad18979f0f"), new DateTime(2022, 5, 3, 23, 8, 57, 114, DateTimeKind.Local).AddTicks(3615), new Guid("879a7449-1661-42e6-94ac-b8b0d920c972"), new Guid("0aca32ea-ffea-4f49-8d03-4cb7a5395919") },
                    { new Guid("15094c8c-50d0-4b48-b38e-7120e3b8df9f"), new DateTime(2023, 3, 5, 18, 36, 22, 256, DateTimeKind.Local).AddTicks(2688), new Guid("da56e1a9-02b6-451e-a256-e6827436bac6"), new Guid("a02ee119-bbf8-4615-9ca3-f6bd40723c5f") },
                    { new Guid("15ca7cb4-e6d3-4542-8cc4-792d64f19c34"), new DateTime(2021, 7, 4, 4, 2, 4, 368, DateTimeKind.Local).AddTicks(8264), new Guid("1edc248a-4812-43ac-81e0-2237d0e9b33c"), new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb") },
                    { new Guid("17b3e763-d52e-4660-baf4-7b41366ed644"), new DateTime(2022, 5, 8, 8, 25, 53, 470, DateTimeKind.Local).AddTicks(8110), new Guid("1406b8ff-dc6c-42be-99b7-ba21064ec5bf"), new Guid("44659a54-101a-4243-98e3-928f906d93a2") },
                    { new Guid("185155f0-4052-4b1f-9fda-d0331fe66a42"), new DateTime(2022, 1, 1, 4, 46, 10, 267, DateTimeKind.Local).AddTicks(8011), new Guid("17a1e1a1-1008-4747-beb0-bb90fabd35d3"), new Guid("c95fdcfd-ab1d-4d59-9abe-7afaa99d40d3") },
                    { new Guid("2c678dd1-50dc-4a3c-8658-cef3027ec30a"), new DateTime(2021, 8, 10, 15, 14, 23, 725, DateTimeKind.Local).AddTicks(8367), new Guid("28f67f4d-6846-4e83-a816-334cb57ff0c0"), new Guid("4d66d0ee-947e-4579-be7a-3e3d6ec73768") },
                    { new Guid("3eddfe32-eef8-4f5e-b305-c9b5928e092d"), new DateTime(2021, 9, 15, 12, 23, 9, 234, DateTimeKind.Local).AddTicks(9263), new Guid("02ed211d-6417-425b-b7c4-7e22eb2a98ed"), new Guid("451640a5-0dff-4ff9-8b15-51be9fee5746") },
                    { new Guid("4bf527ce-d206-4ecb-a4e1-3c2e093410b1"), new DateTime(2022, 4, 29, 2, 59, 29, 341, DateTimeKind.Local).AddTicks(8169), new Guid("28f67f4d-6846-4e83-a816-334cb57ff0c0"), new Guid("b8ad88ca-2ed1-4f91-9269-2c90f8844049") },
                    { new Guid("4e1eb341-67dc-482a-8bbc-41002bfa6099"), new DateTime(2021, 10, 15, 4, 19, 13, 430, DateTimeKind.Local).AddTicks(4171), new Guid("2fb0e66c-8312-49d5-880a-693e2f45046c"), new Guid("3eeb28c3-deb2-4934-8bc3-c9678b02c4e7") },
                    { new Guid("4efcf061-e58b-466e-828d-e05f5231b464"), new DateTime(2022, 7, 3, 0, 8, 51, 819, DateTimeKind.Local).AddTicks(5683), new Guid("a7d8baff-c0a7-4aaa-9ed6-ff27d114a51f"), new Guid("926211e8-fa2b-41c3-ad8b-8da4d6c76518") },
                    { new Guid("5a2824d0-738a-4706-8b89-a27a1a618e7e"), new DateTime(2022, 5, 1, 2, 7, 51, 515, DateTimeKind.Local).AddTicks(9201), new Guid("0f12b2b8-d06f-4d10-b5ef-1bd35e939fbd"), new Guid("24f0d318-55eb-47d8-8925-70ef553d4745") },
                    { new Guid("5ce33d31-78f3-4ed7-b67e-cd7dbf05be54"), new DateTime(2022, 8, 7, 5, 4, 17, 776, DateTimeKind.Local).AddTicks(5), new Guid("44cbaa62-772b-4203-b5ac-6c124427fbfb"), new Guid("90567b15-12de-431d-8c18-2597ef948af6") },
                    { new Guid("6356a2f9-8dbe-4767-8dbd-3286c8c456c1"), new DateTime(2023, 2, 2, 12, 26, 47, 231, DateTimeKind.Local).AddTicks(5170), new Guid("6de64932-7b2f-4b06-b17c-a8997eefa7fe"), new Guid("5fb63832-6bac-4e71-90ad-b24ad67461b8") },
                    { new Guid("658f4606-7adf-47ef-9c04-a897beb1e268"), new DateTime(2022, 10, 20, 11, 11, 26, 932, DateTimeKind.Local).AddTicks(9852), new Guid("f6c51653-07f6-4e33-b010-69cb5710f02e"), new Guid("b8ad88ca-2ed1-4f91-9269-2c90f8844049") },
                    { new Guid("67af5711-9c82-4538-a1f9-c7ece5a37b7f"), new DateTime(2021, 8, 10, 0, 40, 46, 120, DateTimeKind.Local).AddTicks(4026), new Guid("ee41996c-baf6-43e7-ab2e-28ca69d3da38"), new Guid("926211e8-fa2b-41c3-ad8b-8da4d6c76518") },
                    { new Guid("6e74ee83-b3b8-4aa8-97b0-bce19b8f97bc"), new DateTime(2022, 12, 3, 14, 15, 49, 721, DateTimeKind.Local).AddTicks(6736), new Guid("b25e90ff-199e-453b-9ce7-ab904fd20489"), new Guid("64da1a27-bc10-4bf1-bc47-526a488cbe7d") },
                    { new Guid("724f597c-a171-465d-ac4e-e6bf092079f5"), new DateTime(2022, 4, 30, 3, 33, 40, 938, DateTimeKind.Local).AddTicks(8774), new Guid("727c0c10-28c8-4976-9fb7-4ba6d24d538e"), new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb") },
                    { new Guid("72eb8087-a4ae-4a4d-96cf-395c4e6d45d9"), new DateTime(2023, 2, 8, 10, 25, 50, 562, DateTimeKind.Local).AddTicks(705), new Guid("ef41ff40-dfc4-480a-94a5-abaf63f7d3f2"), new Guid("a02ee119-bbf8-4615-9ca3-f6bd40723c5f") },
                    { new Guid("75073006-024a-40fb-9af9-c5aa92eb2b94"), new DateTime(2021, 12, 18, 17, 3, 0, 422, DateTimeKind.Local).AddTicks(7111), new Guid("7ea297b3-8922-4878-b6b3-839a6ffd4872"), new Guid("f10b97f3-0e83-49a4-832f-2c15961f1fbd") },
                    { new Guid("7644f246-7a4c-42ed-8367-0d80bb0723b0"), new DateTime(2022, 12, 19, 0, 47, 52, 763, DateTimeKind.Local).AddTicks(4583), new Guid("944fdaa2-12a2-4011-89b9-1daed9bf796a"), new Guid("b5d9db3c-0f34-4717-bf2a-c341a2e967ee") },
                    { new Guid("7de17fa3-45ca-4482-aee1-f5c57e1cc301"), new DateTime(2022, 9, 29, 9, 33, 26, 320, DateTimeKind.Local).AddTicks(195), new Guid("e096a1aa-a656-4b07-9227-c03d7e4b870d"), new Guid("ae7f4b25-f70b-4b3d-92a0-fdec6669464b") },
                    { new Guid("7f477cd0-1fe5-43c1-bf69-23f11311af5a"), new DateTime(2022, 2, 5, 11, 9, 20, 14, DateTimeKind.Local).AddTicks(1776), new Guid("c5f8e076-a16c-4430-8bc9-a9558c1442a1"), new Guid("730f8a97-cf99-4215-ba82-cd2fb3351ba1") },
                    { new Guid("829676c4-e88c-483d-9cb5-03d6d83e5149"), new DateTime(2022, 4, 12, 6, 11, 52, 991, DateTimeKind.Local).AddTicks(835), new Guid("2a3b35d4-b5b7-452c-8751-a3dbaadc6e62"), new Guid("904ecce7-a25a-4c37-b3fa-b14c71b55e14") },
                    { new Guid("838cf1f1-f486-4990-a66b-0ed407ff7958"), new DateTime(2021, 8, 29, 3, 36, 40, 333, DateTimeKind.Local).AddTicks(5729), new Guid("38bc2525-70f1-4491-93e5-36ca4a7fddfe"), new Guid("967fc6d2-34a7-4ece-b0dd-361a7264b0d8") },
                    { new Guid("86707e47-e7f3-4228-a625-06909ef63276"), new DateTime(2023, 4, 27, 4, 33, 23, 763, DateTimeKind.Local).AddTicks(7110), new Guid("727c0c10-28c8-4976-9fb7-4ba6d24d538e"), new Guid("88af0a21-835e-4861-89e8-4c0dcfadae4a") },
                    { new Guid("8c1ded7e-3653-4b92-bda4-bc5fc6772de0"), new DateTime(2023, 4, 30, 4, 41, 39, 557, DateTimeKind.Local).AddTicks(7032), new Guid("c262dbc1-d62d-43c8-8016-682d807a2b18"), new Guid("1cafab03-1491-4d63-9ef3-24d48ef65d44") },
                    { new Guid("a124cf8e-b482-405c-8c73-d64a4936ccdf"), new DateTime(2022, 3, 9, 21, 35, 9, 278, DateTimeKind.Local).AddTicks(6004), new Guid("7ea297b3-8922-4878-b6b3-839a6ffd4872"), new Guid("c6c3ae61-aea9-4e5d-932e-46e883867fe5") },
                    { new Guid("a22821cb-0c43-4c1e-b312-64b186c460ee"), new DateTime(2023, 5, 21, 23, 41, 29, 464, DateTimeKind.Local).AddTicks(8128), new Guid("ef41ff40-dfc4-480a-94a5-abaf63f7d3f2"), new Guid("635f4f32-50e8-47eb-b1fb-e22bdb82e028") },
                    { new Guid("a8fcc184-7f7a-4278-bbd0-2da85b40b94d"), new DateTime(2022, 6, 25, 12, 18, 12, 563, DateTimeKind.Local).AddTicks(5826), new Guid("6d8f5454-8ad8-4cb1-933f-e8a47e95c6e3"), new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb") },
                    { new Guid("af6e1b9d-c31d-4c70-b346-6a2946439e6b"), new DateTime(2021, 9, 10, 23, 39, 56, 149, DateTimeKind.Local).AddTicks(4397), new Guid("6de64932-7b2f-4b06-b17c-a8997eefa7fe"), new Guid("63abc1d4-127d-4575-a7fd-3606ef1e724a") },
                    { new Guid("b165fafd-28aa-4fd2-bbd2-df320dfd1f11"), new DateTime(2022, 4, 25, 7, 39, 4, 569, DateTimeKind.Local).AddTicks(5105), new Guid("944fdaa2-12a2-4011-89b9-1daed9bf796a"), new Guid("1cafab03-1491-4d63-9ef3-24d48ef65d44") },
                    { new Guid("b8ea6cb7-2dd3-4224-81e3-481d52051a73"), new DateTime(2022, 9, 17, 19, 56, 39, 25, DateTimeKind.Local).AddTicks(6160), new Guid("da56e1a9-02b6-451e-a256-e6827436bac6"), new Guid("730f8a97-cf99-4215-ba82-cd2fb3351ba1") },
                    { new Guid("bb52b5dc-2728-488f-8d04-c6d8e01becfa"), new DateTime(2022, 1, 9, 2, 44, 57, 274, DateTimeKind.Local).AddTicks(6296), new Guid("ee41996c-baf6-43e7-ab2e-28ca69d3da38"), new Guid("ebe19982-87ae-4234-a30f-7c708523efdb") },
                    { new Guid("bbddd9e6-424f-4c23-b248-fa7e6e8ff2c9"), new DateTime(2023, 3, 18, 8, 2, 53, 410, DateTimeKind.Local).AddTicks(5181), new Guid("a7d8baff-c0a7-4aaa-9ed6-ff27d114a51f"), new Guid("a6afe325-3ee2-4803-b067-88fec590968e") },
                    { new Guid("c569ae84-0de1-4b19-bb18-c1e9cb76b6cb"), new DateTime(2022, 9, 7, 16, 7, 25, 629, DateTimeKind.Local).AddTicks(8109), new Guid("423c8f0a-5da7-4250-be4f-c8ac08b3fcbd"), new Guid("2764ffa2-fcc6-4f3e-b65e-fd14a5d04700") },
                    { new Guid("c6e112dd-784d-46a2-89b1-a7469da707a1"), new DateTime(2021, 12, 2, 16, 53, 52, 238, DateTimeKind.Local).AddTicks(8152), new Guid("50e5b6a0-b2d5-4143-976b-dd3219c1f42d"), new Guid("926211e8-fa2b-41c3-ad8b-8da4d6c76518") },
                    { new Guid("c996d970-725d-4b1a-b4c1-4a5c0e2a0276"), new DateTime(2022, 1, 8, 4, 48, 2, 315, DateTimeKind.Local).AddTicks(2879), new Guid("c22ebf68-f4f3-48bc-8581-3d75491967af"), new Guid("4d66d0ee-947e-4579-be7a-3e3d6ec73768") },
                    { new Guid("c9bc166a-17a2-45fb-852f-427f87e91723"), new DateTime(2021, 10, 24, 6, 58, 26, 43, DateTimeKind.Local).AddTicks(5544), new Guid("28f67f4d-6846-4e83-a816-334cb57ff0c0"), new Guid("a02ee119-bbf8-4615-9ca3-f6bd40723c5f") },
                    { new Guid("d011bd96-f2e3-4560-9b05-73e941c27cc5"), new DateTime(2022, 5, 19, 16, 53, 19, 559, DateTimeKind.Local).AddTicks(3585), new Guid("e096a1aa-a656-4b07-9227-c03d7e4b870d"), new Guid("5145e1e5-754f-456e-ab12-380e46cd25c9") },
                    { new Guid("d1161372-57eb-495c-8aef-e0076bf66a37"), new DateTime(2022, 3, 1, 15, 59, 19, 351, DateTimeKind.Local).AddTicks(9773), new Guid("e096a1aa-a656-4b07-9227-c03d7e4b870d"), new Guid("1cafab03-1491-4d63-9ef3-24d48ef65d44") },
                    { new Guid("d3db304d-9ae8-4b8f-be65-42568ec0b0ac"), new DateTime(2023, 5, 17, 21, 58, 24, 37, DateTimeKind.Local).AddTicks(3948), new Guid("423c8f0a-5da7-4250-be4f-c8ac08b3fcbd"), new Guid("c6c3ae61-aea9-4e5d-932e-46e883867fe5") },
                    { new Guid("d406d6b9-ce37-4fe3-9456-c800b445c75e"), new DateTime(2022, 1, 6, 14, 47, 0, 935, DateTimeKind.Local).AddTicks(8146), new Guid("879a7449-1661-42e6-94ac-b8b0d920c972"), new Guid("f35b9589-753a-48cf-809d-b99e848c01f4") },
                    { new Guid("e208d6c9-7d51-4bd3-a2da-d977f4e0d0d1"), new DateTime(2022, 1, 21, 6, 24, 52, 719, DateTimeKind.Local).AddTicks(4340), new Guid("82e48874-81d2-4c7d-87a5-737ded184ce1"), new Guid("b8ad88ca-2ed1-4f91-9269-2c90f8844049") },
                    { new Guid("e3815f48-ba27-4b7d-bdeb-16af53b7a266"), new DateTime(2021, 7, 1, 17, 22, 3, 847, DateTimeKind.Local).AddTicks(2405), new Guid("c22ebf68-f4f3-48bc-8581-3d75491967af"), new Guid("2764ffa2-fcc6-4f3e-b65e-fd14a5d04700") },
                    { new Guid("e5671a9c-f517-46f0-8fa0-16f392f5fa79"), new DateTime(2021, 9, 11, 4, 41, 28, 257, DateTimeKind.Local).AddTicks(5654), new Guid("a1c739fa-8b15-48e7-9a4f-4c9022474076"), new Guid("f35b9589-753a-48cf-809d-b99e848c01f4") },
                    { new Guid("e655bb6e-04b1-4018-8ee9-224889ae0b27"), new DateTime(2021, 10, 14, 4, 18, 43, 205, DateTimeKind.Local).AddTicks(7100), new Guid("2a3b35d4-b5b7-452c-8751-a3dbaadc6e62"), new Guid("7aa6fcc6-25e8-4f79-b7fe-d053e1e20e78") },
                    { new Guid("e95ce11c-d338-4f90-8acf-82a1e3b82edf"), new DateTime(2021, 8, 12, 16, 25, 36, 485, DateTimeKind.Local).AddTicks(7858), new Guid("2a3b35d4-b5b7-452c-8751-a3dbaadc6e62"), new Guid("c95fdcfd-ab1d-4d59-9abe-7afaa99d40d3") },
                    { new Guid("f1c6762c-afea-4c31-9d58-4cd2b9f40637"), new DateTime(2022, 5, 5, 4, 17, 46, 325, DateTimeKind.Local).AddTicks(8735), new Guid("c22ebf68-f4f3-48bc-8581-3d75491967af"), new Guid("f2d6e6b6-33e0-4508-b1df-b3ea49c7752d") },
                    { new Guid("faf09957-e41b-4b6b-87f6-ee75ba2617a5"), new DateTime(2022, 11, 5, 5, 31, 3, 610, DateTimeKind.Local).AddTicks(7995), new Guid("d897b29f-e036-4b09-9b21-e591c68c740f"), new Guid("7aa6fcc6-25e8-4f79-b7fe-d053e1e20e78") },
                    { new Guid("fd1dcae4-e27b-4b2e-b945-1de4ac8edc6e"), new DateTime(2022, 10, 19, 2, 21, 29, 696, DateTimeKind.Local).AddTicks(6201), new Guid("02ed211d-6417-425b-b7c4-7e22eb2a98ed"), new Guid("649ce298-629b-4846-bc8c-1bb0ff6aaff3") }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "ClassId", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("079f7b86-60f2-4d04-9e5d-c8eaf5ae9f9f"), new DateTime(2024, 4, 2, 0, 4, 32, 378, DateTimeKind.Local).AddTicks(3972), new Guid("f6c51653-07f6-4e33-b010-69cb5710f02e"), new Guid("fb66fb6b-5bb1-495d-bd3b-7d63046777e2") },
                    { new Guid("0b4b1507-9223-40f7-ac10-c383a1ab5eb2"), new DateTime(2024, 10, 9, 20, 57, 39, 810, DateTimeKind.Local).AddTicks(643), new Guid("c262dbc1-d62d-43c8-8016-682d807a2b18"), new Guid("926211e8-fa2b-41c3-ad8b-8da4d6c76518") },
                    { new Guid("137f0039-216a-442f-a22c-00529db45e45"), new DateTime(2025, 1, 27, 4, 56, 39, 14, DateTimeKind.Local).AddTicks(9960), new Guid("71dfe563-8e10-40ce-a681-3eee12293f3f"), new Guid("1e5b278c-1fed-4cc2-a48b-cf1e4979c735") },
                    { new Guid("1847f6d5-bc05-4662-a83e-c69d29211c29"), new DateTime(2023, 10, 8, 22, 27, 35, 222, DateTimeKind.Local).AddTicks(8587), new Guid("9c826928-a81b-4fa3-b4a9-18c9f54e2e8f"), new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb") },
                    { new Guid("19c716ed-07ec-4404-b4ef-dbed10a1eaf1"), new DateTime(2024, 8, 13, 2, 52, 4, 24, DateTimeKind.Local).AddTicks(1188), new Guid("c262dbc1-d62d-43c8-8016-682d807a2b18"), new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb") },
                    { new Guid("1b4da351-6700-4bfc-ad18-3621f6790e0e"), new DateTime(2023, 7, 31, 21, 15, 44, 401, DateTimeKind.Local).AddTicks(3309), new Guid("b31cc042-0cff-4076-a784-eb9f30be8380"), new Guid("7aa6fcc6-25e8-4f79-b7fe-d053e1e20e78") },
                    { new Guid("2747e313-111b-44da-8b7c-0a145e7c2051"), new DateTime(2024, 8, 3, 22, 42, 23, 466, DateTimeKind.Local).AddTicks(1751), new Guid("6d8f5454-8ad8-4cb1-933f-e8a47e95c6e3"), new Guid("c37160a8-2223-417f-aeea-48ee0530053b") },
                    { new Guid("2c2f08bf-3a61-4166-a501-5327005320a5"), new DateTime(2023, 10, 16, 20, 12, 34, 69, DateTimeKind.Local).AddTicks(1487), new Guid("38bc2525-70f1-4491-93e5-36ca4a7fddfe"), new Guid("7aaf255d-aad0-4d4a-bfc9-6a7cffbc3b43") },
                    { new Guid("31d12ac4-df0b-460a-9293-f090c5ff74a9"), new DateTime(2023, 8, 5, 4, 8, 17, 592, DateTimeKind.Local).AddTicks(5181), new Guid("8ed87979-b1b1-4415-9b58-6a984c4f7860"), new Guid("24f0d318-55eb-47d8-8925-70ef553d4745") },
                    { new Guid("34a4ddc1-464c-464d-abd3-e3d6cbd977aa"), new DateTime(2023, 9, 26, 12, 58, 2, 486, DateTimeKind.Local).AddTicks(4628), new Guid("0f12b2b8-d06f-4d10-b5ef-1bd35e939fbd"), new Guid("649ce298-629b-4846-bc8c-1bb0ff6aaff3") },
                    { new Guid("462d877e-bb03-4b89-a39c-4d7f0f5d8b55"), new DateTime(2025, 4, 23, 16, 4, 57, 578, DateTimeKind.Local).AddTicks(6036), new Guid("1406b8ff-dc6c-42be-99b7-ba21064ec5bf"), new Guid("ae92defd-67aa-482d-baa8-27f05f1cbff5") },
                    { new Guid("49b17b05-5f94-4818-9d77-22fcf8bf444b"), new DateTime(2023, 8, 16, 3, 5, 38, 103, DateTimeKind.Local).AddTicks(358), new Guid("944fdaa2-12a2-4011-89b9-1daed9bf796a"), new Guid("2764ffa2-fcc6-4f3e-b65e-fd14a5d04700") },
                    { new Guid("4bbedc4d-1dc7-44bf-ba1d-cdca78c51e60"), new DateTime(2024, 5, 6, 19, 57, 6, 540, DateTimeKind.Local).AddTicks(2730), new Guid("6d8f5454-8ad8-4cb1-933f-e8a47e95c6e3"), new Guid("730f8a97-cf99-4215-ba82-cd2fb3351ba1") },
                    { new Guid("4c951c05-b096-4344-b1d7-e787836d77da"), new DateTime(2024, 1, 23, 20, 49, 10, 91, DateTimeKind.Local).AddTicks(4642), new Guid("87bb5f1f-37b8-4183-bd67-17808673c870"), new Guid("926211e8-fa2b-41c3-ad8b-8da4d6c76518") },
                    { new Guid("52caed97-dbb4-49f7-a53e-94d182974722"), new DateTime(2024, 1, 15, 23, 43, 10, 965, DateTimeKind.Local).AddTicks(4981), new Guid("2504495d-5c68-4f4a-8dc2-56c324ce56d5"), new Guid("88af0a21-835e-4861-89e8-4c0dcfadae4a") },
                    { new Guid("562aa367-aa48-4237-bcc7-648c278525fd"), new DateTime(2024, 5, 14, 22, 13, 4, 954, DateTimeKind.Local).AddTicks(1343), new Guid("501ff17b-16e5-4a1b-aa6d-643ca5e33d06"), new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb") },
                    { new Guid("58f94f4e-8aee-4891-83ca-7db3eda858fc"), new DateTime(2024, 12, 30, 3, 25, 34, 385, DateTimeKind.Local).AddTicks(3967), new Guid("8ed87979-b1b1-4415-9b58-6a984c4f7860"), new Guid("5145e1e5-754f-456e-ab12-380e46cd25c9") },
                    { new Guid("5bc048bb-a026-4ba2-be3e-2440df7bc759"), new DateTime(2024, 4, 1, 23, 40, 26, 987, DateTimeKind.Local).AddTicks(3264), new Guid("1406b8ff-dc6c-42be-99b7-ba21064ec5bf"), new Guid("4d66d0ee-947e-4579-be7a-3e3d6ec73768") },
                    { new Guid("5d178299-a6f4-4400-a38b-ed4618200a2f"), new DateTime(2025, 4, 14, 20, 16, 40, 586, DateTimeKind.Local).AddTicks(5464), new Guid("1406b8ff-dc6c-42be-99b7-ba21064ec5bf"), new Guid("b8ad88ca-2ed1-4f91-9269-2c90f8844049") },
                    { new Guid("64aa29e1-c66d-40cd-a8fe-02b51b07bb26"), new DateTime(2024, 8, 29, 2, 6, 38, 499, DateTimeKind.Local).AddTicks(3021), new Guid("e1ec4026-76b5-42e0-8fee-70ccd481bede"), new Guid("1cafab03-1491-4d63-9ef3-24d48ef65d44") },
                    { new Guid("6708d693-ed5b-4e62-b4a0-29b31170199e"), new DateTime(2023, 10, 21, 5, 2, 12, 699, DateTimeKind.Local).AddTicks(8309), new Guid("1406b8ff-dc6c-42be-99b7-ba21064ec5bf"), new Guid("941803f4-8e93-46c8-a97c-fc3896a630f0") },
                    { new Guid("6f410b20-4b67-4a5e-bc75-4eb48b036807"), new DateTime(2024, 5, 24, 20, 6, 24, 621, DateTimeKind.Local).AddTicks(9621), new Guid("82e48874-81d2-4c7d-87a5-737ded184ce1"), new Guid("f10b97f3-0e83-49a4-832f-2c15961f1fbd") },
                    { new Guid("7545c2b7-9fbb-4a08-8dda-e582ba084a1f"), new DateTime(2025, 4, 6, 8, 41, 6, 183, DateTimeKind.Local).AddTicks(9989), new Guid("7ea297b3-8922-4878-b6b3-839a6ffd4872"), new Guid("6c041b84-d055-4227-94a5-f2f7ef5d60de") },
                    { new Guid("78965f2e-007d-4834-be17-c7f096d95269"), new DateTime(2025, 3, 10, 0, 12, 45, 283, DateTimeKind.Local).AddTicks(1132), new Guid("82e48874-81d2-4c7d-87a5-737ded184ce1"), new Guid("24f0d318-55eb-47d8-8925-70ef553d4745") },
                    { new Guid("7d005f9f-5cbd-4710-8a45-f8f6970886b5"), new DateTime(2024, 2, 22, 17, 45, 9, 962, DateTimeKind.Local).AddTicks(3150), new Guid("5749520d-456d-4ec7-a769-e17ba22b867b"), new Guid("f6f34628-c0e0-4b87-8561-b948d83c28bb") },
                    { new Guid("808aa6c3-d4ac-4c24-b2f9-7a0dd19cbbd7"), new DateTime(2024, 12, 4, 7, 25, 10, 877, DateTimeKind.Local).AddTicks(837), new Guid("42b97a31-0634-474f-af48-42554ee91ab9"), new Guid("90567b15-12de-431d-8c18-2597ef948af6") },
                    { new Guid("80c90298-8a8b-478b-bafc-5ec6e38189ac"), new DateTime(2023, 8, 27, 5, 32, 32, 649, DateTimeKind.Local).AddTicks(5955), new Guid("82e48874-81d2-4c7d-87a5-737ded184ce1"), new Guid("926211e8-fa2b-41c3-ad8b-8da4d6c76518") },
                    { new Guid("86184cb9-100a-4307-85ef-0eea007ea186"), new DateTime(2024, 3, 1, 14, 19, 20, 74, DateTimeKind.Local).AddTicks(1068), new Guid("501ff17b-16e5-4a1b-aa6d-643ca5e33d06"), new Guid("ae92defd-67aa-482d-baa8-27f05f1cbff5") },
                    { new Guid("86548ea3-a8d8-4eee-bada-e56ae5d36a14"), new DateTime(2025, 6, 6, 11, 6, 57, 858, DateTimeKind.Local).AddTicks(219), new Guid("501ff17b-16e5-4a1b-aa6d-643ca5e33d06"), new Guid("176d9a75-94a8-4205-91f7-73905d6c9f74") },
                    { new Guid("878d4edc-0115-428d-a9d2-1a9744a1151a"), new DateTime(2023, 10, 14, 13, 32, 25, 506, DateTimeKind.Local).AddTicks(508), new Guid("44cbaa62-772b-4203-b5ac-6c124427fbfb"), new Guid("17c77a46-da2c-4b96-8388-fe64f151404e") },
                    { new Guid("9c035060-5d75-4010-9660-268e1781bd57"), new DateTime(2024, 11, 6, 23, 8, 29, 590, DateTimeKind.Local).AddTicks(1012), new Guid("1edc248a-4812-43ac-81e0-2237d0e9b33c"), new Guid("5fb63832-6bac-4e71-90ad-b24ad67461b8") },
                    { new Guid("9d7cf5df-2955-493d-9cf4-5411074e075c"), new DateTime(2024, 11, 1, 19, 44, 13, 454, DateTimeKind.Local).AddTicks(3569), new Guid("a7d8baff-c0a7-4aaa-9ed6-ff27d114a51f"), new Guid("1e5b278c-1fed-4cc2-a48b-cf1e4979c735") },
                    { new Guid("ab265e32-8de3-427f-a758-6d4222c59a22"), new DateTime(2023, 7, 11, 15, 51, 44, 435, DateTimeKind.Local).AddTicks(1185), new Guid("e096a1aa-a656-4b07-9227-c03d7e4b870d"), new Guid("f10b97f3-0e83-49a4-832f-2c15961f1fbd") },
                    { new Guid("ad1268f5-af39-4502-9d48-dca39e06ff73"), new DateTime(2023, 11, 27, 3, 55, 4, 796, DateTimeKind.Local).AddTicks(4656), new Guid("332f2032-533e-4698-9038-81c7e74c36d3"), new Guid("635f4f32-50e8-47eb-b1fb-e22bdb82e028") },
                    { new Guid("b048ccb8-c50f-4477-9468-a4bcb9ec3f96"), new DateTime(2024, 6, 15, 17, 43, 52, 509, DateTimeKind.Local).AddTicks(3495), new Guid("2504495d-5c68-4f4a-8dc2-56c324ce56d5"), new Guid("90567b15-12de-431d-8c18-2597ef948af6") },
                    { new Guid("b93060d4-0a74-4173-9e38-4262b50226b5"), new DateTime(2025, 3, 12, 20, 42, 10, 11, DateTimeKind.Local).AddTicks(4428), new Guid("82e48874-81d2-4c7d-87a5-737ded184ce1"), new Guid("941803f4-8e93-46c8-a97c-fc3896a630f0") },
                    { new Guid("bc99cda1-1960-4065-9002-c9d21a4c8ce4"), new DateTime(2024, 9, 5, 21, 14, 28, 427, DateTimeKind.Local).AddTicks(4939), new Guid("5749520d-456d-4ec7-a769-e17ba22b867b"), new Guid("64da1a27-bc10-4bf1-bc47-526a488cbe7d") },
                    { new Guid("c1210c98-6101-4734-9694-f06eb2c5ba09"), new DateTime(2023, 12, 13, 0, 16, 51, 308, DateTimeKind.Local).AddTicks(9935), new Guid("87bb5f1f-37b8-4183-bd67-17808673c870"), new Guid("5145e1e5-754f-456e-ab12-380e46cd25c9") },
                    { new Guid("d3d3bd41-78f8-47b8-926d-527adb30142b"), new DateTime(2024, 11, 17, 5, 34, 39, 546, DateTimeKind.Local).AddTicks(6668), new Guid("44cbaa62-772b-4203-b5ac-6c124427fbfb"), new Guid("451640a5-0dff-4ff9-8b15-51be9fee5746") },
                    { new Guid("d4fbc197-2116-442f-b8be-c74eab324f99"), new DateTime(2024, 6, 20, 12, 52, 20, 761, DateTimeKind.Local).AddTicks(9821), new Guid("c5f8e076-a16c-4430-8bc9-a9558c1442a1"), new Guid("32cf5e73-fd17-42c2-a41d-ba21ac44f81b") },
                    { new Guid("d97bc48a-6864-43ce-a490-b7c2cba3da57"), new DateTime(2025, 6, 17, 16, 54, 53, 144, DateTimeKind.Local).AddTicks(9305), new Guid("d897b29f-e036-4b09-9b21-e591c68c740f"), new Guid("904ecce7-a25a-4c37-b3fa-b14c71b55e14") },
                    { new Guid("dbd01f59-35fa-4a99-b7b5-16c340cfb966"), new DateTime(2023, 12, 18, 13, 30, 30, 41, DateTimeKind.Local).AddTicks(8662), new Guid("e096a1aa-a656-4b07-9227-c03d7e4b870d"), new Guid("6c041b84-d055-4227-94a5-f2f7ef5d60de") },
                    { new Guid("dc38c5a5-ea1c-4963-ad2b-666be0408f5f"), new DateTime(2024, 8, 14, 1, 57, 40, 378, DateTimeKind.Local).AddTicks(5191), new Guid("2504495d-5c68-4f4a-8dc2-56c324ce56d5"), new Guid("f2d6e6b6-33e0-4508-b1df-b3ea49c7752d") },
                    { new Guid("ddac9149-2f0a-4be2-aef8-d2ca8ee843d1"), new DateTime(2023, 10, 17, 2, 24, 29, 135, DateTimeKind.Local).AddTicks(6455), new Guid("ef41ff40-dfc4-480a-94a5-abaf63f7d3f2"), new Guid("f35b9589-753a-48cf-809d-b99e848c01f4") },
                    { new Guid("e2c0da13-720c-4c20-83fa-7dcba9900ae5"), new DateTime(2024, 4, 28, 4, 14, 40, 682, DateTimeKind.Local).AddTicks(7163), new Guid("2504495d-5c68-4f4a-8dc2-56c324ce56d5"), new Guid("124c5327-ecf3-4935-b9fd-c5ed4160391d") },
                    { new Guid("f89d0e24-80a7-4be0-8f66-c3045a20a6ae"), new DateTime(2023, 10, 24, 18, 52, 3, 859, DateTimeKind.Local).AddTicks(6116), new Guid("c5f8e076-a16c-4430-8bc9-a9558c1442a1"), new Guid("fb66fb6b-5bb1-495d-bd3b-7d63046777e2") },
                    { new Guid("f8d61382-8630-407a-8127-b95f0b6c4afa"), new DateTime(2025, 3, 22, 14, 39, 17, 140, DateTimeKind.Local).AddTicks(305), new Guid("87bb5f1f-37b8-4183-bd67-17808673c870"), new Guid("17c77a46-da2c-4b96-8388-fe64f151404e") },
                    { new Guid("fb9534c4-ae3d-4750-8fb3-a34cf7b4517e"), new DateTime(2024, 5, 1, 17, 39, 29, 387, DateTimeKind.Local).AddTicks(9988), new Guid("d3adfab1-7ae3-412c-802b-e6cb52fd4abf"), new Guid("44659a54-101a-4243-98e3-928f906d93a2") },
                    { new Guid("fd015ce4-e73a-4422-afc3-522ea71816cf"), new DateTime(2023, 9, 29, 4, 53, 53, 495, DateTimeKind.Local).AddTicks(7353), new Guid("44cbaa62-772b-4203-b5ac-6c124427fbfb"), new Guid("88af0a21-835e-4861-89e8-4c0dcfadae4a") },
                    { new Guid("fdfb71db-21e8-4d9d-b83f-10bcb38d0861"), new DateTime(2025, 5, 20, 15, 41, 52, 219, DateTimeKind.Local).AddTicks(2734), new Guid("879a7449-1661-42e6-94ac-b8b0d920c972"), new Guid("a6afe325-3ee2-4803-b067-88fec590968e") }
                });

            migrationBuilder.InsertData(
                table: "EquipmentClass",
                columns: new[] { "EquipmentClassId", "ClassId", "EquipmentId" },
                values: new object[,]
                {
                    { new Guid("06293460-8460-4100-9ec5-34d3366f19f9"), new Guid("ef41ff40-dfc4-480a-94a5-abaf63f7d3f2"), new Guid("c3528680-cfd9-4f8a-8068-5514427dd673") },
                    { new Guid("0f3ade0b-5652-478c-af82-ef015ae62ae1"), new Guid("c262dbc1-d62d-43c8-8016-682d807a2b18"), new Guid("f7032e79-d695-42da-a79c-5f8121641505") },
                    { new Guid("1f56f8c8-c586-4972-a752-a88b0c13912c"), new Guid("8ed87979-b1b1-4415-9b58-6a984c4f7860"), new Guid("06926f99-872b-4bc0-a225-805123da282a") },
                    { new Guid("290abb31-03fa-486d-b777-39c921762abd"), new Guid("727c0c10-28c8-4976-9fb7-4ba6d24d538e"), new Guid("d5d7bbee-6fbd-4491-9b34-cbf3f458a490") },
                    { new Guid("2c3e3dd8-1205-42c1-84b2-167b10931d3e"), new Guid("b25e90ff-199e-453b-9ce7-ab904fd20489"), new Guid("b965d4c9-84e1-4b91-8860-ad55ff56e962") },
                    { new Guid("2c55fce9-6812-46d4-b1bf-28e894669d63"), new Guid("02ed211d-6417-425b-b7c4-7e22eb2a98ed"), new Guid("bafffccd-36c7-4d0e-bef0-2df5f09086e6") },
                    { new Guid("2d803f97-8275-4400-b8d9-f58196d5a8fc"), new Guid("944fdaa2-12a2-4011-89b9-1daed9bf796a"), new Guid("55b9b5b1-a0b2-4fa0-962f-2787d2fd56d6") },
                    { new Guid("2ee3ee59-72ea-4bcf-ad54-19e02edf1f10"), new Guid("44cbaa62-772b-4203-b5ac-6c124427fbfb"), new Guid("2c335605-a301-432e-a10d-c04d328d2f59") },
                    { new Guid("340b1939-9b60-49c8-9fed-c91db4688562"), new Guid("c5f8e076-a16c-4430-8bc9-a9558c1442a1"), new Guid("0fd0c38f-3db9-4078-9545-8c01bd65a2ae") },
                    { new Guid("365fd14b-4dbc-4615-8c98-dae91bc46001"), new Guid("b31cc042-0cff-4076-a784-eb9f30be8380"), new Guid("b21475d3-d038-4347-9181-50d60ecde580") },
                    { new Guid("370d7b39-b04f-431f-a143-46f17472f761"), new Guid("2fb0e66c-8312-49d5-880a-693e2f45046c"), new Guid("0e88b17a-8fed-4eca-bae3-9d32a36cb3c0") },
                    { new Guid("3bd763a6-ba17-44a1-bb1d-c856d8fab0b7"), new Guid("38bc2525-70f1-4491-93e5-36ca4a7fddfe"), new Guid("904dd314-0ea9-465c-b410-ec373f397e5c") },
                    { new Guid("47ed5cda-8729-45cc-bd34-90918a797a6d"), new Guid("e1ec4026-76b5-42e0-8fee-70ccd481bede"), new Guid("e3213874-7860-428b-a5e7-c0296e8df6c5") },
                    { new Guid("50715c66-1b9e-42e6-8b78-f1f14d1cc68c"), new Guid("d3adfab1-7ae3-412c-802b-e6cb52fd4abf"), new Guid("c2474ff4-e303-45ba-a4c9-a1f109970567") },
                    { new Guid("61a1bf5b-f790-41ef-b589-bfd5e741149a"), new Guid("87bb5f1f-37b8-4183-bd67-17808673c870"), new Guid("06926f99-872b-4bc0-a225-805123da282a") },
                    { new Guid("68c35845-0aef-45b1-bd45-bcd8d56f4bb3"), new Guid("1406b8ff-dc6c-42be-99b7-ba21064ec5bf"), new Guid("3f62f322-d818-424e-b286-73d0e28f91ac") },
                    { new Guid("68ea2783-a11a-4ece-9450-0e47bad9a6d4"), new Guid("2a3b35d4-b5b7-452c-8751-a3dbaadc6e62"), new Guid("6db8dbde-b98f-4cc3-9a64-ddcb8aec88f5") },
                    { new Guid("7385147a-6324-4831-bb97-d5cbf79df8b6"), new Guid("cd21e82a-379f-40b6-89b3-2b94e20268cc"), new Guid("1e365200-2c19-43b5-b424-f3954e2b8b11") },
                    { new Guid("786ce171-19eb-4eef-abd3-a1881c093c3e"), new Guid("e1ec4026-76b5-42e0-8fee-70ccd481bede"), new Guid("904dd314-0ea9-465c-b410-ec373f397e5c") },
                    { new Guid("7f17ae3a-2e83-44a3-ab68-73d519eb83fe"), new Guid("b31cc042-0cff-4076-a784-eb9f30be8380"), new Guid("06926f99-872b-4bc0-a225-805123da282a") },
                    { new Guid("82a4aa61-0ec9-47ea-8679-2ec07b245a1e"), new Guid("38bc2525-70f1-4491-93e5-36ca4a7fddfe"), new Guid("dbe636f5-b0f9-4c3b-af96-bd7d7402f2e4") },
                    { new Guid("88511967-0ccf-4358-bdc2-af688fd6c415"), new Guid("1edc248a-4812-43ac-81e0-2237d0e9b33c"), new Guid("b5f725c7-17e7-4a26-99d3-58dee892ebc7") },
                    { new Guid("8897ef0a-49b6-4542-aa60-507864f73df8"), new Guid("44cbaa62-772b-4203-b5ac-6c124427fbfb"), new Guid("67e6b5e3-22f3-4719-8b0a-6304ef2e7bea") },
                    { new Guid("8b508acf-b200-4065-861d-5c5c7bc695fd"), new Guid("7ea297b3-8922-4878-b6b3-839a6ffd4872"), new Guid("c3528680-cfd9-4f8a-8068-5514427dd673") },
                    { new Guid("9093b958-a351-44b6-a22a-eb2e5181297f"), new Guid("e096a1aa-a656-4b07-9227-c03d7e4b870d"), new Guid("152f975f-2413-497a-9f81-6956d00cb853") },
                    { new Guid("a2994477-c53e-4b68-a614-0359e9cc8959"), new Guid("2098392a-7c04-4fc4-b00c-3b95a279ab34"), new Guid("bd83ac6b-cfea-4d0c-9a2d-7e92b85a5693") },
                    { new Guid("a2d5248a-2aa5-4db2-92cb-85588e85790c"), new Guid("7ea297b3-8922-4878-b6b3-839a6ffd4872"), new Guid("dbe636f5-b0f9-4c3b-af96-bd7d7402f2e4") },
                    { new Guid("a336d56e-c84d-4282-a63e-bcf4c43026d0"), new Guid("2504495d-5c68-4f4a-8dc2-56c324ce56d5"), new Guid("a79f5e33-e531-45d1-b3bd-0e697c2e313e") },
                    { new Guid("ad0f35dc-863b-47a9-b9a7-605813bcab0d"), new Guid("501ff17b-16e5-4a1b-aa6d-643ca5e33d06"), new Guid("b5f725c7-17e7-4a26-99d3-58dee892ebc7") },
                    { new Guid("ad984809-a7d4-40c4-8f33-0fe1ff38d842"), new Guid("28f67f4d-6846-4e83-a816-334cb57ff0c0"), new Guid("361dcae5-4dc8-4408-8691-c9e628646c26") },
                    { new Guid("afcca15f-b761-44d0-92da-e6f7377ef0d1"), new Guid("8ed87979-b1b1-4415-9b58-6a984c4f7860"), new Guid("c2474ff4-e303-45ba-a4c9-a1f109970567") },
                    { new Guid("afea072b-b6a3-4c51-bdea-d5d75b9cfd53"), new Guid("727c0c10-28c8-4976-9fb7-4ba6d24d538e"), new Guid("f43373c9-24b4-48be-a0fe-dab9ea5fb7cb") },
                    { new Guid("b1a5f8da-73f8-4556-a606-daf032e15889"), new Guid("501ff17b-16e5-4a1b-aa6d-643ca5e33d06"), new Guid("a79f5e33-e531-45d1-b3bd-0e697c2e313e") },
                    { new Guid("b7838ea5-682c-46f3-8b6a-2beb44a521fb"), new Guid("6de64932-7b2f-4b06-b17c-a8997eefa7fe"), new Guid("ffc5258c-f792-4be0-8aac-e03d3c1cbef0") },
                    { new Guid("bdec64c3-8afb-461e-98bb-653cfd8e401b"), new Guid("ef41ff40-dfc4-480a-94a5-abaf63f7d3f2"), new Guid("d5d7bbee-6fbd-4491-9b34-cbf3f458a490") },
                    { new Guid("c1611ff9-a4ca-4b56-b935-600c20aa64fe"), new Guid("727c0c10-28c8-4976-9fb7-4ba6d24d538e"), new Guid("76e9fd1f-0316-46cd-8ef6-ded0675f14f9") },
                    { new Guid("cb1737ec-808a-47e7-9f0c-d1a25bea1a24"), new Guid("50e5b6a0-b2d5-4143-976b-dd3219c1f42d"), new Guid("ecc8d467-f969-43e6-93f1-c97e00692516") },
                    { new Guid("cb811497-dadc-4c50-918b-d0f152ca4831"), new Guid("5235da63-213a-484a-a5b6-ce98b1234cf3"), new Guid("a79f5e33-e531-45d1-b3bd-0e697c2e313e") },
                    { new Guid("ce58b193-2f02-42cb-aec9-76e0a0529bc0"), new Guid("332f2032-533e-4698-9038-81c7e74c36d3"), new Guid("46fe3590-cc0a-48fb-9234-acbbf184f68c") },
                    { new Guid("d1dd2241-bec2-41b8-bbff-ef9fd4bef330"), new Guid("71dfe563-8e10-40ce-a681-3eee12293f3f"), new Guid("bd83ac6b-cfea-4d0c-9a2d-7e92b85a5693") },
                    { new Guid("d3add632-7762-48bc-a963-54b69d0ae7a6"), new Guid("7bf5c703-1f02-498c-8cdf-71cf134e9360"), new Guid("b9ca055c-f1ea-41a2-955e-b447f920eb29") },
                    { new Guid("e1b304a6-a721-40c1-81da-a4623e329e06"), new Guid("f6c51653-07f6-4e33-b010-69cb5710f02e"), new Guid("0fd0c38f-3db9-4078-9545-8c01bd65a2ae") },
                    { new Guid("e6460e3e-5e95-4132-87e3-2ac19636e3c1"), new Guid("ee41996c-baf6-43e7-ab2e-28ca69d3da38"), new Guid("3f62f322-d818-424e-b286-73d0e28f91ac") },
                    { new Guid("e67a655d-ebf5-47b7-9616-1b3d2f8af0b8"), new Guid("a7d8baff-c0a7-4aaa-9ed6-ff27d114a51f"), new Guid("f177f9d0-49d0-4bc1-b012-e936383e2208") },
                    { new Guid("eb576fb9-8176-46b0-92d7-76b980152a35"), new Guid("2504495d-5c68-4f4a-8dc2-56c324ce56d5"), new Guid("2c335605-a301-432e-a10d-c04d328d2f59") },
                    { new Guid("f312546e-f1b5-4bbd-aac0-e34ad18638d8"), new Guid("b25e90ff-199e-453b-9ce7-ab904fd20489"), new Guid("c3528680-cfd9-4f8a-8068-5514427dd673") },
                    { new Guid("f61b12a0-6e48-426a-b147-069b40fd9798"), new Guid("50b1c496-a52a-4f0b-9502-5cce70d30897"), new Guid("361dcae5-4dc8-4408-8691-c9e628646c26") },
                    { new Guid("f9aa93ca-7a63-4dec-9917-cdf8483dc4cc"), new Guid("28f67f4d-6846-4e83-a816-334cb57ff0c0"), new Guid("db26b976-6bca-4773-aff2-7bb0f99f65c1") },
                    { new Guid("fbc987dd-b8d0-413e-8beb-81afcf7f1a67"), new Guid("cd21e82a-379f-40b6-89b3-2b94e20268cc"), new Guid("d5d7bbee-6fbd-4491-9b34-cbf3f458a490") },
                    { new Guid("feb44c10-041b-4758-9310-fd69076dd840"), new Guid("d3adfab1-7ae3-412c-802b-e6cb52fd4abf"), new Guid("87ff608b-ad47-4f7d-aeb3-bfe900b08e57") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ClassId",
                table: "Attendance",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_CustomerId",
                table: "Attendance",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClassId",
                table: "Bookings",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_InstructorId",
                table: "Classes",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentClass_ClassId",
                table: "EquipmentClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentClass_EquipmentId",
                table: "EquipmentClass",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "EquipmentClass");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
