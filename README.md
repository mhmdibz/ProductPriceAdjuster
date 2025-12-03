# 💰 Product Price Adjuster - Category Discount Calculator

A powerful C# console application for managing product prices through category-based discount adjustments using the Northwind database. Perfect for retail management, pricing strategies, and bulk discount operations.

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=flat&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white)

## 🌟 Features

### Core Functionality
- 📦 **Category Selection** - Browse and select product categories by ID or Name
- 💵 **Discount Calculation** - Apply percentage-based discounts (1-100%)
- 📊 **Price Comparison** - View original and discounted prices side-by-side
- 🔍 **Smart Search** - Search categories by ID or Name (case-insensitive)
- ✅ **Input Validation** - Robust validation for all user inputs
- 🗄️ **Database Integration** - Direct integration with Northwind database

### Technical Features
- ⚡ **Entity Framework Core** - Modern ORM for database operations
- 🎯 **AsNoTracking** - Optimized read-only queries
- 🔗 **Include Navigation** - Efficient loading of related products
- 💾 **SQL Server** - Enterprise-grade database support
- 🛡️ **Error Handling** - Comprehensive input validation

## 🎯 Use Cases

- **Retail Management** - Apply seasonal discounts to product categories
- **Pricing Strategy** - Test different discount scenarios
- **Sales Planning** - Calculate promotional pricing
- **Inventory Management** - Adjust prices for clearance sales
- **Financial Analysis** - Compare pricing structures

## 🚀 Getting Started

### Prerequisites

```
- .NET 6.0 or higher
- SQL Server (LocalDB or Full Version)
- Northwind Database
- Visual Studio 2022 or VS Code
```

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/yourusername/product-price-adjuster.git
cd product-price-adjuster
```

2. **Restore Northwind Database**
```sql
-- Download Northwind database from Microsoft
-- Attach to your SQL Server instance
-- Or run the Northwind installation script
```

3. **Update Connection String**
```csharp
// In Program.cs, update the connection string:
.UseSqlServer("Server=.;Database=NORTHWIND;Trusted_Connection=True;TrustServerCertificate=True;")
```

4. **Install Dependencies**
```bash
dotnet restore
```

5. **Build the Project**
```bash
dotnet build
```

6. **Run the Application**
```bash
dotnet run
```

## 📖 How to Use

### Step-by-Step Guide

1. **Launch the Application**
   - Run the program and view all available categories

2. **Select a Category**
   - Enter Category ID (e.g., `1`) OR
   - Enter Category Name (e.g., `Beverages`)
   - Case-insensitive search supported

3. **Enter Discount Percentage**
   - Input a value between 1 and 100
   - Example: `15` for 15% discount

4. **View Results**
   - See all products in the selected category
   - Compare original prices with discounted prices

### Example Session

```
Category ID    Category Name             Description
==========================================================
1              Beverages                 Soft drinks, coffees, teas...
2              Condiments                Sweet and savory sauces...
3              Confections               Desserts, candies, and sweet breads

Enter Category Name/Id
> 1

Enter Discount Percentage (1:100)
> 20

=======================================================================
Products                              Price          Discounted
Chai                                  18             14.4
Chang                                 19             15.2
Guaraná Fantástica                    4.5            3.6
```

## 🏗️ Project Structure

```
ProductPriceAdjuster/
│
├── Program.cs                 # Main application logic
├── Models/
│   ├── NORTHWINDContext.cs   # Database context
│   ├── Category.cs            # Category entity
│   └── Product.cs             # Product entity
├── appsettings.json           # Configuration (if added)
└── README.md                  # Project documentation
```

## 🔧 Technologies Used

### Core Technologies
- **C# 10+** - Modern C# features
- **. NET 6.0/7.0/8.0** - Cross-platform framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Relational database management

### Key Libraries
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
```

## 💻 Code Highlights

