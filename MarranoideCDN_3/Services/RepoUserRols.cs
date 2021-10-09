using MarranoideCDN_3.Application;
using MarranoideCDN_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Services
{
    public class RepoUserRols
    {
        /// <summary>
        /// Agrega o actualiza una entidad
        /// </summary>
        /// <param name="userRol">UserRol</param>
        /// <returns>Numero de filas agregadas o modificadas</returns>
        public static int AddOrUpdate(UserRol userRol)
        {
            using (var db = new Context())
            {
                db.UserRols.Update(userRol);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// Obtiene una entidad
        /// </summary>
        /// <param name="id">ID del UserRol</param>
        /// <returns><see cref="UserRol"/></returns>
        public static UserRol Get(string id)
        {
            using (var db = new Context())
            {
                return db.UserRols.Single(x => x.IDUserRol == id);
            }
        }
        /// <summary>
        /// Obtiene una entidad
        /// </summary>
        /// <param name="userlevel">Nivel del rol</param>
        /// <returns><see cref="UserRol"/></returns>
        public static UserRol Get(int userlevel)
        {
            using (var db = new Context())
            {
                return db.UserRols.Single(x => x.UserLevel == userlevel);
            }
        }
    }
}
