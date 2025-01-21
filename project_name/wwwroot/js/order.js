$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: '/admin/order/getall',

        },
        "columns": [
            { data: 'id', title: 'ID', "width": "15%" },
            { data: 'name', title: 'Name', "width": "15%" },
            { data: 'phoneNumber', title: 'Phone', "width": "15%" },
            { data: 'applicationUser.email', title: 'Email', "width": "15%" },
            { data: 'orderStatus', title: 'Order Status', "width": "15%" },
            { data: 'orderTotal', title: 'Order Total', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                   <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i></a>
                  
                  

                   </div>`
                },
                "width": "25%"

            }
        ]

    });
}
