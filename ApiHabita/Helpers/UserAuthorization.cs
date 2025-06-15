using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHabita.Helpers
{
    public class UserAuthorization
    {
    public enum Rols
    {
        Administrator,
        Professional,
        Patient
    }

    public const Rols rol_predeterminado = Rols.Patient;
    }
}