﻿using Microsoft.AspNetCore.Mvc;
using TourOperatorApp.Common;
using TourOperatorApp.Models;

namespace TourOperatorApp.Controllers;

public class TouristAgencyController : Controller
{
    public TouristAgency TouristAgency { get; set; }

    public TouristAgencyController()
    {
        TouristAgency = new TouristAgency();
    }

    #region CRUD
    //переход на страницу с формой маршрута для его добавления
    public IActionResult AddRoute() => View("RouteForm", new Models.Route());
    //переход на страницу с формой маршрута для его редактирование
    public IActionResult EditeRoute(int id) => View("RouteForm", TouristAgency.Routes.Find(x => x.Id == id));
    //добавление или редактирвоание маршрута
    [HttpPost]
    public IActionResult CreateOrUpdateRoute(Models.Route item)
    {
        item.Instructor = Utils.instructorsList.Find(x => x.Id == item.InstructorId)!;

        if (item.Id == 0)
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
        return View("Routes", TouristAgency.Routes);
    }
    //вывод маршрутов
    public IActionResult Routes() => View("Routes", TouristAgency.Routes);
    //вывод инструкторов
    public IActionResult Instructors() => View(TouristAgency.Instructors);
    #endregion

    #region Действия с коллекцие инструкторов 
    //Вывод сведений об инструкторах с заданной категорией
    public IActionResult InstctsShowByCategory(char cat)
        => View("Instructors", TouristAgency.Instructors.Where(x => x.Category == cat));
    //Вывод сведений об инструкторах в порядке убывания категорий
    public IActionResult InstctsSortByCategory()
        => View("Instructors", TouristAgency.Instructors.OrderByDescending(x => x.Category));
    //Вывод сведений об инструкторах в алфавитном порядке
    public IActionResult InstctsSortByAlphabet()
        => View("Instructors", TouristAgency.Instructors.OrderBy(x => x.Name));
    #endregion

    #region Действия с коллекцие маршрутов 

    //Вывод сведений о маршруте по убыванию протяженности маршрута
    public IActionResult RtsSortByLengthDesc()
        => View("Routes", TouristAgency.Routes.OrderByDescending(x => x.Length));
    //Вывод сведений о маршруте по убыванию протяженности маршрута
    public IActionResult RtsSortByLength()
        => View("Routes", TouristAgency.Routes.OrderBy(x => x.Length));
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

        return View("Routes", TouristAgency.Routes.OrderBy(x => diff[x.Difficulty]));
    }
    //Вывод маршрутов с заданным начальным пунктом
    [HttpPost]
    public IActionResult ShowByStartPoint(string point)
        => View("Routes", TouristAgency.Routes.Where(x => x.StartPoint.Equals(point)));
    //Вывод маршрутов, проходящих через заданный промежуточный пункт
    [HttpPost]
    public IActionResult ShowByBrakePoint(string point)
        => View("Routes", TouristAgency.Routes.Where(x => x.BrakePoint.Equals(point)));
    //Вывод маршрутов с протяженностью, попадающей в заданный интервал
    [HttpPost]
    public IActionResult ShowByLength(int lengthFrom, int lengthTo)
        => View("Routes", TouristAgency.Routes.Where(x => x.Length >= lengthFrom && x.Length <= lengthTo));
    #endregion

}