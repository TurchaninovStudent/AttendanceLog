using System.Xml.Serialization;
using AttendanceLog.Logic.Interfaces;
using AttendanceLog.Logic.Models;

namespace AttendanceLog.Data.Repositories;

/// <summary>
/// <see cref="IVisitRepository"/>, сохраняющий данные в файл в формате xml
/// </summary>
public class XmlVisitRepository : IVisitRepository
{
    private readonly string path;
    private readonly XmlSerializer serializer =
        new(typeof(List<Visit>));

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="JsonVisitRepository"/>
    /// </summary>
    public XmlVisitRepository(string path)
    {
        this.path = path;
    }

    /// <inheritdoc/>
    public List<Visit> GetAll()
    {
        if (!File.Exists(path))
        {
            return [];
        }

        using var reader = new StreamReader(path);
        return serializer.Deserialize(reader) as List<Visit> ?? [];
    }

    void IVisitRepository.Add(Visit item)
    {
        var items = GetAll();
        items.Add(item);

        using var writer = new StreamWriter(path);
        serializer.Serialize(writer, items);
    }
}
