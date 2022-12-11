import { width as Width, height as Height } from "./main.js";
var slider = /** @class */ (function () {
    function slider(width, height, slider_speed_x, pos, slider_Image) {
        var _this = this;
        this.width = width;
        this.height = height;
        this.slider_speed_x = slider_speed_x;
        this.pos = pos;
        this.slider_Image = slider_Image;
        this.sliderImage = new Image();
        this.LEFT = false;
        this.RIGHT = false;
        this.y = Height - this.sliderImage.height - 10;
        this.GO = function (e) {
            if (e.code === 'ArrowLeft' || e.key === 'ArrowLeft')
                _this.LEFT = true;
            if (e.code === 'ArrowRight' || e.key === 'ArrowRight')
                _this.RIGHT = true;
        };
        this.Stop = function (e) {
            if (e.code === 'ArrowLeft' || e.key === 'ArrowLeft')
                _this.LEFT = false;
            if (e.code === 'ArrowRight' || e.key === 'ArrowRight')
                _this.RIGHT = false;
        };
        this.Move = function () {
            if (_this.RIGHT && _this.pos.x + _this.sliderImage.width < Width)
                _this.pos.x += _this.slider_speed_x;
            if (_this.LEFT && _this.pos.x > 0)
                _this.pos.x -= _this.slider_speed_x;
        };
        this.GET_MID_X = function () {
            return _this.pos.x + (_this.width * .5);
        };
        this.GET_MID_y = function () {
            return _this.pos.y + (_this.height * 0.5);
        };
        this.height = height;
        this.width = width;
        this.slider_speed_x = slider_speed_x;
        this.pos = pos;
        this.sliderImage.src = slider_Image;
        document.addEventListener("keydown", this.GO);
        document.addEventListener("keyup", this.Stop);
    }
    slider.prototype.collide = function (r1) {
        var dx = (r1.pos.x + r1.width / 2) - (this.pos.x + this.width / 2);
        var dy = (r1.pos.y + r1.height / 2) - (this.pos.y + this.height / 2);
        var width = (r1.width + this.width) / 2;
        var height = (r1.height + this.height) / 2;
        var crossWidth = width * dy;
        var crossHeight = height * dx;
        if (Math.abs(dx) <= width && Math.abs(dy) <= height) {
            if (crossWidth > crossHeight) {
                if (crossWidth > (-crossHeight)) {
                    r1.Ball_speed_y *= -1;
                    console.log("bottom");
                }
                else {
                    r1.Ball_speed_x *= -1, console.log("left");
                }
                ;
            }
            else {
                if (crossWidth > -(crossHeight)) {
                    r1.Ball_speed_x *= -1;
                    console.log("right");
                }
                else {
                    r1.Ball_speed_y *= -1;
                    console.log("top");
                }
                ;
            }
        }
    };
    return slider;
}());
export { slider };
