using MarranoideCDN_3.Application;
using MarranoideCDN_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Services
{
    public class RepoSessions
    {
        /// <summary>
        /// Agrega o actualiza una entidad
        /// </summary>
        /// <param name="account">Account</param>
        /// <returns>Numero de filas agregadas o modificadas</returns>
        public static int Add(Session session)
        {
            using (var db = new Context())
            {
                db.Sessions.Add(session);
                return db.SaveChanges();
            }
        }
        public static int Update(Session session)
        {
            using (var db = new Context())
            {
                db.Sessions.Update(session);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// Obtiene una entidad
        /// </summary>
        /// <param name="idAccount">ID de la cuenta</param>
        /// <returns><see cref="Session"/></returns>
        public static Session Get(string idAccount)
        {
            using (var db = new Context())
            {
                return db.Sessions.Single(x => x.IDAccount == idAccount);
            }
        }
        /// <summary>
        /// Obtiene una entidad
        /// </summary>
        /// <param name="sessionToken">Token de la sesion</param>
        /// <param name="idAccount">ID de la cuenta</param>
        /// <returns><see cref="Session"/></returns>
        public static Session Get(string sessionToken, string idAccount)
        {
            using (var db = new Context())
            {
                return db.Sessions.Single(x => x.SessionToken == sessionToken && x.IDAccount == idAccount);
            }
        }

        /// <summary>
        /// Compueba que el token asignado sea el correcto
        /// </summary>
        /// <param name="sessionToken">Token de la sesion</param>
        /// <param name="idAccount">ID de la cuenta</param>
        /// <returns>True: si el token asignado a la cuenta es correcto. False: Si es incorrecto</returns>
        public static bool OnSession(string sessionToken, string idAccount)
        {
            using (var db = new Context())
            {
                return db.Sessions.Single(x => x.SessionToken == sessionToken && x.IDAccount == idAccount) != null ? true : false;
            }
        }
        /// <summary>
        /// Compueba que exista al menos una entidad
        /// </summary>
        /// <param name="idAccount">ID de la cuenta</param>
        /// <returns>True: si existe una entidad para esa cuenta. False: Si no existe</returns>
        public static bool Exist(string idAccount)
        {
            using (var db = new Context())
            {
                return db.Sessions.Any(x => x.IDAccount == idAccount);
            }
        }
    }
}
