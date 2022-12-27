using Microsoft.AspNetCore.Mvc;
using TourOperatorApp.Common;
using TourOperatorApp.Models.TourOperator;
using TourOperatorApp.Models.ViewModels;

namespace TourOperatorApp.Controllers;

public class TouristAgencyController : Controller
{
    public TouristAgency TouristAgency { get; set; }

    public TouristAgencyController()
    {
        TouristAgency = new TouristAgency();
    }

    #region Клиенты
    //вывод клиентов
    public IActionResult Clients() => View("Clients", new ClientsViewModel { Clients = TouristAgency.Clients });
    //добавление клиента 
    public IActionResult AddClient()
    {
        ViewBag.IsEdite = false;
        return View("ClientForm", new ClientFormViewModel { Client = new Client() });
    }
    //редактирование клиента 
    public IActionResult EditeClient(int id)
    {
        ViewBag.IsEdite = true;
        return View("ClientForm", new ClientFormViewModel { Client = TouristAgency.Clients.Find(x => x.Id == id) });
    }
    //добавление или редактирвоание клиента
    public async Task<IActionResult> CreateOrUpdateClientAsync(Client client, IFormFile ImgFile)
    {
        if (ImgFile != null)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\clients\\", ImgFile.FileName);
            using var fileStream = new FileStream(path, FileMode.Create);
            await ImgFile.CopyToAsync(fileStream);
            client.Img = ImgFile!.FileName;
        }


        if (client.Id == -1)
        {
            client.Id = TouristAgency.GetNewClientId();
            TouristAgency.AddClient(client);
        }
        else
            TouristAgency.UpdateClient(client);

