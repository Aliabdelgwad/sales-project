

using Sales.Interface;
using Sales.Models;
using Sales.ReposInterface;
using Sales.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace Sales
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();

            container.RegisterType<IReposCustomer, CustomerRepos>();
            container.RegisterType<IReposCategory, CategoryRepos>();
            container.RegisterType<IReposProduct, ProductRepos>();

            container.RegisterType<IReposInvoice, InvoiceRepos>();
            container.RegisterType<IReposUser, UserRepos>();




            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        protected void Application_BeginRequest()
        {
            // ﬁ—«¡… «·Àﬁ«›… „‰ «·ﬂÊﬂÌ“ √Ê «” Œœ«„ «··€… «·«› —«÷Ì…
            var culture = Request.Cookies["culture"]?.Value ?? "en-US";
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
        }
    }
}
