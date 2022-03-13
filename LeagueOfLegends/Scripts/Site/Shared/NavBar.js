const sizes = [];

function calculateSizes() {
    $('nav.navbar .navbar-nav > li').each(function () {
        sizes.push($(this).width());
    });
    sizes.pop();
}

function calculateItem() {
    const windowWidth = $(window).width();
    if (windowWidth < 1200) return;

    let enough = false;
    const moreItems = $('nav.navbar .navbar-nav > li.more .dropdown ul');
    moreItems.innerHTML = '';

    $($('nav.navbar .navbar-nav > li').get().reverse()).each(function (i) {
        if (this.classList.contains('more')) return;
        console.log(i);

        const rightBtn = $('nav.navbar .right-btn')[1];
        if (rightBtn.clientWidth + rightBtn.offsetLeft >= windowWidth && !enough) {
            if (i == 1) {
                $('nav.navbar .navbar-nav > li.more')[0].style.setProperty('display', 'flex', 'important');
            }
            this.style.setProperty('display', 'none', 'important');
            const href = $(this).find('a')[0].href;
            const html = $(this).find('p')[0].innerHTML;
            moreItems.append(`
                <li class="d-block mx-3 my-1">
                    <a class="d-block px-3 py-2 text-decoration-none" href="${href}">${html}</a>
                </li>
            `);
        } else {
            if (i == 1) {
                $('nav.navbar .navbar-nav > li.more')[0].style.setProperty('display', 'none', 'important');
                moreItems.innerHTML = '';
            }
            this.style.setProperty('display', 'flex', 'important');
            enough = true;
        }
    })
}

$(document).ready(function () {
    calculateSizes();
    calculateItem();
    $(window).resize(function () {
        calculateItem();
    })
})