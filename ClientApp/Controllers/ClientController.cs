using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using CommonSolution.ENUMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    public class ClientController : Controller
    {
        // GET: ClientController
        public ActionResult NewFinalClient()
        {
            IEnumerable<ClientTypeEnum> colClientTypeEnum = Enum.GetValues(typeof(ClientTypeEnum)).Cast<ClientTypeEnum>();
            List<SelectListItem> ClientTypeList = new List<SelectListItem>();
            foreach (ClientTypeEnum item in colClientTypeEnum)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.ToString();
                option.Text = item.ToString();
                ClientTypeList.Add(option);
            }

            ViewBag.colClientTypeSelect = ClientTypeList;

            return View();
        }

        public ActionResult AddFinalClient(FinalClientDto dto)
        {
            IController lgc = new LFinalClientController();

            List<string> colErrors = lgc.Add(dto);

            //if (colErrors.Count == 0)
            //{
            //    Session[CGlobals.USER_MESSAGE] = "Usuario registrado con éxito";
            //    ModelState.Clear();
            //}

            return RedirectToAction("NewFinalClient");
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
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

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
