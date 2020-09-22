using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoCondominio.Domain.Contracts.Repositories;
using GestaoGestaoCondominio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace GestaoCondominio.UI.Controllers
{
    public class FamiliaController : Controller
    {
        private readonly ILogger<FamiliaController> _logger;
        private readonly IFamiliaRepository _repository;
        private readonly ICondominioRepository _condominioRepository;

        public FamiliaController(IFamiliaRepository repository
            , ICondominioRepository condominioRepository
            , ILogger<FamiliaController> logger)
        {
            _repository = repository;
            _logger = logger;
            _condominioRepository = condominioRepository;
        }
        public IActionResult AddEdit(int? id)
        {
            Familia model = null;
            if (id != null)
            {
                var data = _repository.GetById((int)id);
                if (data != null)
                {
                    model = data;
                }
            }
            PopularCondominios();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(Familia familia)
        {
            try
            {
                if (familia.FamiliaId == 0)
                {
                    _repository.Add(familia);
                }
                else
                {
                    _repository.Edit(familia);
                }
            }
            catch (Exception ex)
            {
                LogaErro(ex);
            }

            return RedirectToAction("Lista");
        }
        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            try
            {
                var entity = _repository.GetById(id);

                if (entity == null)
                    throw new KeyNotFoundException();
                _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                LogaErro(ex);
            }
            return RedirectToAction("Lista");
        }

        public IActionResult Lista()
        {
            try
            {
                PopularCondominios();
                var lista = _repository.Get();
                return View(lista);
            }
            catch (Exception ex)
            {
                LogaErro(ex);
                return View(new List<Familia>());
            }
          
        }

        private void PopularCondominios()
        {
            ViewBag.Condominios =
                            _condominioRepository.Get()
                                .Select(c => new SelectListItem(c.Nome, c.CondominioId.ToString()));
        }
        private void LogaErro(Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
