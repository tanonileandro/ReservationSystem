using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de habitación es obligatorio.")]
        public RoomType Type { get; set; }

        [Required(ErrorMessage = "La capacidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad debe ser al menos 1.")]
        public int Capacity { get; set; }

        public bool Available { get; set; }

        [Required(ErrorMessage = "El número de dormitorios es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de dormitorios debe ser al menos 1.")]
        public int Bedrooms { get; set; }
    }

    public enum RoomType
    {
        Single,
        Double,
        Suite,
        Family
    }
}

