using Newtonsoft.Json;
using TourOperatorApp.Common;

namespace TourOperatorApp.Models.TourOperator;
public class TouristAgency
{
    private readonly string _instructorsPath = $"{Environment.CurrentDirectory}\\App_Data\\instructors.json";
    private readonly string _routesPath = $"{Environment.CurrentDirectory}\\App_Data\\routes.json";
    private readonly string _clientssPath = $"{Environment.CurrentDirectory}\\App_Data\\clients.json";
    public List<Instructor> Instructors { get; set; }
    public List<Route> Routes { get; set; }
    public List<Client> Clients { get; set; }

    public TouristAgency()  
    {
        if (File.Exists(_instructorsPath))
            Instructors = Utils.Deserialize<Instructor>(_instructorsPath);
        else
        {
            Instructors = Utils.instructorsList;
            Utils.Serialize(_instructorsPath, Instructors);
        }

        if (File.Exists(_routesPath))
            Routes = Utils.Deserialize<Route>(_routesPath);
        else
        {
            Routes = Utils.routesList;
            Utils.Serialize(_routesPath, Routes);
        }

        if (File.Exists(_clientssPath))
            Clients = Utils.Deserialize<Client>(_clientssPath);
        else
        {
            Clients = Utils.clientsList;
            Utils.Serialize(_clientssPath, Clients);
        }
    }

    //обновление инструктора
    public void UpdateInstructor(Instructor instructor)
    {
        Instructors[Instructors.FindIndex(x => x.Id == instructor.Id)] = instructor;
        Utils.Serialize(_instructorsPath, Instructors);
    }
    //удаление инструктора
    public void RemoveInstructor(Instructor instructor)
    {
        Instructors.Remove(instructor);
        Utils.Serialize(_instructorsPath, Instructors);
    }


    //добавление маршрута
    public void AddRoute(Route route)
    {
        Routes.Insert(0, route);
        Utils.Serialize(_routesPath, Routes);
    }
    //обновление маршрута
    public void UpdateRoute(Route route)
    {
        Routes[Routes.FindIndex(x => x.Id == route.Id)] = route;
        Utils.Serialize(_routesPath,Routes);
    }
    //удаление маршрута
    public void RemoveRoute(Route route)
    {
        Routes.Remove(route);
        Utils.Serialize(_routesPath, Routes);
    }
    //метод возвращает новый айди для маршрута
    public int GetNewRouteId() => Routes.Max(x => x.Id) + 1;


    //добавление клиента
    public void AddClient(Client client)
    {
        Clients.Insert(0, client);
        Utils.Serialize(_clientssPath, Clients);
    }
    //обновление клиента
    public void UpdateClient(Client client)
    {
        Clients[Clients.FindIndex(x => x.Id == client.Id)] = client;
        Utils.Serialize(_clientssPath, Clients);
    }
    //удаление клиента
    public void RemoveClient(Client client)
    {
        File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\clients\\" + client.Img);
        Clients.Remove(client);
        Utils.Serialize(_clientssPath, Clients);
    }
    //метод возвращает новый айди для клиента
    public int GetNewClientId() => Clients.Max(x => x.Id) + 1;
}
