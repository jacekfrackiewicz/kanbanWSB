$(document).ready(function () {


    var maxColumns = 5;
    var wrapper = $("#columns-names");
    var addColumn = $("#columns");
    var add_button = $('#add-column-btn');

    var currentColumns = 1;
    $(add_button).click(function (e) { 
        e.preventDefault();
        if (currentColumns < maxColumns) {
            currentColumns++; 
            var div = '<div class="form-group" id="column-div"><label for="column-name">Column Name:</label><div class="input-group"><input type="text" class="form-control column-name"><span class="input-group-btn"><button class="btn btn-secondary remove_field" type="button" >Delete</button></span></div></div>';
            $(wrapper).append(div);
  
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { //user click on remove text
        $(this).closest('.form-group').remove();
        currentColumns--;
    });
    

    $('#create-board').on('click', function () {
        var name = $('#name').val();
        var columns = $('.column-name').map(function (x,z)
        {
            return z.value;
        }).toArray();

        var post = $.ajax({
            type: "POST",
            url: document.location.origin + '/KanbanBoard/AddBoard',
            data: {
                name: name,
                columns: columns
            }
        });

        post.done(function () {
            $("#modal-confirm").modal();
        });
        post.fail(function () {
            $("#modal-failed").modal();
        });

    });
});