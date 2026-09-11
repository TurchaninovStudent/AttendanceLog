using AttendanceLog.Logic.Models;

namespace AttendanceLog.Logic.Interfaces;

/// <summary>
/// Репозиторий для <see cref="Visit"/>
/// </summary>
public interface IVisitRepository
{
    /// <summary>
    /// Получить все посещения
    /// </summary>
    List<Visit> GetAll();

    /// <summary>
    /// Добавить запись о посещении
    /// </summary>
    void Add(Visit visit);
}
