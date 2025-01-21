$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: '/admin/product/getall',
        },
        "columns": [
            { data: 'title', title: 'Title', "width": "15%" },
            { data: 'productCode', title: 'Product Code', "width": "15%" }, // Updated to camelCase
            { data: 'price', title: 'Price', "width": "15%" },
            { data: 'producer', title: 'Producer', "width": "15%" }, // Updated to camelCase
            { data: 'category.name', title: 'Category', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                           <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a>
                            <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>Delete</a>
                           </div>`;
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
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
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        $('#tblData').DataTable().ajax.reload(); // Reload DataTable
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function (xhr) {
                    toastr.error("An error occurred while deleting the item.");
                }
            });
        }
    });
}
