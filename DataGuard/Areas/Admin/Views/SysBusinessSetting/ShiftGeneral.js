var Time;
(function (Time) {
    var Tests = /** @class */ (function () {
        function Tests(e) {
            this.element = e;
            this.element.innerHTML = "Now Time is: ";
            this.span = document.createElement('span');
            this.element.appendChild(this.span);
            this.span.innerHTML = new Date().toTimeString();
        }
        Tests.prototype.start = function () {
            var _this = this;
            this.timer = setInterval(function () { return _this.span.innerHTML = new Date().toTimeString(); }, 500);
        };
        Tests.prototype.stop = function () {
            clearTimeout(this.timer);
        };
        return Tests;
    }());
    Time.Tests = Tests;
})(Time || (Time = {}));
//# sourceMappingURL=ShiftGeneral.js.map