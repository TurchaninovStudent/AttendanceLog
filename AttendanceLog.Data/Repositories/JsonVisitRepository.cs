using System.Text.Encodings.Web;
using System.Text.Json;
using AttendanceLog.Logic.Interfaces;
using AttendanceLog.Logic.Models;

namespace AttendanceLog.Data.Repositories;

/// <summary>
/// <see cref="IVisitRepository"/>, сохраняющий данные в файл в формате json
/// </summary>
public class JsonVisitRepository : IVisitRepository
{
    private readonly string path;
    private readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="JsonVisitRepository"/>
    /// </summary>
    /// <param name="path"></param>
    public JsonVisitRepository(string path)
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

        var text = File.ReadAllText(path);
        try
        {
            return JsonSerializer.Deserialize<List<Visit>>(text) ?? [];
        }
        catch (JsonException)
        {
            return [];
        }
    }

    void IVisitRepository.Add(Visit item)
    {
        var items = GetAll();
        items.Add(item);

        var text = JsonSerializer.Serialize(items, options);
        File.WriteAllText(path, text);
    }
}
