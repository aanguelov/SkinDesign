using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinDesign.Entities;
using SkinDesign.Interfaces;
using SkinDesign.ViewModels;
using System.Linq;

namespace SkinDesign.Controllers
{
    public class ProceduresController : Controller
    {
        private IProceduresData _data;

        public ProceduresController(IProceduresData data)
        {
            _data = data;
        }

        public IActionResult All()
        {
            var model = _data.GetAll().ToList();

            return View(model);
        }

        public IActionResult Procedure(int id)
        {
            var model = _data.GetById(id);

            if(model == null)
            {
                return RedirectToAction(nameof(ProcedureNotFound));
            }

            return View(model);
        }

        public IActionResult ProcedureNotFound()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddProcedure()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddProcedure(ProcedureViewModel model)
        {
            if(ModelState.IsValid)
            {
                var newProcedure = new Procedure();
                newProcedure.Name = model.Name;
                newProcedure.Description = model.Description;

                _data.Add(newProcedure);

                return RedirectToAction(nameof(All));
            }

            return View(model);
            
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            _data.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var procedure = _data.GetById(id);
            if(procedure == null)
            {
                return RedirectToAction(nameof(ProcedureNotFound));
            }

            return View(procedure);
        }

        [HttpPost]
        public IActionResult Edit(ProcedureViewModel model, int id)
        {
            if(ModelState.IsValid)
            {
                var procedure = _data.GetById(id);
                if(procedure == null)
                {
                    return RedirectToAction(nameof(ProcedureNotFound));
                }

                procedure.Name = model.Name;
                procedure.Description = model.Description;
                _data.Save();

                return View(nameof(Procedure), procedure);
            }

            return View(model);
            
        }
    }
}
