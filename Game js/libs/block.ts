import { Vector } from "./VEC.js";
import { ball } from "./ball.js";

export var score:number=0;
export class block {
    public brickImage: HTMLImageElement = new Image();
    constructor(
        public width:number,
        public height:number,
        public B_hp:number,
        public pos:Vector,
        public B_img:string,
    ){
        this.width=width;
        this.height=height;
        this.B_hp=B_hp;
        this.brickImage.src = B_img;
        this.pos=pos;
    }
    GET_MID_X=():number =>{
        return this.pos.x + (this.width * .5)
    }
    GET_MID_y=():number =>{
        return this.pos.y + (this.height * .5)
    }
    collide_block(r1:ball,List:Array<block>):void{
        var dx:number=(r1.pos.x+r1.width/2)-(this.pos.x+this.width/2);
        var dy:number=(r1.pos.y+r1.height/2)-(this.pos.y+this.height/2);
        var width:number=(r1.width+this.width)/2;
        var height:number=(r1.height+this.height)/2;
        var crossWidth:number=width*dy;
        var crossHeight:number=height*dx;
        if(Math.abs(dx)<=width && Math.abs(dy)<=height){
            score += this.B_hp;
            document.querySelector("#score").innerHTML = score.toString();
            this.B_hp -=1;
            this.brickImage.src = `./assets/images/brick-${this.B_hp}.png`
            if (this.B_hp <= 0){
                List.splice(List.indexOf(this),1);}
            if(crossWidth>crossHeight){
                if (crossWidth>(-crossHeight)){r1.Ball_speed_y*=-1;console.log("bottom")}else{r1.Ball_speed_x*=-1,console.log("left")};
            }else{
                if(crossWidth>-(crossHeight)){r1.Ball_speed_x*=-1;console.log("right")}else{r1.Ball_speed_y*=-1;console.log("top")};
            }
        }
    }
} 