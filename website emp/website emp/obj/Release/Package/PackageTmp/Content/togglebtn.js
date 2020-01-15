
var count = 1;
function ftn()
{
    var togglebar = document.getElementById("togglebar");
    var togglex = document.getElementById("togglex");
    if (count === 1) {
        togglebar.style.display = "none";
        togglex.style.display = "block";
        count++;
    }
    else {
        togglebar.style.display = "block";
        togglex.style.display = "none";
        count = 1;
    }
}