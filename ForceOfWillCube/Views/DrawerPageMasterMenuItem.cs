using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForceOfWillCube.Views
{

    public class DrawerPageMasterMenuItem
    {
        public DrawerPageMasterMenuItem()
        {
            TargetType = typeof(DrawerPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}