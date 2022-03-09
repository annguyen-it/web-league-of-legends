$(".canvas-rect-wrapper").each(function () {
    const canvas = $(this).find('canvas')[0];
    const ctx = canvas.getContext('2d');
    const topRight = $(canvas).attr('data-top-right');
    const topLeft = $(canvas).attr('data-top-left');
    const bottomRight = $(canvas).attr('data-bottom-right');
    const bottomLeft = $(canvas).attr('data-bottom-left');
    const size = $(canvas).attr('data-size');
    const hasSize = size > 0;
    const w = $(canvas).parent.width();
    const h = $(canvas).parent.height();

    ctx.beginPath();
    ctx.moveTo(topLeft && hasSize ? size : 0, 0);
    if (topRight && hasSize) {
        ctx.lineTo(w - size, 0);
        ctx.lineTo(w, size);
    }
    else {
        ctx.lineTo(w, 0);
    }
    if (bottomRight && hasSize) {
        ctx.lineTo(w, h - size);
        ctx.lineTo(w - size, size);
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
    if (topLeft && hasSize) {
        ctx.lineTo(0, size);
        ctx.lineTo(size, 0);
    }
    else {
        ctx.lineTo(0, 0);
    }
    ctx.strokeStyle = '#ABABAB';
    ctx.lineWidth = 1;
    ctx.stroke();
})