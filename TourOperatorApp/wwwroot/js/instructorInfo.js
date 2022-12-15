// объект для AJAX-запроса - чистый JavaScript
// AJAX - Asynchronous Javascript And XML 
let xhr = new XMLHttpRequest();

let btn = document.getElementById("table");
btn.addEventListener("click",
    (e) => {

        // открыть AJAX-запрос
        xhr.open("GET", `/touristagency/details/${e.target.dataset.id}`);

        // отправить запрос
        xhr.send();

        // настроить callback-функцию - сработает по приему данных
        xhr.onload = () => {
            let instructor = JSON.parse(xhr.response);
            document.getElementById("idspan").innerHTML = instructor.id;
            document.getElementById("namespan").innerHTML = instructor.name;
            document.getElementById("datespan").innerHTML = new Date(instructor.bornDate).toLocaleDateString();
            document.getElementById("categoryspan").innerHTML = instructor.category;
        };
    });