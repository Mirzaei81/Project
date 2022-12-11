var red = document.getElementById("red");
var yellow = document.getElementById("yellow");
var green = document.getElementById("green");
var blue = document.getElementById("blue");
var level = 4;
var last_random = null;
var colors = [red,yellow,green,blue];
var finished = true;
var parent = document.querySelector(".parent");
var C_list = [];
var index = 0;
var span = document.querySelector("span");

for (let i=0;i<colors.length;i++){
    colors[i].addEventListener("click",is_choise_currect);
}

function show_seq(){
    let i = 0;
    (function blink(){
        let current = C_list[i];
        console.log(current.id);
        current.classList.remove(current.id+"_blink");
        void current.offsetWidth;
        current.classList.add(current.id+"_blink");
        i++;
        if (i < C_list.length){
            setTimeout(blink, 2000);
        }
        else{
            setTimeout(function(){
                parent.classList.remove("no_tap");
                document.getElementById("status").innerHTML = "Choose PLZ";
            },2000)
        }
    })();
}

function R_color(){
    return colors[Math.floor(Math.random() * colors.length)];
}

function draw_Color(){
    index=0;
    document.getElementById("status").innerHTML = "Wait for lights";
    parent.classList.add("no_tap");
    C_list.push(R_color());
    span.innerHTML = C_list.length;
    show_seq();
}


function is_choise_currect(){
    if (C_list.length !=0){
        if (index <C_list.length){
            if (this == C_list[index]){
                index++;
                if(index == C_list.length){
                    draw_Color();
                }
            }
            else if(this != C_list[index]){
                index = 0;
                span.innerHTML =0;
                C_list = [];
                document.querySelector("#status").innerHTML = "Oops You were wrong";
            }


}}
}