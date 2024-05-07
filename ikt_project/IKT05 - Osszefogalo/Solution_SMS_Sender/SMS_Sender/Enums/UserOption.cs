namespace SMS_Sender.Enums;

public enum UserOption
{
    [Description("Add new message")]
    AddNewMessage = 1,

    [Description("Delete message")]
    DeleteMessage = 2,

    [Description("Send messages")]
    SendMessages = 3,

    [Description("View report")]
    ViewReport = 4,

    Exit = 5
}