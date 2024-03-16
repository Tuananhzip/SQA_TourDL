using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using DAPM_TOURDL.Models;

namespace DAPM_TOURDL.Controllers
{
    public class TOURsController : Controller
    {
        private QLTOUR db = new QLTOUR();

        public ActionResult ExportToExcel()
        {
            var tours = db.TOURs;
            //var khS = db.HOADONs.Include(h => h.KHACHHANG).Include(h => h.SPTOUR);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("DanhSachTour");
                var currentrow = 1;
                worksheet.Cell(currentrow, 1).Value = "ID khách hàng";
                worksheet.Cell(currentrow, 2).Value = "Tên tour";
                worksheet.Cell(currentrow, 3).Value = "Giá tour";
                worksheet.Cell(currentrow, 4).Value = "Loại tour";
                worksheet.Cell(currentrow, 5).Value = "Mô tả";
                foreach (var tour in tours)
                {
                    currentrow++;
                    worksheet.Cell(currentrow, 1).Value = tour.ID_TOUR;
                    worksheet.Cell(currentrow, 2).Value = tour.TenTour;
                    worksheet.Cell(currentrow, 3).Value = tour.GiaTour;
                    worksheet.Cell(currentrow, 4).Value = tour.LoaiTour;
                    worksheet.Cell(currentrow, 5).Value = tour.MoTa;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "DanhSachTour.xlsx"
                        );
                }
            }
        }
        // GET: TOURs
        public ActionResult Index(string SearchString)
        {
            var tour = db.TOURs.ToList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                tour = tour.Where(s => s.ID_TOUR.Contains(SearchString) || s.TenTour.Contains(SearchString)).ToList();
            }
            return View(tour);
        }

        // GET: TOURs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // GET: TOURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TOURs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TOUR,TenTour,GiaTour,MoTa,HinhTour,TinhThanh,LoaiTour")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.TOURs.Add(tOUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tOUR);
        }

        // GET: TOURs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // POST: TOURs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TOUR,TenTour,GiaTour,MoTa,HinhTour,TinhThanh,LoaiTour")] TOUR tOUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tOUR);
        }

        // GET: TOURs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOUR tOUR = db.TOURs.Find(id);
            if (tOUR == null)
            {
                return HttpNotFound();
            }
            return View(tOUR);
        }

        // POST: TOURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TOUR tOUR = db.TOURs.Find(id);
            db.TOURs.Remove(tOUR);
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