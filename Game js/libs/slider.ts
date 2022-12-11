import { width as Width,height as Height } from "./main.js";
import {Vector,sign} from "./VEC.js";
import {hit_prop} from  "./helper.js";
import { ball } from "./ball.js";

export class slider{
    public sliderImage: HTMLImageElement = new Image();
    public LEFT:Boolean = false;
    public RIGHT:Boolean = false;
    public y:number = Height - this.sliderImage.height -10;
    constructor(
        public width:number,
        public height:number,
        public slider_speed_x:number,
        public pos:Vector,
        public slider_Image:string,
    ){
        this.height = height;
        this.width = width;
        this.slider_speed_x = slider_speed_x;
        this.pos = pos;
        this.sliderImage.src = slider_Image;
        document.addEventListener("keydown",this.GO)
        document.addEventListener("keyup",this.Stop)
    }
    GO=(e:KeyboardEvent):void => {
        if (e.code === 'ArrowLeft' || e.key === 'ArrowLeft') this.LEFT = true;
        if (e.code === 'ArrowRight' || e.key === 'ArrowRight')this.RIGHT = true;
    }
    Stop=(e:KeyboardEvent):void =>{
        if (e.code === 'ArrowLeft' || e.key === 'ArrowLeft') this.LEFT = false;
        if (e.code === 'ArrowRight' || e.key === 'ArrowRight')
          this.RIGHT = false;
    };
    Move=():void =>{
        if (this.RIGHT && this.pos.x+this.sliderImage.width<Width) this.pos.x += this.slider_speed_x ;
        if (this.LEFT && this.pos.x>0) this.pos.x -= this.slider_speed_x;
    };
    GET_MID_X=():number =>{
        return this.pos.x + (this.width *.5);
    };
    GET_MID_y=():number =>{
        return this.pos.y + (this.height * 0.5);
    };
    collide(r1:ball):void{
        var dx=(r1.pos.x+r1.width/2)-(this.pos.x+this.width/2);
        var dy=(r1.pos.y+r1.height/2)-(this.pos.y+this.height/2);
        var width=(r1.width+this.width)/2;
        var height=(r1.height+this.height)/2;
        var crossWidth=width*dy;
        var crossHeight=height*dx;
        if(Math.abs(dx)<=width && Math.abs(dy)<=height){
            if(crossWidth>crossHeight){
                if (crossWidth>(-crossHeight)){r1.Ball_speed_y*=-1;console.log("bottom")}else{r1.Ball_speed_x*=-1,console.log("left")};
            }else{
                if(crossWidth>-(crossHeight)){r1.Ball_speed_x*=-1;console.log("right")}else{r1.Ball_speed_y*=-1;console.log("top")};
            }
        }
    }
}