using System;
using System.Threading.Tasks;
using Logary;
using Logary.Configuration;
using Logary.Targets;
using Logary.Formatting;
using static Logary.Targets.Console;

namespace LogaryExample
{
    class LogaryClass
    {
        static async Task Log(string[] args)
        {
            // Logary'yi console hedefi ile başlatın
            var logary = await LogaryFactory.New("MyApp", with =>
                with.Target<Logary.Targets.Console.Builder>(
                    "console", target => target.Console()
                ).Create());

            var logger = logary.GetLogger("Main");

            // Loglama örnekleri
            logger.Info("Uygulama başlatıldı");
            logger.Warn("Bu bir uyarı mesajıdır");
            logger.Error("Bu bir hata mesajıdır");

            // Biraz iş simüle edin
            System.Console.WriteLine("Merhaba, Logary!");
            System.Console.ReadLine();

            // Çıkmadan önce tüm logların yazıldığından emin olun
            await logary.DisposeAsync();
        }
    }
}
