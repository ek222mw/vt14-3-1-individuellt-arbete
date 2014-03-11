using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace IndividuelltArbete_Emil_K
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Titel", "titel/list", "~/Pages/TitelPages/Listing.aspx");
            routes.MapPageRoute("TitelCreate", "titlar/ny", "~/Pages/TitelPages/Create.aspx");
            routes.MapPageRoute("TitelEdit", "titlar/{id}/edit", "~/Pages/TitelPages/Edit.aspx");
            routes.MapPageRoute("TitelDelete", "titlar/{id}/tabort", "~/Pages/TitelPages/Delete.aspx");

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

            routes.MapPageRoute("Default", "", "~/Pages/TitelPages/Listing.aspx");

            routes.MapPageRoute("TekniskInfo", "tekniskinfo/list", "~/Pages/TitelPages/TekniskInfoPage/Listing.aspx");
            routes.MapPageRoute("TekniskInfoCreate", "tekniskinfo/ny", "~/Pages/TitelPages/TekniskInfoPage/Create.aspx");
            routes.MapPageRoute("TekniskInfoEdit", "tekniskinfo/{id}/edit", "~/Pages/TitelPages/TekniskInfoPage/Edit.aspx");
            routes.MapPageRoute("TekniskInfoDelete", "tekniskinfo/{id}/tabort", "~/Pages/TitelPages/TekniskInfoPage/Delete.aspx");

            routes.MapPageRoute("Format", "format/list", "~/Pages/TitelPages/FormatPage/Listing.aspx");
            routes.MapPageRoute("FormatCreate", "format/ny", "~/Pages/TitelPages/FormatPage/Create.aspx");
            routes.MapPageRoute("FormatEdit", "format/{id}/edit", "~/Pages/TitelPages/FormatPage/Edit.aspx");
            routes.MapPageRoute("FormatDelete", "format/{id}/tabort", "~/Pages/TitelPages/FormatPage/Delete.aspx");
        }
    }
}
