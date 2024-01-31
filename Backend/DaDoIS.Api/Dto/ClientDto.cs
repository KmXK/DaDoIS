using DaDoIS.Data.Entities;

namespace DaDoIS.Api;

/// <summary>
/// Сущность "Клиент"
/// </summary>
public record ClientDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public required string Patronymic { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public GenderType Gender { get; set; }

    /// <summary>
    /// Серия паспорта
    /// </summary>
    public required string PassportSeries { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Кем был выдан паспорт
    /// </summary>
    public required string PassportIssuer { get; set; }

    /// <summary>
    /// Дата выдачи паспорта
    /// </summary>
    public DateTime PassportIssueDate { get; set; }

    /// <summary>
    /// Идентификационный номер паспорта
    /// </summary>
    public required string IdentificationNumber { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public required string BirthPlace { get; set; }

    /// <summary>
    /// Id города фактического проживания
    /// </summary>
    public required int LivingCityId { get; set; }

    /// <summary>
    /// Адрес фактического проживания
    /// </summary>
    public required string LivingAddress { get; set; }

    /// <summary>
    /// Номер домашнего телефона
    /// </summary>
    public string? HomePhoneNumber { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// E-mail
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Место работы
    /// </summary>
    public string? WorkPlace { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// Id города прописки
    /// </summary>
    public required int RegistrationCityId { get; set; }

    /// <summary>
    /// Адрес прописки
    /// </summary>
    public required string RegistrationAddress { get; set; }

    /// <summary>
    /// Семейное положение
    /// </summary>
    public MaritalStatus MaritalStatus { get; set; }

    /// <summary>
    /// Id гражданство
    /// </summary>
    public required int CitizenshipId { get; set; }

    /// <summary>
    /// Инвалидность
    /// </summary>
    public DisabilityGroup DisabilityGroup { get; set; }

    /// <summary>
    /// Пенсионер
    /// </summary>
    public bool IsRetired { get; set; }

    /// <summary>
    /// Ежемесячный доход
    /// </summary>
    public double? Salary { get; set; }

    /// <summary>
    /// Военнообязанный
    /// </summary>
    public bool IsLiableForMilitaryService { get; set; }
}

/// <summary>
/// Сущность "Создание клиента"
/// </summary>
public record CreateClientDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public required string Patronymic { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public GenderType Gender { get; set; }

    /// <summary>
    /// Серия паспорта
    /// </summary>
    public required string PassportSeries { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// Кем был выдан паспорт
    /// </summary>
    public required string PassportIssuer { get; set; }

    /// <summary>
    /// Дата выдачи паспорта
    /// </summary>
    public DateTime PassportIssueDate { get; set; }

    /// <summary>
    /// Идентификационный номер паспорта
    /// </summary>
    public required string IdentificationNumber { get; set; }

    /// <summary>
    /// Место рождения
    /// </summary>
    public required string BirthPlace { get; set; }

    /// <summary>
    /// Id города фактического проживания
    /// </summary>
    public required int LivingCityId { get; set; }

    /// <summary>
    /// Адрес фактического проживания
    /// </summary>
    public required string LivingAddress { get; set; }

    /// <summary>
    /// Номер домашнего телефона
    /// </summary>
    public string? HomePhoneNumber { get; set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// E-mail
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Место работы
    /// </summary>
    public string? WorkPlace { get; set; }

    /// <summary>
    /// Должность
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// Id города прописки
    /// </summary>
    public required int RegistrationCityId { get; set; }

    /// <summary>
    /// Адрес прописки
    /// </summary>
    public required string RegistrationAddress { get; set; }

    /// <summary>
    /// Семейное положение
    /// </summary>
    public MaritalStatus MaritalStatus { get; set; }

    /// <summary>
    /// Id гражданство
    /// </summary>
    public required int CitizenshipId { get; set; }

    /// <summary>
    /// Инвалидность
    /// </summary>
    public DisabilityGroup DisabilityGroup { get; set; }

    /// <summary>
    /// Пенсионер
    /// </summary>
    public bool IsRetired { get; set; }

    /// <summary>
    /// Ежемесячный доход
    /// </summary>
    public double? Salary { get; set; }

    /// <summary>
    /// Военнообязанный
    /// </summary>
    public bool IsLiableForMilitaryService { get; set; }
}

/// <summary>
/// Сущность "Удаление клиента"
/// </summary>
public record DeleteClientDto
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid Id { get; set; }
}

