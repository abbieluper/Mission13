using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingRepository _repo { get; set; }

        // constructor
        public HomeController(IBowlingRepository temp)
        {
            _repo = temp; 
        }

        // DISPLAY BOWLER 
        public IActionResult Index()
        {
            ViewBag.Teams = _repo.Teams.ToList();

            ViewBag.headerTest = ""; 

            var blah = _repo.Bowlers
                .ToList();

            return View(blah);
        }

        // FILTER BOWLERS BY TEAM NAME
        [HttpGet]
        public IActionResult Filter(int teamid)
        {
            ViewBag.Teams = _repo.Teams.ToList();

            //var blah = _repo.Bowlers.Select(x => x.TeamID == teamid).ToList();
            var blah = _repo.Bowlers
                                .Where(x => x.TeamID == teamid)
                                .ToList();

            ViewBag.headerTest = _repo.Teams
                                .Where(x => x.TeamID == teamid)
                                .ToList(); 

            return View("Index", blah); 
        }

        // ADD BOWLER
        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();

            return View(); 
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateBowler(b);

                return View("Confirmation", b); 
            }

            else
            {
                ViewBag.Teams = _repo.Teams.ToList();

                return View(); 
            }
        }

        // EDIT BOWLER
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _repo.Teams.ToList();

            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("AddBowler", bowler); 
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.UpdateBowler(b);

            return RedirectToAction("Index"); 
        }


        // DELETE BOWLER
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowl = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View(bowl); 
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            Bowler bowlerChange = _repo.Bowlers.Single(x => x.BowlerID == bowler.BowlerID);

            _repo.DeleteBowler(bowlerChange);

            return RedirectToAction("Index");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
