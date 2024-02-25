using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDB.DAO
{
    class DAOFactory
    {
        public IDAO GetDAO(MODEL.PELISContext context)
        {
            return new DAOManager(context);
        }
    }
}
