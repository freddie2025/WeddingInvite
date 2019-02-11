(function () {
    var burger = document.querySelector('.burger');
    var menu = document.querySelector('#' + burger.dataset.target);
    burger.addEventListener('click', function () {
        burger.classList.toggle('is-active');
        menu.classList.toggle('is-active');
    });
})();

var countDownDate = new Date("Jul 27, 2019 12:30:00").getTime();
var x = setInterval(function () {

    var now = new Date().getTime();
    var distance = countDownDate - now;
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    document.getElementById("countdown").innerHTML = days + " days " + hours + " hours " + minutes + " minutes " + seconds + " seconds ";

    if (distance < 0) {
        clearInterval(x);
        document.getElementById("countdown").innerHTML = "We got married!";
    }
}, 1000);

document.addEventListener("DOMContentLoaded", function () {
    var o = document.documentElement,
        e = d(".modal"),
        t = d(".modal-button"),
        n = d(".modal-background, .modal-close, .modal-card-head .delete, .modal-card-foot .button");

    function c() {
        o.classList.remove("is-clipped"), e.forEach(function (e) {
            e.classList.remove("is-active");
        });
    }

    function d(e) {
        return Array.prototype.slice.call(document.querySelectorAll(e), 0);
    }
    0 < t.length && t.forEach(function (n) {
        n.addEventListener("click", function () {
            var e = n.dataset.target,
                t = document.getElementById(e);
            o.classList.add("is-clipped"), t.classList.add("is-active");
        });
    }), 0 < n.length && n.forEach(function (e) {
        e.addEventListener("click", function () {
            c();
        });
    }), document.addEventListener("keydown", function (e) {
        27 === (e || window.event).keyCode && c();
    });
});