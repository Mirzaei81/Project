import { Vector } from "./VEC.js";
var hit_prop = /** @class */ (function () {
    function hit_prop(collider) {
        this.collider = collider;
        this.pos = new Vector();
        this.delta = new Vector();
        this.normal = new Vector();
        this.time = 0;
    }
    return hit_prop;
}());
export { hit_prop };
var Sweep = /** @class */ (function () {
    function Sweep() {
        this.hit = null;
        this.pos = new Vector();
        this.time = 1;
    }
    return Sweep;
}());
export { Sweep };
