$(document).ready(function () {
    $('#jquerytable').DataTable();
});

        function GetSelectedValue() {
            // dit stopt de huidige url in var result
        var result = window.location.href;
        // dit verwijdert create van de url
        var res = result.substr(0, 45);

        let dropdown = document.getElementById('consumpties');
        dropdown.length = 0;

        let defaultOption = document.createElement('option');
        defaultOption.text = 'Kies uw consumptie';

        dropdown.add(defaultOption);
        dropdown.selectedIndex = 0;
        var url = "";
        var e = document.getElementById("categorieid");
        var result = e.options[e.selectedIndex].value;
            url = res + "GetConsumpties/" + result;

            //if (result === "1") {
            //    url = res + "GetConsumpties/1";
            //} else if (result == "2") {
            //    url = res + "GetConsumpties/2";
            //} else if (result == "3") {
            //    url = res + "GetConsumpties/3";
            //}

            const request = new XMLHttpRequest();
        request.open('GET', url, true);

            request.onload = function () {
                if (request.status === 200) {
                    const data = JSON.parse(request.responseText);
        let option;
                    for (let i = 0; i < data.length; i++) {
            option = document.createElement('option');
        option.text = data[i].naam;
        option.value = data[i].id;
        dropdown.add(option);
    }
                } else {
            // Reached the server, but it returned an error
        }
        }

            request.onerror = function () {
            console.error('An error occurred fetching the JSON from ' + url);
        };

        request.send();
    }

// credits naar https://www.codebyamir.com/blog/populate-a-select-dropdown-list-with-json ^^^
