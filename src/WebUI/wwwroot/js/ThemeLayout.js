// .............them............

let darkTheme = document.getElementById("darkTheme");
let lightTheme = document.getElementById("lightTheme");
let cloudTheme = document.getElementById("cloudTheme");
//window.localStorage.clear();

if(darkTheme){    
darkTheme.addEventListener("change", function(e){
 
  if(e.target.checked){
 localStorage.setItem("Theme", "DarkTheme");
 document.getElementsByTagName("body")[0].classList.add("Dark")
 document.getElementsByTagName("body")[0].classList.remove("Light")
 document.getElementsByTagName("body")[0].classList.remove("Cloud")

    }
})
}
if(lightTheme){    
  lightTheme.addEventListener("change", function(e){
   
    if(e.target.checked){
   localStorage.setItem("Theme", "LightTheme");
   document.getElementsByTagName("body")[0].classList.add("Light")
   document.getElementsByTagName("body")[0].classList.remove("Dark")
   document.getElementsByTagName("body")[0].classList.remove("Cloud")

      }
  })
  }

  if(cloudTheme){    
    cloudTheme.addEventListener("change", function(e){
     
      if(e.target.checked){
     localStorage.setItem("Theme", "CloudTheme");
     document.getElementsByTagName("body")[0].classList.add("Cloud")
     document.getElementsByTagName("body")[0].classList.remove("Dark")
     document.getElementsByTagName("body")[0].classList.remove("Light")      
      }
    })
    } 




if(localStorage.getItem("Theme")==="DarkTheme"){
 document.getElementsByTagName("body")[0].classList.add("Dark")
 if(darkTheme){
    darkTheme.checked=true
 }

}
if(localStorage.getItem("Theme")==="LightTheme"){
 document.getElementsByTagName("body")[0].classList.add("Light")
 if(lightTheme){
  lightTheme.checked=true
 }
}
if(localStorage.getItem("Theme")==="CloudTheme"){
  document.getElementsByTagName("body")[0].classList.add("Cloud")
  if(cloudTheme){
    cloudTheme.checked=true
  }
 }
if(localStorage.getItem("Theme")===null){

document.getElementsByTagName("body")[0].classList.add("Cloud");
if(cloudTheme){
  cloudTheme.checked=true
 }
}



//..........fullscreen.............


let FullScreen = document.getElementById("FullScreen");

if(FullScreen){


FullScreen.addEventListener("change", function(e) 
	{
		if (e.target.checked) {
      localStorage.setItem("FullScreen", "active");
		var Full = document.documentElement,
		  rfs = Full.requestFullscreen
			|| Full.webkitRequestFullScreen
			|| Full.mozRequestFullScreen
			|| Full.msRequestFullscreen 
		;
		}else{
			document.exitFullscreen();
      localStorage.removeItem("FullScreen", "active");

		}
	
		rfs.call(Full);
	});

}
