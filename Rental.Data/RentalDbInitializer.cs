using System.Data.Entity;
using Rental.Data.Migrations;

namespace Rental.Data
{
    public class RentalDbInitializer : MigrateDatabaseToLatestVersion<DataContext, Configuration>
    {
        
    }
}
