using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Helper
{
    public class Autorizacija
    {
        public class AutorizacijaAttribute : TypeFilterAttribute
        {
            public AutorizacijaAttribute(TipZaposlenika autorizovanitip)
                : base(typeof(MyAuthorizeImpl))
            {
                Arguments = new object[] { autorizovanitip };
            }
        }


        public class MyAuthorizeImpl : IAsyncActionFilter
        {
            public MyAuthorizeImpl(TipZaposlenika autorizovanitip)
            {
                _autorizovanitip = autorizovanitip;
            }
            private readonly TipZaposlenika _autorizovanitip;

            public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
            {
                Zaposlenik k = filterContext.HttpContext.GetLogiraniKorisnik();

                // Korisnik nije bio logiran
                if (k == null)
                {
                    if (filterContext.Controller is Controller controller)
                    {
                        controller.TempData["error_poruka"] = "Niste logirani";
                    }

                    filterContext.Result = new RedirectResult("/Autentifikacija");
                    return;
                }

                //Preuzimamo DbContext preko app services
                MyContext db = filterContext.HttpContext.RequestServices.GetService(typeof(MyContext)) as MyContext;

                //provjera tipa korisnika
                if (k.Tip == _autorizovanitip)
                {
                    await next(); //ok - ima pravo pristupa
                    return;
                }

                if (filterContext.Controller is Controller c1)
                {
                    c1.TempData["error_poruka"] = "Nemate pravo pristupa";
                }
                filterContext.Result = new RedirectResult("/Autentifikacija");
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                // throw new NotImplementedException();
            }
        }
    }
}
