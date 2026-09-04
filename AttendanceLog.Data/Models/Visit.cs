namespace AttendanceLog.Data.Models;

/// <summary>
/// Посещение студента
/// </summary>
public class Visit
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ФИО студента
    /// </summary>
    public string Student { get; set; } = string.Empty;

    /// <summary>
    /// Присутсвовал ли студент
    /// </summary>
    public bool WasPresent { get; set; }
}
