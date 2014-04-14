using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Projekt
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Titel", "titel/list", "~/Pages/TitelPages/Listing.aspx");
            routes.MapPageRoute("TitelCreate", "titlar/ny", "~/Pages/TitelPages/Create.aspx");
            routes.MapPageRoute("TitelEdit", "titlar/{id}/edit", "~/Pages/TitelPages/Edit.aspx");
            /* routes.MapPageRoute("TitelDelete", "titlar/{id}/tabort", "~/Pages/TitelPages/Delete.aspx");*/

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

            routes.MapPageRoute("Default", "", "~/Pages/TitelPages/Listing.aspx");

            routes.MapPageRoute("TitelFormat", "tekniskinfo/list", "~/Pages/TitelPages/TekniskInfoPage/Listing.aspx");
            routes.MapPageRoute("TitelFormatCreate", "tekniskinfo/ny", "~/Pages/TitelPages/TekniskInfoPage/Create.aspx");
            routes.MapPageRoute("TitelFormatEdit", "tekniskinfo/{id}/edit", "~/Pages/TitelPages/TekniskInfoPage/Edit.aspx");
            routes.MapPageRoute("TitelFormatDelete", "tekniskinfo/{id}/tabort", "~/Pages/TitelPages/TekniskInfoPage/Delete.aspx");

            routes.MapPageRoute("Format", "format/list", "~/Pages/TitelPages/Formatslisting.aspx");
            
        }
    }
}
