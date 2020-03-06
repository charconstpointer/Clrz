using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Clrz.ConsoleApp.Models;
using Newtonsoft.Json;

namespace Clrz.ConsoleApp.Interface
{
    public interface IImageService
    {
        Task Colorize(ActionConfiguration actions);
        Task Enhance(ActionConfiguration actions);
        Task Waifu(ActionConfiguration actions);
        Task Dream(ActionConfiguration actions);
    }

    internal class ImageService : IImageService
    {
        public async Task Colorize(ActionConfiguration actions)
        {
            Process(actions,"colorizer");
        }

        public async Task Enhance(ActionConfiguration actions)
        {
            Process(actions,"torch-srgan");
        }

        public async Task Waifu(ActionConfiguration actions)
        {
            Process(actions,"waifu2x");
        }

        public async Task Dream(ActionConfiguration actions)
        {
            Process(actions, "deepdream");
        }

        private static void DownloadAndSaveFile(ApiResponse enhancedApiResponse, string file,
            ActionConfiguration actionConfiguration)
        {
            var outputFolder = Directory.CreateDirectory(actionConfiguration.Output());
            using var webClient = new WebClient();
            // ReSharper disable once MethodHasAsyncOverload
            webClient.DownloadFile(new Uri(enhancedApiResponse.Output_url),
                $"{outputFolder}/output_{Path.GetFileName(file)}");
        }

        private static void Process(ActionConfiguration actions, string url)
        {
            Parallel.ForEach(actions.Files(), file =>
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{DateTime.UtcNow.Millisecond} > Started converting {file} [{url}]");
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Api-Key", "3ccc6de8-0e16-4e36-810a-d90fb52d2ffe");
                var formData = new MultipartFormDataContent
                {
                    {new StreamContent(new MemoryStream(File.ReadAllBytes(file))), "image", $"{file}"}
                };
                var response = client.PostAsync($"https://api.deepai.org/api/{url}",
                    formData).GetAwaiter().GetResult();
                var res = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var model = JsonConvert.DeserializeObject<ApiResponse>(res);
                DownloadAndSaveFile(model, file, actions);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{DateTime.UtcNow.Millisecond} > Finished converting {file} [{url}]");
            });
        }
    }
}