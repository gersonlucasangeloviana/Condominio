using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoCondominio.Domain.Contracts.Repositories;
using GestaoCondominio.UI.Models;
using GestaoGestaoCondominio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace GestaoCondominio.UI.Controllers
{
    public class MoradorController : Controller
    {
        private readonly ILogger<MoradorController> _logger;
        private readonly IMoradorRepository _repository;
        private readonly IFamiliaRepository _familiaRepository;
        public MoradorController(IMoradorRepository repository
            , IFamiliaRepository familiaRepository
            , ILogger<MoradorController> logger)
        {
            _repository = repository;
            _logger = logger;
            _familiaRepository = familiaRepository;
        }
        public IActionResult AddEdit(int? id)
        {
            Morador morador = null;
            if(id != null)
            {
                var data = _repository.GetById((int)id);
                if(data != null)
                {
                    morador = data;
                }
            }
            PopularFamilias();
            return View(morador);
        }
        [HttpPost]
        public IActionResult AddEdit(Morador morador)
        {
            try
            {
                if (morador.MoradorId == 0)
                {
                    _repository.Add(morador);
                }
                else
                {
                    _repository.Edit(morador);
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
                return View(new List<Morador>());
            }
          
        }
        public async Task<IActionResult> ListaComFamilia()
        {
            List<MoradorComFamiliaVM> listView = new List<MoradorComFamiliaVM>();
            try
            {
                var lista = await _repository.GetWithFamiliaAsync();
                var listaFiltrada = from morador in lista
                                    select new {morador.Nome
                                    ,  Animais = morador.QuantidadeBichosEstimacao
                                    ,  Familia = morador.Familia.Nome
                                    };
                foreach (var item in listaFiltrada)
                {
                    listView.Add(new MoradorComFamiliaVM()
                    {
                        Nome = item.Nome, Animais = item.Animais, Familia = item.Familia
                    });
                }
                return View(listView);
            }
            catch (Exception ex)
            {
                LogaErro(ex);
            }
          
            return View();
        }

        private void PopularFamilias()
        {
            ViewBag.Familias =
                            _familiaRepository.Get()
                                .Select(c => new SelectListItem(c.Nome, c.FamiliaId.ToString()));
        }
        private void LogaErro(Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
