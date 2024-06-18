using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la reserva es obligatorio.")]
        public string ReservationName { get; set; }

        [Required(ErrorMessage = "El ID de la habitación es obligatorio.")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int ClientId { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        [DateGreaterThan("StartDate", ErrorMessage = "La fecha de fin debe ser posterior a la fecha de inicio.")]
        public DateTime EndDate { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public Room Room { get; set; }
    }

    // Custom validation attribute to ensure EndDate is greater than StartDate
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(ErrorMessage);

            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (currentValue <= comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}

