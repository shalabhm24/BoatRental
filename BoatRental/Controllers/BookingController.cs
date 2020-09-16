using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoatRental.Models;

namespace BoatRental.Controllers
{
    public class BookingController : Controller
    {
        private readonly BoatRentalContext _context;
        public BookingController(BoatRentalContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoatId,CustomerName")] TblBooking tblBooking)
        {
            if (ModelState.IsValid)
            {
                var isRegistered = _context.TblRegister.ToList().Exists(x => x.Id == tblBooking.BoatId);
                if(isRegistered)
                {
                    var isExist = _context.TblBooking.ToList().Exists(x => x.BoatId == tblBooking.BoatId);
                    if (isExist)
                    {
                        ViewBag.Message = "Already Exist";
                        return View();
                    }
                    _context.Add(tblBooking);
                    await _context.SaveChangesAsync();
                    ViewBag.Message = "Booking Confirmed!!!";

                }
                else
                {
                    ViewBag.Message = "Boat Number is Invalid";
                }
        
            }
            return View();
        }
    }
}
