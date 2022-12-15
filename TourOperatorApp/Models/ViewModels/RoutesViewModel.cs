using System.ComponentModel.DataAnnotations;

namespace TourOperatorApp.Models.ViewModels
{
    public class RoutesViewModel
    {
        public List<TourOperatorApp.Models.TourOperator.Route> Routes { get; set; }

        [Display(Name = "От")]
        [Range(1, Int64.MaxValue, ErrorMessage = "Минимальное значение не может быть отрицательным или нулевым"),]
        public int Min { get; set; }
        [Display(Name = "До")]
        [Range(1, Int64.MaxValue, ErrorMessage = "Минимальное значение не может быть отрицательным или нулевым"),]
        public int Max { get; set; }
    }
}
