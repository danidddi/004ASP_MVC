using System.ComponentModel.DataAnnotations;
using TourOperatorApp.Models.TourOperator;

namespace TourOperatorApp.Models.ViewModels;

public class ClientsViewModel
{
    public IEnumerable<Client> Clients { get; set; }

    [Display(Name="Поиск по фамилии:")]
    [Required(ErrorMessage ="Поле не может быть пустым")]
    public string Surname { get; set; }


    [Display(Name = "От")]
    [Required(ErrorMessage ="Поле не может быть пустым")]
    [Range(18, 65, ErrorMessage = "Допустимый возраст от 18 до 65 лет.")]
    public int Min { get; set; }

    [Display(Name = "До")]
    [Required(ErrorMessage ="Поле не может быть пустым")]
    [Range(18, 65, ErrorMessage = "Допустимый возраст от 18 до 65 лет.")]
    public int Max { get; set; }
}
