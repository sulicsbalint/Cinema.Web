// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function reserve(_seat, checkb, rows, cols) {
    var str = ' ' + checkb
    str = str.replace(/\s/g, '')
    console.log(str)

    var checkbox = document.getElementById(str)
    var seat = document.getElementById(_seat)

    var ctr = 0
    for (var i = 0; i < rows; i++) {
        for (var j = 0; j < cols; j++) {
            if (document.getElementById('id' + i + j).checked && document.getElementById("seat " + i + " " + j).classList.contains("seat-selected")) {
                ctr++
            }
        }
    }

    console.log(ctr);
    if (ctr == 6 && seat.classList.contains("seat-free")) return

    if (seat.classList.contains("seat-free")) {
        checkbox.checked = true
        seat.classList.remove("seat-free")
        seat.classList.add("seat-selected")
    } else if (seat.classList.contains("seat-selected")) {
        checkbox.checked = false
        seat.classList.remove("seat-selected")
        seat.classList.add("seat-free")
    }
}