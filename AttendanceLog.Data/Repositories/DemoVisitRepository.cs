using AttendanceLog.Logic.Interfaces;
using AttendanceLog.Logic.Models;

namespace AttendanceLog.Data.Repositories;

/// <summary>
/// Демпонстрационный <see cref="IVisitRepository"/>
/// </summary>
public class DemoVisitRepository : IVisitRepository
{
    private readonly List<Visit> items =
    [
        new()
        {
            Id = 1,
            Student = "Голубев А.В.",
            WasPresent = false
        },
    ];

    List<Visit> IVisitRepository.GetAll() => items;
}
