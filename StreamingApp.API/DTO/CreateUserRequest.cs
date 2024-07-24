using System.ComponentModel.DataAnnotations;

namespace StreamingApp.API.DTO
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid PlanId { get; set; }

        [Required]

        public CardRequest Card { get; set; }

    }

    public class CardRequest
    {
        public Boolean Active { get; set; }
        public Decimal Limit { get; set; }
        public String Number { get; set; }
    }
}
