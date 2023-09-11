$(document).ready(function () {
    $(".model-item-course").on('click', 'a.course-model-group', function (e) {
        e.preventDefault();
        $(this).parents('.model-item-course').find('.model-child-group .model-item-in-group').show();
        if ($(this).parents('.model-item-course').find('.model-child-group').is(":visible")) {
            $(this).parents('.model-item-course').find('.model-child-group').hide();
        } else {
            $(this).parents('.model-item-course').find('.model-child-group').fadeIn(1000);
        }
    });

    $(".model-item-course-group").on('click', 'a.group-model-student', function (e) {
        e.preventDefault();
        $(this).parents('.model-item-course-group').find('.model-child-group-student .model-item-in-group-student').show();
        if ($(this).parents('.model-item-course-group').find('.model-child-group-student').is(":visible")) {
            $(this).parents('.model-item-course-group').find('.model-child-group-student').hide();
        } else {
            $(this).parents('.model-item-course-group').find('.model-child-group-student').fadeIn(1000);
        }
    });
});