
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TicketBooking.Migrations;
using System.Data.Entity.Migrations;

namespace TicketBooking
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbMigration();
        }
        private static void DbMigration()
        {
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();

        }

    }
}
