$(document).ready(function(){
$(".open-menu").click(function(){
    $(".magic-line-menu-pill").slideToggle()();
})
})


// -------------PASSWORD------------



let showPass  = document.getElementById('show-pass');
let inputPass  = document.querySelector('.input-pass');



if(showPass){


showPass.addEventListener("click", function(e) {

if(showPass.classList.contains("fa-eye")){
showPass.classList.remove("fa-eye")
showPass.classList.add("fa-eye-slash")
inputPass.setAttribute('type', 'text')


}else{
showPass.classList.add("fa-eye")
showPass.classList.remove("fa-eye-slash")
inputPass.setAttribute('type', 'password')

}


})
}

// -------------Menu------------

let menuFixed = document.querySelector(".nav-menu");
let menuAction = document.querySelector("header");
let wScroll = window.pageYOffset;

if(menuFixed){
    window.onscroll = function () {
        if(document.body.scrollTop >= 40){
         menuFixed.style.cssText = "position:fixed; top:0px; left:0px";
     
        }else{
            menuFixed.style.cssText = "position:static";
        }
     }
     
}
//...................rocket ................	
$(function() {
    $.fn.scrollToTop = function() {
    $(this).hide().removeAttr("href");
    if ($(window).scrollTop() != "0") {
    $(this).fadeIn("slow")
    }
    var scrollDiv = $(this);
    $(window).scroll(function() {
    if ($(window).scrollTop() == "0") {
    $(scrollDiv).fadeOut("slow")
    } else {
    $(scrollDiv).fadeIn("slow")
    }
    });
    $(this).click(function() {
    $("html, body").animate({
    scrollTop: 0
    }, "slow")
    })
    }
    });
    $(function() {
    $("#hb-gotop").scrollToTop();
    });

          // -------------timer------------
          let circle = document.getElementById('pink-halo');
          let myTimer = document.getElementById('myTimer');
          let timerCount = document.querySelector(".timer");
          let resendCode = document.getElementById('resend-code');
          
    if(circle){
           function timerCounFun () {
            let t = 60;
            let interval = 60;
            let angle = 0;
            let angle_increment = 360/t;
            let intervalCounter = 0;
        
          window.timer = window.setInterval(function () {
            intervalCounter ++;    
              circle.setAttribute("stroke-dasharray", angle + ", 361");
           
             myTimer.innerHTML = t - parseInt((angle/360)*t);
      
              if (angle >= 360) {
                  window.clearInterval(window.timer);
                  timerCount.style.display="none";
                  resendCode.style.display="inline-block";
    
              }
           
           
      
            angle += angle_increment/(1000/interval);
          }.bind(this), interval);
      };
      timerCounFun()
    
      resendCode.addEventListener("click", function(ele) {
    
    ele.target.style.display ="none"
    timerCount.style.display="flex";
    timerCounFun()
      })
    }
    

    //...................adv..........

        
	$(document).ready(function(e) {
        
    
    $(window).on('load', function() {
          $('#myModal').modal('show');
      });
    
    $(".menu-icon-div").click(function(e) {
          $(".big-menu").addClass("open-menu");
              $(".over-menu").show();
  
      });
    $(".close-menu, .over-menu").click(function(e) {
          $(".big-menu").removeClass("open-menu");
              $(".over-menu").hide();
  
      });
    $(".btn-open-filter").click(function(e) {
          $(".filter-div").slideToggle();
    
  
      });
    
    
  });


  // ................
  let DropDown = document.getElementById("drop-Down");
  ['click', 'blur'].forEach(function (ev) {
      document.getElementById("triggerToggle").addEventListener(ev, function () {
          if (ev === "blur") {
              DropDown.classList.add("Toggle");
          }
          if (ev === 'click') {
              DropDown.classList.contains("Toggle") ? DropDown.classList.remove("Toggle") : DropDown.classList.add("Toggle");
          }
      })
  
  });