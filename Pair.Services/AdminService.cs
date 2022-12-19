using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Services
{
#pragma warning disable CA1416 
    public class AdminService
    {
        public bool GetCurrentUserPermission()
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public WindowsIdentity GetCurrentUser() => WindowsIdentity.GetCurrent();
    }
}
