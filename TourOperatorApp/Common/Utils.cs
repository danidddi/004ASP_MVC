using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TourOperatorApp.Models.TourOperator;

namespace TourOperatorApp.Common;

public class Utils
{
    public static List<string> pointsList = new List<string> { "Херсон", "Олешковские пески", "Нова", "Ужгород", "Невицкое",
                                    "Карпаты", "Батурин", "Тростянец","Качановка","Винница", "Тульчин", "Буша",
                                    "Урыч", "Розгирче", "Бубнище", "Подольский", "Кривче", "Хотин","Черновцы",
                                    "Залещики", "Нырков", "Киев", "Буки", "Умань", "Коростень", "Волынский",
                                    "Корец", "Луцк", "Дубно", "Клевань" };
    public static List<string> difficultysList = new List<string> { "A-", "A", "A+",
                                                "B-", "B", "B+",
                                                "C-", "C", "C+"};
    public static List<Instructor> instructorsList = new List<Instructor> {
                new Instructor(0,"Верховетский Иван Андреевич", new DateTime(1990,10,23),'A'),
                new Instructor(1,"Пенов Андрей Иванович", new DateTime(1983,3,13),'B'),
                new Instructor(2,"Судиловский Петр Игоревич", new DateTime(1995,11,4),'C'),
                new Instructor(3,"Андреев Денис Петрович", new DateTime(1980,8,18),'A'),
                new Instructor(4,"Вершинин Игорь Денисович", new DateTime(1988,4,1),'C')};
    public static List<Models.TourOperator.Route> routesList = new List<Models.TourOperator.Route> {
                new Models.TourOperator.Route(0,"Херсон", "Олешковские пески", "Аскания-Нова", 167, "A-", instructorsList[0]),
                new Models.TourOperator.Route(1,"Ужгород", "Невицкое", "Карпаты", 80, "A", instructorsList[1]),
                new Models.TourOperator.Route(2,"Батурин", "Тростянец", "Качановка", 143, "A+", instructorsList[2]),
                new Models.TourOperator.Route(3,"Винница", "Тульчин", "Буша", 90, "B-", instructorsList[3]),
                new Models.TourOperator.Route(4,"Урыч", "Розгирче", "Бубнище", 100, "B", instructorsList[4]),
                new Models.TourOperator.Route(5,"Каменец-Подольский", "Кривче", "Хотин", 55, "B+", instructorsList[0]),
                new Models.TourOperator.Route(6,"Черновцы", "Залещики", "Нырков", 55, "C-", instructorsList[1]),
                new Models.TourOperator.Route(7,"Киев", "Буки", "Умань", 80, "C", instructorsList[2]),
                new Models.TourOperator.Route(8,"Коростень", "Новоград-Волынский", "Корец", 30, "C+", instructorsList[3]),
                new Models.TourOperator.Route(9,"Луцк", "Дубно", "Клевань", 70, "A-", instructorsList[4])};
    public static List<char> categorysList = new List<char> { 'A', 'B', 'C' };
    public static List<Client> clientsList = new List<Client>
    {
        new Client(0, "Петров Анатолий Андреевич", 42, "3807136294663", "home@mail.ru", "qwsddderty", true, "andreich.jpg"),
        new Client(1, "Ляшенко Виктория Александровна", 21, "3807139594663", "fgd@mail.ru", "assdcssdcd", false, "vika.jpg"),
        new Client(2, "Крыжко Максим Анатольевич", 24, "3807136234233", "sdf@mail.ru", "asdcsddcdd", true, "vasia.jpg"),
        new Client(3, "Истомин Антон Павлович", 25, "3807136234436", "sdfa@mail.ru", "qwsadcsderty", false, "vlad.jpg"),
        new Client(4, "Агафонов Василий Максимович", 36, "3807133424663", "erq@mail.ru", "asdcsdcssd", false, "ilja.jpg"),
        new Client(5, "Дмитерко Владимир Владимирович", 39, "3807136296565", "qwevf@mail.ru", "asdcasdcdc", false, "jenia.jpg"),
        new Client(6, "Дивидов Петр Александрович", 46, "3807125454663", "asfvd@mail.ru", "SDADSSasDdss", true, "juzep.jpg"),
        new Client(7, "Ган Христиан Андерсон", 51, "3807136245553", "sqeg@mail.ru", "qwsadsdcerty", true, "gop.jpg"),
    };

    public static string EncryptDecrypt(string data, int key)
    {

        return System.Text.Encoding.UTF8.GetString(System.Text.Encoding.UTF8.GetBytes(data)
                .Select(x => (byte)(x ^ key))
                .ToArray());
    }

    #region Serializetion 
    public static void Serialize<T>(string path, List<T> items)
        => File.WriteAllText(path, JsonConvert.SerializeObject(items));
    public static List<T> Deserialize<T>(string path)
        => JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path))!;
    #endregion
}

