using System.Web.Mvc;

namespace DadVille.Areas.Cover
{
    public class CoverAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cover";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Cover_default",
                "Cover/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}