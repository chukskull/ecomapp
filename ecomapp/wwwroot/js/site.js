// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var dataTable;

function Delete(url)  {
    Swal.fire({
    title: "Are you sure?",
    text: "You won't be able to revert this!",
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Yes, delete it!"
    }).then((result) => {
    if (result.isConfirmed) {
        $.ajax({
            url: url,
            type: 'DELETE',
            success: function(data) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        })
    }
    });
}

// Write your JavaScript code.
$(document).ready( function () {
        loadTable();
} );

function loadTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            url: '/admin/product/getall',
            dataSrc: 'data'
        },
        "columns": [
            { data: 'title', "width": "15%" },
            { data: 'isbn', "width": "15%" },
            { data: 'author', "width": "10%" },
            { data: 'price', "width": "15%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id', "width": "20%", "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                            <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a onClick=Delete("/admin/product/delete/${data}")
                                class="btn btn-danger mx-2">
                            <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>`
                }
            }

        ]
    })
}