        return View("Clients", new ClientsViewModel { Clients = TouristAgency.Clients });
    }
    //удаление клиента 
    public IActionResult DeleteClient(int id)
    {
        TouristAgency.RemoveClient(TouristAgency.Clients.Find(x => x.Id == id));
        return View("Clients", new ClientsViewModel { Clients = TouristAgency.Clients });
    }
    //сортировка по имени
    public IActionResult ClsSortByName() => View("Clients"
        , new ClientsViewModel { Clients = TouristAgency.Clients.OrderBy(x => x.Name) });
    //сортировка по убыванию возраста
    public IActionResult ClsSortByAgeDesc() => View("Clients"
        , new ClientsViewModel { Clients = TouristAgency.Clients.OrderByDescending(x => x.Age) });
    //вывод только постоянных клиентов
    public IActionResult ClsShowByRegular() => View("Clients"
        , new ClientsViewModel { Clients = TouristAgency.Clients.Where(x => x.IsRegular) });
    //вывод клиентов, возраст которых попадает под заданый диапазон
    public IActionResult ClientsByAge(int Min, int Max) => View("Clients"
        , new ClientsViewModel { Clients = TouristAgency.Clients.Where(x => x.Age >= Min && x.Age <= Max) });
    //вывод клиентов с заданной фамилией
    public IActionResult ClientsBySurname(string Surname) => View("Clients"
        , new ClientsViewModel { Clients = TouristAgency.Clients.Where(x => x.Name.ToLower().Contains(Surname.ToLower())) });
    //json представление клиента
    public IActionResult ClientDetails(int id) =>
        Json(TouristAgency.Clients.Find(x => x.Id == id));

    #endregion
    #region Действия с коллекцие инструкторов 
    //переход на страницу с формой инструктора для его редактирования
    public IActionResult EditeInstructor(int id) => View("InstructorForm", TouristAgency.Instructors.Find(x => x.Id == id));

    [HttpPost]
    public IActionResult UpdateInstructor(Instructor item)
    {
        TouristAgency.UpdateInstructor(item);
        Utils.instructorsList = TouristAgency.Instructors;

        return View("Instructors", TouristAgency.Instructors);
    }
    //вывод инструкторов
    public IActionResult Instructors() => View(TouristAgency.Instructors);
    //Вывод сведений об инструкторах с заданной категорией
    public IActionResult InstctsShowByCategory(char cat)
        => View("Instructors", TouristAgency.Instructors.Where(x => x.Category == cat));
    //Вывод сведений об инструкторах в порядке убывания категорий
    public IActionResult InstctsSortByCategory()
        => View("Instructors", TouristAgency.Instructors.OrderByDescending(x => x.Category));
    //Вывод сведений об инструкторах в алфавитном порядке
    public IActionResult InstctsSortByAlphabet()
        => View("Instructors", TouristAgency.Instructors.OrderBy(x => x.Name));

    public IActionResult Details(int id) => Json(TouristAgency.Instructors.Find(x => x.Id == id));

    #endregion
    #region Действия с коллекцие маршрутов 
    //переход на страницу с формой маршрута для его добавления
    public IActionResult AddRoute() => View("RouteForm", new Models.TourOperator.Route());
    //переход на страницу с формой маршрута для его редактирования
    public IActionResult EditeRoute(int id) => View("RouteForm", TouristAgency.Routes.Find(x => x.Id == id));
    //добавление или редактирвоание маршрута
    [HttpPost]
    public IActionResult CreateOrUpdateRoute(Models.TourOperator.Route item)
    {
        //валидация
        if (!ModelState.IsValid)
            return View("RouteForm", item);


        item.Instructor = Utils.instructorsList.Find(x => x.Id == item.InstructorId)!;

        if (item.Id == -1)
        {
            item.Id = TouristAgency.GetNewRouteId();
            TouristAgency.AddRoute(item);

        }
        else
            TouristAgency.UpdateRoute(item);

        Utils.routesList = TouristAgency.Routes;

        return View("Routes", TouristAgency.Routes);
    }

    //удаление маршрута
    public IActionResult DeleteRoute(int id)
    {
        TouristAgency.RemoveRoute(TouristAgency.Routes.FirstOrDefault(x => x.Id == id)!);
        return View("Routes", new RoutesViewModel { Routes = TouristAgency.Routes });
    }
    //вывод маршрутов
    public IActionResult Routes() => View("Routes", new RoutesViewModel { Routes = TouristAgency.Routes });

    //Вывод сведений о маршруте по убыванию протяженности маршрута
    public IActionResult RtsSortByLengthDesc()
        => View("Routes", new RoutesViewModel { Routes = TouristAgency.Routes.OrderByDescending(x => x.Length) });
    //Вывод сведений о маршруте по убыванию протяженности маршрута
    public IActionResult RtsSortByLength()
        => View("Routes", new RoutesViewModel { Routes = TouristAgency.Routes.OrderBy(x => x.Length) });

    //Вывод сведений о маршруте по возрастанию сложности
    public IActionResult RtsSortByDiff()
    {
        Dictionary<string, int> diff = new Dictionary<string, int>()
        {
            ["A-"] = 0,
            ["A"] = 1,
            ["A+"] = 2,
            ["B-"] = 3,
            ["B"] = 4,
            ["B+"] = 5,
            ["C-"] = 6,
            ["C"] = 7,
            ["C+"] = 8,
        };

        return View("Routes"
            , new RoutesViewModel { Routes = TouristAgency.Routes.OrderBy(x => diff[x.Difficulty]) });
    }


    public IActionResult ShowByPoint(string RoutePoint, string point)
    {
        var items = point switch
        {
            "start" => TouristAgency.Routes.Where(x => x.StartPoint == RoutePoint),
            "brake" => TouristAgency.Routes.Where(x => x.BrakePoint == RoutePoint),
        };
        return View("Routes"
            , new RoutesViewModel { Routes = items });
    }

    [HttpPost]
    public IActionResult ShowByLength(int Min, int Max)
        => View("Routes"
            , new RoutesViewModel { Routes = TouristAgency.Routes.Where(x => x.Length >= Min && x.Length <= Max).ToList() });
    public IActionResult RDetails(int id) => Json(TouristAgency.Routes.Find(x => x.Id == id));
    #endregion

}
