function getAbilityItems() {
    return $('.abilities .abilities__list .abilities__list-item');
}

function drawAbilityCanvas(index) {
    const item = $(getAbilityItems()[index]);
    if (item.hasClass('active')) return;
    $('.abilities .abilities__list .abilities__list-item.active').removeClass('active');
    item.addClass('active');
    $('.abilities .abilities__list .active-circle').css('transform', `translateX(${88 * index}px)`);
    $('.abilities .abilities__description .abilities__description-item.active').removeClass('active');
    $($('.abilities .abilities__description .abilities__description-item')[index]).addClass('active');
}

function alignAbilitiesContent() {
    const left = $('.abilities .section-content--left > div > :first-child').width();
    $('.abilities h2').css('left', left + 5);
    $('.abilities .abilities__description-item').css('paddingLeft', left + 35);
}

function playAbilityVideo(index) {
    const currentActive = $('.abilities .section-content--right .video-wrapper .active');
    const currentIndex = currentActive.index();
    if (index === currentIndex && currentIndex >= 0) {
        return;
    }

    if (currentIndex >= 0) {
        $($('.abilities .section-content--right .video-wrapper > *')[currentIndex]).find('video')[0]?.pause();
        $($('.abilities .section-content--right .video-wrapper > *')[index]).find('video')[0]?.load();
        currentActive.removeClass('active');
    }
    const newActive = $($('.abilities .section-content--right .video-wrapper > *')[index]);
    newActive.addClass('active');
    setTimeout(() => {
        newActive.find('video')[0]?.play();
    }, 150)
}

function handleClickSkin() {
    $('.carousel-skin-item').click(function () {
        const index = $(this).index()
        $('.carousel-skins-list').css('top', Math.min(60 - 100 * (index - 1), 60));
    })
}

$(document).ready(function () {
    alignAbilitiesContent();
    drawAbilityCanvas(0);
    playAbilityVideo(0);

    $(window).resize(function () {
        alignAbilitiesContent();
    })

    getAbilityItems().each(function (i) {
        $(this).click(function () {
            drawAbilityCanvas(i);
            playAbilityVideo(i);
        })
    })

    handleClickSkin();

    $('.abilities .abilities__description').removeClass('d-none');
})
