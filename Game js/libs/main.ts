import { ball } from "./ball.js";
import { Vector,coll_outside } from "./VEC.js";
import { block } from "./block.js"
import { slider } from "./slider.js"

export let canves:HTMLCanvasElement;
let ctx:CanvasRenderingContext2D ;

export const height:number=600;
export const width:number=800;

var Pause:boolean=false;
const FPS:HTMLElement=document.querySelector("#fps");

let vector:Vector=new Vector(
    width/2,
    height/2,
);

let vec_slide:Vector=new Vector(
    width/2-90,
    height - 40,
)

const Slider = new slider(180,30,7,vec_slide,"./assets/images/slider - Copy.png");
const Ball = new ball(22,22,4,3,vector,"./assets/images/ball.png");
const Block_list:Array<block> = [];  
const LEVEL = [
    [0, 1, 1, 1, 1, 1, 1, 0, 0],
    [2, 2, 2, 2, 2, 2, 2, 2, 0],
    [3, 3, 3, 3, 3, 3, 3, 3, 0],
    [0, 4, 4, 4, 4, 4, 4, 0, 0],
    [0, 5, 5, 0, 0, 5, 5, 0, 0],
  ];
function setup():void{
    for (let i:number=0;i<5;i++){
            for(let j=0;j<9;j++){
            let Blocks_VEC:Vector= new Vector(
                50+((80 +10) *j),
                20+((30 + 20) *i),
            );
            if (LEVEL[i][j] !=0){
                Block_list.push(new block(80,30,LEVEL[i][j],Blocks_VEC,`assets/images/brick-${LEVEL[i][j]}.png`));
            };
        };
    };
};

setup()

window.onload=init;
document.querySelector("#start").addEventListener("click",function():void{Pause=true});

function init():void {
    canves  =document.querySelector("#game");
    ctx = canves.getContext("2d");
    window.requestAnimationFrame(gameloop);
};

function gameloop(Timestamp:DOMHighResTimeStamp):void{
    ctx.clearRect(0,0,width,height);
    draw();
    if (Pause){
        Update();
        coll_outside(Ball);
        Slider.collide(Ball)
        for (let i=0;i<Block_list.length;i++)
            Block_list[i].collide_block(Ball,Block_list);
        if (Block_list == []){
            Pause=true;
        }
        if (Ball.pos.y+Ball.height >=height){
            GameOver();
        }
    }
    window.requestAnimationFrame(gameloop);
};

function draw():void{
    ctx.drawImage(Ball.ballImage,Ball.pos.x,Ball.pos.y);
    ctx.drawImage(Slider.sliderImage,Slider.pos.x,Slider.pos.y);
    for (let x=0;x<Block_list.length;x++){
        ctx.drawImage(Block_list[x].brickImage,Block_list[x].pos.x,Block_list[x].pos.y)};
};

function Update():void {
    Ball.pos.x +=Ball.Ball_speed_x;
    Ball.pos.y +=Ball.Ball_speed_y;
    Slider.Move();
}

function GameOver():void{
    canves.offsetWidth;
    Ball.pos.x = width/2;
    Ball.pos.y = height/2;
    Slider.pos.x = vec_slide.x;
    Block_list.splice(0, Block_list.length);
    canves.offsetWidth;
    Ball.Ball_speed_x =3;
    Ball.Ball_speed_y =4;
    Pause = false;
    setup();
}
