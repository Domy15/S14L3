using Microsoft.AspNetCore.Mvc;
using S14L3.Models;

namespace S14L3.Controllers
{
    public class CinemaController : Controller
    {
        private static List<Cliente> _SalaNORD = new List<Cliente>();
        private static List<Cliente> _SalaSUD = new List<Cliente>();
        private static List<Cliente> _SalaEST = new List<Cliente>();

        public IActionResult Index()
        {
            var model = new ClienteViewModel()
            { 
                SalaNORD = _SalaNORD,
                SalaSUD = _SalaSUD,
                SalaEST = _SalaEST
            };
            model.Sala = "N";
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ClienteViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Cliente newClient = new Cliente()
                {
                    _id = Guid.NewGuid(),
                    _nome = model.Nome,
                    _cognome = model.Cognome,
                    _tipoBiglietto = model.TipoBiglietto,
                };
                switch (model.Sala)
                {
                    case "N":
                        if (_SalaNORD.Count < 120)
                        {
                            Console.WriteLine("Sala Nord");
                            _SalaNORD.Add(newClient);
                        }
                        else
                        {
                            TempData["Error"] = "Sala piena selezionane un'altra";
                        }
                        break;

                    case "S":
                        if (_SalaSUD.Count < 120)
                        {
                            _SalaSUD.Add(newClient);
                        }
                        else
                        {
                            TempData["Error"] = "Sala piena selezionane un'altra";
                        }
                        break;

                    case "E":
                        if (_SalaEST.Count < 120)
                        {
                            _SalaEST.Add(newClient);
                        }
                        else
                        {
                            TempData["Error"] = "Sala piena selezionane un'altra";
                        }
                        break;

                    default:
                        break;
                }
            }

            return RedirectToAction("Index");
        }
    }
}
