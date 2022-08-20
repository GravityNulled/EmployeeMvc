using Employee.Data;
using Employee.Dtos;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StaffController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var staffs = await _dbContext.Staffs.ToListAsync();
            return View(staffs);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StaffDto staffDto)
        {
            var staff = new Staff()
            {
              Id = Guid.NewGuid(),
              Name = staffDto.Name,
              Depertment = staffDto.Depertment,
              Email = staffDto.Email,
              Phone = staffDto.Phone
            };
             _dbContext.Staffs.Add(staff);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var staff = await _dbContext.Staffs.FindAsync(id);
            return View(staff);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Staff staff)
        {
            var user = await _dbContext.Staffs.FindAsync(staff.Id);
            if (user==null) return RedirectToAction("Index");
            user.Name = staff.Name;
            user.Email = staff.Email;
            user.Phone = staff.Phone;
            user.Depertment = staff.Depertment;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Staff staff)
        {
            var user = await _dbContext.Staffs.FindAsync(staff.Id);
            _dbContext.Staffs.Remove(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
