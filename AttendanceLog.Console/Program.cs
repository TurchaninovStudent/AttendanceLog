using AttendanceLog.Data.Repositories;
using AttendanceLog.Logic.Interfaces;
using AttendanceLog.Logic.Services;

Console.WriteLine("Учёт посещаемости студентов AttendanceLog, Турчанинов Андрей");

var jsonPath = Path.Combine(AppContext.BaseDirectory, "visits.json");
var xmlPath = Path.Combine(AppContext.BaseDirectory, "visits.xml");
var kind = args.Length > 0 ? args[0] : "json";
IVisitRepository repository = kind switch
{
    "xml" => new XmlVisitRepository(xmlPath),
    "memory" => new VisitRepository(),
    _ => new JsonVisitRepository(jsonPath)
};
Console.WriteLine($"Хранилище: {kind}");

var service = new VisitService(repository);

//Console.Write("Посещения нового студента: ");
//var student = Console.ReadLine() ?? "";
//service.AddVisit(student, wasPresent: true);

Console.WriteLine("Отсутствующие студенты:");

foreach (var item in service.GetAbsent())
{
    Console.WriteLine($"{item.Id}: {item.Student}");
}

Console.WriteLine("Доля пропусков (%):");

Console.WriteLine($"{service.GetAbsencePersentage() * 100}");
