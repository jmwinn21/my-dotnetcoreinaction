using System;
using System.IO;
using System.Net.Http;
using Microsoft.DocAsCode.MarkdownLite;

namespace MarkdownTestLite {
    class Program {
        static void Main (string[] args) {

            var client = new HttpClient ();
            var response = client.PostAsync (
                "http://localhost:5000",
                new StreamContent (
                    new FileStream ("test.md", FileMode.Open))
            ).Result;
            string markdown = response.Content.
            ReadAsStringAsync ().Result;
            Console.WriteLine (markdown);
        }
    }
}