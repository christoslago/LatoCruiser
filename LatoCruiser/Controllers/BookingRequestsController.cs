using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LatoCruiser.Data;
using LatoCruiser.Models;

using Syncfusion.EJ2.Grids;


namespace LatoCruiser.Controllers
{
    public class BookingRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookingRequests
        public async Task<IActionResult> Index()
        {

            
            List<object> DataRange = new();
            DataRange.Add(new { Text = "1,000 Rows 11 Columns", Value = "1000" });
            DataRange.Add(new { Text = "10,000 Rows 11 Columns", Value = "10000" });
            DataRange.Add(new { Text = "1,00,000 Rows 11 Columns", Value = "100000" });
            ViewBag.Data = DataRange;

            var Order = await _context.Booking.ToListAsync();
            ViewBag.DataSource = Order;


            return View(await _context.Booking.ToListAsync());
        }

        // GET: BookingRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingRequest = await _context.Booking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookingRequest == null)
            {
                return NotFound();
            }

            return View(bookingRequest);
        }

        // GET: BookingRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookingRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookerName,BookerEmail,BookerPhone,BookStart,BookEnd,BookDescription")] BookingRequest bookingRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(bookingRequest);
        }

        // GET: BookingRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingRequest = await _context.Booking.FindAsync(id);
            if (bookingRequest == null)
            {
                return NotFound();
            }
            return View(bookingRequest);
        }

        // POST: BookingRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookerName,BookerEmail,BookerPhone,BookStart,BookEnd,BookDescription")] BookingRequest bookingRequest)
        {
            if (id != bookingRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingRequestExists(bookingRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookingRequest);
        }

        // GET: BookingRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingRequest = await _context.Booking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookingRequest == null)
            {
                return NotFound();
            }

            return View(bookingRequest);
        }

        // POST: BookingRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingRequest = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(bookingRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingRequestExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
