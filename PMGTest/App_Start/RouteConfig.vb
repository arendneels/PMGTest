Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            "HomePage",
            "{lang}/tegels/{page}",
            New With {.controller = "Home", .action = "Index"}
        )

        routes.MapRoute(
            "EditPage",
            "{lang}/tegels/edit/{id}",
            New With {.controller = "Home", .action = "Edit"}
        )

        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )

    End Sub
End Module