

function Delete(Id) {
    bootbox.confirm("are you sure to delete this record permanently", function (result) {
  
        
    if (result) {
        $.ajax({
            url: "/Employee/Delete/" + Id, 
            type: "post",
            contentType: "application/json;charset=Utf-8",
            dataType: "json",
            success: function (result) {
                toastr.success("Succesfully Deleted", { timeOut: 2000 });
                /* window.Location.href("Employee/Index");*/
            }
          

        });
        }
    });
    //$(document).ajaxStop(function () {
    //    window.location.reload();
    //});
   
    
}