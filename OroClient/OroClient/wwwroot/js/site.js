$(document).ready(function () {
    $('table').DataTable({
        "language": {
            "emptyTable": "No hay informacion disponible",
            "info": "Mostrando _START_ - _END_ de _TOTAL_ registros",
            "infoEmpty": "Mostrando 0 registros",
            "infoFiltered": "(filtrados a partir de _MAX_ total registros)",
            "lengthMenu": "Mostrar _MENU_ registros",
            "search": "Buscar:",
            "zeroRecords": "No se encontraron registros",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
    });
});