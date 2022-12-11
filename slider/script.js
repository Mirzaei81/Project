var index = 0;
var images  = document.getElementsByClassName("slide fade");
slide_bar();
function slide_bar(){

    var i;
    for (i = 0;i<images.length;i++) {
        images[i].style.display = "none";
    }
    index ++ ;
    if (index >= images.length){
        index = 0
    }
    images[index].style.display = "block";
    setTimeout(slide_bar,2000);
}

function Slide_NUM(){
    index ++;
    if (index >= images.length){
        index = 0
    }
    var i = 0;
    for (i;i<images.length;i++){
        images[i].style.display = "none";
    }
    images[index].style.display = "block";
}

