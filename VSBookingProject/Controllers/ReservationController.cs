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
    public class ReservationController : Controller
    {

        IReservationManager ReservationManager { get; }
        IBookingManager BookingManager { get; }
        IRoomManager RoomManager { get; }
        
        
        
        

        public ReservationController(IReservationManager reservationManager, IBookingManager bookingManager, IRoomManager roomManager)
        {
  
            ReservationManager = reservationManager;
            BookingManager = bookingManager;
            RoomManager = roomManager;
        }
        // GET: ReservationController
        /// <summary>
        /// Used in "my reservations"
        /// display all the reservations
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            
            var reservations = ReservationManager.GetReservations();

           
            return View(reservations);
        }

        // GET: ReservationController/Details/5
        /// <summary>
        /// Display a list of room
        /// used in "shopping cart"
        /// used a int[] to store id of rooms in TempData
        /// </summary>
        /// <returns></returns>
        public ActionResult Details()
        {
            List<int> idRs = new List<int>();
            List<DTO.Room> rms = new List<DTO.Room>();

            string ds = null;
            string de = null;
            int idh = 0;

            if (TempData.ContainsKey("idh"))
                idh = (int)TempData.Peek("idh");

            if (TempData.ContainsKey("dateS"))
                ds = (string)TempData.Peek("dateS");

            if (TempData.ContainsKey("dateE"))
                de = (string)TempData.Peek("dateE");


            if (TempData.ContainsKey("IdRs"))
            {
                int[] idr = (int[])TempData.Peek("IdRs");

                if(idr != null)
                {
                    foreach (var v in idr)
                    {
                        idRs.Add(v);
                    }
                }
                
            }
               
 

            foreach(var i in idRs)
            {
                rms.Add(RoomManager.GetRoomById(i));
            }

            if (ds != null && de != null)
            {
                if (RoomManager.CountRoomWithDate(idh, ds, de) * 100 / RoomManager.CountRoom(idh) > 70)
                {
                    foreach (var rrr in rms)
                    {
                        rrr.Price += (rrr.Price * 0.2);
                    }
                }
            }



            return View(rms);
        }
        /// <summary>
        /// used to clean the shopping cart
        /// remove information from TempData
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Details(int id)
        {
            int[] idr =(int[])TempData["IdRs"];
            List<DTO.Room> rms = new List<DTO.Room>();



            return View(rms);
        }

        // GET: ReservationController/Create
        public ActionResult Create(int id)
        {
            

            TempData["idRoom"] = id;
            return View();
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        // POST: ReservationController/Create
        /// <summary>
        /// get the firstname and lastname of the user to create a reservation
        /// add also the bookings
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Reservation r)
        {
            int[] IdRms = null;
            string ds = null;
            string de = null;
            DateTime dateSt = new DateTime();
            DateTime dateEd = new DateTime();
           
            if (TempData.ContainsKey("dateS"))
                ds = (string)TempData.Peek("dateS");

            if (TempData.ContainsKey("dateE"))
                de = (string)TempData.Peek("dateE");

            if (TempData.ContainsKey("IdRs"))
                IdRms = (int[])TempData["IdRs"];

            
            TempData.Remove("IdRs");

            if(ds!=null)
                dateSt = DateTime.ParseExact(ds, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);

            if(de!=null)
                dateEd = DateTime.ParseExact(de, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (ModelState.IsValid)
            {
                int d = ReservationManager.AddReservation(r);

                foreach(var i in IdRms)
                {
                    BookingManager.AddBooking(d, i, dateSt, dateEd);
                }
                    
                TempData["res"] = d;
                return RedirectToAction(nameof(Confirmation));
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        // GET: ReservationController/Delete/5
        /// <summary>
        /// get and display the reservation to delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var res = ReservationManager.GetReservation(id);
            return View(res);
        }

        // POST: ReservationController/Delete/5
        /// <summary>
        /// Delete the reservation and the bookings related to
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var res = ReservationManager.GetReservation(id);
            BookingManager.DeleteBooking(res);
            ReservationManager.DeleteReservation(res);

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
