namespace MyMicroservice.Domain.Entities;

public class Tio
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string Nombre { get; set; }
}
