var xInvEntry, xInvExit, yInvEntry, yInvExit, xEntry, xExit, yEntry, yExit, entryTime, exitTime;
var ball = /** @class */ (function () {
    function ball(width, height, Ball_speed_x, Ball_speed_y, pos, Ball_Image) {
        var _this = this;
        this.width = width;
        this.height = height;
        this.Ball_speed_x = Ball_speed_x;
        this.Ball_speed_y = Ball_speed_y;
        this.pos = pos;
        this.Ball_Image = Ball_Image;
        this.ballImage = new Image();
        this.GET_MID_X = function () {
            return _this.pos.x + (_this.width * .5);
        };
        this.GET_MID_y = function () {
            return _this.pos.y + (_this.height * .5);
        };
        this.height = height;
        this.width = width;
        this.Ball_speed_x = Ball_speed_x;
        this.Ball_speed_y = Ball_speed_y;
        this.pos = pos;
        this.ballImage.src = Ball_Image;
    }
    return ball;
}());
export { ball };
;
