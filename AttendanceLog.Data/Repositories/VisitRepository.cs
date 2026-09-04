using AttendanceLog.Data.Models;

namespace AttendanceLog.Data.Repositories;

/// <summary>
/// Репозиторий для <see cref="Visit"/>
/// </summary>
public class VisitRepository
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

    /// <summary>
    /// Получить все посещения
    /// </summary>
    /// <returns></returns>
    public List<Visit> GetAll() => items;
}
