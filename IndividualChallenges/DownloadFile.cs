public void DownloadFile(string url)
{
    if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) || uriResult.Scheme != Uri.UriSchemeHttps)
    {
        throw new ArgumentException("Invalid URL. Only HTTPS URLs are allowed.");
    }

    string fileName = Path.GetFileName(uriResult.LocalPath);
    string safeFilePath = Path.Combine("/safe/directory/", fileName);

    using (var client = new WebClient())
    {
        client.DownloadFile(uriResult, safeFilePath);
    }
    Console.WriteLine("File downloaded from: " + url);

    // using (var client = new WebClient())
    // {
    //     client.DownloadFile("http://example.com/file.txt", "file.txt"); // Insecure: Uses HTTP and hardcoded URL
    // }
    // Console.WriteLine("File downloaded from: " + url);
}
