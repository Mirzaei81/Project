import { block } from "./block.js";
import { slider } from "./slider.js";
import { Vector,sign } from "./VEC.js";
import { hit_prop } from "./helper.js"


var xInvEntry:number,
    xInvExit:number,
    yInvEntry:number,
    yInvExit:number,
    xEntry:number,
    xExit:number,
    yEntry:number,
    yExit:number,
    entryTime:number,
    exitTime:number;


export class ball{
    public ballImage: HTMLImageElement = new Image();
    constructor(
        public width:number,
        public height:number,
        public Ball_speed_x:number,
        public Ball_speed_y:number,
        public pos:Vector,
        public Ball_Image:string,
    ){
        this.height = height;
        this.width = width;
        this.Ball_speed_x = Ball_speed_x;
        this.Ball_speed_y = Ball_speed_y;
        this.pos = pos;
        this.ballImage.src = Ball_Image;
    }
    GET_MID_X=():number =>{
        return this.pos.x + (this.width * .5);
    }
    GET_MID_y=():number =>{
        return this.pos.y + (this.height * .5);
    }


};