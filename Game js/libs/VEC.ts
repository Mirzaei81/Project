import { ball } from "./ball";
import {height,width} from "./main.js"


export class Vector {
    public x: number;
    public y: number;
  
    constructor(x: number = 0, y: number = 0) {
      this.x = x;
      this.y = y;
    }
  
    public clone(): Vector {
      return new Vector(this.x, this.y);
    }
  
    public normalize(): number {
      let length = this.x * this.x + this.y * this.y;
      if (length > 0) {
        length = Math.sqrt(length);
        const inverseLength = 1.0 / length;
        this.x *= inverseLength;
        this.y *= inverseLength;
      } else {
        this.x = 1;
        this.y = 0;
      }
      return length;
    }
  }

export function coll_outside(ball:ball) {
    if (ball.pos.y < 0) ball.Ball_speed_y= -ball.Ball_speed_y;
    if (ball.pos.x+ball.width > width) ball.Ball_speed_x= -ball.Ball_speed_x;
    if (ball.pos.x < 0) ball.Ball_speed_x= -ball.Ball_speed_x;
};

export const epsilon =1e-8;

export function sign(value: number): number {
    return value < 0 ? -1 : 1;
};



