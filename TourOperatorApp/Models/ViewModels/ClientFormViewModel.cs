using System.ComponentModel.DataAnnotations;

namespace TourOperatorApp.Models.ViewModels;

public class ClientFormViewModel
{
    [Display(Name="Фото")]
    public IFormFile? ImgFile { get; set; }
    public Models.TourOperator.Client  Client { get; set; }
}
