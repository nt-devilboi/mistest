namespace MIS.Core.Entities;

public class Disease
{
    public int Id { get; set; }

    /// <summary>Код МКБ-10, например E11.9. Естественный ключ нозологии.</summary>
    public required string IcdCode { get; set; }

    public required string Name { get; set; }

    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
