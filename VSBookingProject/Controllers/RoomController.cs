using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using VSBookingProject.Models;

namespace VSBookingProject.Controllers
{
    public class RoomController : Controller
    {

        IRoomManager RoomManager { get; }
        IPictureManager PictureManager { get; }
        
       

        public RoomController(IRoomManager roomManager, IPictureManager pictureManager)
        {
          
            RoomManager = roomManager;
            PictureManager = pictureManager;

        }
        // GET: RoomController
        public ActionResult Index(int id)
        {
            

            return View();
        }

        // GET: RoomController/Details/5
        /// <summary>
        /// Display details of the room
        /// use of viewModel to display room infos and pictures
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {

            var room = RoomManager.GetRoomById(id);

            var r = new RoomViewModel
            {
                Room = RoomManager.GetRoomById(id),
                Pictures = PictureManager.GetPictures(room)
            };

            TempData["IdR"] = id;

            return View(r);
            
        }

        /// <summary>
        /// used with the "add to shopping cart" button
        /// retrieve the id of the room from TempData
        /// add the room to the array of id room displayed in shopping cart
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Details()
        {
            int id = new int();

            if (TempData.ContainsKey("IdR"))
                id = (int)TempData.Peek("IdR");

            var room = RoomManager.GetRoomById(id);
           

            var r = new RoomViewModel
            {
                Room = RoomManager.GetRoomById(id),
                Pictures = PictureManager.GetPictures(room)
            };

            

            List<int> idRs = new List<int>();
            List<DTO.Room> rms = new List<DTO.Room>();


            if (TempData.ContainsKey("IdRs"))
            {
                int[] idr = (int[])TempData.Peek("IdRs");

                if (idr != null)
                {
                    foreach (var v in idr)
                    {
                        idRs.Add(v);
                    }
                }
                
            }


            idRs.Add(id);

            foreach (var i in idRs)
            {
                rms.Add(RoomManager.GetRoomById(i));
            }
            TempData["IdRs"] = idRs;

            return View(r);
           
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
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

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomController/Edit/5
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

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
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
