using DTOs;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = RoleKeywords.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IStudentService _studentService;

        public AdminController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(StudentDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentService.Create(dto);
                    ViewBag.Success = "Student was added successfully to our system!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }

        [HttpGet("Admin/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var res = _studentService.Get(id);
            return View(res);
        }

        [HttpPost]
        public IActionResult EditDTO(StudentDTO dto)
        {
            var res = dto;
            try
            {
                if (ModelState.IsValid)
                {
                    res = _studentService.Update(dto);
                    ViewBag.Success = "Student's data was updated successfully!";
                    return View("Edit", res);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View("Edit", res);
        }

        [HttpGet("Admin/Remove/{id}")]
        public IActionResult Remove(int id)
        {
            var res = _studentService.Get(id);
            return View(res);
        }

        [HttpPost]
        public IActionResult RemoveDTO(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("GetAll", "Admin");
        }

        [HttpGet("Admin/Get/{id}")]
        public IActionResult Get(int id)
        {
            var res = _studentService.Get(id);

            if (res == null)
            {
                ViewBag.Error = "Student is not found!";
                return View();
            }
            return View(res);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _studentService.GetAll();
            return View(res);
        }
    }
}