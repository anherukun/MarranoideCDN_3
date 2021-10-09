using MarranoideCDN_3.Application;
using MarranoideCDN_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Services
{
    public class RepoAccounts
    {
        /// <summary>
        /// Agrega o actualiza una entidad
        /// </summary>
        /// <param name="account">Account</param>
        /// <returns>Numero de filas agregadas o modificadas</returns>
        public static int AddOrUpdate(Account account)
        {
            using (var db = new Context())
            {
                db.Accounts.Update(account);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// Obtiene una lista de entidades
        /// </summary>
        /// <returns>Lista de <see cref="Account"/></returns>
        public static List<Account> Get()
        {
            using (var db = new Context())
            {
                return db.Accounts.Include(x => x.UserRol).Select(x => new Account
                {
                    IDAccount = x.IDAccount,
                    Email = x.Email,
                    Username = x.Username,
                    IDUserRol = x.IDUserRol,
                    UserRol = x.UserRol,
                    CreatedAt = x.CreatedAt
                }).ToList();
            }
        }
        /// <summary>
        /// Obtiene una entidad
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        /// <returns><see cref="Account"/></returns>
        public static Account Get(string id)
        {
            using (var db = new Context())
            {
                return db.Accounts.Include(x => x.UserRol).Select(x => new Account
                {
                    IDAccount = x.IDAccount,
                    Email = x.Email,
                    Username = x.Username,
                    IDUserRol = x.IDUserRol,
                    UserRol = x.UserRol,
                    CreatedAt = x.CreatedAt
                }).Single(x => x.IDAccount == id) ;
            }
        }
        /// <summary>
        /// Comparador de contraseñas
        /// </summary>
        /// <param name="id">ID de la cuenta</param>
        /// <param name="value">Cadena de comparacion</param>
        /// <returns>True: si es correcta. False: si es incorrecta</returns>
        public static bool IsPasswordCorrect(string id, string value)
        {
            using (var db = new Context())
            {
                return db.Accounts.Single(x => x.IDAccount == id).PasswordHash == Security.SHA256Hash(value) ? true : false;
            }
        }
    }
}
