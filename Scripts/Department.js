$(function () {

    ShowData();
    $('#btnUpdate').hide();

    $('#btnSave').click(function () {

        if (Validate()) {
            Save();
        }
    });

    $('#btnUpdate').click(function () {

        if (Validate()) {
            Update();
        }
    });

});
function Delete(p) {

    var td = p.parentNode;

    var ID = $(td).find("span:eq(0)").html();
    var Title = $(td).find("span:eq(1)").html();
    var Abb = $(td).find("span:eq(2)").html();
    var FarTit = $(td).find("span:eq(3)").html();


    swal({
        title: "Are you sure to delete <span style='color:red;'>" + Title + "</span> ?",
        html: "Once deleted, you will not be able to recover this record!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel please!",
        closeOnConfirm: false,
        closeOnCancel: true,

    }).then(function (isConfirm) {
        if (isConfirm.value) {
            
            $.ajax({
                type: "post",
                url: "Department.aspx/DeleteRecord",
                data: '{Code:' + ID + '}',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (r) {
                    if (r.d == '0') {
                        toastr.success("Record deleted Successfully!", "BU-MIS: Success Alert !", { progressBar: !0, positionClass: 'toast-bottom-right' });
                        swal("DELETED", "The record has been removed...!", "success");
                        ShowData();

                    }
                    else {
                        toastr.error(r.d, "BU-MIS: STOP !", { progressBar: !0 });

                    }

                },
                error: function () {
                    alert('something went wrong...!!!');
                }
            });
        }
    });
   
}
function EditDetail(p) {

    var td = p.parentNode;

    var ID = $(td).find("span:eq(0)").html();
    var Title = $(td).find("span:eq(1)").html();
    var Abb = $(td).find("span:eq(2)").html();
    var FarTit = $(td).find("span:eq(3)").html();
    
    $('#hfCode').val(ID);
    $('#txtTitle').val(Title);
    $('#txtAbbreviation').val(Abb);
    $('#txtFarsiTitle').val(FarTit);


    $('#btnUpdate').show();
    $('#btnSave').hide();
}
function ShowData() {

    $.ajax({
        type: "post",
        url: "Department.aspx/ShowRecord",
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            var $table = "<table id='tblData' width='100%'  class='table table-xs nowrap table-striped scroll-horizontal table-hover'>";
            var header = "<thead><tr ><th>Code</th><th style='text-align:center;'>Title</th><th style='text-align:center;'>Abbreviation</th><th style='text-align:center;'>Farsi Title</th><th style='text-align:center;'>Edit/Delete</th></tr></thead>";
            $table += header;
            
            $.each(data.d, function (i, x) {
                var row = "<tr ><td style='text-align:center;'>" + x.ID + "</td>" +
                    "<td style='text-align:center;'><span>" + x.Title + "  </span></td>" +
                    "<td style='text-align:center;'><span>" + x.Abbreviation + "</span></td>" +
                    "<td style='text-align:center;'><span>" + x.FarsiTitle + "</span></td>" +
                    "<td style='text-align:center;'>" + (x.Edit == false ? "" : "<a class='btn-sm btn-green edit' onclick='EditDetail(this)' href='#' data-toggle='tooltip' data-placement='top' title='Edit'><i class='icon-edit2'></i></a>") + ' ' + (x.Delete == false ? "" : "<a class='btn-sm btn-danger' onclick='Delete(this)' href='#' data-toggle='tooltip' data-placement='top' title='Delete'><i class='icon-bin'></i></a>") + "<span style='display:none'>" + x.ID + "</span><span style='display:none'>" + x.Title + "</span><span style='display:none'>" + x.Abbreviation + "</span><span style='display:none'>" + x.FarsiTitle + "</span></td>" +

                    "</tr>";
                $table += row;
                
            });
            var footer = "<tfoot> <tr><td></td><th>Title</th><th>Abbreviation</th><th>Farsi Title</th><td></td></tr></tfoot>";
            $table += footer;

            $table += "</table>";

            $('#dvData').html($table);

           

            $('#tblData tfoot th').each(function () {
                var title = $(this).text();
                $(this).html('<input type="text" style="font-size:11px; width: 100%;" class="form-control" placeholder="' + title + '" />');
            });

            var table = $('#tblData').DataTable({
                "sScrollX": "100%", "responsive": true, "bAutoWidth": true, "bPaginate": true, "bLengthChange": true, "bFilter": true, "bSort": true, "bInfo": true, "bAutoWidth": true, 'iDisplayLength': 5, "aLengthMenu": [[5, 10, 25, -1], ["2 Rows", 10, 25, "All"]], "aaSorting": []
            
            });
            table.columns().every(function () {
                var that = this;
            
                $('input', this.footer()).on('keyup change', function () {
                    if (that.search() !== this.value) {
                        that
                            .search(this.value)
                            .draw();
                    }
                });
            });

        },
        error: function () {
            alert('Something went wrong...!');
        }
    });

}
function Save() {

    var dept = {};
    dept.Title = $('#txtTitle').val();
    dept.Abbreviation = $('#txtAbbreviation').val();
    dept.FarsiTitle = $('#txtFarsiTitle').val();

    var JSONObj = JSON.stringify({ obj: dept });


    $.ajax({
        type: "post",
        url: "Department.aspx/SaveRecord",
        data: JSONObj,
        dataType: "json",
        contentType:"application/json; charset=utf-8",
        success: function (r) {

            if (r.d == "0") {
                toastr.success("Record Saved Successfully!", "BU-MIS: Success Alert !", { progressBar: !0, positionClass: 'toast-bottom-right' });
                swal("SAVED", "The record has been saved...!", "success");
                ShowData();
            }
            else {
                toastr.error(r.d, "BU-MIS: STOP !", { progressBar: !0 });
            }

        },
        error: function () {
            alert('Something went wrong...!');
        }
    });


}
function Update() {

    var dept = {};
    dept.ID = $('#hfCode').val();
    dept.Title = $('#txtTitle').val();
    dept.Abbreviation = $('#txtAbbreviation').val();
    dept.FarsiTitle = $('#txtFarsiTitle').val();

    var JSONObj = JSON.stringify({ obj: dept });


    $.ajax({
        type: "post",
        url: "Department.aspx/UpdateRecord",
        data: JSONObj,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (r) {

            if (r.d == "0") {
                toastr.success("Record updated Successfully!", "BU-MIS: Success Alert !", { progressBar: !0, positionClass: 'toast-bottom-right' });
                swal("UPDATED", "The record has been updated...!", "success");
                ShowData();
            }
            else {
                toastr.error(r.d, "BU-MIS: STOP !", { progressBar: !0 });
            }

        },
        error: function () {
            alert('Something went wrong...!');
        }
    });


}
function Validate() {

    var flag = true;

    if ($('#txtTitle').val() == "") {
        flag = false;
        $('#txtTitle').css("background-color", "#FFAAAA");
    }
    else {
        $('#txtTitle').css("background-color", "#fff");
    }

    if ($('#txtAbbreviation').val() == "") {
        flag = false;
        $('#txtAbbreviation').css("background-color", "#FFAAAA");
    }
    else {
        $('#txtAbbreviation').css("background-color", "#fff");
    }

    if ($('#txtFarsiTitle').val() == "") {
        flag = false;
        $('#txtFarsiTitle').css("background-color", "#FFAAAA");
    }
    else {
        $('#txtFarsiTitle').css("background-color", "#fff");
    }


    if (flag != true) {

        toastr.warning("Please enter valid informations in red backgrounds!", "BU-MIS: Validation Alert !", { progressBar: !0 });
        swal("STOP", "Please enter valid informations in red backgrounds.", "error");
    }

    return flag;

}