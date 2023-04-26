var tableBody = document.getElementById('table-body');
var rows = tableBody.querySelectorAll('tr');
var pageCount = Math.ceil(rows.length / 5);

var pagination = document.getElementById('pagination');
for (var i = 1; i <= pageCount; i++) {
    var li = document.createElement('li');
    li.classList.add('page-item');

    var link = document.createElement('a');
    link.classList.add('page-link');
    link.innerText = i;
    link.href = '#';
    link.onclick = function () {
        showPage(this.innerText);
        return false;
    };

    li.appendChild(link);
    pagination.appendChild(li);
}

showPage(1);

function showPage(pageNumber) {
    var start = (pageNumber - 1) * 5;
    var end = start + 5;

    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        if (i >= start && i < end) {
            row.classList.add('active');
        } else {
            row.classList.remove('active');
        }
    }
}
