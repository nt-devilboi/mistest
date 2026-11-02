using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MIS.Core.Abstractions;
using MIS.Infrastructure.Persistence;
using MIS.Infrastructure.Persistence.Repositories;

namespace MIS.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Регистрирует DbContext и репозитории. Благодаря этому Program.cs остаётся
    /// единственным местом в MIS.Api, которое знает о существовании EF.
    /// </summary>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string? connectionString)
    {
        services.AddDbContext<MisDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IDiseaseRepository, DiseaseRepository>();

        return services;
    }

    /// <summary>
    /// Накатывает недостающие миграции и наполняет пустую базу демо-данными.
    /// MigrateAsync идемпотентен: если применять нечего, он не делает ничего.
    /// </summary>
    public static async Task MigrateAndSeedAsync(
        this IServiceProvider services,
        CancellationToken cancellationToken = default)
    {
        await using var scope = services.CreateAsyncScope();

        var db = scope.ServiceProvider.GetRequiredService<MisDbContext>();

        await db.Database.MigrateAsync(cancellationToken);
        await DatabaseSeeder.SeedAsync(db, cancellationToken);
    }
}
