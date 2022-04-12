$('.checkbox.stay-sign-in-cb').click(function () {
    const cb = $('input#stay-sign-in-cb');
    cb.prop('checked', !cb.prop('checked'));
})