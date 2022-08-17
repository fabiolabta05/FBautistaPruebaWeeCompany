using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Entidad
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FBautistaPruebaWeecompanyEntities context = new DL.FBautistaPruebaWeecompanyEntities())
                {
                    var usuarios = context.EntidadGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)

                    {
                        foreach (var obj in usuarios)

                        {
                            ML.Entidad entidad = new ML.Entidad();
                            entidad.IdEntidad = obj.IdEntidad;
                            entidad.Nombre = obj.Nombre;
                            //usuario.Imagen = obj.Imagen;

                            result.Objects.Add(entidad);
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
    }
}
