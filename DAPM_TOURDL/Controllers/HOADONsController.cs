﻿using System;
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
    public class HOADONsController : Controller
    {
        private QLTOUR db = new QLTOUR();

        public ActionResult ExportToExcel()
        {
            var hOADONs = db.HOADONs.Include(h => h.KHACHHANG).Include(h => h.SPTOUR);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("HOADON");
                var currentrow = 1;
                worksheet.Cell(currentrow, 1).Value = "ID Hóa đơn";
                worksheet.Cell(currentrow, 2).Value = "ID Khách hàng";
                worksheet.Cell(currentrow, 3).Value = "Tên khách hàng";
                worksheet.Cell(currentrow, 4).Value = "Tình trạng";
                worksheet.Cell(currentrow, 5).Value = "Ngày đặt";
                foreach (var hoadon in hOADONs)
                {
                    currentrow++;
                    worksheet.Cell(currentrow, 1).Value = hoadon.ID_HoaDon;
                    worksheet.Cell(currentrow, 2).Value = hoadon.ID_KH;
                    worksheet.Cell(currentrow, 3).Value = hoadon.KHACHHANG.HoTen_KH;
                    worksheet.Cell(currentrow, 4).Value = hoadon.TinhTrang;
                    worksheet.Cell(currentrow, 5).Value = hoadon.NgayDat;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "DanhSachHoaDon.xlsx"
                        );
                }
            }
        }

        // GET: HOADONs
        public ActionResult Index(string SearchString)
        {
            var hd = db.HOADONs.ToList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                hd = hd.Where(s => s.KHACHHANG.HoTen_KH.Contains(SearchString) || s.KHACHHANG.Mail_KH.Contains(SearchString)).ToList();
            }
            return View(hd);
        }

        // GET: HOADONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.ID_KH = new SelectList(db.KHACHHANGs, "ID_KH", "HoTen_KH");
            ViewBag.ID_SPTour = new SelectList(db.SPTOURs, "ID_SPTour", "TenSPTour");
            return View();
        }

        // POST: HOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HoaDon,SLTreEm,TongTienTour,NgayDat,TinhTrang,SLNguoiLon,TienKhuyenMai,TienPhaiTra,ID_SPTour,ID_KH")] HOADON hOADON)
        {
            var spTour = db.SPTOURs.Find(hOADON.ID_SPTour);
            if(spTour == null)
            {
                ModelState.AddModelError("ID_SPTour", "SPTOUR không tồn tại");
            }
            var khachHang = db.KHACHHANGs.Find(hOADON.ID_KH);
            if (khachHang == null)
            {
                ModelState.AddModelError("ID_KH", "KHACHHANG không tồn tại");
            }
            if(hOADON.SLNguoiLon + hOADON.SLTreEm > spTour.SoNguoi)
            {
                ModelState.AddModelError("", $"Tổng số lượng người lớn và trẻ em không được vượt quá {spTour.SoNguoi}");
            }
            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_KH = new SelectList(db.KHACHHANGs, "ID_KH", "HoTen_KH", hOADON.ID_KH);
            ViewBag.ID_SPTour = new SelectList(db.SPTOURs, "ID_SPTour", "TenSPTour", hOADON.ID_SPTour);
            return View(hOADON);
        }

        // GET: HOADONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KH = new SelectList(db.KHACHHANGs, "ID_KH", "HoTen_KH", hOADON.ID_KH);
            ViewBag.ID_SPTour = new SelectList(db.SPTOURs, "ID_SPTour", "TenSPTour", hOADON.ID_SPTour);
            return View(hOADON);
        }

        // POST: HOADONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HoaDon,SLTreEm,TongTienTour,NgayDat,TinhTrang,SLNguoiLon,TienKhuyenMai,TienPhaiTra,ID_SPTour,ID_KH")] HOADON hOADON)
        {
            // Kiểm tra xem đơn hàng có tồn tại không
            var existHD = db.HOADONs.Find(hOADON.ID_HoaDon);
            if(existHD == null)
            {
                ModelState.AddModelError("ID_HoaDon", "Đơn hàng không tồn tại");
                return View(hOADON);
            }
            // Kiểm tra xem SPTOUR có tồn tại không
            var spTour = db.SPTOURs.Find(hOADON.ID_SPTour);
            if(spTour == null)
            {
                ModelState.AddModelError("ID_SPTour", "Sản phẩm tour không tồn tại");
            }
            // Kiểm tra xem KHACHHANG có tồn tại không
            var khachHang = db.KHACHHANGs.Find(hOADON.ID_KH);
            if (khachHang == null)
            {
                ModelState.AddModelError("ID_KH", "Khách hàng không tồn tại");
            }
            if (hOADON.SLNguoiLon + hOADON.SLTreEm > spTour.SoNguoi)
            {
                ModelState.AddModelError("", $"Tổng số lượng người lớn và trẻ em không được vượt quá {spTour.SoNguoi}");
            }
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KH = new SelectList(db.KHACHHANGs, "ID_KH", "HoTen_KH", hOADON.ID_KH);
            ViewBag.ID_SPTour = new SelectList(db.SPTOURs, "ID_SPTour", "TenSPTour", hOADON.ID_SPTour);
            return View(hOADON);
        }

        // GET: HOADONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
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