import { ball } from "./ball.js";
import { Vector, coll_outside } from "./VEC.js";
import { block } from "./block.js";
import { slider } from "./slider.js";
export var canves;
var ctx;
export var height = 600;
export var width = 800;
var Pause = false;
var FPS = document.querySelector("#fps");
var vector = new Vector(width / 2, height / 2);
var vec_slide = new Vector(width / 2 - 90, height - 40);
var Slider = new slider(180, 30, 7, vec_slide, "./assets/images/slider - Copy.png");
var Ball = new ball(22, 22, 4, 3, vector, "./assets/images/ball.png");
var Block_list = [];
var LEVEL = [
    [0, 1, 1, 1, 1, 1, 1, 0, 0],
    [2, 2, 2, 2, 2, 2, 2, 2, 0],
    [3, 3, 3, 3, 3, 3, 3, 3, 0],
    [0, 4, 4, 4, 4, 4, 4, 0, 0],
    [0, 5, 5, 0, 0, 5, 5, 0, 0],
];
function setup() {
    for (var i = 0; i < 5; i++) {
        for (var j = 0; j < 9; j++) {
            var Blocks_VEC = new Vector(50 + ((80 + 10) * j), 20 + ((30 + 20) * i));
            if (LEVEL[i][j] != 0) {
                Block_list.push(new block(80, 30, LEVEL[i][j], Blocks_VEC, "assets/images/brick-".concat(LEVEL[i][j], ".png")));
            }
            ;
        }
        ;
    }
    ;
}
;
setup();
window.onload = init;
document.querySelector("#start").addEventListener("click", function () { Pause = !Pause;
    if (Pause){
        document.querySelector("#start").innerHTML = "Pause";
    }
    else{document.querySelector("#start").innerHTML = "UnPause";}
 });
function init() {
    canves = document.querySelector("#game");
    ctx = canves.getContext("2d");
    window.requestAnimationFrame(gameloop);
}
;
function gameloop(Timestamp) {
    ctx.clearRect(0, 0, width, height);
    draw();
    if (Pause) {
        Update();
        coll_outside(Ball);
        Slider.collide(Ball);
        for (var i = 0; i < Block_list.length; i++)
            Block_list[i].collide_block(Ball, Block_list);
        if (Block_list == []) {
            Pause = true;
        }
        if (Ball.pos.y + Ball.height >= height) {
            GameOver();
        }
    }
    window.requestAnimationFrame(gameloop);
}
;
function draw() {
    ctx.drawImage(Ball.ballImage, Ball.pos.x, Ball.pos.y);
    ctx.drawImage(Slider.sliderImage, Slider.pos.x, Slider.pos.y);
    for (var x = 0; x < Block_list.length; x++) {
        ctx.drawImage(Block_list[x].brickImage, Block_list[x].pos.x, Block_list[x].pos.y);
    }
    ;
}
;
function Update() {
    Ball.pos.x += Ball.Ball_speed_x;
    Ball.pos.y += Ball.Ball_speed_y;
    Slider.Move();
}
function GameOver() {
    canves.offsetWidth;
    Ball.pos.x = width / 2;
    Ball.pos.y = height / 2;
    Slider.pos.x = vec_slide.x;
    Block_list.splice(0, Block_list.length);
    canves.offsetWidth;
    Ball.Ball_speed_x = 3;
    Ball.Ball_speed_y = 4;
    Pause = false;
    setup();
}
