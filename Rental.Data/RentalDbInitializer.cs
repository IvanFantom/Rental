using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Data.Migrations;

namespace Rental.Data
{
    public class RentalDbInitializer : MigrateDatabaseToLatestVersion<DataContext, Configuration>
    {
        
    }
}
