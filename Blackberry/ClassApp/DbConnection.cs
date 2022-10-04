using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackberry.ADOApp;

namespace Blackberry.ClassApp
{
    public class DbConnection
    {
        public static BlackMarketEntities Connection = new BlackMarketEntities();
    }
}
