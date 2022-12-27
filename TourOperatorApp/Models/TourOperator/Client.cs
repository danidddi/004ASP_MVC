using System.ComponentModel.DataAnnotations;
using TourOperatorApp.Common;

namespace TourOperatorApp.Models.TourOperator;

public class Client
{

    [UIHint("HiddenInput")]
    public int Id { get; set; }


    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    [StringLength(100, ErrorMessage = "Не более 100 символов")]
    public string Name { get; set; }


    [Display(Name = "Возраст")]
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    [Range(18, 65, ErrorMessage = "Допустимый возраст от 18 до 65 лет")]
    public int Age { get; set; }


    [Display(Name = "Номер телефона")]
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    [UIHint("PhoneNumber")]
    public string PhoneNumber { get; set; }


    [Display(Name = "Электронная почта")]
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    [UIHint("EmailAddress")]
    public string EmailAddress { get; set; }


    private string _password;
    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    [UIHint("Password")]
    [MinLength(8, ErrorMessage = "Пароль слишком короткий")]
    [MaxLength(28, ErrorMessage = "Пароль слишком большой")]
    public string Password {
        get { 
           
            return  _password != null ? Utils.EncryptDecrypt(_password, 42) : ""; 
        } 
        set { _password = Utils.EncryptDecrypt(value, 42); } 
    }


    [Display(Name = "Постоянный клиент")]
    public bool IsRegular { get; set; }


    [Display(Name = "Фотография")]
    public string Img { get; set; }

    public Client()
    {
        Id = -1;
        Age = 18;
        Img = "default.png";
    }

    public Client(int id, string name, int age, string phone, string email, string password, bool isregular, string img)
    {
        Id = id;
        Name = name;    
        Age = age;
        PhoneNumber = phone;
        EmailAddress = email;
        Password = password;
        IsRegular = isregular;
        Img = img;
    }

}
