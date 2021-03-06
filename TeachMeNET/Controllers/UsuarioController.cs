using Microsoft.AspNetCore.Mvc;
using TeachMeNET.Models;
using Microsoft.AspNetCore.Http;
using TeachMeNET.Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TeachMeNET.Controllers
{
    public class UsuarioController: BaseController
    {
        private readonly TeachMeContext _context;
        public UsuarioController(TeachMeContext context)
        {
            this._context = context;
        }
    
        public IActionResult Registro()
        {
            ViewBag.Nombre = HttpContext.Session.GetString("UserName");
            if(ViewBag.Nombre!=null){
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Registro(User model)
        {
            if (ModelState.IsValid)
            {
                //TempData["usuario"] = model;
                var existeUsuario = _context.InicioSesiones.Any(u => u.Email == model.Input.Email);
                if (!existeUsuario)
                {
                    //User usuario = TempData["usuario"] as User;
                    if (model == null)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    
                    _context.Add(model);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("Id", model.Id);
                    HttpContext.Session.SetString("UserName", model.Name1);
                    HttpContext.Session.SetString("FirstName", model.Name1);
                    HttpContext.Session.SetString("LastName", model.LastName1);
                    return RedirectToAction("Index", "Home");
                }else{
                     ModelState.AddModelError("Incorrecto", "El correo ya existe");
                }
            }
            //return RedirectToAction("Registro");
            return View(model);
        }
        
        public IActionResult Login()
		{
            if(ViewBag.nombre!=null){
                return RedirectToAction("Index","Home");
            }
			return View();
		}

        [HttpPost]
        public IActionResult Login(InicioSesionModel inicio)
		{
            if(ModelState.IsValid){
                
                //aqui obtienes la lista de logins
                //var existeUsuario = _context.InicioSesiones.Any(u => u.Email == inicio.Email && u.Password == inicio.Password); //para ver si hay alguno que cumple con la condicion
                var usuario = _context
                                .InicioSesiones
                                .Include(i => i.User)
                                .FirstOrDefault(u => u.Email == inicio.Email && u.Password == inicio.Password);

                if (usuario == null) {
                    ModelState.AddModelError("Incorrecto", "contraseña o correo incorrecta");
                    
                }
                else {
                    HttpContext.Session.SetInt32("Id", usuario.User.Id);
                    HttpContext.Session.SetString("FirstName", usuario.User.Name1);
                    HttpContext.Session.SetString("LastName", usuario.User.LastName1);

                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View(inicio);
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

		public IActionResult MiPerfil()
		{
			if (ViewBag.Id == null)
				return RedirectToAction("Index", "Home");
			else
				return View();
		}


        public IActionResult PerfilAlumno()
        {
            if (ViewBag.Id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public IActionResult PerfilProfesor()
        {
            if (ViewBag.Id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var profesores = _context
                                .Teachers
                                .FromSql("SELECT * FROM teachers")
                                .Where(b => b.UserId == HttpContext.Session.GetInt32("Id"))
                                .ToList()
                                .FirstOrDefault();
                if (profesores != null)
                {
                    ViewBag.ProfeId = profesores.Id;
                    ViewBag.Country = profesores.Country;
                    ViewBag.City = profesores.City;
                    ViewBag.LinkedIn = profesores.LinkedIn;
                    ViewBag.Topic1 = profesores.Topic1;
                    ViewBag.Price1 = profesores.Price1;
                    ViewBag.AboutMe = profesores.AboutMe;
                    ViewBag.ToHouse = profesores.ToHouse;
                    ViewBag.MyHouse = profesores.MyHouse;
                    ViewBag.PublicSpace = profesores.PublicSpace;
                    ViewBag.Online = profesores.Online;
                }
                return View();
            }   
               
        }

        [HttpPost]
        public IActionResult PerfilProfesor(Teacher profesor)
        {
            if (ModelState.IsValid)
            {
                var teacher = _context
                                .Teachers
                                .FromSql("SELECT * FROM teachers")
                                .Where(b => b.UserId == HttpContext.Session.GetInt32("Id"))
                                .ToList()
                                .FirstOrDefault();

                if (teacher == null)
                {
                    var profe = new Teacher();
                    profe.UserId = (int)HttpContext.Session.GetInt32("Id");
                    _context.Add(profe);
                    _context.SaveChanges();

                    teacher = _context
                                .Teachers
                                .FromSql("SELECT * FROM teachers")
                                .Where(b => b.UserId == HttpContext.Session.GetInt32("Id"))
                                .ToList()
                                .FirstOrDefault();
                }

                teacher.Country = profesor.Country;
                teacher.City = profesor.City;
                teacher.LinkedIn = profesor.LinkedIn;
                teacher.Topic1 = profesor.Topic1;
                teacher.Price1 = profesor.Price1;
                teacher.AboutMe = profesor.AboutMe;
                teacher.ToHouse = profesor.ToHouse;
                teacher.MyHouse = profesor.MyHouse;
                teacher.PublicSpace = profesor.PublicSpace;
                teacher.Online = profesor.Online;

                _context
                .Teachers
                .Update(teacher);

                _context.SaveChanges();
                    
                

            }
            var profes = _context
                                .Teachers
                                .FromSql("SELECT * FROM teachers")
                                .Where(b => b.UserId == HttpContext.Session.GetInt32("Id"))
                                .ToList()
                                .FirstOrDefault();
            if (profes != null)
            {
                ViewBag.ProfeId = profes.Id;
                ViewBag.Country = profes.Country;
                ViewBag.City = profes.City;
                ViewBag.LinkedIn = profes.LinkedIn;
                ViewBag.Topic1 = profes.Topic1;
                ViewBag.Price1 = profes.Price1;
                ViewBag.AboutMe = profes.AboutMe;
                ViewBag.ToHouse = profes.ToHouse;
                ViewBag.MyHouse = profes.MyHouse;
                ViewBag.PublicSpace = profes.PublicSpace;
                ViewBag.Online = profes.Online;
                
            }
            return View();
        }
    }
}