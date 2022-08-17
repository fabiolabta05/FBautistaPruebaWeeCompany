using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FBautistaPruebaWeecompanyEntities context = new DL.FBautistaPruebaWeecompanyEntities())
                {
                    var usuarios = context.UsuarioGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)

                    {
                        foreach (var obj in usuarios)

                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.EstadoCivil = new ML.EstadoCivil();
                            usuario.EstadoCivil.IdEstadoCivil = obj.IdEstadoCivil;
                            usuario.EstadoCivil.Nombre = obj.EstadoCivil;
                            usuario.Genero = new ML.Genero();
                            usuario.Genero.IdGenero = obj.IdGenero;
                            usuario.Genero.Nombre = obj.Genero;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Entidad = new ML.Entidad();
                            usuario.Entidad.IdEntidad = obj.IdEntidad;
                            usuario.Entidad.Nombre = obj.Entidad;
                            usuario.Curp = obj.Curp;
                            usuario.RFC = obj.RFC;
                            usuario.Telefono = obj.Telefono;
                            usuario.Email = obj.Email;
                            usuario.Imagen = obj.Imagen;
                            result.Objects.Add(usuario);
                            
                        }

                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public static ML.Result Add(ML.Usuario usuario)//agregar un usuario con entity Framework
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FBautistaPruebaWeecompanyEntities context = new DL.FBautistaPruebaWeecompanyEntities())
                {
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,usuario.EstadoCivil.IdEstadoCivil,usuario.Genero.IdGenero, usuario.FechaNacimiento, usuario.Entidad.IdEntidad, usuario.Curp,usuario.RFC,
                        usuario.Telefono,usuario.Email, usuario.Imagen );
                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "usuario registrado";
                    }
                    else
                    {
                        result.Correct = false;

                    }
                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        //public static ML.Result Update(ML.Usuario usuario)//actualiza un usuario con entity framework
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL.FBautistaPruebaWeecompanyEntities context = new DL.FBautistaPruebaWeecompanyEntities())
        //        {
        //            var updateResult = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno,
        //                usuario.ApellidoMaterno, usuario.EstadoCivil.Nombre, usuario.Genero, usuario.FechaNacimiento, usuario.Entidad, usuario.Curp, usuario.RFC,
        //                usuario.Telefono, usuario.Email, usuario.Imagen);
        //            if (updateResult >= 1)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se actualizo";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        public static ML.Result Delete( int IdUsuario)//elimina un usuario con entity framework
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FBautistaPruebaWeecompanyEntities context = new DL.FBautistaPruebaWeecompanyEntities())
                {
                    var query = context.UsuarioDelete( IdUsuario);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //public static ML.Result GetById(int IdUsuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL.FBautistaPruebaWeecompanyEntities context = new DL.FBautistaPruebaWeecompanyEntities())
        //        {
        //            var objUsuario = context.UsuarioGetbyId(IdUsuario).FirstOrDefault();
        //            result.Objects = new List<object>();
        //            if (objUsuario != null)
        //            {
        //                ML.Usuario usuario = new ML.Usuario();
        //                usuario.IdUsuario = objUsuario.IdUsuario;
        //                usuario.Nombre = objUsuario.Nombre;
        //                usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
        //                usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
        //                usuario.EstadoCivil = new ML.EstadoCivil();
        //                usuario.EstadoCivil.Nombre = objUsuario.EstadoCivil;
        //                usuario.Genero= objUsuario.Genero;
        //                //usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
        //                usuario.Entidad = objUsuario.Entidad;
        //                usuario.Curp = objUsuario.Curp;
        //                usuario.Email = objUsuario.Email;
        //                //usuario.Imagen = objUsuario.Imagen;
        //                result.Object = usuario;
        //                result.Correct = true;

        //        }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "no se encontro registro";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;

        //    }
        //    return result;
        //}
    }
}
