$(function () {
    $('.js-basic-example').DataTable({
        responsive: true

    });

    //Exportable table
    $('.js-exportable').DataTable({
        dom: 'lBfrtip',
        responsive: true,
        buttons: [
            'copy', 'excel', 'pdf', 'print'
        ],
		"aLengthMenu": [[20, 40, 60, -1], [20, 40, 60, "All"]],
        "iDisplayLength": 20
    });
});