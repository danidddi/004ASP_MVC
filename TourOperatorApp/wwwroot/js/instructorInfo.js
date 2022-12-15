// вспомогательная функция для доступа к элементам DOM
$ = id => document.getElementById(id);

// объект для AJAX-запроса - чистый JavaScript
// AJAX - Asynchronous Javascript And XML 
let xhr = new XMLHttpRequest();

let btn = $("table");
btn.addEventListener("click",
    (e) => {

        // открыть AJAX-запрос
        xhr.open("GET", `/touristagency/details/${e.target.dataset.id}`);

        // отправить запрос
        xhr.send();

        // настроить callback-функцию - сработает по приему данных
        xhr.onload = () => {
            let instructor = JSON.parse(xhr.response);
            console.log(instructor);

            $("idspan").innerHTML = instructor.id;
            $("namespan").innerHTML = instructor.name;
            $("datespan").innerHTML = new Date(instructor.bornDate).toLocaleDateString();
            $("categoryspan").innerHTML = instructor.category;
        };
    });