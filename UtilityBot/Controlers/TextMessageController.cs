using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using UtilityBot.Commands;

namespace UtilityBot.Controlers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        public static string command;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Калькулятор" , $"calc"),
                        InlineKeyboardButton.WithCallbackData($" Длинна" , $"lengh")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Наш бот выполняет две комманды:</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}1) Калькулятор - написав числа через пробел он выдаст вам сумму.{Environment.NewLine}" +
                        $"{Environment.NewLine}2) Длинная сообщения - написав сообщения он выдаст вам длинну.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;
            }
            switch (command)
            {
                case "calc":
                    await _telegramClient.SendTextMessageAsync(message.From.Id, $"Сумма чисел: {Calculator.Calc(message.Text)} ");
                    break;
                case "lenght":
                    await _telegramClient.SendTextMessageAsync(message.From.Id, $"Длина сообщения: {message.Text.Length} знаков");
                    break;

            }
        }
    }
}