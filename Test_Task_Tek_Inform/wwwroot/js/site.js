function SelectedDateChanged(e) {
    const date = e.target.value
    //$.ajax({
    //    url: 'Test/GetFilesByDate',
    //    type: 'POST',
    //    data: { selectedDate: date },
    //    success: function (valid) {
    //        if (valid) {
    //            //show that id is valid 
    //        } else {
    //            //show that id is not valid 
    //        }
    //    }
    //});

    const fs = require("fs");
}

function DownloadFiles() {
    const date = document.querySelector(".test_container_date-control");

    $.ajax({
        url: 'Test/GetFilesByDate',
        type: 'POST',
        data: { selectedDate: date.value },
        success: function (valid) {
            if (valid) {
                //show that id is valid 
            } else {
                //show that id is not valid 
            }
        }
    });
}