namespace NuGet
{
    public class DownloadCache
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:URI-like properties should not be strings", Justification = "<Pending>")]
        public string OriginalUrl { get; set; }
        public string FileName { get; set; }
        public string Checksum { get; set; }
    }
}