using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Study_Case_4.Data;
using Study_Case_4.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Study_Case_4.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var employees = _context.ListNama.ToList();

            var viewModel = new AttendanceViewModel
            {
                EmployeeList = employees.Select(e => new SelectListItem
                {
                    Text = $"{e.NIK} - {e.Nama}",
                    Value = e.NIK
                }).ToList(),
                TanggalAbsen = DateTime.Today
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttendanceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newAttendance = new Absen
                {
                    NIK = viewModel.SelectedNik,
                    TanggalAbsen = viewModel.TanggalAbsen
                };

                _context.Absensi.Add(newAttendance);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Index()
        {
            var attendanceRecords = from absen in _context.Absensi
                                    join employee in _context.ListNama on absen.NIK equals employee.NIK
                                    orderby absen.NIK, absen.TanggalAbsen
                                    select new AttendanceRecordViewModel
                                    {
                                        NIK = absen.NIK,
                                        Nama = employee.Nama,
                                        TanggalAbsen = absen.TanggalAbsen
                                    };

            return View(await attendanceRecords.ToListAsync());
        }
        public async Task<IActionResult> PivotReport()
        {
            var allAttendances = await _context.Absensi.OrderBy(a => a.TanggalAbsen).ToListAsync();
            var allEmployees = await _context.ListNama.ToListAsync();

            var dateHeaders = allAttendances
                .Select(a => a.TanggalAbsen.ToString("dd-MM-yyyy"))
                .Distinct()
                .ToList();

            var groupedAttendances = allAttendances.GroupBy(a => a.NIK);

            var reportViewModel = new PivotReportViewModel
            {
                DateHeaders = dateHeaders
            };

            foreach (var group in groupedAttendances)
            {
                var employee = allEmployees.FirstOrDefault(e => e.NIK == group.Key);
                if (employee == null) continue;

                var reportRow = new PivotReportRow
                {
                    NIK = employee.NIK,
                    Nama = employee.Nama
                };

                foreach (var dateHeader in dateHeaders)
                {
                    bool hasAttended = group.Any(a => a.TanggalAbsen.ToString("dd-MM-yyyy") == dateHeader);
                    reportRow.AttendanceMarks.Add(hasAttended ? "X" : "");
                }

                reportRow.Total = group.Count();
                reportViewModel.Rows.Add(reportRow);
            }

            return View(reportViewModel);
        }
        public async Task<IActionResult> MonthlyPivotReport()
        {
            var allAttendances = await _context.Absensi.ToListAsync();
            var allEmployees = await _context.ListNama.ToListAsync();

            var monthHeaders = allAttendances
                .Select(a => a.TanggalAbsen.ToString("yyyyMM"))
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            var reportViewModel = new MonthlyPivotReportViewModel
            {
                MonthHeaders = monthHeaders
            };

            var groupedAttendances = allAttendances.GroupBy(a => a.NIK);

            foreach (var group in groupedAttendances)
            {
                var employee = allEmployees.FirstOrDefault(e => e.NIK == group.Key);
                if (employee == null) continue;

                var reportRow = new MonthlyPivotReportRow
                {
                    NIK = employee.NIK,
                    Nama = employee.Nama
                };

                foreach (var monthHeader in monthHeaders)
                {
                    int count = group.Count(a => a.TanggalAbsen.ToString("yyyyMM") == monthHeader);
                    reportRow.AttendanceCounts.Add(count);
                }

                reportRow.Total = group.Count();
                reportViewModel.Rows.Add(reportRow);
            }

            return View(reportViewModel);
        }
    }
}