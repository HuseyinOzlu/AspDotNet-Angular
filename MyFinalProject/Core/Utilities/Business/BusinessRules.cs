using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) // params == istediğin kadar IResult paramtresi verebilirsin
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; //Başarısız ise direl logic' i (iş kuralını) döndürür.((Direk Kurala uymayanı))
                }
            }
            return null;
        }
    }
}
