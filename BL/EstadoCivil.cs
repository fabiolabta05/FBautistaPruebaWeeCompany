using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstadoCivil
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FBautistaPruebaWeecompanyEntities context = new DL.FBautistaPruebaWeecompanyEntities())
                {
                    var usuarios = context.EstadoCivilGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)

                    {
                        foreach (var obj in usuarios)

                        {
                            ML.EstadoCivil estadocivil= new ML.EstadoCivil();
                            estadocivil.IdEstadoCivil = obj.IdEstadoCivil;
                            estadocivil.Nombre = obj.Nombre;
                            //usuario.Imagen = obj.Imagen;

                            result.Objects.Add(estadocivil);
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
