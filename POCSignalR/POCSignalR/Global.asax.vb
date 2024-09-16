Imports System.Web.Optimization
Imports Microsoft.Owin
Imports Owin

<Assembly: OwinStartup(GetType(Setup.Startup))>

Namespace Setup
    Public Class Startup
        Public Sub Configuration(app As IAppBuilder)
            app.MapSignalR()
        End Sub
    End Class

    Public Class Global_asax
        Inherits HttpApplication

        Sub Application_Start(sender As Object, e As EventArgs)
            ' Fires when the application is started
            RouteConfig.RegisterRoutes(RouteTable.Routes)
            BundleConfig.RegisterBundles(BundleTable.Bundles)
        End Sub
    End Class
End Namespace
