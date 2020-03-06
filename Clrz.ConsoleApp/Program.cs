using System;
using System.Linq;
using System.Threading.Tasks;
using Clrz.ConsoleApp.Interface;

namespace Clrz.ConsoleApp
{
    class Program
    {
        private static async Task Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  .-._                                                   _,-,\n  `._`-._                                           _,-'_,'\n     `._ `-._                                   _,-' _,'\n        `._  `-._        __.-----.__        _,-'  _,'\n           `._   `#===\"\"\"           \"\"\"===#'   _,'\n              `._/)  ._               _.  (\\_,'\n               )*'     **.__     __.**     '*( \n               #  .==..__  \"\"   \"\"  __..==,  # \nPortal.        #   `\"._(_).       .(_)_.\"'   #");
            var configurationManager = new ConfigurationManager();
            var config = await configurationManager.GetConfiguration();
            var imageService = new ImageService();

            Parallel.ForEach(config.Actions, configAction =>
            {
                switch (configAction.Name().ToLower())
                {
                    case "color":
                        imageService.Colorize(configAction).GetAwaiter().GetResult();
                        break;
                    case "resolution":
                        imageService.Enhance(configAction).GetAwaiter().GetResult();
                        break;
                    case "waifu":
                        imageService.Waifu(configAction).GetAwaiter().GetResult();
                        break;
                    case "dream":
                        imageService.Dream(configAction).GetAwaiter().GetResult();
                        break;
                }
            });
            // foreach (var configAction in config.Actions)
            // {
            //     switch (configAction.Name().ToLower())
            //     {
            //         case "color":
            //             await imageService.Colorize(configAction);
            //             break;
            //         case "resolution":
            //             await imageService.Enhance(configAction);
            //             break;
            //         case "waifu":
            //             await imageService.Waifu(configAction);
            //             break;
            //     }
            // }
        }
    }
}