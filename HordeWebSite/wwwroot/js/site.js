// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $(".gazetteRadio").change(function () {
        doGazetteUpdate(); 
    });

    $("#selectUser").change(function () {
        event.preventDefault();
        getListRoleUser();
        
    });

    $("#deleteGazette").click(function () {
        event.preventDefault();
        deleteGazette();
    });

    $("#nextGazette").click(function () {
        nextGazetteUpdate();
    });

    $("#previousGazette").click(function () {
        previousGazetteUpdate();   
    });

    $("#addImageCreateGazette").click(function () {
        event.preventDefault();
        insertNewInputImageGazette();
    });

    $("#delImageCreateGazette").click(function () {
        event.preventDefault();
        deleteLastInputImageGazette();
    });

    function getListRoleUser() {
        $.ajax({
            type: "POST",
            url: 'getRoleUser',
            data: {
                Name: document.getElementById("selectUser").value
            },
            success: function (data) {
                //console.log("okList");
                $('#listRole').html(data);
            }
        });
    }

    function deleteGazette() {
        $.ajax({
            type: "POST",
            url: 'Gazettes/Delete',
            data: {
                str: $('input[name=Date]:checked', '#formGazette').val()
            },
            success: function (data) {
                //console.log("deleted");
            }
        });
    }

    function nextGazetteUpdate() {
        $.ajax({
            type: "POST",
            url: 'Gazettes/OnClickNext',
            data: {
                Date: $('input[name=Date]:checked', '#formGazette').val(),
                page: $('#pageNumber').html()
            },
            success: function (data) {
                $('#partial').html(data);
                var p = parseInt($('#pageNumber').html())
                $('#pageNumber').html(p + 1);
                handleBtn();
            }
        });
    }

    function previousGazetteUpdate() {
        $.ajax({
            type: "POST",
            url: 'Gazettes/OnClickPrevious',
            data: {
                Date: $('input[name=Date]:checked', '#formGazette').val(),
                page: $('#pageNumber').html()
            },
            success: function (data) {
                $('#partial').html(data);
                var p = parseInt($('#pageNumber').html())
                $('#pageNumber').html(p - 1);
                handleBtn();
            }
        });
    }

    $('#sendDateGazette').click(function () {
        event.preventDefault();
        doGazetteUpdate();
    });


    function readURL(input, pg) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $("#canvas-" + pg)
                    .attr('src', e.target.result);
            };

            reader.readAsDataURL(input.files[0]);
        }
    }

    function insertNewInputImageGazette() {
        var i = parseInt($('#numberImg').html()) + 1;
        $('#numberImg').html(i);
        $('#imageCreateGazette').append("<div class='form-group added' id='inputImg-" + i + "'><span class='text-danger field-validation-valid' data-valmsg-for='image' data-valmsg-replace='true' ></span ><label class='control-label' for='image'>image</label><input type='file' class='form-control-file' onchange='readURL(this,"+i+");' id='image-" + i + "' name='image'></div>\n");
        $('#listImg').append("<div id=divImg-" + i + " class='carousel-item'><img id=img-" + i +" class='added img-fluid'/><p>Page "+i+"</p></div>");
    }

    function deleteLastInputImageGazette() {
        var i = parseInt($('#numberImg').html());
        if (i > 1) {
            document.getElementById('inputImg-' + i).remove();
            document.getElementById('divImg-' + i).remove();
            i--;
            let k = i;
            for (let p = 1; p <= i; p++) {
                if (document.getElementById('divImg-' + p).classList.contains("active")) {
                    k = p;
                }
                document.getElementById('divImg-' + p).classList.remove("active");
            }
            document.getElementById('divImg-' + k).classList.add("active");
            $('#numberImg').html(i);
        }
    }

});

function handleBtn() {
    $.ajax({
        type: "GET",
        url: 'Gazettes/getMax',
        data: 'Date=' + $('input[name=Date]:checked', '#formGazette').val(),
        success: function (data) {
            var p = parseInt($('#pageNumber').html());
            if (p >= data) {
                $('#nextGazette').prop("disabled", true);
            } else {
                $('#nextGazette').prop("disabled", false);
            }
            if (p == 1) {
                $('#previousGazette').prop("disabled", true);
            } else {
                $('#previousGazette').prop("disabled", false);
            }
        }
    });
}

function doGazetteUpdate() {
    $.ajax({
        type: "POST",
        url: 'Gazettes/OnSelectDate',
        data: $('form').serialize(),
        success: function (data) {
            //console.log(data);
            $('#partial').html(data);
            $('#pageNumber').html(1);
            handleBtn();
        }
    });
}