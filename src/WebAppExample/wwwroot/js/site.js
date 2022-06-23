// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    ObjectController.clickSave();
    
});

var ObjectController = {
    clickSave: function () {

        var btnSave = document.getElementById("btnSave");

        if (btnSave != undefined) {
            btnSave.addEventListener("click", function () {
                var id = $("#txt_ID").val();
                var name = $("#txt_Name").val();
                var description = $("#txt_Description").val();
                var typeId = $("#sel_type").val();

                var url = "";

                if (id > 0) {
                    url = "/Object/SaveEdit";
                }
                else {
                    url = "/Object/Create"
                }
                
                $.ajax({
                    data: { ID: id, Name: name, Description: description, TypeId: typeId, TypeDescription: "" },
                    url: url,
                    dataType: 'json',
                    type: 'POST',
                    beforeSend:
                        function () {
                            btnSave.innerText = "Saving...";
                        },
                    complete: function (result) {                        
                            btnSave.innerText = "Save";                                                    
                    },
                    error: function () {
                        
                    }

                });

            });
        }

        

       

        
    },
};
