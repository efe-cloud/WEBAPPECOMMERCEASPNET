$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: '/admin/company/getall', // <-- Must be the correct URL
        },
        "columns": [
            { data: 'name', title: 'Name', "width": "15%" },
            { data: 'streetAddress', title: 'Address', "width": "15%" },
            { data: 'city', title: 'City', "width": "15%" },
            { data: 'state', title: 'State', "width": "15%" },
            { data: 'phoneNumber', title: 'Phone Number', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group" role="group">
                        <a href="/admin/company/upsert?id=${data}"
                           class="btn btn-primary mx-2">
                           <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a onClick=Delete('/admin/company/delete/${data}')
                           class="btn btn-danger mx-2">
                           <i class="bi bi-trash-fill"></i> Delete
                        </a>
                    </div>`
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
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        $('#tblData').DataTable().ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function () {
                    toastr.error("An error occurred while deleting the item.");
                }
            });
        }
    });
}
