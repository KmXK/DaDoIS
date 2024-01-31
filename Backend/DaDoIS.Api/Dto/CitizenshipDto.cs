namespace DaDoIS.Api;

/// <summary>
/// Сущность "Гражданство"
/// </summary>
public record CitizenshipDto
{
    /// <summary>
    /// Идентификатор гражданства
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название гражданства
    /// </summary>
    public required string Name { get; set; }
}

/// <summary>
/// Сущность "Создание гражданства"
/// </summary>
public record CreateCitizenshipDto
{
    /// <summary>
    /// Название гражданства
    /// </summary>
    public required string Name { get; set; }
}

/// <summary>
/// Сущность "Удаление гражданства"
/// </summary>
public record DeleteCitizenshipDto
{
    /// <summary>
    /// Идентификатор гражданства
    /// </summary>
    public int Id { get; set; }
}
