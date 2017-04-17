function Search() {
    var name = document.getElementById("titleNameSearch").value.toString();
    var xhttp = new XMLHttpRequest();

    if (name === null) {
        xhttp.open("GET", "/api/titles", false);
    }
    else {
        xhttp.open("GET", "/api/titles/" + name, false);
    }

    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
    var jsonArray = jQuery.parseJSON(xhttp.responseText);
    var source = $("#data-template").html();
    var template = Handlebars.compile(source);
    $('#form').html("");
    $('#form').append(template(jsonArray));
}