namespace TourOperatorApp.Models;

public class Instructor
{
    //Сведения об инструкторах содержат: идентификатор инструктора, фамилия, имя,
    //отчество, дата рождения, категория(А, В, С; А – низшая категория, С – высшая категория).
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BornDate { get; set; }
    public char Category { get; set; }
    public string ToShortInfo => $"{Name}({Category})";
    public Instructor(int id, string name, DateTime bornDate, char category)
    {
        Id = id;
        Name = name;
        BornDate = bornDate;
        Category = category;    
    }

    //строка содержащая имя и категорию интсруктора
}
