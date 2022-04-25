function myFunction() {
    var input, filter, ul, li, a, i, txtValue;
    input = document.getElementById('myInput');
    filter = input.value.toUpperCase();
    ul = document.getElementById("myUL");
    li = ul.getElementsByTagName('li');
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("p")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}

function details() {
    var x = document.getElementById("movie-details");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
}
function details2() {
    var x = document.getElementById("movie-details2");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
}
function RemoveMovie1() {
    var element = document.getElementById("movie1-container");
    var x = document.getElementById("movie-details");
    if (x.style.display === "block") {
        alert("please close the details section");
    } else {
        element.remove();
    }
}
function RemoveMovie2() {
    var element = document.getElementById("movie2-container");
    var x = document.getElementById("movie-details2");
    if (x.style.display === "block") {
        alert("please close the details section");
    } else {
        element.remove();
    }
}

const Movie = document.getElementById("movie");
const Director = document.getElementById("director");
const Actors = document.getElementById("actor");
const Trailer = document.getElementById("trailer");
const edit_button = document.getElementById("edit-button");
const done_button = document.getElementById("done-button");

edit_button.addEventListener("click", function () {
    Movie.contentEditable = true;
    Director.contentEditable = true;
    Actors.contentEditable = true;
    Trailer.contentEditable = true;
});

done_button.addEventListener("click", function () {
    Movie.contentEditable = false;
    Director.contentEditable = false;
    Actors.contentEditable = false;
    Trailer.contentEditable = false;
});
