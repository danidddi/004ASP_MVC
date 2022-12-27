using System.ComponentModel.DataAnnotations;

namespace TourOperatorApp.Models.ViewModels
{
    public class RoutesViewModel
    {
        public IEnumerable<TourOperatorApp.Models.TourOperator.Route> Routes { get; set; }

        [Display(Name = "От")]
        [Required(ErrorMessage ="Поле должно быть заполнено")]
        [Range(1, Int64.MaxValue, ErrorMessage = "Минимальное значение не может быть отрицательным или нулевым")]
        public int Min { get; set; }

        [Display(Name = "До")]
        [Required(ErrorMessage ="Поле должно быть заполнено")]
        [Range(1, Int64.MaxValue, ErrorMessage = "Минимальное значение не может быть отрицательным или нулевым")]
        public int Max { get; set; }

        public string RoutePoint { get; set; }

    }
}
