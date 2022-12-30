using System.Security.Principal;

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
