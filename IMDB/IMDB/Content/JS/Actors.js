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
    var x = document.getElementById("actor-details");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
}

function RemoveActor1() {
    var element = document.getElementById("actor1-container");
    var x = document.getElementById("actor-details");
    if (x.style.display === "block") {
        alert("please close the details section");
    } else {
        element.remove();
    }
}

const FirstName = document.getElementById("first-name");
const LastName = document.getElementById("last-name");
const Age = document.getElementById("age");
const Movies = document.getElementById("actor-movies");
const edit_button = document.getElementById("edit-button");
const done_button = document.getElementById("done-button");

edit_button.addEventListener("click", function () {
    FirstName.contentEditable = true;
    LastName.contentEditable = true;
    Age.contentEditable = true;
    Movies.contentEditable = true;
});

done_button.addEventListener("click", function () {
    FirstName.contentEditable = false;
    LastName.contentEditable = false;
    Age.contentEditable = false;
    Movies.contentEditable = false;
});
