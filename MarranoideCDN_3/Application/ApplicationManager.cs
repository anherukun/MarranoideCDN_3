using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Application
{
    public class ApplicationManager
    {
        /// <summary>
        /// Genera un GUID aleatorio
        /// </summary>
        public static string GenerateGUID => Guid.NewGuid().ToString().ToUpper();
    }
}
