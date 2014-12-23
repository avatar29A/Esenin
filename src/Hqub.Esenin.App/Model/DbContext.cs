using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hqub.Esenin.App.Model
{
    public static class DbContext
    {
        public static MyEntityContext Create()
        {
            return new MyEntityContext(Properties.Properties.ConnectionString);
        }
    }
}
