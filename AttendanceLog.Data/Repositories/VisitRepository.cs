using AttendanceLog.Logic.Interfaces;
using AttendanceLog.Logic.Models;

namespace AttendanceLog.Data.Repositories;

/// <inheritdoc cref="IVisitRepository"/>
public class VisitRepository : IVisitRepository
{
    private readonly List<Visit> items =
    [
        new()
        {
            Id = 1,
            Student = "Абрамович В.А.",
            WasPresent = true
        },
        new()
        {
            Id = 2,
            Student = "Мамбетов Н.А.",
            WasPresent = true
        },
        new()
        {
            Id = 3,
            Student = "Соколов Б.М.",
            WasPresent = false
        }
    ];

    List<Visit> IVisitRepository.GetAll() => items;
}
