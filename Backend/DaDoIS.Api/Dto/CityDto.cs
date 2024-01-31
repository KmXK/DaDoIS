namespace DaDoIS.Api;

/// <summary>
/// Сущность "Город"
/// </summary>
public record CityDto
{
    /// <summary>
    /// Идентификатор города
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Название города
    /// </summary>
    public required string Name { get; set; }
}

/// <summary>
/// Сущность "Создание города"
/// </summary>
public record CreateCityDto
{
    /// <summary>
    /// Название города
    /// </summary>
    public required string Name { get; set; }
}

/// <summary>
/// Сущность "Удаление города"
/// </summary>
public record DeleteCityDto
{
    /// <summary>
    /// Идентификатор города
    /// </summary>
    public int Id { get; set; }
}


