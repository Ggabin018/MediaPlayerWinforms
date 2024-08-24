public class VideoUrlChecker
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<string?> GetVideoStreamUrlAsync(string url)
    {

        // For non-YouTube URLs, use HEAD request to check if it's a video
        using (var request = new HttpRequestMessage(HttpMethod.Head, url))
        {
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                string contentType = response.Content.Headers.ContentType.MediaType.ToLowerInvariant();
                if (contentType.StartsWith("video/"))
                {
                    return url;
                }
            }
        }

        return null;
    }
}