### Category Display
```csharp
var cats = db.Categories.AsNoTracking().ToList();
Console.WriteLine($"{"Category ID".PadRight(15)}{"Category Name".PadRight(25)} Description");
```

### Discount Calculation
```csharp
decimal discount = (userPercnt / 100);
decimal discountedPrice = item1.UnitPrice - (item1.UnitPrice * discount);
```

### Smart Category Search
```csharp
// Search by ID or Name
if (int.TryParse(userCat, out int catId))
{
    prods = db.Categories.Include(x => x.Products)
              .Where(c => c.CategoryId == id).ToList();
}
else
{
    prods = db.Categories.Include(x => x.Products)
              .Where(c => c.CategoryName == userCat).ToList();
}
```

## 📊 Database Schema

### Categories Table
```sql
CategoryId (int, PK)
CategoryName (nvarchar)
Description (ntext)
```

### Products Table
```sql
ProductId (int, PK)
ProductName (nvarchar)
CategoryId (int, FK)
UnitPrice (money)
UnitsInStock (smallint)
```

## 🔮 Future Enhancements

- [ ] Export discounted prices to CSV/Excel
- [ ] Save discount configurations to database
- [ ] Apply multiple discount tiers
- [ ] Date range for discount validity
- [ ] Undo/Redo discount changes
- [ ] Graphical User Interface (WPF/WinForms)
- [ ] API integration for web applications
- [ ] Generate discount reports
- [ ] Compare multiple discount scenarios
- [ ] Bulk discount operations on multiple categories
- [ ] Email notifications for price changes
- [ ] Audit trail for price modifications
- [ ] Integration with inventory management
- [ ] Real-time price updates

## ⚠️ Important Notes

### Validation Rules
- Category ID must be valid and exist in database
- Category Name search is case-insensitive
- Discount percentage must be between 1 and 100
- Empty inputs are rejected with error messages

### Database Considerations
- Uses `AsNoTracking()` for read-only operations (performance optimization)
- Includes related Products using `.Include()`
- Handles null descriptions gracefully
- No actual database updates (read-only application)

## 🛡️ Error Handling

The application includes comprehensive error handling for:
- ✅ Invalid category IDs
- ✅ Non-existent category names
- ✅ Invalid discount percentages
- ✅ Empty or whitespace inputs
- ✅ Database connection errors
- ✅ Type conversion failures

## 🎓 Learning Outcomes

This project demonstrates:
- Entity Framework Core implementation
- LINQ queries and operations
- Database relationships (one-to-many)
- Input validation techniques
- Console formatting and padding
- String manipulation and comparison
- Type conversion and parsing
- Navigation properties in EF Core
- AsNoTracking optimization

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Contribution Guidelines
- Follow C# coding conventions
- Add XML documentation comments
- Include unit tests for new features
- Update README for significant changes
- Ensure code passes all validations

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
 
## 🙏 Acknowledgments

- **Microsoft** - For Northwind sample database
- **Entity Framework Team** - For excellent ORM framework
- **Stack Overflow Community** - For troubleshooting support
 

## 🐛 Known Issues

- Application is read-only (doesn't persist discount changes to database)
- Limited to single category selection at a time
- Console-only interface (no GUI)
- Discount is calculated but not saved

## 📈 Version History

### Version 1.0.0 (Current)
- ✅ Initial release
- ✅ Category selection by ID or Name
- ✅ Discount percentage calculation
- ✅ Price comparison display
- ✅ Input validation

### Planned for Version 1.1.0
- [ ] Save discount configurations
- [ ] Export to CSV
- [ ] Multiple category selection

## 🌐 System Requirements

- **OS**: Windows 10/11, Linux, macOS
- **RAM**: Minimum 2GB
- **Storage**: 100MB free space
- **Database**: SQL Server 2016 or higher
- **Framework**: .NET 6.0 SDK or higher

---

⭐ **If you find this project useful, please give it a star!** ⭐

**Happy Discounting!** 💰�
