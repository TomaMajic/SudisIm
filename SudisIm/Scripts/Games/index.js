$(document).ready(function() {
    $("#games-table").DataTable({
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Pretraži...",
            "paginate": {
                "previous": "Prethodna",
                "next": "Sljedeća"
            },
            "info": ""
        },
        "lengthChange": false
    });

});