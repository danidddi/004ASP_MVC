
// объект для AJAX-запроса - чистый JavaScript
// AJAX - Asynchronous Javascript And XML 
let xhr = new XMLHttpRequest();

let btn = document.getElementById("table");
btn.addEventListener("click",
    (e) => {

        // открыть AJAX-запрос
        xhr.open("GET", `/touristagency/rdetails/${e.target.dataset.id}`);

        // отправить запрос
        xhr.send();

        // настроить callback-функцию - сработает по приему данных
        xhr.onload = () => {
            let route = JSON.parse(xhr.response);
            console.log(route);

            document.getElementById("idspan").innerHTML = `${route.id}`;
            document.getElementById("startpointspan").innerHTML = route.startPoint;
            document.getElementById("brakepointspan").innerHTML = route.brakePoint;
            document.getElementById("endpointspan").innerHTML = route.endPoint;
            document.getElementById("lenthspan").innerHTML = route.length;
            document.getElementById("diffspan").innerHTML = route.difficulty;
            document.getElementById("instrspan").innerHTML = route.instructor.toShortInfo;

        };
    });