// объект для AJAX-запроса - чистый JavaScript
// AJAX - Asynchronous Javascript And XML 
let xhr = new XMLHttpRequest();

let btn = document.getElementById("table");
btn.addEventListener("click",
    (e) => {

        // открыть AJAX-запрос
        xhr.open("GET", `/touristagency/ClientDetails/${e.target.dataset.id}`);

        // отправить запрос
        xhr.send();

        // настроить callback-функцию - сработает по приему данных
        xhr.onload = () => {
            let client = JSON.parse(xhr.response);
            document.getElementById("imgclient").src = `../img/clients/${client.img}`;
            document.getElementById("idspan").innerHTML = client.id;
            document.getElementById("namespan").innerHTML = client.name;
            document.getElementById("agespan").innerHTML = client.age;
            document.getElementById("phonespan").innerHTML = client.phoneNumber;
            document.getElementById("emailspan").innerHTML = client.emailAddress;
            document.getElementById("regularspan").innerHTML = client.isRegular ? "&#10004" : "X";
        };
    });