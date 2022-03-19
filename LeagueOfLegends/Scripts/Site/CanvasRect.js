let animateInInterval = animateOutInterval = extraVertexInInterval = extraVertexOutInterval = [];

function handleResize(canvas) {
    const strokeWidth = $(canvas).attr('data-width');
    $(canvas).attr('width', parseFloat($(canvas).parent().width()) + parseInt(strokeWidth) - 1);
    $(canvas).attr('height', parseFloat($(canvas).parent().height()));
}

function drawCanvas(canvas) {
    const ctx = canvas.getContext('2d');
    const topRight = $(canvas).attr('data-top-right') == 'True';
    const topLeft = $(canvas).attr('data-top-left') == 'True';
    const bottomRight = $(canvas).attr('data-bottom-right') == 'True';
    const bottomLeft = $(canvas).attr('data-bottom-left') == 'True';
    const size = $(canvas).attr('data-current-size');
    const strokeWidth = $(canvas).attr('data-width');
    const strokeColor = $(canvas).attr('data-color');
    const avoidId = $(canvas).attr('data-avoid-id');
    const fill = $(canvas).attr('data-fill');
    const avoidElement = $(avoidId);
    const hasSize = size > 0;
    const w = $(canvas).parent().width();
    const h = $(canvas).parent().height();

    ctx.beginPath();
    ctx.strokeStyle = strokeColor;
    ctx.lineWidth = strokeWidth;
    if (topLeft && hasSize) {
        ctx.moveTo(0, size);
        ctx.lineTo(size, 0);
    }
    else {
        ctx.moveTo(0, 0);
    }
    if (avoidId) {
        const left = avoidElement[0].getBoundingClientRect().left - canvas.getBoundingClientRect().left - 20;
        ctx.lineTo(left, 0);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(left + avoidElement.width() + 20, 0);
        ctx.lineTo(w, 0);
    }
    else if (topRight && hasSize) {
        ctx.lineTo(w - size, 0);
        ctx.lineTo(w, size);
    }
    else {
        ctx.lineTo(w, 0);
    }
    if (bottomRight && hasSize) {
        ctx.lineTo(w, h - size);
        ctx.lineTo(w - size, h);
    }
    else {
        ctx.lineTo(w, h);
    }
    if (bottomLeft && hasSize) {
        ctx.lineTo(size, h);
        ctx.lineTo(0, h - size);
    }
    else {
        ctx.lineTo(0, h);
    }
    if (avoidId) {
        ctx.lineTo(0, 0);
    }
    else {
        ctx.closePath();
    }
    if (fill) {
        ctx.fillStyle = fill;
        ctx.fill();
    }
    ctx.stroke();
}

function draw(canvas) {
    handleResize(canvas);
    drawCanvas(canvas);
}

function animateIn(canvas) {
    const currentSize = $(canvas).attr('data-current-size');
    if (currentSize == 0) {
        clearInterval(animateInInterval[$(canvas).attr('data-animate-id')]);
        return;
    }
    $(canvas).attr('data-current-size', parseInt(currentSize) - 1);
    draw(canvas);
}

function animateOut(canvas) {
    const currentSize = $(canvas).attr('data-current-size');
    if (currentSize == $(canvas).attr('data-size')) {
        clearInterval(animateOutInterval[$(canvas).attr('data-animate-id')]);
        return;
    }
    $(canvas).attr('data-current-size', parseInt(currentSize) + 1);
    draw(canvas);
}

$(document).ready(function () {
    $('.canvas-rect-wrapper').each(function () {
        $(this).parent().addClass('position-relative');
        const canvas = $(this).find('canvas')[0];
        const asyncId = $(canvas).attr('data-async-id');

        if (asyncId) {
            switch ($(asyncId)[0].tagName.toLowerCase()) {
                case 'img':
                    $(asyncId).imagesLoaded(function () {
                        draw(canvas);
                    })
                    break;
                case 'video':
                    $(asyncId)[0].onloadeddata = function () {
                        draw(canvas);
                    }
                    break;
            }
        }
        else {
            draw(canvas);
        }

        if ($(canvas).attr('data-resizable') == 'True') {
            $(window).resize(function () {
                draw(canvas);
            })
        }
        const animateId = $(canvas).attr('data-animate-id');
        if (animateId != '') {
            $(canvas).attr('data-animate-in', false);
            $(this).hover(function (e) {
                e.stopPropagation();
                $(canvas).attr('data-animate-in', true);
                clearInterval(animateInInterval[animateId]);
                clearInterval(animateOutInterval[animateId]);
                animateInInterval[animateId] = setInterval(animateIn, 1, canvas);
            }, function (e) {
                e.stopPropagation();
                $(canvas).attr('data-animate-in', false);
                clearInterval(animateInInterval[animateId]);
                clearInterval(animateOutInterval[animateId]);
                animateOutInterval[animateId] = setInterval(animateOut, 1, canvas);
            });
        }
    })
});
