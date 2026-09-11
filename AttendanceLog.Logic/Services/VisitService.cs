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

    /// <summary>
    /// Добавить запись о посещяемости
    /// </summary>
    public void AddVisit(string student, bool wasPresent)
    {
        if (string.IsNullOrWhiteSpace(student))
        {
            return;
        }
        int nextId = visitRepository.GetAll().Count + 1;
        visitRepository.Add(new Visit
        {
            Id = nextId,
            Student = student,
            WasPresent = wasPresent
        });
    }

    /// <summary>
    /// Получить долю пропусков в проценте
    /// </summary>
    public float GetAbsencePersentage()
    {
        var all = visitRepository.GetAll();
        var absenceCount = all.Where(x => !x.WasPresent).Count();
        return ((float)absenceCount / (float)all.Count);
    }
}
