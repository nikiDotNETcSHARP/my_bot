using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace my_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("6271023416:AAGl8itNsfQ8KMpJ6uXozQ_X6OSJEb_wfv0");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName}     |     {message.Text}");

                if (message.Text.ToLower().Contains("привет"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Привет.");
                    return;
                }
            }

            if (message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Хорошее изображение, но лучше отправь его документом.");
                return;
            }
        }

        private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}