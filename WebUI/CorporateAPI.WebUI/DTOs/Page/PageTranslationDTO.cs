using System.Text.Json.Serialization;
namespace CorporateAPI.WebUI.DTOs.Page
{
    public class PageTranslationDTO
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("pageTitle")]
        public string PageTitle { get; set; }
        [JsonPropertyName("brief")]
        public string Brief { get; set; }
        [JsonPropertyName("metaDescription")]
        public string MetaDescription { get; set; }
        [JsonPropertyName("content")]

        public string Content { get; set; }
        [JsonPropertyName("pageId")]
        public int PageId { get; set; }

    }
}
