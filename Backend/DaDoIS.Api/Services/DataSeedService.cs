using AutoMapper;
using DaDoIS.Data;
using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Services;

/// <summary>
/// Сервис для заполнения базы данных начальными значениями
/// </summary>
public class DataSeedService(AppDbContext dbContext, IMapper mapper)
{
    /// <summary>
    /// Заполнение базы данных начальными значениями
    /// </summary>
    public void Seed()
    {
        if (!dbContext.Cities.Any() && !dbContext.Citizenship.Any() && !dbContext.Cities.Any())
        {
            dbContext.Cities.AddRange(
                new List<City>
                {
                    new() { Name = "Брест" },
                    new() { Name = "Витебск" },
                    new() { Name = "Гомель" },
                    new() { Name = "Гродно" },
                    new() { Name = "Минск" },
                    new() { Name = "Могилев" },
                }
            );

            dbContext.SaveChanges();

            dbContext.Citizenship.AddRange(
                new List<Citizenship>
                {
                    new() { Name = "Республика Беларусь" },
                    new() { Name = "Российская Федерация" },
                }
            );

            dbContext.SaveChanges();

            dbContext.Clients.AddRange(
                new List<CreateClientDto>
                {
                    new() {
                        FirstName = "Олег",
                        LastName = "Олегович",
                        Patronymic = "Олегович",
                        BirthDate = DateTime.Parse("2000-01-09"),
                        Gender = GenderType.Male,
                        PassportSeries = "MP",
                        PassportNumber = "2345234",
                        PassportIssuer = "кем-то",
                        PassportIssueDate = DateTime.Parse("2015-01-01"),
                        IdentificationNumber = "7911111A000PB8",
                        BirthPlace = "Минск",
                        LivingCityId = dbContext.Cities.First().Id,
                        LivingAddress = "Минск, ул. Пушкина, д. 23",
                        RegistrationCityId = dbContext.Cities.First().Id,
                        RegistrationAddress = "Минск, ул. Пушкина, д. 23",
                        MaritalStatus = MaritalStatus.Single,
                        CitizenshipId = dbContext.Citizenship.First().Id,
                        DisabilityGroup = DisabilityGroup.None,
                        IsRetired = false,
                        IsLiableForMilitaryService = true,
                    },

                }.Select(mapper.Map<Client>)
            );

            dbContext.SaveChanges();
        }
    }
}