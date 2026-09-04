using AttendanceLog.Data.Models;
using AttendanceLog.Data.Repositories;

namespace AttendanceLog.Logic.Services;

/// <summary>
/// Сервис для работы с <see cref="Visit"/>
/// </summary>
public class VisitService
{
    private readonly VisitRepository repository = new();

    /// <summary>
    /// Получить всех отсутствующих
    /// </summary>
    public List<Visit> GetAbsent()
        => repository.GetAll()
            .Where(item => !item.WasPresent)
            .ToList();
}
