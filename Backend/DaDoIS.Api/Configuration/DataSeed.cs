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
            !db.DepositContracts.Any() &&
            !db.Credits.Any() &&
            !db.CreditContracts.Any() &&
            !db.BankAccounts.Any() &&
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
                    new() {
                        FirstName = "Бондарь",
                        LastName = "Алексей",
                        Patronymic = "Дмитриевич",
                        BirthDate = DateTime.Parse("2003-03-04"),
                        Gender = GenderType.Male,
                        PassportSeries = "MP",
                        PassportNumber = "2345290",
                        PassportIssuer = "кем-то",
                        PassportIssueDate = DateTime.Parse("2015-01-01"),
                        IdentificationNumber = "7911111A011PB8",
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
                    new() {
                        FirstName = "Гуйдо",
                        LastName = "Кирилл",
                        Patronymic = "Игоревич",
                        BirthDate = DateTime.Parse("2003-04-03"),
                        Gender = GenderType.Male,
                        PassportSeries = "MP",
                        PassportNumber = "2345810",
                        PassportIssuer = "кем-то",
                        PassportIssueDate = DateTime.Parse("2015-01-01"),
                        IdentificationNumber = "7911111A221PB8",
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
                    new() {
                        FirstName = "Кредитов",
                        LastName = "Кредит",
                        Patronymic = "Кредитович",
                        BirthDate = DateTime.Parse("2000-01-01"),
                        Gender = GenderType.Male,
                        PassportSeries = "MP",
                        PassportNumber = "2435810",
                        PassportIssuer = "кем-то",
                        PassportIssueDate = DateTime.Parse("2015-01-01"),
                        IdentificationNumber = "7911221A221PB8",
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
                    new() {
                        FirstName = "Депозитов",
                        LastName = "Депозит",
                        Patronymic = "Депозитович",
                        BirthDate = DateTime.Parse("2000-02-02"),
                        Gender = GenderType.Male,
                        PassportSeries = "MP",
                        PassportNumber = "2456810",
                        PassportIssuer = "кем-то",
                        PassportIssueDate = DateTime.Parse("2015-01-01"),
                        IdentificationNumber = "7913321A221PB8",
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
                    new() {
                        FirstName = "Банкоматов",
                        LastName = "Банкомат",
                        Patronymic = "Банкоматович",
                        BirthDate = DateTime.Parse("2000-02-02"),
                        Gender = GenderType.Male,
                        PassportSeries = "MP",
                        PassportNumber = "4156810",
                        PassportIssuer = "кем-то",
                        PassportIssueDate = DateTime.Parse("2015-01-01"),
                        IdentificationNumber = "7913388A221PB8",
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
                        AccountType = AccountType.Passive,
                        TypeOfAccount = TypeOfAccount.Main

                    },
                    new () {
                        Debit = 0,
                        Credit = 0,
                        CurrencyId = 1,
                        Currency = db.Currencies.Find(1)!,
                        AccountType = AccountType.Active,
                        TypeOfAccount = TypeOfAccount.Cash
                    },
                    new () {
                        Debit = 0,
                        Credit = 0,
                        CurrencyId = 1,
                        Currency = db.Currencies.Find(1)!,
                        AccountType = AccountType.Passive,
                        TypeOfAccount = TypeOfAccount.MTS
                    },
                    new () {
                        Debit = 0,
                        Credit = 0,
                        CurrencyId = 1,
                        Currency = db.Currencies.Find(1)!,
                        AccountType = AccountType.Passive,
                        TypeOfAccount = TypeOfAccount.A1
                    },
                }
            );
            db.SaveChanges();

            db.Deposits.AddRange(
                new List<Deposit>(){
                    new() {
                        Name = "Online-стратегия",
                        Interest = 0.10,
                        Period = 90,
                        IsRevocable = true,
                        Currency = db.Currencies.Find(1)!,
                        CurrencyId = 1
                    },
                    new() {
                        Name = "Online-решение new",
                        Interest = 0.135,
                        Period = 30,
                        IsRevocable = false,
                        Currency = db.Currencies.Find(1)!,
                        CurrencyId = 1
                    }
                }
            );
            db.SaveChanges();

            db.Credits.AddRange(
                new List<Credit>(){
                    new(){
                        Name = "R-деньги mix",
                        Interest = 0.20,
                        Period = 30 * 6,
                        IsAnnuity = true,
                        Currency = db.Currencies.Find(1)!,
                        CurrencyId = 1
                    },
                    new(){
                        Name = "R-деньги light",
                        Interest = 0.16,
                        Period = 2 * 30,
                        IsAnnuity = false,
                        Currency = db.Currencies.Find(1)!,
                        CurrencyId = 1
                    }
                }
            );
            db.SaveChanges();
        }
    }
}