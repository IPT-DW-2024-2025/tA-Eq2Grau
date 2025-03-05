using Eq2Grau.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Eq2Grau.Controllers {
   public class HomeController: Controller {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger) {
         _logger = logger;
      }

      /// <summary>
      /// C�lculo das ra�zes de uma equa��o do 2� grau
      /// </summary>
      /// <param name="A">par�metro do x2</param>
      /// <param name="B">par�metro do x</param>
      /// <param name="C">par�metro independente</param>
      /// <returns></returns>
      public IActionResult Index(string A, string B, string C) {
         /* ALGORITMO
          * 1- ler par�metros a, b, c
          * 2- verificar se os par�metros s�o n�meros
          *    se n�o, criar msg aviso
          *    se sim, continuo
          * 3- a =/= 0 ????
          *    se n�o, mostro msg de aviso
          *    se sim, continuo
          * 4- calcular DELTA = b2-4ac
          *    4.1- se DELTA > 0, calcular ra�zes reais
          *         x1 = (-b - sqrt(DELTA))/2/a
          *         x2 = (-b + sqrt(DELTA))/2/a
          *    4.2- se DELTA = 0
          *         x1 = x2 = (-b)/2/a
          *    4.3- se DELTA < 0, calcular ra�zes complexas, conjugadas
          *         x1 = (-b)/2/a '+' sqrt(-DELTA))/2/a 'i'
          *         x2 = (-b)/2/a '-' sqrt(-DELTA))/2/a 'i'
          * 5- mostrar o resultado na VIEW
          */

         // determinar se h� dados para fazer o c�lculo
         if (
            !(string.IsNullOrEmpty(A) &&
              string.IsNullOrEmpty(B) &&
              string.IsNullOrEmpty(C) )
            ) {

            // 2-
            double auxA;
            if (!double.TryParse(A, out auxA)) {
               // Criar msg de aviso
               string msg = "O par�metro A tem de ser um n�mero!";
               ViewBag.mensagem = msg;
               // devolver contolo � view
               return View();
            };
            //double auxB=Convert.ToDouble(B);
            //double auxC=Convert.ToDouble(C);

            double auxB;
            if (!double.TryParse(B, out auxB)) {
               // Criar msg de aviso
               string msg = "O par�metro B tem de ser um n�mero!";
               ViewBag.mensagem = msg;
               // devolver contolo � view
               return View();
            };

            double auxC;
            if (!double.TryParse(C, out auxC)) {
               // Criar msg de aviso
               string msg = "O par�metro C tem de ser um n�mero!";
               ViewBag.mensagem = msg;
               // devolver contolo � view
               return View();
            };

            // 3- tenho n�meros, mas A=/=0?
            if (auxA == 0) {
               // Criar msg de aviso
               string msg = "O par�metro A n�o pode ser 0 (zero)";
               ViewBag.mensagem = msg;
               // devolver contolo � view
               return View();
            };

            // 4-
            // tenho garantias que posso calcular as ra�zes
            string x1 = "";
            string x2 = "";

            double delta = auxB * auxB - 4 * auxA * auxC;
            // 4.1
            if (delta > 0) {
               x1 = (-auxB - Math.Sqrt(delta)) / 2 / auxA + "";
               x2 = (-auxB + Math.Sqrt(delta)) / 2 / auxA + "";
               ViewBag.mensagem = "Existem duas ra�zes reais distintas!";
            }
            // 4.2
            if (delta == 0) {
               x1 = (-auxB) / 2 / auxA + "";
               x2 = x1;
               ViewBag.mensagem = "Existem duas ra�zes reais, mas iguais!";
            }
            // 4.3
            if (delta < 0) {
               x1 = -auxB / 2 / auxA + " - " + Math.Sqrt(-delta) / 2 / auxA + "i";
               x2 = -auxB / 2 / auxA + " + " + Math.Sqrt(-delta) / 2 / auxA + "i";
               ViewBag.mensagem = "Existem duas ra�zes complexas conjugadas!";
            }

            // 5-
            ViewBag.x1 = x1;
            ViewBag.x2 = x2;
         }

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
