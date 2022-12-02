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

// .............menu.............
let toggelNav = document.getElementById("toggel-nav");
let BigNav = document.getElementById("BigNav")
let Header = document.getElementById("Header")
let bigContainer = document.getElementById("bigContainer")
let btnOpen = document.getElementById("btn-open-menu")
let btnClose = document.getElementById("btn-close-menu")

if(btnOpen){
    btnOpen.addEventListener("click", function () {
        BigNav.classList.remove("width-menu");
        bigContainer.classList.add("padding-toggel");
        btnClose.style.display="block"
        btnOpen.style.display="none"
        })
}
if(btnClose){

    btnClose.addEventListener("click",function(){
      
        BigNav.classList.add("width-menu");
        bigContainer.classList.remove("padding-toggel");
        btnClose.style.display="none"
        btnOpen.style.display="block"
                })
            }

// ...............alertdropdowwn.............

let dropNotifaction = document.getElementById("dropNotifaction");
['click', 'blur'].forEach(function (ev) {
    document.getElementById("actionDrop").addEventListener(ev, function () {
        if (ev === "blur") {
            dropNotifaction.classList.add("hide-not");
        }
        if (ev === 'click') {
            dropNotifaction.classList.contains("hide-not") ? dropNotifaction.classList.remove("hide-not") : dropNotifaction.classList.add("hide-not");
        }
    })

});


// ...............filterdropdowwn.............

let DropFilter = document.getElementById("DropFilter");
    document.getElementById("filterAction").addEventListener("click", function () {

        if (DropFilter.classList.contains("hide-filter")) {
           DropFilter.classList.remove("hide-filter") ;
        }
    })
    document.getElementById("closeFilter").addEventListener("click", function () {
        DropFilter.classList.add("hide-filter") ;
    });

// ...............filterdropdowwn.............



    document.getElementById("actionNav").addEventListener("click", function () {

        if (BigNav.classList.contains("nav-mobile")) {
            BigNav.classList.remove("nav-mobile") ;
            document.getElementsByTagName("body")[0].classList.add("modal-open")
            document.getElementById("overLay").style.display ="block";
        }
      
    })
    document.getElementById("toggel-nav-mobile").addEventListener("click", function () {

            BigNav.classList.add("nav-mobile") ;
            document.getElementsByTagName("body")[0].classList.remove("modal-open")
            document.getElementById("overLay").style.display ="none";
      
    })

    document.getElementById("overLay").addEventListener("click", function(){
        BigNav.classList.add("nav-mobile") ;
        document.getElementsByTagName("body")[0].classList.remove("modal-open")
        document.getElementById("overLay").style.display ="none";

    })




// ...................table Check...............

let labelAction = document.querySelectorAll(".label-action");
let checkInput = Array.from(document.querySelectorAll(".input-check"))
let checkAllInput = Array.from(document.querySelectorAll(".default__check"))
let imageTable= document.querySelectorAll(".image-table");
let allSelect = document.getElementById("allCheck");
finalCheck = []
if(labelAction){
  labelAction.forEach((e)=>{
    e.addEventListener("change", function(){

let finalCheck = checkInput.filter((ele)=>{
    return (ele.checked)
    
})
if(finalCheck.length > 0 ){
    imageTable.forEach((img)=>{
        img.classList.add("imageHide")
    })
    document.getElementById("NumberDIv").style.display="block"
    document.getElementById("iconsTables").style.display= "block"
    document.getElementById("numberSelect").innerHTML=`${finalCheck.length}`
}else {
    imageTable.forEach((img)=>{
        img.classList.remove("imageHide")
    }) 
    document.getElementById("NumberDIv").style.display="none"
    document.getElementById("iconsTables").style.display= "none"

}
if(finalCheck.length === checkInput.length){
    document.getElementById("allCheckInput").checked=true;
}else{
    document.getElementById("allCheckInput").checked=false;
}

    })
})  
}



// ...............all click...
if(allSelect){
    allSelect.addEventListener("change", function(){
        if(document.getElementById("allCheckInput").checked){
            
            checkInput.forEach((e)=>{e.checked=true})
            imageTable.forEach((img)=>{
                img.classList.add("imageHide")
            })
            let finalCheck = checkInput.filter((ele)=>{
                return (ele.checked)
                
            })
    
            document.getElementById("NumberDIv").style.display="block"
            document.getElementById("iconsTables").style.display= "block"
            document.getElementById("numberSelect").innerHTML=`${finalCheck.length}`
        }else{
            checkInput.forEach((e)=>{e.checked=false})
            imageTable.forEach((img)=>{
                img.classList.remove("imageHide")
            })
            document.getElementById("NumberDIv").style.display="none"
            document.getElementById("iconsTables").style.display= "none"
        
        }
    
    })
}


// ...............clearbtn...
let clearSelection = document.getElementById("clearSelection");
if(clearSelection){
    clearSelection.addEventListener("click",function(){
        checkAllInput.forEach((e)=>{e.checked=false})
        imageTable.forEach((img)=>{
            img.classList.remove("imageHide")
        })
        let finalCheck = checkInput.filter((ele)=>{
            return (ele.checked)
            
        })
        document.getElementById("NumberDIv").style.display="none"
        document.getElementById("iconsTables").style.display= "none"
    
    
    })
    
}
// ...................contact Check...............
let labelActionContact = document.querySelectorAll(".action-contact-label");
let checkInputContact = Array.from(document.querySelectorAll(".input-contact"))
finalCheckContact = []
if(labelActionContact){
 labelActionContact.forEach((e)=>{
    e.addEventListener("change", function(){

let finalCheckContact = checkInputContact.filter((ele)=>{
    return (ele.checked)
    
})

if(finalCheckContact.length > 0 ){
    document.getElementById("NumContact").innerHTML=`${finalCheckContact.length}`
    document.getElementById("actionContact").style.display="block"
}else {
    document.getElementById("actionContact").style.display="none"

}
})
})   
}

// ...................chat ...............
let btnChat = document.getElementById("btnChat");
let closeChat = document.getElementById("close-chat");
let chatItem = document.querySelectorAll(".chat-item-li li");

if(btnChat){
    btnChat.addEventListener("click",()=>{
        document.getElementById("chatDiv").classList.remove("open-chat")
    })
}
if(closeChat){
    closeChat.addEventListener("click",()=>{
        document.getElementById("chatDiv").classList.add("open-chat")
        document.getElementById("chatItemDiv").style.display="none"
    })
}

// ...................chat item...............
if(chatItem){
    chatItem.forEach((e)=>{
        e.addEventListener("click",()=>{
        document.getElementById("chatItemDiv").style.display="block"
        })
    })
    document.getElementById("closeItemChat").addEventListener("click",()=>{
        document.getElementById("chatItemDiv").style.display="none"
    })
}



// ....................slide down..............

let linkToggle = document.querySelectorAll('.js-toggle');

for(i = 0; i < linkToggle.length; i++){

  linkToggle[i].addEventListener('click', function(event){

    event.preventDefault();

    let container = document.getElementById(this.dataset.container);

    if (!container.classList.contains('active')) {
      container.parentElement.classList.add("rotate-arrow");
      container.classList.add('active');
      container.style.height = 'auto';

      let height = container.clientHeight + 'px';

      container.style.height = '0px';

      setTimeout(function () {
        container.style.height = height;
      }, 0);
      
    } else {
      container.parentElement.classList.remove("rotate-arrow");

      container.style.height = '0px';

      container.addEventListener('transitionend', function () {
        container.classList.remove('active');
      }, {
        once: true
      });
      
    }
    
  });

}




