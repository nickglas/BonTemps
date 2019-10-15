using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Areas.Systeem.Models;
using BonTemps.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BonTemps.Areas.Chef.Controllers
{
    [Area("Chef")]
    public class AllergenenController : Controller
    {
        private static string ImgName;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public AllergenenController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
            var path = Path.Combine(env.WebRootPath + "/img/Uploads/" + "test");
            Console.WriteLine("ORIGINEEL PATH = " + env.WebRootPath);
            Console.WriteLine("NEW PATH = " + path);
        }

        // GET: Chef/Allergenen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Allergenen.ToListAsync());
        }

        // GET: Chef/Allergenen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergenen = await _context.Allergenen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergenen == null)
            {
                return NotFound();
            }

            return View(allergenen);
        }

          // GET: Chef/Allergenen/Create
        public IActionResult Create()
        {
            return View();

        }

        // POST: Chef/Allergenen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Beschrijving,AllergenenIcoon")] Allergenen allergenen/*, IFormFile file*/)
        {
            //ImgUpload(file, _env);
            //allergenen.AllergenenIcoon = file.FileName;
            //Console.WriteLine("file is: " + file);
            //Console.WriteLine("file.FileName is: " + file.FileName);
            if (ModelState.IsValid)
            {
                _context.Add(allergenen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allergenen);
        }

        //private void ImgUpload(IFormFile file, IHostingEnvironment env)
        //{
        //    var fileName = file.FileName;
        //    var path = Path.Combine(env.WebRootPath + "/img/Uploads/" + fileName);
        //    using (var fileStream = new FileStream(path, FileMode.Create))
        //    {
        //        file.CopyTo(fileStream);
        //    }
        //}

        //private void UploadFile(IFormFile file, IHostingEnvironment env)
        //{

        //    Random random = new Random();
        //    string RandomString(int length)
        //    {
        //        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
        //        return new string(Enumerable.Repeat(chars, length)
        //          .Select(s => s[random.Next(s.Length)]).ToArray());
        //    }
        //    var fileName = RandomString(15) + ".png";
        //    ImgName = fileName;
        //    var path = Path.Combine(env.WebRootPath + "/img/Uploads/" + fileName);
        //    using (var fileStream = new FileStream(path, FileMode.Create))
        //    {
        //        file.CopyTo(fileStream);
        //    }
        //}

        // GET: Chef/Allergenen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergenen = await _context.Allergenen.FindAsync(id);
            if (allergenen == null)
            {
                return NotFound();
            }
            return View(allergenen);
        }

        // POST: Chef/Allergenen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Beschrijving,AllergenenIcoon")] Allergenen allergenen)
        {
            if (id != allergenen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergenen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergenenExists(allergenen.Id))
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
            return View(allergenen);
        }

        // GET: Chef/Allergenen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergenen = await _context.Allergenen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allergenen == null)
            {
                return NotFound();
            }

            return View(allergenen);
        }

        // POST: Chef/Allergenen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allergenen = await _context.Allergenen.FindAsync(id);
            _context.Allergenen.Remove(allergenen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergenenExists(int id)
        {
            return _context.Allergenen.Any(e => e.Id == id);
        }
    }
}
