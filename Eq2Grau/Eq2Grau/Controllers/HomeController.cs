using Eq2Grau.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Eq2Grau.Controllers {
   public class HomeController: Controller {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger) {
         _logger = logger;
      }

      public IActionResult Index() {
         /* ALGORITMO
          * 1- ler parâmetros a, b, c
          * 2- verificar se os parâmetros são números
          *    se não, criar msg aviso
          *    se sim, continuo
          * 3- a =/= 0 ????
          *    se não, mostro msg de aviso
          *    se sim, continuo
          * 4- calcular DELTA = b2-4ac
          *    4.1- se DELTA > 0, calcular raízes reais
          *         x1 = (-b - sqrt(DELTA))/2/a
          *         x2 = (-b + sqrt(DELTA))/2/a
          *    4.2- se DELTA = 0
          *         x1 = x2 = (-b)/2/a
          *    4.3- se DELTA < 0, calcular raízes complexas, conjugadas
          *         x1 = (-b)/2/a '+' sqrt(-DELTA))/2/a 'i'
          *         x2 = (-b)/2/a '-' sqrt(-DELTA))/2/a 'i'
          * 5- mostrar o resultado na VIEW
          */


         return View();
      }

      public IActionResult Privacy() {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error() {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
