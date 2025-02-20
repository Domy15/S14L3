using Microsoft.AspNetCore.Mvc;
using S14L3.Models;

namespace S14L3.Controllers
{
    public class CinemaController : Controller
    {
        private static List<Cliente> _SalaNORD = new List<Cliente>();
        private static List<Cliente> _SalaSUD = new List<Cliente>();
        private static List<Cliente> _SalaEST = new List<Cliente>();
        private static List<Cliente> _SalaGenerale = new List<Cliente>();

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

        [HttpGet("cinema/sala{id}")]
        public IActionResult ClientList(string id)
        {
            
            if (id == "NORD")
            {
                _SalaGenerale = _SalaNORD;
            }
            else if (id == "SUD")
            {
                _SalaGenerale = _SalaSUD;
            }
            else
            {
                _SalaGenerale = _SalaEST;
            }

            var model = new SalaViewModel()
            {
                SalaGenerale = _SalaGenerale,
            };

            return View(model);
        }

        [HttpGet("cinema/edit/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var existingClient = _SalaGenerale.FirstOrDefault(x => x._id == id);

            if (existingClient == null)
            {
                TempData["Error"] = "Client not found";
                return RedirectToAction("Index");
            }

            var newClient = new EditCliente()
            {
                _id = existingClient._id,
                _nome = existingClient._nome,
                _cognome = existingClient._cognome,
                _tipoBiglietto = existingClient._tipoBiglietto,
            };

            return View(newClient);
        }

        [HttpPost("cinema/edit/{id:guid}")]
        public IActionResult SaveEdit(Guid id, EditCliente editCliente)
        {
            var existingClient = _SalaGenerale.FirstOrDefault(x => x._id == id);

            if (existingClient == null)
            {
                TempData["Error"] = "Client not found";
                return RedirectToAction("Index");
            }

            existingClient._id = editCliente._id;
            existingClient._nome = editCliente._nome;
            existingClient._cognome = editCliente._cognome;
            existingClient._tipoBiglietto = editCliente._tipoBiglietto;

            return RedirectToAction("Index");
        }

        [HttpGet("cinema/delete/{id:guid}")]
        public IActionResult Delete(Guid id) 
        {
            var existingClient = _SalaGenerale.FirstOrDefault(x => x._id == id);

            if (existingClient == null)
            {
                return RedirectToAction("Index");
            }

            var isRemoveSuccessful =  _SalaGenerale.Remove(existingClient);

            if (!isRemoveSuccessful)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
