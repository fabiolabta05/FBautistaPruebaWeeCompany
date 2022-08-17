using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();//instanciar un objeto
            ML.Result result = BL.Usuario.GetAll();

            ML.Result resultEstadocivil = BL.EstadoCivil.GetAll();
            usuario.EstadoCivil = new ML.EstadoCivil();

            ML.Result resultEntidad = BL.Entidad.GetAll();
            usuario.Entidad = new ML.Entidad();


            ML.Result resultGenero = BL.Genero.GetAll();
            usuario.Genero = new ML.Genero();

            usuario.Usuarios = result.Objects;
            usuario.EstadoCivil.EstadosCiviles = resultEstadocivil.Objects;
            usuario.Entidad.Entidades = resultEntidad.Objects;
            usuario.Genero.Generos = resultGenero.Objects;
            return View(usuario);
        }


        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            //ML.Result result =new ML.Result();


            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                usuario.Imagen = ConvertToBytes(file);
            }


            //if (usuario.IdUsuario != 0)
            //{
            //    ML.Result result = BL.Usuario.Update(usuario);

            //    if (result.Correct)
            //    {
            //        ViewBag.Message = "Actualiza usuario";
            //        return PartialView("Modal");
            //    }
            //    else
            //    {
            //        ViewBag.Message = "no se actualizo usuario";
            //        return PartialView("Modal");
            //    }
            //}
            //else
            //{
            ML.Result result = BL.Usuario.Add(usuario);
            if (result.Correct)
            {
                ViewBag.Message = "usuario registrado";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "El usuario no se pudo registrar";
                return PartialView("Modal");
            }
        }


    public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
    {
        byte[] data = null;
        System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
        data = reader.ReadBytes((int)Imagen.ContentLength);

        return data;
    }

    public JsonResult EstadoCivilGetAll(int IdEstadoCivil)
    {
        ML.Result result = BL.EstadoCivil.GetAll();
        return Json(result.Objects);

    }
}
}
