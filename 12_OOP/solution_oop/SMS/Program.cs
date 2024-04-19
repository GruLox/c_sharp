//sms küldő rendszer 3 különböző rendszerre lehet küldeni,
//bejön az üzenet, a rendszer tudja melyik telefonról van szó
// ki kell küldeni az üzenetet a megfelelő rendszerre
// factory pattern
// interface

var factory = new SmsSenderFactory();

ISmsSender sender = factory.GetSmsSender(Platform.Android);

await sender.SendSmsAsync("Hello World");

