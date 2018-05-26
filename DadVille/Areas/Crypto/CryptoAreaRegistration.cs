using System.Web.Mvc;

namespace DadVille.Areas.Crypto
{
    public class CryptoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Crypto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Crypto_default",
                "Crypto/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}