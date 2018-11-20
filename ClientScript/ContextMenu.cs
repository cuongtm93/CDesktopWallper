using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using static Retyped.dom;
using static Retyped.jquery;
namespace ClientScript
{
    public class ContextMenu
    {
        public ContextMenu()
        {
            
        }
        public static void Disable()
        {
            window.addEventListener("contextmenu", (Event e) =>
            {
                e.preventDefault();
            });
        }
    }
}
