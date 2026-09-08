using AttendanceLog.Logic.Interfaces;
using AttendanceLog.Logic.Models;

namespace AttendanceLog.Logic.Services;

/// <summary>
/// Сервис для работы с <see cref="Visit"/>
/// </summary>
public class VisitService
{
    private readonly IVisitRepository visitRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="VisitService"/>
    /// </summary>
    public VisitService(IVisitRepository visitRepository)
    {
        this.visitRepository = visitRepository;
    }

    /// <summary>
    /// Получить всех отсутствующих
    /// </summary>
    public List<Visit> GetAbsent()
        => visitRepository.GetAll()
            .Where(item => !item.WasPresent)
            .ToList();
}
