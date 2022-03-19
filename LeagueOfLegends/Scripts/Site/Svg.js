$(document).ready(function () {
    $(".svg-wrapper").each(function () {
        const fill = $(this).attr('data-color');
        $(this).children('svg').attr('fill', fill);
    })
})