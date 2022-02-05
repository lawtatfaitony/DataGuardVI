var Time;
(function (Time) {
    var Test = /** @class */ (function () {
        function Test(e) {
            this.element = e;
            this.element.innerHTML = "Now Time is: ";
            this.span = document.createElement('span');
            this.element.appendChild(this.span);
            this.span.innerHTML = new Date().toTimeString();
        }
        Test.prototype.start = function () {
            var _this = this;
            this.timer = setInterval(function () { return _this.span.innerHTML = new Date().toTimeString(); }, 500);
        };
        Test.prototype.stop = function () {
            clearTimeout(this.timer);
        };
        return Test;
    }());
    Time.Test = Test;
})(Time || (Time = {}));
///sdfsdfsdf
var genUI = "sdfsfsdfsdfdsfs";
//# sourceMappingURL=Shift.js.map