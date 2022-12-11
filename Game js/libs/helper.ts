import {Vector} from "./VEC.js"
import {block} from "./block.js"
import { slider } from "./slider.js";
import { ball } from "./ball.js";

type Collider = block|slider|ball;

export class hit_prop{
    public collider: Collider;
    public pos:Vector;
    public delta: Vector;
    public normal: Vector;
    public time: number;
  
    constructor(collider: Collider) {
      this.collider = collider;
      this.pos = new Vector();
      this.delta = new Vector();
      this.normal = new Vector();
      this.time = 0;
    }
}

export class Sweep {
    public hit: hit_prop | null;
    public pos: Vector;
    public time: number;
  
    constructor() {
      this.hit = null;
      this.pos = new Vector();
      this.time = 1;
    }
    
  }