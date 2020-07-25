using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class AppControl
    {
        private SanPham_DAL_BLL spDAL_BLL;

        public AppControl()
        {
            spDAL_BLL = new SanPham_DAL_BLL();
        }

        public SanPham_DAL_BLL getSpDAL_BLL()
        {
            return spDAL_BLL;
        }
    }
}
