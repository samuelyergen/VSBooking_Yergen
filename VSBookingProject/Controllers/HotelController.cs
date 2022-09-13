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
    public class HotelController : Controller
    {
        IHotelManager HotelManager { get; }
        IRoomManager RoomManager { get; }
        IPictureManager PictureManager { get; }
        

        public HotelController(IHotelManager hotelManager, IRoomManager roomManager, IPictureManager pictureManager)
        {
            HotelManager = hotelManager;
            RoomManager = roomManager;
            PictureManager = pictureManager;

        }


        // GET: HotelController
        /// <summary>
        /// Display the hotels according to the filters
        /// Used for the advanced search
        /// Put the filters informations in TempData
        /// </summary>
        /// <param name="location"></param>
        /// <param name="category"></param>
        /// <param name="hasParking"></param>
        /// <param name="hasWifi"></param>
        /// <returns></returns>
        public ActionResult Index(string location, string category, string hasParking, string hasWifi)
        {
            TempData["location"] = location;
            TempData["category"] = category;
            TempData["hasParking"] = hasParking;
            TempData["hasWifi"] = hasWifi;


            if (location == null && category == null && hasParking == null && hasWifi == null)
            {
                var hote = HotelManager.GetHotels();
                return View(hote);
            }

            var hs = HotelManager.GetHotelsAdvancedSearch(location, category, hasParking, hasWifi);

           
            return View(hs);
        }

        /// <summary>
        /// Used with the button "back to hotel list"
        /// take informations in TempData to filter hotels
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index()
        {
            string location = null;
            string  category = null;
            string hasParking = null;
            string hasWifi = null;

            if (TempData.ContainsKey("location"))
                location = (string)TempData.Peek("location");

            if (TempData.ContainsKey("category"))
                category = (string)TempData.Peek("category");

            if (TempData.ContainsKey("hasParking"))
                hasParking = (string)TempData.Peek("hasParking");

            if (TempData.ContainsKey("hasWifi"))
                hasWifi = (string)TempData.Peek("hasWifi");



            if (location == null && category == null && hasParking == null && hasWifi == null)
            {
                var hote = HotelManager.GetHotels();
                return View(hote);
            }

            var hs = HotelManager.GetHotelsAdvancedSearch(location, category, hasParking, hasWifi);

          
            return View(hs);
        }

        // GET: HotelController/Details/5
        /// <summary>
        /// Used for the advanced search of rooms
        /// put informations of the filters in TempData
        /// use a viewModel to display hotel details and rooms
        /// </summary>
        /// <param name="id"></param>
        /// <param name="searchDateStart"></param>
        /// <param name="searchDateEnd"></param>
        /// <param name="price"></param>
        /// <param name="hasHairDryer"></param>
        /// <param name="hasTv"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult Details(int id, string searchDateStart, string searchDateEnd, string price, string hasHairDryer, string hasTv, string type)
        {
            

            TempData["price"] = price;
            TempData["hhd"] = hasHairDryer;
            TempData["htv"] = hasTv;
            TempData["tpe"] = type;

            if(searchDateStart!=null)
                TempData["dateS"] = searchDateStart;

            if(searchDateEnd!=null)
                TempData["dateE"] = searchDateEnd;
            

            if (id == 0)
                id = (int)TempData.Peek("idh");
            else
                TempData["idh"] = id;

         

            if (searchDateStart == null && searchDateEnd == null && price == null && hasHairDryer == null && hasTv == null && type == null)
            {

                
                var h = HotelManager.GetHotelById(id);
                var rooms = RoomManager.GetRooms(h);

                var hotel = new HotelViewModel
                {
                    Hotel = h,
                    Rooms = rooms
                };

                return View(hotel);
            }



            var ho = HotelManager.GetHotelById(id);
            var ro = RoomManager.GetRoomsAdvancedSearch(id, searchDateStart, searchDateEnd, price, hasHairDryer, hasTv, type);

            if(searchDateStart != null && searchDateEnd != null)
            {
                if (RoomManager.CountRoomWithDate(id, searchDateStart, searchDateEnd) * 100 / RoomManager.CountRoom(id) > 70)
                {
                    foreach (var rrr in ro)
                    {
                        rrr.Price += (rrr.Price * 0.2);
                    }
                }
            }
           

            var hot = new HotelViewModel
            {
                Hotel = ho,
                Rooms = ro

            };
           

            return View(hot);
        }

        /// <summary>
        /// Used for advanced search
        /// take the informations in TempData to filter the room
        /// used with the "back to room list" button
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Details(int id)
        {

 
            string ds = null;
            string de = null;
            string price = null;
            string hhd = null;
            string htv = null;
            string type = null;
            int idh = 0;

            if (TempData.ContainsKey("price"))
                price = (string)TempData.Peek("price");

            if (TempData.ContainsKey("dateS"))
                ds = (string)TempData.Peek("dateS");

            if (TempData.ContainsKey("dateE"))
                de = (string)TempData.Peek("dateE");

            if (TempData.ContainsKey("hhd"))
                hhd = (string)TempData.Peek("hhd");

            if (TempData.ContainsKey("htv"))
                htv = (string)TempData.Peek("htv");

            if (TempData.ContainsKey("tpe"))
                type = (string)TempData.Peek("tpe");

            if (TempData.ContainsKey("idh"))
                idh = (int)TempData.Peek("idh");


            var ho = HotelManager.GetHotelById(idh);
            var ro = RoomManager.GetRoomsAdvancedSearch(idh, ds, de, price, hhd, htv, type);

            if (ds != null && de != null)
            {
                if (RoomManager.CountRoomWithDate(idh, ds, de) * 100 / RoomManager.CountRoom(idh) > 70)
                {
                    foreach (var rrr in ro)
                    {
                        rrr.Price += (rrr.Price * 0.2);
                    }
                }
            }


            var hot = new HotelViewModel
            {
                

                Hotel = ho,
                Rooms = ro

            };

           
            return View(hot);
        }

        // GET: HotelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelController/Create
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

        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            var hotel = HotelManager.GetHotelById(id);
            return View(hotel);
        }

        // POST: HotelController/Edit/5
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

        // GET: HotelController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: HotelController/Delete/5
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
