﻿<%@ Application Language="C#" %>
<%@ Import Namespace="System.ComponentModel.DataAnnotations" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="LCCHPEntityModel" %>


<script RunAt="server">
    private static MetaModel s_defaultModel = new MetaModel();
    public static MetaModel DefaultModel {
        get {
            return s_defaultModel;
        }
    }

    public static void RegisterRoutes(RouteCollection routes) {
        //                    IMPORTANT: DATA MODEL REGISTRATION 
        // Uncomment this line to register an ADO.NET Entity Framework model for ASP.NET Dynamic Data.
        // Set ScaffoldAllTables = true only if you are sure that you want all tables in the
        // data model to support a scaffold (i.e. templates) view. To control scaffolding for
        // individual tables, create a partial class for the table and apply the
        // [ScaffoldTable(true)] attribute to the partial class.
        // Note: Make sure that you change "YourDataContextType" to the name of the data context
        // class in your application.
        // See http://go.microsoft.com/fwlink/?LinkId=257395 for more information on how to add and configure an Entity Data model to this project



        DefaultModel.RegisterContext(typeof(LCCHPEntityModelContainer), new ContextConfiguration() { ScaffoldAllTables = true });

        // The following statement supports separate-page mode, where the List, Detail, Insert, and 
        // Update tasks are performed by using separate pages. To enable this mode, uncomment the following 
        // route definition, and comment out the route definitions in the combined-page mode section that follows.
        routes.Add(new DynamicDataRoute("{table}/{action}.aspx") {
            Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert" }),
            Model = DefaultModel
        });

        // The following statements support combined-page mode, where the List, Detail, Insert, and
        // Update tasks are performed by using the same page. To enable this mode, uncomment the
        // following routes and comment out the route definition in the separate-page mode section above.
        //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
        //    Action = PageAction.List,
        //    ViewName = "ListDetails",
        //    Model = DefaultModel
        //});

        //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
        //    Action = PageAction.Details,
        //    ViewName = "ListDetails",
        //    Model = DefaultModel
        //});
    }

    private static void RegisterScripts() {
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/Scripts/jquery-1.11.2.min.js",
            DebugPath = "~/Scripts/jquery-1.11.2.js",
            CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.11.2.min.js",
            CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.11.2.js",
            CdnSupportsSecureConnection = true,
            LoadSuccessExpression = "window.jQuery"
        });
    }
    
    void Application_Start(object sender, EventArgs e) {
        RegisterRoutes(RouteTable.Routes);
        RegisterScripts();
    }

</script>