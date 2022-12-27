using System.ComponentModel.DataAnnotations;

namespace TourOperatorApp.Models.TourOperator;

public class Instructor
{
    //Сведения об инструкторах содержат

    //идентификатор инструктора
    [UIHint("HiddenInput")]
    public int Id { get; set; }

    //фамилия, имя, отчество
    [Display(Name = "Имя")] // это текст, выводимый в label, декорированной asp-for
    [Required(ErrorMessage ="Поле обязательно к заполнению")]
    [StringLength(100,ErrorMessage = "Не более 100 символов")]
    public string Name { get; set; }

    //дата рождения
    [Display(Name = "Дата рождения")]
    [Required(ErrorMessage ="Поле обязательно к заполнению")]
    [UIHint("Date")] // параметры отображения, не нужно прописывать тип input
    public DateTime BornDate { get; set; }

    //категория(А, В, С; А – низшая категория, С – высшая категория)
    [Display(Name = "Категория")] 
    [Required(ErrorMessage ="Поле обязательно к заполнению")]
    public char Category { get; set; }

    // имя и категория - свойство только для чтения
    [UIHint("HiddenInput")] public string ToShortInfo => $"{Name}({Category})";

    public Instructor()
    {

    }
    public Instructor(int id, string name, DateTime bornDate, char category)
    {
        Id = id;
        Name = name;
        BornDate = bornDate;
        Category = category;
    }

}
