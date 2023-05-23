using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentUser.Context;
using AssessmentUser.Models;



namespace AssessmentUser.Controllers
{
    public class LoginController : Controller
    {
        private readonly Userdbcontext _context;



        public LoginController(Userdbcontext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]



        public IActionResult Login(LoginPage model)
        {
            User user = _context.Users.FirstOrDefault(x => x.Username == model.username && x.Password == model.password);

            if (user != null)
            {
                if (user.Role == UserRole.Manager)
                    return RedirectToAction("Index", "Users");
                else if (user.Role == UserRole.Employee)
                    return RedirectToAction("", "Batches");
                else

                    ModelState.AddModelError("", "Invalid username or password");
            }
            else
                ViewBag.msg = "There s no user";
            return View();
        }




    }
}