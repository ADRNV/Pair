namespace Pair.Infrastructure.EF.Security.Entities.Configurations
{
    [Flags]
    public enum Permissions
    {
        Read = 0,
        ReadAndWrite = 1,
        Manage = 2,
    }
}
