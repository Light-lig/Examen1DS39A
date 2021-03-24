using Examen1DS39A.Models;
using Examen1DS39A.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1DS39A.Controllers
{
    public class HomeController : Controller
    {
        DaoUsuario dao = new DaoUsuario();
        DaoCliente daoCliente = new DaoCliente();
        Constantes cos = new Constantes();
        public ActionResult Clientes()
        {
            string filterFinal = null;
            if(Session["usuario"] == null)
            {
                return RedirectToAction("Login");
            }
            if(TempData["valor"] != null)
            {
                filterFinal = TempData["valor"].ToString();
            }
            else
            {
                filterFinal = null;
            }
            ViewBag.clientes = daoCliente.getData(filterFinal);
            return View();
        }
        [HttpPost]
        public ActionResult getDataFilter(string valor)
        {
            if(valor == "")
            {
                valor = null;
            }
            TempData["valor"] = valor;
            return RedirectToAction("Clientes");
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CerrarSession()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Login(Usuario us)
        {
            if (ModelState.IsValid)
            {
                Usuario user = dao.login(us.nombre_usuario, us.contra);
                if (user.cod_user == 0)
                {
                    Session["msj"] = cos.mostrarMensaje("Ocurrio un error, verifique sus credenciales", "alert-danger");
                    return View();
                }
                else
                {
                    Session["msj"] = null;
                    Session["usuario"] = user.nombre_usuario;
                    Session["nivel"] = user.nivel_usuario;
                    return RedirectToAction("Clientes");
                }

            }

                return View();
      

        }

        public ActionResult AddCliente()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddCliente(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                bool estado = daoCliente.insertar(cli);
                Session["estado"] = estado;
           
                if (estado)
                {
                    Session["msj"] = cos.mostrarMensaje("Se agrego correctamente", "alert-success");
                }
                else
                {
                    Session["msj"] = cos.mostrarMensaje("Ocurrio un error.", "alert-danger");
                }
              
                return RedirectToAction("Clientes");
            }
            return View();
        }

        public ActionResult EditCliente(int id)
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Login");
            }
            Cliente cli = daoCliente.getData(null).ToList().Find(c => c.cod_cliente == id);
            return View(cli);
        }

        [HttpPost]
        public ActionResult EditCliente(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                bool estado = daoCliente.modificar(cli);
                Session["estado"] = estado;

                if (estado)
                {
                    Session["msj"] = cos.mostrarMensaje("Se modifico correctamente", "alert-success");
                }
                else
                {
                    Session["msj"] = cos.mostrarMensaje("Ocurrio un error.", "alert-danger");
                }
                return RedirectToAction("Clientes");
                
            }
                return View();
        }
        public ActionResult DeleteCliente(int id)
        {
            daoCliente.eliminar(id);

            Session["msj"] = cos.mostrarMensaje("Se elimino correctamente", "alert-success");

            return RedirectToAction("Clientes");
        }
    }
}