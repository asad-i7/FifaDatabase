using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FifaDatabase.DAL;
using FifaDatabase.Models;
using PagedList;

namespace FifaDatabase.Views
{
    public class PlayerController : Controller
    {
        private PlayerContext db = new PlayerContext();

        // GET: Player
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RatingSortParm = String.IsNullOrEmpty(sortOrder) ? "rating_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc": "Name";
            ViewBag.PositionSortParm = sortOrder == "Position" ? "position_desc": "Position";
            ViewBag.PaceSortParm = sortOrder == "Pace" ? "pace_desc": "Pace";
            ViewBag.ShootingSortParm = sortOrder == "Shooting" ? "shooting_desc" : "Shooting";
            ViewBag.PassingSortParm = sortOrder == "Passing" ? "passing_desc": "Passing";
            ViewBag.DribblingSortParm = sortOrder == "Dribbling" ? "dribbling_desc": "Dribbling";
            ViewBag.DefendingSortParm = sortOrder == "Defending" ? "defending_desc": "Defending";
            ViewBag.PhysicalSortParm = sortOrder == "Physical" ? "physical_desc": "Physical";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var players = from s in db.Players
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "rating_desc":
                    players = players.OrderBy(s => s.Rating);
                    break;
                case "name_desc":
                    players = players.OrderByDescending(s => s.Name);
                    break;
                case "Name":
                    players = players.OrderBy(s => s.Name);
                    break;
                case "position_desc":
                    players = players.OrderByDescending(s => s.Position);
                    break;
                case "Postion":
                    players = players.OrderBy(s => s.Position);
                    break;
                case "pace_desc":
                    players = players.OrderByDescending(s => s.Pace);
                    break;
                case "Pace":
                    players = players.OrderBy(s => s.Pace);
                    break;
                case "shooting_desc":
                    players = players.OrderByDescending(s => s.Shooting);
                    break;
                case "Shooting":
                    players = players.OrderBy(s => s.Shooting);
                    break;
                case "passing_desc":
                    players = players.OrderByDescending(s => s.Passing);
                    break;
                case "Passing":
                    players = players.OrderBy(s => s.Passing);
                    break;
                case "dribbling_desc":
                    players = players.OrderByDescending(s => s.Dribbling);
                    break;
                case "Dribbling":
                    players = players.OrderBy(s => s.Dribbling);
                    break;
                case "defending_desc":
                    players = players.OrderByDescending(s => s.Defending);
                    break;
                case "Defending":
                    players = players.OrderBy(s => s.Defending);
                    break;
                case "physical_desc":
                    players = players.OrderByDescending(s => s.Physical);
                    break;
                case "Physical":
                    players = players.OrderBy(s => s.Physical);
                    break;
                default:
                    players = players.OrderByDescending(s => s.Rating);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(players.ToPagedList(pageNumber, pageSize));
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Rating,Name,Position,Club,League,Nation,Age,Height,Workrates,Pace,Shooting,Dribbling,Passing,Defending,Physical,Traits,Specialities,Description,Image,Card")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Rating,Name,Position,Club,League,Nation,Age,Height,Workrates,Pace,Shooting,Dribbling,Passing,Defending,Physical,Traits,Specialities,Description,Image,Card")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
