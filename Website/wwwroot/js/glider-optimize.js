let Partner = document.querySelector('.Partner-Slider');
let Doctor = document.querySelector('.Doctor-Slider');
let Service = document.querySelector('.Service-Slider');
let Patient = document.querySelector('.Patient-Slider');
let Event = document.querySelector('.Event-Slider');
if(Partner){
  new Glider(document.querySelector('.Partner-Slider'), {
    // Mobile-first defaults
    slidesToShow: 1,
    draggable: true,
  
    slidesToScroll: 1,
    scrollLock: true,
    dots: '#resp-dots',
    arrows: {
      prev: '.partner-prev',
      next: '.partner-next'
    },
    responsive: [
      {
        // screens greater than >= 775px
        breakpoint: 200,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 1,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 600,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 2,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 768,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 3,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },{
        // screens greater than >= 1024px
        breakpoint: 992,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      }
    ]
  });
  
}


if(Doctor){
  new Glider(document.querySelector('.Doctor-Slider'), {
    // Mobile-first defaults
    slidesToShow: 1,
    draggable: true,
  
    slidesToScroll: 1,
    scrollLock: true,
    dots: '#resp-dots',
    arrows: {
      prev: '.Doctor-prev',
      next: '.Doctor-next'
    },
    responsive: [
      {
        // screens greater than >= 775px
        breakpoint: 200,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 1,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 600,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 2,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 768,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 3,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },{
        // screens greater than >= 1024px
        breakpoint: 992,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      }
    ]
  });
  
}


if(Service){
  new Glider(document.querySelector('.Service-Slider'), {
    // Mobile-first defaults
    slidesToShow: 1,
    draggable: true,
  
    slidesToScroll: 1,
    scrollLock: true,
    dots: '#resp-dots',
    arrows: {
      prev: '.Service-prev',
      next: '.Service-next'
    },
    responsive: [
      {
        // screens greater than >= 775px
        breakpoint: 200,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 1,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 600,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 2,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 768,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 2,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },{
        // screens greater than >= 1024px
        breakpoint: 992,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      }
    ]
  });
  
}


if(Patient){
  new Glider(document.querySelector('.Patient-Slider'), {
    // Mobile-first defaults
    slidesToShow: 1,
    draggable: true,
  
    slidesToScroll: 1,
    scrollLock: true,
    dots: '#resp-dots',
    arrows: {
      prev: '.Patient-prev',
      next: '.Patient-next'
    },
    responsive: [
      {
        // screens greater than >= 775px
        breakpoint: 200,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 1,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 600,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 2,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 768,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 2,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      },{
        // screens greater than >= 1024px
        breakpoint: 992,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 1,
          itemWidth: 150,
          duration: 1
        }
      }
    ]
  });
  
}

if(Event){
  new Glider(document.querySelector('.Event-Slider'), {
    // Mobile-first defaults
    slidesToShow: 1,
    draggable: true,
  
    slidesToScroll: 1,
    scrollLock: true,
    dots: '#resp-dots',
    arrows: {
      prev: '.Event-prev',
      next: '.Event-next'
    },
    responsive: [
      {
        // screens greater than >= 775px
        breakpoint: 200,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 1,
          slidesToScroll: 1,
          itemWidth: 200,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 600,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 2,
          slidesToScroll: 1,
          itemWidth: 200,
          duration: 1
        }
      },
      {
        // screens greater than >= 775px
        breakpoint: 768,
        settings: {
          // Set to `auto` and provide item width to adjust to viewport
          slidesToShow: 2,
          slidesToScroll: 1,
          itemWidth: 200,
          duration: 1
        }
      },{
        // screens greater than >= 1024px
        breakpoint: 992,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 1,
          itemWidth: 250,
          duration: 1
        }
      }
    ]
  });
  
}

