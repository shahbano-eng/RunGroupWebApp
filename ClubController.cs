using Microsoft.AspNetCore.Mvc;
using RunGroupWebApp.Models;
using RunGroupWebApp.Data;
using System.Data.Entity;

namespace RunGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _Context;

        public ClubController(ApplicationDbContext context)
        {
            _Context = context;
        }
        public IActionResult Index()  ///CCC
        {
            List<Club> clubs = _Context.Clubs.ToList(); ///MMM //brings whole table and applying querry to it by excecuting the sql
            return View(clubs); ///VVV
        }

        public IActionResult Detail(int id)
        {
    
            var clubList = _Context.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == id);

            if (clubList == null)
            {
                return NotFound(); 
            }

            return View(clubList); 
        }
    }
}