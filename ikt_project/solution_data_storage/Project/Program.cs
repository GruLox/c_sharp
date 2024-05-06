var consoleService = new ConsoleService();
var jsonUtilities = new JsonUtilities();

var studentManager = new StudentManager(consoleService, jsonUtilities, "students.json", "subjects.json"); 
await studentManager.Run();