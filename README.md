# CryptoPriceBot - Blog Post Source Code
This is the source code for the blog post [Creating a Cryptocurrency Price Bot in .NET 5 (Core)](https://ramstad.io/2021/04/22/Creating-a-Cryptocurrency-Price-Bot-in-NET-5-CORE/).

## Prerequisites
Make sure that you have an environment setup to run [.NET 5 (Core)](https://dot.net), such as [Visual Studio 2019](https://visualstudio.microsoft.com/vs/), [JetBrains Rider](https://www.jetbrains.com/rider/), or just [Visual Studio Code](https://code.visualstudio.com/) with the [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) installed.

## Running the application
To be able to send an email notification you will need to update the SMTP login credentials inside the `Notifications/SmtpEmailNotificationService.cs` file to your own details.

You should also update Program.cs with more current prices for both Bitcon (BTC) and Ethereum (ETH).

## Extending the application
Use the `IPriceAnalyzer` interface to create new analyzers, this could for example be a `PriceBelowAnalyzer` that notifies the user when the price dips below a certain threshold and its implementation would be similar to the `PriceAboveAnalyzer`.
Likewise use the `INotificationService` interface to create other methods of being notified, for example this could be via SMS using [twilio](https://www.twilio.com/sms).

Enjoy!