import { width } from "./main.js";
var Vector = /** @class */ (function () {
    function Vector(x, y) {
        if (x === void 0) { x = 0; }
        if (y === void 0) { y = 0; }
        this.x = x;
        this.y = y;
    }
    Vector.prototype.clone = function () {
        return new Vector(this.x, this.y);
    };
    Vector.prototype.normalize = function () {
        var length = this.x * this.x + this.y * this.y;
        if (length > 0) {
            length = Math.sqrt(length);
            var inverseLength = 1.0 / length;
            this.x *= inverseLength;
            this.y *= inverseLength;
        }
        else {
            this.x = 1;
            this.y = 0;
        }
        return length;
    };
    return Vector;
}());
export { Vector };
export function coll_outside(ball) {
    if (ball.pos.y < 0)
        ball.Ball_speed_y = -ball.Ball_speed_y;
    if (ball.pos.x + ball.width > width)
        ball.Ball_speed_x = -ball.Ball_speed_x;
    if (ball.pos.x < 0)
        ball.Ball_speed_x = -ball.Ball_speed_x;
}
;
export var epsilon = 1e-8;
export function sign(value) {
    return value < 0 ? -1 : 1;
}
;
