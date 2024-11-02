using Managerment_fish.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Managerment_fish.Controllers
{
	public class LoginController : Controller
	{

        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Kiểm tra xem người dùng có tồn tại và mật khẩu có khớp không
            var user = await _context.NguoiDung
                .FirstOrDefaultAsync(u => u.TenDangNhap == username && u.MatKhau == password);

            if (user != null)
            {
                TempData["SuccessMessage"] = "Đăng nhập thành công!";
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Tài khoản hoặc mật khẩu không chính xác.";
            return RedirectToAction("Index"); // Quay lại trang Login để hiển thị thông báo
        }

    }
}
