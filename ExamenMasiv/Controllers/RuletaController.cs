using ExamenMasiv.DTOs;
using ExamenMasiv.Infraestructure;
using ExamenMasiv.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using ExamenMasiv.Models;
using System.Web.Http.Description;
using AutoMapper;

namespace ExamenMasiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuletaController : BaseClass
    {
        private readonly IServicesRuleta _servicesRuleta;
        public RuletaController(IServicesRuleta servicesRuleta)
        {
            _servicesRuleta = servicesRuleta;
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        [ResponseType(typeof(OutJsonModel))]
        public async Task<HttpResponseMessage> Create([FromBody] RuletaDTO ruleta)
        {
            string errorMessages;
            if (!Helpers.Validators.IsValid(ruleta, out errorMessages))
            {
                return BadRequestResponse(OutJsonModel.BuildError(errorMessages));
            }
            var ruletaModel = AutoMapper.AutoMapperConfiguration.Mapper.Map<Ruleta>(ruleta);

            return OkRequestResponse(OutJsonModel.BuildOk(await _servicesRuleta.Create(ruletaModel)));
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<HttpResponseMessage> GetAll()
        {
            var response = await _servicesRuleta.GetRuleta();

            return OkRequestResponse(OutJsonModel.BuildOk(response));
        }

        // GET: RuletaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RuletaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RuletaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RuletaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RuletaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RuletaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RuletaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
