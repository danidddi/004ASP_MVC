namespace TourOperatorApp.Models;

public class Route
{
    //Сведения о туристических маршрутах содержат: 
    //идентификатор маршрута, начальный пункт маршрута, обязательный промежуточный пункт маршрута,
    //конечный пункт маршрута, протяженность маршрута в км(целое число),
    //сложность маршрута(значение из ряда А-, А, А+, В-, В, В+, С-, С, С+; А- соответствует минимальной сложности,
    //С+ соответствует максимальной сложности), фамилия и инициалы инструктора маршрута(всего на фирме работает
    //пять инструкторов, не требуется редактировать сведения об инструкторах).
    public int Id { get; set; }
    public string StartPoint { get; set; }
    public string BrakePoint { get; set; }
    public string EndPoint { get; set; }
    public int Length { get; set; }
    public string Difficulty { get; set; }
    public Instructor Instructor { get; set; }
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
