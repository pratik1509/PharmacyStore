namespace PharmacyStore.Framework
{
    public interface IWorkContext
    {
        string SiteBaseUrl { get; }
        void SetCurrentRequestId(string key, string requestId);
        string GetCurrentRequestId(string key);
    }
}
