$(document).ready(function () {
    //select the likes span
    $('.likes').on('click', function () {
        var id = $(this).data('id');
        var postRating = $(this);
        $.get('/home/rating/' + id, function (data) {
            $(postRating).parent().html(data);
        });
    });

    $('.showComments').on('click', function () {
        $(this).parent().find('.commentsDiv').slideToggle();
    });

    //Handle the add comments bit
    $('.commentForm').on('submit', function (event) {
        //stop the form from submitting
        event.preventDefault();
        var id = $(this).data('id');
        var theForm = $(this);
        $.post('/home/AddComment/' + id, $(this).serialize(), function (data) {
            $(theForm).parent().html(data);
        });


    });
});