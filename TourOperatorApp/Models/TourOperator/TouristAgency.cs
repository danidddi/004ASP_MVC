using Newtonsoft.Json;
using TourOperatorApp.Common;

namespace TourOperatorApp.Models.TourOperator;
public class TouristAgency
{
    private readonly string _instructorsPath = $"{Environment.CurrentDirectory}\\App_Data\\instructors.json";
    private readonly string _routesPath = $"{Environment.CurrentDirectory}\\App_Data\\routes.json";
    public List<Instructor> Instructors { get; set; }
    public List<Route> Routes { get; set; }

    public TouristAgency()
    {
        if (File.Exists(_instructorsPath))
            DeserializeInstructors();
        else
        {
            Instructors = Utils.instructorsList;
            SerializeInstructors();
        }

        if (File.Exists(_routesPath))
            DeserializeRoutes();
        else
        {
            Routes = Utils.routesList;
            SerializeRoutes();
        }
    }

    //удаление инструктора
    public void RemoveInstructor(Instructor instructor)
    {
        Instructors.Remove(instructor);
        SerializeInstructors();
    }
    //удаление маршрута
    public void RemoveRoute(Route route)
    {
        Routes.Remove(route);
        SerializeRoutes();
    }
    //добавление маршрута
    public void AddRoute(Route route)
    {
        Routes.Insert(0, route);
        SerializeRoutes();
    }
    //обновление маршрута
    public void UpdateRoute(Route route)
    {
        Routes[Routes.FindIndex(x => x.Id == route.Id)] = route;
        SerializeRoutes();

    }
    //обновление инструктора
    public void UpdateInstructor(Instructor instructor)
    {
        Instructors[Instructors.FindIndex(x => x.Id == instructor.Id)] = instructor;
        SerializeInstructors();
    }
    //метод возвращает новый айди для маршрута
    public int GetNewRouteId() => Routes.Max(x => x.Id) + 1;

    #region Serializetion 
    private void SerializeInstructors()
        => File.WriteAllText(_instructorsPath, JsonConvert.SerializeObject(Instructors));
    private void DeserializeInstructors()
        => Instructors = JsonConvert.DeserializeObject<List<Instructor>>(File.ReadAllText(_instructorsPath))!;
    private void SerializeRoutes()
        => File.WriteAllText(_routesPath, JsonConvert.SerializeObject(Routes));
    private void DeserializeRoutes()
        => Routes = JsonConvert.DeserializeObject<List<Route>>(File.ReadAllText(_routesPath))!;
    #endregion

}
