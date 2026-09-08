using AttendanceLog.Data.Repositories;
using AttendanceLog.Logic.Services;

Console.WriteLine("Учёт посещаемости студентов AttendanceLog, Турчанинов Андрей");

var service = new VisitService(new VisitRepository());

Console.WriteLine("Отсутствующие студенты:");

foreach (var item in service.GetAbsent())
{
    Console.WriteLine($"{item.Id}: {item.Student}");
}