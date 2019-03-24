using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DocAsCode.MarkdownLite;
using Microsoft.Extensions.Configuration;

namespace MarkdownService {
  [Route ("/")]
  public class MdlController : Controller {
    private static readonly HttpClient client = new HttpClient ();
    private readonly IMarkdownEngine engine;
    private readonly string AccountName;
    private readonly string AccountKey;
    private readonly string BlobEndpoint;
    private readonly string ServiceVersion;

    public MdlController (IMarkdownEngine engine, IConfigurationRoot configRoot) {
      this.engine = engine;
      AccountName = configRoot["AccountName"];
      AccountKey = configRoot["AccountKey"];
      BlobEndpoint = configRoot["BlobEndpoint"];
      ServiceVersion = configRoot["ServiceVersion"];
    }

    [HttpPost]
    public async Task<IActionResult> Convert () {
      using (var reader = new StreamReader (Request.Body)) {
        var markdown = await reader.ReadToEndAsync ();
        var result = engine.Markup (markdown);
        return Content (result);
      }
    }
  }
}