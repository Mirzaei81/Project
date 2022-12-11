export var score = 0;
var block = /** @class */ (function () {
    function block(width, height, B_hp, pos, B_img) {
        var _this = this;
        this.width = width;
        this.height = height;
        this.B_hp = B_hp;
        this.pos = pos;
        this.B_img = B_img;
        this.brickImage = new Image();
        this.GET_MID_X = function () {
            return _this.pos.x + (_this.width * .5);
        };
        this.GET_MID_y = function () {
            return _this.pos.y + (_this.height * .5);
        };
        this.width = width;
        this.height = height;
        this.B_hp = B_hp;
        this.brickImage.src = B_img;
        this.pos = pos;
    }
    block.prototype.collide_block = function (r1, List) {
        var dx = (r1.pos.x + r1.width / 2) - (this.pos.x + this.width / 2);
        var dy = (r1.pos.y + r1.height / 2) - (this.pos.y + this.height / 2);
        var width = (r1.width + this.width) / 2;
        var height = (r1.height + this.height) / 2;
        var crossWidth = width * dy;
        var crossHeight = height * dx;
        if (Math.abs(dx) <= width && Math.abs(dy) <= height) {
            score += this.B_hp;
            document.querySelector("#score").innerHTML = score.toString();
            this.B_hp -= 1;
            this.brickImage.src = "./assets/images/brick-".concat(this.B_hp, ".png");
            if (this.B_hp <= 0) {
                List.splice(List.indexOf(this), 1);
            }
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
    return block;
}());
export { block };
