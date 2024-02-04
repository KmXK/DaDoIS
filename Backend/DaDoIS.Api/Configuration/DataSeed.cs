using AutoMapper;
using DaDoIS.Api.Dto;
using DaDoIS.Data;
using DaDoIS.Data.Entities;

namespace DaDoIS.Api.Configuration;

public class DataSeed(AppDbContext db, IMapper mapper)
{
    public void Seed()
    {
        if (
            !db.Cities.Any() &&
            !db.Citizenship.Any() &&
            !db.Clients.Any() &&
            !db.Currencies.Any() &&
            !db.Deposits.Any() &&
            !db.BankAccounts.Any() &&
            !db.DepositContracts.Any() &&
            !db.TransitLogs.Any()
        )
        {
            db.Cities.AddRange(
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
            db.SaveChanges();

            db.Citizenship.AddRange(
                new List<Citizenship>
                {
                    new() { Name = "Республика Беларусь" },
                    new() { Name = "Российская Федерация" },
                }
            );
            db.SaveChanges();

            db.Clients.AddRange(
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
                        LivingCityId = db.Cities.First().Id,
                        LivingAddress = "Минск, ул. Пушкина, д. 23",
                        RegistrationCityId = db.Cities.First().Id,
                        RegistrationAddress = "Минск, ул. Пушкина, д. 23",
                        MaritalStatus = MaritalStatus.Single,
                        CitizenshipId = db.Citizenship.First().Id,
                        DisabilityGroup = DisabilityGroup.None,
                        IsRetired = false,
                        IsLiableForMilitaryService = true,
                    },

                }.Select(mapper.Map<Client>)
            );
            db.SaveChanges();

            db.Currencies.AddRange(
                new List<Currency>(){
                    new() {
                        Name = "BYN",
                        ExchangeRate = 1
                    },
                    new() {
                        Name = "RUB",
                        ExchangeRate = 0.03513
                    },
                    new() {
                        Name = "USD",
                        ExchangeRate = 3.20
                    },
                    new() {
                        Name = "EUR",
                        ExchangeRate = 3.485
                    },
                }
            );
            db.SaveChanges();

            db.BankAccounts.AddRange(
                new List<BankAccount>(){
                    new () {
                        Debit = 0,
                        Credit = 100_000_000_000,
                        CurrencyId = 1,
                        Currency = db.Currencies.Find(1)!,
                        Type = AccountType.Main,
                    },
                    new () {
                        Debit = 0,
                        Credit =0,
                        CurrencyId = 1,
                        Currency = db.Currencies.Find(1)!,
                        Type = AccountType.Cash,
                    },
                }
            );
            db.SaveChanges();

            db.Deposits.AddRange(
                new List<Deposit>(){
                    new() {
                        Name = "Online-стратегия",
                        Interest = 10,
                        Period = 90,
                        IsRevocable = true,
                    },
                    new() {
                        Name = "Online-решение new",
                        Interest = 13.5,
                        Period = 9 * 30,
                        IsRevocable = false
                    }
                }
            );
            db.SaveChanges();
        }
    }
}