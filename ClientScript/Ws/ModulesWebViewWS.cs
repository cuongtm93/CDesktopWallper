using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Retyped;
using static Retyped.dom;
namespace ClientScript
{
    public class ModulesWebViewWS
    {
        public ModulesWebViewWS()
        {
            App.SetTitle("Danh sách ứng dụng");
            App.SetBreadcrumb("Kho tính năng", "Danh sách");
            App.Append("Đây là danh sách các ứng dụng của hệ thống");
            
        }
    }
}
