using System.ComponentModel.DataAnnotations;

namespace TourOperatorApp.Models.TourOperator;

public class Route
{
    //Сведения о туристических маршрутах содержат: 
    //идентификатор маршрута, начальный пункт маршрута, обязательный промежуточный пункт маршрута,
    //конечный пункт маршрута, протяженность маршрута в км(целое число),
    //сложность маршрута(значение из ряда А-, А, А+, В-, В, В+, С-, С, С+; А- соответствует минимальной сложности,
    //С+ соответствует максимальной сложности), фамилия и инициалы инструктора маршрута(всего на фирме работает
    //пять инструкторов, не требуется редактировать сведения об инструкторах).
    public int Id { get; set; }

    [Required(ErrorMessage = "Обязательно к заполнению")]
    [Display(Name = "Начальный пункт")]
    public string StartPoint { get; set; }

    [Required(ErrorMessage = "Обязательно к заполнению")]
    [Display(Name = "Промежуточный пункт")]
    public string BrakePoint { get; set; }

    [Required(ErrorMessage = "Обязательно к заполнению")]
    [Display(Name = "Конечный маршрута")]
    public string EndPoint { get; set; }

    [Required(ErrorMessage = "Обязательно к заполнению")]
    [Range(1, long.MaxValue, ErrorMessage = "Длина маршрута не может быть отрицательной или нулевой")]
    [Display(Name = "Длина маршрута")]
    public int Length { get; set; }

    [Required(ErrorMessage = "Обязательно к заполнению")]
    [Display(Name = "Сложность")]
    public string Difficulty { get; set; }

    public Instructor Instructor { get; set; }

    [Required(ErrorMessage = "Обязательно к заполнению")]
    [Display(Name = "Инструктор")]
    public int InstructorId { get; set; }

    public Route()
    {
        Id = -1;
    }

    public Route(int id, string startPoint, string brakePoint, string endPoint, int length, string difficulty, Instructor instructor)
    {
        Id = id;
        StartPoint = startPoint;
        BrakePoint = brakePoint;
        EndPoint = endPoint;
        Length = length;
        Difficulty = difficulty;
        Instructor = instructor;
        InstructorId = instructor.Id;
    }
}
