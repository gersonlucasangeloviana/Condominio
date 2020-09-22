using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoCondominio.Domain.Contracts.Repositories;
using GestaoCondominio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestaoCondominio.UI.Controllers
{
    public class CondominioController : Controller
    {
        private readonly ILogger<CondominioController> _logger;
        private readonly ICondominioRepository _repository;
        public CondominioController(ICondominioRepository repository, ILogger<CondominioController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            Condominio model = null;
            if (id != null)
            {
                var data = _repository.GetById((int)id);
                if (data != null)
                {
                    model = data;
                }
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(Condominio condominio)
        {
            try
            {
                if (condominio.CondominioId == 0)
                {
                    _repository.Add(condominio);
                }
                else
                {
                    _repository.Edit(condominio);
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
                var lista = _repository.Get();
                return View(lista);
            }
            catch (Exception ex)
            {
                LogaErro(ex);
                return View(new List<Condominio>());
            }
        
        }
        private void LogaErro(Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
