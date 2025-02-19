using Microsoft.AspNetCore.Mvc;
using S14L3.Models;

namespace S14L3.Controllers
{
    public class CinemaController : Controller
    {
        private static List<Cliente> _SalaNORD = new List<Cliente>();
        private static List<Cliente> _SalaSUD = new List<Cliente>();
        private static List<Cliente> _SalaEST = new List<Cliente>();
        private bool error = false;

        public IActionResult Index()
        {
            var model = new ClienteViewModel()
            { 
                SalaNORD = _SalaNORD,
                SalaSUD = _SalaSUD,
                SalaEST = _SalaEST,
                Error = error
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
                error = false;
                switch (model.Sala)
                {
                    case "N":
                        if (_SalaNORD.Count < 1)
                        {
                            Console.WriteLine("Sala Nord");
                            _SalaNORD.Add(newClient);
                        }
                        else
                        {
                            error = true;
                        }
                        break;

                    case "S":
                        if (_SalaSUD.Count < 120)
                        {
                            _SalaSUD.Add(newClient);
                        }
                        else
                        {
                            error = true;
                        }
                        break;

                    case "E":
                        if (_SalaEST.Count < 120)
                        {
                            _SalaEST.Add(newClient);
                        }
                        else
                        {
                            error = true;
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
