using Microsoft.EntityFrameworkCore;
using MIS.Core.Entities;
using MIS.Core.Enums;

namespace MIS.Infrastructure.Persistence;

/// <summary>
/// Наполняет пустую базу демонстрационными данными. Все значения вымышленные:
/// СНИЛС и номера полисов — заведомо синтетические шаблоны, не принадлежащие людям.
/// </summary>
internal static class DatabaseSeeder
{
    public static async Task SeedAsync(MisDbContext db, CancellationToken cancellationToken = default)
    {
        if (await db.Patients.AnyAsync(cancellationToken))
        {
            return;
        }

        var diabetes = new Disease { IcdCode = "E11.9", Name = "Сахарный диабет 2 типа" };
        var hypertension = new Disease { IcdCode = "I10", Name = "Эссенциальная гипертензия" };
        var acuteRespiratory = new Disease { IcdCode = "J06.9", Name = "Острая инфекция верхних дыхательных путей" };
        var asthma = new Disease { IcdCode = "J45.9", Name = "Астма неуточнённая" };
        var reflux = new Disease { IcdCode = "K21.0", Name = "Гастроэзофагеальный рефлюкс с эзофагитом" };
        var backPain = new Disease { IcdCode = "M54.5", Name = "Боль внизу спины" };
        var myopia = new Disease { IcdCode = "H52.1", Name = "Миопия" };
        var migraine = new Disease { IcdCode = "G43.9", Name = "Мигрень неуточнённая" };

        db.Diseases.AddRange(
            diabetes, hypertension, acuteRespiratory, asthma,
            reflux, backPain, myopia, migraine);

        db.Doctors.AddRange(
            new Doctor
            {
                Id = Guid.Parse("64c92d45-7a59-491b-aab5-683d49526eac"),
                ExternalId = "MIS-D-0017",
                LastName = "Нечаева",
                FirstName = "Ольга",
                MiddleName = "Владимировна",
                Specialty = Specialty.Cardiologist,
                Room = "214"
            },
            new Doctor
            {
                Id = Guid.Parse("796e7e51-bcff-4292-bc13-7e31ec14de48"),
                LastName = "Громов",
                FirstName = "Павел",
                MiddleName = "Андреевич",
                Specialty = Specialty.Therapist,
                Room = "102"
            },
            new Doctor
            {
                Id = Guid.Parse("e23b2473-bd92-42ad-a9c6-2c0ba5afcd82"),
                LastName = "Савельев",
                FirstName = "Игорь",
                MiddleName = "Леонидович",
                Specialty = Specialty.Neurologist,
                Room = "318"
            },
            new Doctor
            {
                Id = Guid.Parse("ed0e0f60-48da-4889-9121-22388ee22066"),
                ExternalId = "MIS-D-0042",
                LastName = "Данилова",
                FirstName = "Екатерина",
                MiddleName = "Юрьевна",
                Specialty = Specialty.Pediatrician,
                Room = "105"
            },
            new Doctor
            {
                Id = Guid.Parse("b87b60f6-ef61-4133-ad91-245367342c38"),
                LastName = "Терехин",
                FirstName = "Максим",
                MiddleName = "Борисович",
                Specialty = Specialty.Surgeon,
                Room = "220"
            },
            new Doctor
            {
                Id = Guid.Parse("79ea0162-20c0-4082-a194-6a3994ac7765"),
                LastName = "Лебедева",
                FirstName = "Вера",
                MiddleName = "Станиславовна",
                Specialty = Specialty.Ophthalmologist,
                Room = "311"
            });

        db.Patients.AddRange(
            new Patient
            {
                Id = Guid.Parse("0d5f8a21-6c3e-4f0b-9a7d-11c2e5b4a890"),
                ExternalId = "MIS-00412",
                LastName = "Соколов",
                FirstName = "Артём",
                MiddleName = "Игоревич",
                BirthDate = new DateOnly(1987, 3, 14),
                Sex = Sex.Male,
                Snils = "111-111-111 11",
                OmsPolicy = "1111111111111111",
                Phone = "+7 900 000-00-01",
                Diseases = { diabetes, hypertension }
            },
            new Patient
            {
                Id = Guid.Parse("1a6c4b78-2d91-4e55-8f30-5c7e9a1b2d44"),
                LastName = "Нестерова",
                FirstName = "Марина",
                MiddleName = "Петровна",
                BirthDate = new DateOnly(1992, 7, 2),
                Sex = Sex.Female,
                Snils = "222-222-222 22",
                OmsPolicy = "2222222222222222",
                Phone = "+7 900 000-00-02",
                Diseases = { migraine }
            },
            new Patient
            {
                Id = Guid.Parse("2b7d5c89-3e02-4f66-9041-6d8f0b2c3e55"),
                ExternalId = "MIS-00987",
                LastName = "Галкин",
                FirstName = "Денис",
                MiddleName = "Сергеевич",
                BirthDate = new DateOnly(1975, 11, 28),
                Sex = Sex.Male,
                Snils = "333-333-333 33",
                OmsPolicy = "3333333333333333",
                Phone = "+7 900 000-00-03",
                Diseases = { backPain, reflux }
            },
            new Patient
            {
                Id = Guid.Parse("3c8e6d90-4f13-4077-a152-7e901c3d4f66"),
                LastName = "Абрамова",
                FirstName = "Лидия",
                MiddleName = "Фёдоровна",
                BirthDate = new DateOnly(1948, 1, 19),
                Sex = Sex.Female,
                Snils = "444-444-444 44",
                OmsPolicy = "4444444444444444",
                Phone = "+7 900 000-00-04",
                Diseases = { hypertension, diabetes, myopia }
            },
            new Patient
            {
                Id = Guid.Parse("4d9f7e01-5024-4188-b263-8f012d4e5007"),
                LastName = "Юсупов",
                FirstName = "Тимур",
                MiddleName = "Рустамович",
                BirthDate = new DateOnly(2016, 5, 30),
                Sex = Sex.Male,
                Snils = "555-555-555 55",
                OmsPolicy = "5555555555555555",
                Phone = "+7 900 000-00-05",
                Diseases = { asthma, acuteRespiratory }
            },
            new Patient
            {
                Id = Guid.Parse("5e0a8f12-6135-4299-c374-9012e5f60118"),
                LastName = "Кравцова",
                FirstName = "Алина",
                MiddleName = "Олеговна",
                BirthDate = new DateOnly(2001, 9, 8),
                Sex = Sex.Female,
                Snils = "666-666-666 66",
                OmsPolicy = "6666666666666666",
                Phone = "+7 900 000-00-06",
                Diseases = { myopia }
            });

        await db.SaveChangesAsync(cancellationToken);
    }
}
