using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozaStore_AspNetCore6.Migrations
{
    public partial class firstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OurStory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OurMission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponStock = table.Column<int>(type: "int", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponDiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    InfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.InfoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiftWrap = table.Column<bool>(type: "bit", nullable: false),
                    Shipped = table.Column<bool>(type: "bit", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotalQuantity = table.Column<int>(type: "int", nullable: false),
                    CouponName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponDiscount = table.Column<int>(type: "int", nullable: true),
                    OrderedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomUserId",
                        column: x => x.CustomUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Materials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo1Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo2Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo3Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineID);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_CartLine_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishListProducts",
                columns: table => new
                {
                    WishListProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WishListId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListProducts", x => x.WishListProductId);
                    table.ForeignKey(
                        name: "FK_WishListProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishListProducts_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "AboutId", "IsActive", "OurMission", "OurStory" },
                values: new object[] { 1, true, "Mauris non lacinia magna. Sed nec lobortis dolor. Vestibulum rhoncus dignissim risus, sed consectetur erat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nullam maximus mauris sit amet odio convallis, in pharetra magna gravida. Praesent sed nunc fermentum mi molestie tempor. Morbi vitae viverra odio. Pellentesque ac velit egestas, luctus arcu non, laoreet mauris. Sed in ipsum tempor, consequat odio in, porttitor ante. Ut mauris ligula, volutpat in sodales in, porta non odio. Pellentesque tempor urna vitae mi vestibulum, nec venenatis nulla lobortis. Proin at gravida ante. Mauris auctor purus at lacus maximus euismod. Pellentesque vulputate massa ut nisl hendrerit, eget elementum libero iaculis.\r\n\r\n> *Creativity is just connecting things. When you ask creative people how they did something, they feel a little guilty because they didn't really do it, they just saw something. It seemed obvious to them after a while.\r\n> \r\n> - Steve Job’s*", "**Lorem ipsum dolor sit amet**, consectetur adipiscing elit. Mauris consequat consequat enim, non auctor massa ultrices non. Morbi sed odio massa. Quisque at vehicula tellus, sed tincidunt augue. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas varius egestas diam, eu sodales metus scelerisque congue. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas gravida justo eu arcu egestas convallis. Nullam eu erat bibendum, tempus ipsum eget, dictum enim. Donec non neque ut enim dapibus tincidunt vitae nec augue. Suspendisse potenti. Proin ut est diam. Donec condimentum euismod tortor, eget facilisis diam faucibus et. Morbi a tempor elit.\r\n\r\nDonec gravida lorem elit, quis condimentum ex semper sit amet. Fusce eget ligula magna. Aliquam aliquam imperdiet sodales. Ut fringilla turpis in vehicula vehicula. Pellentesque congue ac orci ut gravida. Aliquam erat volutpat. Donec iaculis lectus a arcu facilisis, eu sodales lectus sagittis. Etiam pellentesque, magna vel dictum rutrum, neque justo eleifend elit, vel tincidunt erat arcu ut sem. Sed rutrum, turpis ut commodo efficitur, quam velit convallis ipsum, et maximus enim ligula ac ligula.\r\n\r\nAny questions? Let us know in store at 8th floor, 379 Hudson St, New York, NY 10018 or call us on *(+1) 96 716 6879*" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50710b3c-51ee-4ec5-a3f4-320d6bc67d82", "622c9965-42f5-43a1-8210-1173150ba9f7", "User", "USER" },
                    { "d4174acb-1ac5-4fb9-b617-03ee41baf0dd", "953fee96-131d-47dd-8a12-a6a6ab69eb1c", "Editor", "EDITOR" },
                    { "e2226d17-1ed0-4614-8830-774fbae66717", "083c3259-7916-4853-a1bc-028b44b5c013", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "Men", "men" },
                    { 2, "Women", "women" },
                    { 3, "Bag", "bag" },
                    { 4, "Watch", "watch" },
                    { 5, "Hat", "hat" },
                    { 6, "Glasses", "glasses" }
                });

            migrationBuilder.InsertData(
                table: "Informations",
                columns: new[] { "InfoId", "Address", "Email", "IsActive", "Phone" },
                values: new object[] { 1, "123 Main St, Anytown, USA", "contact@example.com", true, "(123) 456-7890" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "Dimensions", "IsActive", "Materials", "Name", "Photo1Url", "Photo2Url", "Photo3Url", "Price", "SKU", "Slug", "Weight" },
                values: new object[,]
                {
                    { 1, 2, "Snow", "A modern and elegant black winter jacket. Long-sleeved, with a collar and belted waist.", "Length: 70 cm, Chest: 100 cm, Sleeve: 60 cm", false, "Wool Blend", "Elegant Winter Jacket", "/img/elegant-winter-jacket66.png", "/img/elegant-winter-jacket15.png", null, 500m, "EWJ456", "elegant-winter-jacket", 800.0 },
                    { 2, 2, "Multi-color", "A chic and contemporary ensemble, featuring luxurious textures and sophisticated styling.", "Vary based on size", false, "Mixed Fabrics", "Chic Contemporary Outfit", "/img/chic-contemporary-outfit56.png", "/img/chic-contemporary-outfit62.png", null, 350m, "CCO789", "chic-contemporary-outfit", 500.0 },
                    { 3, 2, "Beige and Pink", "A chic business casual outfit, perfect for a professional setting. Features a high-waisted skirt and a sophisticated blouse.", "Vary based on size", false, "Cotton Blend", "Business Casual Outfit", "/img/business-casual-outfit74.png", "/img/business-casual-outfit83.png", null, 450m, "BCO1012", "business-casual-outfit", 550.0 },
                    { 4, 2, "White and Blue", "A casual yet trendy outfit, featuring a fitted white t-shirt and stylish pants.", "Vary based on size", false, "Cotton and Elastane", "Trendy Casual Outfit", "/img/trendy-casual-outfit71.png", "/img/trendy-casual-outfit23.png", null, 200m, "TCO1315", "trendy-casual-outfit", 300.0 },
                    { 5, 2, "Black", "A sophisticated classic evening outfit, featuring a black off-the-shoulder dress.", "Vary based on size", false, "Satin", "Classic Evening Outfit", "/img/classic-evening-outfit11.png", "/img/classic-evening-outfit17.png", null, 450m, "CEO1618", "classic-evening-outfit", 450.0 },
                    { 6, 6, "Black", "Stylish eyeglasses with a classic, sophisticated design. Features a timeless frame suitable for any occasion.", "Frame Width: 140 mm, Lens Height: 40 mm, Lens Width: 50 mm", false, "Metal and Plastic", "Classic Eyeglasses", "/img/classic-eyeglasses47.png", null, null, 150m, "CLSEG101", "classic-eyeglasses", 30.0 },
                    { 7, 6, "Silver", "A pair of delicate, rimless eyeglasses, showcasing a modern and lightweight design.", "Frame Width: 13.5 cm, Lens Height: 3.5 cm, Lens Width: 5 cm", false, "Metal and Polycarbonate", "Fashionable Rimless Eyeglasses", "/img/fashionable-rimless-eyeglasses76.png", null, null, 350m, "FRE102", "fashionable-rimless-eyeglasses", 25.0 },
                    { 8, 6, "Brown", "A pair of contemporary eyeglasses featuring a round frame with a stylish and modern design.", "Frame Width: 14 cm, Lens Height: 4.2 cm, Lens Width: 4.5 cm", false, "Acetate", "Contemporary Round Eyeglasses", "/img/contemporary-round-eyeglasses37.png", null, null, 320m, "CRE103", "contemporary-round-eyeglasses", 28.0 },
                    { 9, 5, "Maroon (Fedora), Blue (Cap)", "This set features a sophisticated maroon fedora with a wide black band and a casual denim cap. The fedora offers an air of elegance, while the cap is perfect for everyday wear.", "Fedora - One size fits all; Cap - Adjustable strap", false, "Wool blend (Fedora), Denim (Cap)", "Sophisticated Fedora and Casual Cap", "/img/sophisticated-fedora-and-casual-cap92.png", null, null, 50m, "HATCOMBO1920", "sophisticated-fedora-and-casual-cap", 2.5E+152 },
                    { 10, 5, "Sand and Teal (Sun Hat), Teal (Beanie)", "A dual-season hat set featuring an elegant, wide-brimmed sun hat in a dual-tone of sand and teal, complete with a black ribbon, and a cozy knit beanie with a playful pompom.", "Sun Hat - One size Beanie - Stretch fit", false, "Straw (Sun Hat), Acrylic knit (Beanie)", "Elegant Wide-Brimmed Sun Hat and Knit Beanie", "/img/elegant-wide-brimmed-sun-hat-and-knit-beanie57.png", null, null, 60m, "HATSET2122", "elegant-wide-brimmed-sun-hat-and-knit-beanie", 200.0 },
                    { 11, 4, "Silver Band", "This men's wristwatch features a sophisticated design with a silver stainless steel band and a striking dark blue dial. The watch includes a date function and is water-resistant.", "Case Diameter - 40 mm, Band Width - 20 mm", false, "Stainless Steel", "Men's Classic Blue Dial Watch", "/img/mens-classic-blue-dial-watch70.png", null, null, 250m, "MCBDW3132", "mens-classic-blue-dial-watch", 120.0 },
                    { 12, 4, "Black", "A modern digital smartwatch with a sleek black rubber band and a large, rectangular digital display. It is designed for both men and women and comes with various smart features such as activity tracking and notifications.", "Case Height - 44 mm, Case Width - 35 mm, Band Width - 22 mm", false, "Rubber, Glass", "Unisex Digital Smartwatch", "/img/unisex-digital-smartwatch78.png", null, null, 300m, "UDSW3334", "unisex-digital-smartwatch", 100.0 },
                    { 13, 4, "Black or Rose Gold", "This minimalist timepiece showcases a modern aesthetic with a simple yet elegant design. Suitable for all genders, it features a slim profile, a matte black or rose gold case, and a comfortable strap.", "Case Diameter - 38 mm, Band Width - 18 mm", false, "Metal, Leather", "Minimalist Unisex Timepiece", "/img/minimalist-unisex-timepiece64.png", null, null, 150m, "MUTW3536", "minimalist-unisex-timepiece", 80.0 },
                    { 14, 1, "Dark Navy", "This suit features a contemporary design with a dark navy slim-fit blazer and matching trousers. The outfit is tailored to offer a sleek silhouette, perfect for business meetings or formal events.", "Size varies by selection", false, "Wool Blend", "Modern Slim-Fit Navy Suit", "/img/modern-slim-fit-navy-suit14.png", "/img/modern-slim-fit-navy-suit63.png", null, 350m, "MSFNS3739", "modern-slim-fit-navy-suit", 1200.0 },
                    { 15, 1, "Light Grey", "A fashionable and relaxed outfit, perfect for casual outings. This set features a light grey, crew-neck sweater made from a soft, breathable knit, paired with dark denim jeans and complemented by classic white sneakers.", "Size varies by selection", false, "Cotton Knit (Sweater), Denim (Jeans), Leather (Sneakers)", "Trendy Casual Men's Outfit", "/img/trendy-casual-mens-outfit99.png", "/img/trendy-casual-mens-outfit8.png", null, 180m, "TCMO4042", "trendy-casual-mens-outfit", 1000.0 },
                    { 16, 1, "Charcoal Grey", "A refined and versatile outfit suitable for various occasions. The ensemble includes a tailored charcoal grey wool blazer, a classic white dress shirt, dark navy dress trousers, and brown leather Oxford shoes.", "Size varies by selection", false, "Wool", "Smart Casual Men's Outfit", "/img/smart-casual-mens-outfit38.png", "/img/smart-casual-mens-outfit14.png", null, 350m, "SCMO4344", "smart-casual-mens-outfit", 1500.0 }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "Color", "ProductId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, "Snow", 1, 5, "XL" },
                    { 2, "Black", 2, 5, "S" },
                    { 3, "Pink", 3, 5, "M" },
                    { 4, "White", 4, 5, "XS" },
                    { 5, "Black", 5, 5, "L" },
                    { 6, "Black", 6, 20, "Fix" },
                    { 7, "Silver", 7, 10, "Fix" },
                    { 8, "Maroon (Fedora)", 8, 5, "Fix" },
                    { 9, "Straw", 9, 5, "Fix" },
                    { 10, "Silver Band", 10, 10, "Fix" },
                    { 11, "Black", 11, 12, "Fix" },
                    { 12, "Black", 12, 5, "Fix" },
                    { 13, "Dark Navy", 13, 5, "XL" },
                    { 14, "Light Grey", 14, 5, "XL" },
                    { 15, "Charcoal Grey", 15, 5, "XL" },
                    { 16, "Blue", 1, 10, "XL" },
                    { 17, "Orange", 1, 10, "XL" },
                    { 18, "Orange", 1, 11, "L" },
                    { 19, "Blue", 1, 1, "L" },
                    { 20, "Purple", 1, 10, "M" },
                    { 21, "Red", 1, 15, "M" },
                    { 22, "Orange", 1, 6, "S" },
                    { 23, "Blue", 1, 12, "S" },
                    { 24, "Orange", 2, 1, "XL" },
                    { 25, "Orange", 2, 9, "XL" },
                    { 26, "Yellow", 2, 14, "L" },
                    { 27, "Green", 2, 8, "L" },
                    { 28, "Red", 2, 4, "M" },
                    { 29, "Purple", 2, 5, "M" },
                    { 30, "Purple", 2, 13, "S" },
                    { 31, "Purple", 2, 10, "S" },
                    { 32, "Yellow", 3, 4, "XL" },
                    { 33, "Red", 3, 4, "XL" },
                    { 34, "Blue", 3, 2, "L" },
                    { 35, "Purple", 3, 1, "L" },
                    { 36, "Red", 3, 8, "M" },
                    { 37, "Red", 3, 2, "M" },
                    { 38, "Blue", 3, 6, "S" },
                    { 39, "Green", 3, 5, "S" },
                    { 40, "Red", 4, 1, "XL" },
                    { 41, "Orange", 4, 9, "XL" },
                    { 42, "Orange", 4, 14, "L" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "Color", "ProductId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 43, "Orange", 4, 10, "L" },
                    { 44, "Purple", 4, 4, "M" },
                    { 45, "Purple", 4, 15, "M" },
                    { 46, "Green", 4, 2, "S" },
                    { 47, "Purple", 4, 15, "S" },
                    { 48, "Green", 5, 8, "XL" },
                    { 49, "Purple", 5, 14, "XL" },
                    { 50, "Red", 5, 7, "L" },
                    { 51, "Blue", 5, 11, "L" },
                    { 52, "Green", 5, 1, "M" },
                    { 53, "Yellow", 5, 4, "M" },
                    { 54, "Yellow", 5, 7, "S" },
                    { 55, "Purple", 5, 9, "S" },
                    { 56, "Yellow", 6, 3, "Fix" },
                    { 57, "Purple", 6, 3, "Fix" },
                    { 58, "Orange", 6, 7, "Fix" },
                    { 59, "Green", 7, 7, "Fix" },
                    { 60, "Green", 7, 7, "Fix" },
                    { 61, "Blue", 7, 7, "Fix" },
                    { 62, "Green", 8, 15, "Fix" },
                    { 63, "Yellow", 8, 8, "Fix" },
                    { 64, "Red", 8, 5, "Fix" },
                    { 65, "Blue", 9, 5, "Fix" },
                    { 66, "Red", 9, 14, "Fix" },
                    { 67, "Yellow", 9, 8, "Fix" },
                    { 68, "Orange", 10, 15, "Fix" },
                    { 69, "Blue", 10, 2, "Fix" },
                    { 70, "Yellow", 10, 14, "Fix" },
                    { 71, "Yellow", 11, 14, "Fix" },
                    { 72, "Red", 11, 8, "Fix" },
                    { 73, "Green", 11, 6, "Fix" },
                    { 74, "Blue", 12, 14, "Fix" },
                    { 75, "Blue", 12, 11, "Fix" },
                    { 76, "Orange", 12, 6, "Fix" },
                    { 77, "Purple", 13, 3, "XL" },
                    { 78, "Green", 13, 9, "XL" },
                    { 79, "Red", 13, 1, "L" },
                    { 80, "Yellow", 13, 6, "L" },
                    { 81, "Green", 13, 3, "M" },
                    { 82, "Orange", 13, 3, "M" },
                    { 83, "Purple", 13, 1, "S" },
                    { 84, "Purple", 13, 12, "S" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "Color", "ProductId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 85, "Yellow", 14, 9, "XL" },
                    { 86, "Yellow", 14, 15, "XL" },
                    { 87, "Orange", 14, 6, "L" },
                    { 88, "Red", 14, 3, "L" },
                    { 89, "Purple", 14, 7, "M" },
                    { 90, "Yellow", 14, 4, "M" },
                    { 91, "Orange", 14, 12, "S" },
                    { 92, "Green", 14, 12, "S" },
                    { 93, "Green", 15, 14, "XL" },
                    { 94, "Orange", 15, 1, "XL" },
                    { 95, "Orange", 15, 1, "L" },
                    { 96, "Red", 15, 9, "L" },
                    { 97, "Purple", 15, 8, "M" },
                    { 98, "Green", 15, 14, "M" },
                    { 99, "Purple", 15, 8, "S" },
                    { 100, "Purple", 15, 14, "S" },
                    { 101, "Red", 16, 6, "Fix" },
                    { 102, "Blue", 16, 1, "Fix" },
                    { 103, "Yellow", 16, 9, "Fix" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_OrderId",
                table: "CartLine",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_ProductId",
                table: "CartLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomUserId",
                table: "Orders",
                column: "CustomUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListProducts_ProductId",
                table: "WishListProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListProducts_WishListId",
                table: "WishListProducts",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "WishListProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
