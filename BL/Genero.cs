using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FBautistaPruebaWeecompanyEntities context = new DL.FBautistaPruebaWeecompanyEntities())
                {
                    var usuarios = context.GeneroGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)

                    {
                        foreach (var obj in usuarios)

                        {
                            ML.Genero genero = new ML.Genero();
                            genero.IdGenero = obj.IdGenero;
                            genero.Nombre = obj.Nombre;
                            //usuario.Imagen = obj.Imagen;

                            result.Objects.Add(genero);
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
