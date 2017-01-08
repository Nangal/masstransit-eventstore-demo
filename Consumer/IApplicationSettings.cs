namespace Consumer
{
    public interface IApplicationSettings
    {
        string GesIpAddress { get; }
        int GesHttpPort { get; }
        int GesTcpIpPort { get; }
        string GesUserName { get; }
        string GesPassword { get; }
    }
}
