


var canvas_mix = $('#canvas_mix');

canvas_mix.css({
  width: 1900,
  height: 300
}).LineMixBar({
  data: {
      line: [[
          50, 60, 50, 60, 10,
          50, 60, 50, 60, 10,
          50, 60, 50, 60, 10,
          50, 60, 50, 60, 10,
          50, 60, 50, 60, 10,
          50, 60, 50, 60, 10
      ]],
     // bar: [
//          [0.1, 0.2], [0.3, 1], [0.9, 0.6], [0.8, 0.4], [0.8, 0.2],
//          [0.1, 0.2], [0.3, 0.7], [0.9, 0.6], [0.8, 0.4], [0.8, 0.2],
//          [0.1, 0.2], [0.3, 0.7], [0.9, 0.6], [0.8, 0.4], [0.8, 0.2],
//          [0.1, 0.2], [0.3, 0.7], [0.9, 0.6], [0.8, 0.4], [0.8, 0.2],
//          [0.1, 0.2], [0.3, 0.7], [0.9, 0.6], [0.8, 0.4], [0.8, 0.2],
//          [0.1, 0.2], [0.3, 0.7], [0.9, 0.6], [0.8, 0.4], [0.8, 0.2]
//      ],
      floatTitle: [
          'Oct, 10', 'Oct, 11', 'Oct, 12', 'Oct, 13', 'Oct, 14',
          'Oct, 10', 'Oct, 11', 'Oct, 12', 'Oct, 13', 'Oct, 14',
          'Oct, 10', 'Oct, 11', 'Oct, 12', 'Oct, 13', 'Oct, 14',
          'Oct, 10', 'Oct, 11', 'Oct, 12', 'Oct, 13', 'Oct, 14',
          'Oct, 10', 'Oct, 11', 'Oct, 12', 'Oct, 13', 'Oct, 14',
          'Oct, 10', 'Oct, 11', 'Oct, 12', 'Oct, 13', 'Oct, 14'
      ],
      top: [[
          '10000', '200', '30000', '10000', '1000',
          '10000', '200', '30000', '10000', '1000',
          '10000', '200', '30000', '10000', '1000',
          '10000', '200', '30000', '10000', '1000',
          '10000', '200', '30000', '10000', '1000',
          '10000', '200', '30000', '10000', '1000'
      ]]
  },
  legends: {
      bar: ['Index 1', 'Index 2'],
      line: ['Index 3'],
      top: ['Index 4']
  },
  units: {
      bar: [],
      line: [' '],
      top: []
  },
  colors: {
      line: ['#FFAA88'],
      bar: ['#FFEA98', '#C5EAFF', '#98D0FF'],
      top: ['#946A33']
  },  
  background: 'transparent',  
  isDebug: false,     
  axis: {                                            
      x: [
          ['10-10', 'A4'], ['10-11', 'A4'], ['10-12', 'A4'], ['10-13', 'A4'], ['10-14', 'A4'],
          ['10-10', 'A4'], ['10-11', 'A4'], ['10-12', 'A4'], ['10-13', 'A4'], ['10-14', 'A4'],
          ['10-10', 'A4'], ['10-11', 'A4'], ['10-12', 'A4'], ['10-13', 'A4'], ['10-14', 'A4'],
          ['10-10', 'A4'], ['10-11', 'A4'], ['10-12', 'A4'], ['10-13', 'A4'], ['10-14', 'A4'],
          ['10-10', 'A4'], ['10-11', 'A4'], ['10-12', 'A4'], ['10-13', 'A4'], ['10-14', 'A4'],
          ['10-10', 'A4'], ['10-11', 'A4'], ['10-12', 'A4'], ['10-13', 'A4'], ['10-14', 'A4']
      ],                                       
      fontSize: 12,                                   
      fontFamily: 'Microsoft YaHei',                 
      color: '#666666',                          
      lineColor: '#EEEEEE',                         
      lineWidth: 1,                                
      textMarginTopX: 5,                          
      activeLine: {
          width: 1,
          color: '#999999'
      }
  },
  bar: {
      gap: 2,
      max: 1,
      min: 0,
      default:'',
      defaultColor:'#CCCCCC',
      width: undefined,
      type: 0      // 0 or 1
  },
  line: {
      width: 2,
      dashedLength: 5,
      areaType: 1,          // 0 / 1 / 2
      max: 100,
      min: 0,
      default:'',
      point: {
          radius: 3,
          width: 1,
          fill: 'white'
      }
  },
  top: {
      fontSize: 12,
      fontFamily: 'Roboto',
      color: '#666666', 
      textMarginBottom: 5
  }
}).draw();


//var canvas_pie = $('#canvas_pie');
//
//canvas_pie.css({
//    width: 300,
//    height: 300
//}).Pie({
//    data: [30, 30, 40],
//    colors: ['#ff6131', '#ffad1f', '#4ebf42'],  
//    spacing: 30,        
//    background: 'transparent', 
//    frames: 60,        
//    startAngle: 1,     
//    isAnimation: true,  
//    animationTime: 3,   
//    events: {                         
//        start: function (options) {            
//        },
//        drawing: function (cValue, tValue, options) {   
//        },
//        end: function (options) {              
//        }
//    },
//    proportion: {                       
//        isShow: true,                  
//        fontSize: 10,                    
//        fontFamily: 'Roboto',
//        textColor: '#333333',
//        lineColor: '#333333',
//        lineWidth: 1,            
//        lineLength: 20
//    },
//    title: {                      
//        text: 'Title 1',              
//        fontSize: 20,                  
//        fontFamily: 'Roboto',  
//        color: '#333333'              
//    },
//    subTitle: {
//        text: 'Title 2',            
//        fontSize: 14,                
//        fontFamily: 'Roboto', 
//        color: '#333333'
//    }
//}).draw();




var myLabelFormatter = function (context) {
    var label = context.label;

    // if it's a single bird seen, add an exclamation mark to the outer label
    if (context.section === 'outer') {
        if (context.value === 1) {
            label = label + '!';
        }
    }
    return label;
};

var pie = new d3pie("pie", {
  //  header: {
//        title: {
//            text: "Nice birds I saw this morning",
//            fontSize: 22
//        }
//    },
    size: {
        "pieOuterRadius": "100%"
    },
    labels: {
        formatter: myLabelFormatter,
        inner: {
            format: "value"
        }
    },
    data: {
        content: [
            { label: "Nashville warbler", value: 1 },
            { label: "Black-throated gray warbler", value: 5 },
            { label: "Yellow-rumped warbler", value: 2 },
            { label: "Orange-crowned warbler", value: 8 },
            { label: "Townsend's warbler", value: 10 },
            { label: "Cassin's vireo", value: 1 }
        ]
    }
});



//
//var canvas_exponent = $('#canvas_exponent');
//
//canvas_exponent.css({
//  width: 300,
//  height: 200
//}).Exponent({
//  target: 3,
//  data: [1.8142, 1.311, 0.8079],
//  colors: ["#ffd076", "#43e1a7", "#fee0a6"],
//  background: 'transparent', 
//  frames: 60,        
//  isAnimation: true,
//  animationTime: 5,  
//  lineWidth: 1,
//  isDebug: false,  
//  isPercent: true, 
//  events: {                                       
//      start: function (options) {                    
//      },
//      drawing: function (cValue, tValue, options) {  
//      },
//      end: function (options) {                       
//      }
//  },
//  axis: {                                            
//      x: ['', '1 Year', '2 Years', '3 Years'],  
//      y: 4,                                        
//      fontSize: 10,                              
//      fontFamily: 'Roboto',                  
//      color: '#666666',                              
//      lineColor: '#EEEEEE',                           
//      lineWidth: 1,                                   
//      manualY: false,                               
//      minY: 0,                                      
//      maxY: 10,                                     
//      isShowMinY: true
//  }
//}).draw();
//
//var canvas_line = $('#canvas_line');
//
//canvas_line.css({
//  width: 300,
//  height: 200
//}).Line({
//  data: [[0.21,0.38,0.12,0.44,0.36,0.21,0.25],[1,1,1,1,1,1,1]],
//  colors: ["#99d1fd", "#fed27c"],
//  isArea: [true,false],  
//  background: 'transparent',
//  frames: 60,   
//  isAnimation: true, 
//  animationTime: 5, 
//  lineWidth: 1,   
//  isDebug: false,  
//  events: {                                         
//      start: function (options) {                    
//      },
//      drawing: function (cValue, tValue, options) { 
//      },
//      end: function (options) {                       
//      }
//  },
//  axis: {                                           
//      x:["08-22","08-31","09-07","09-14"],                                        
//      y:4,                                           
//      fontSize: 10,                                   
//      fontFamily: 'Roboto',                 
//      color: '#666666',                             
//      lineColor:'#EEEEEE',                            
//      lineWidth:1,                                    
//      precision: 2,                                  
//      isPercent: true,                               
//      manualY: false,                                 
//      minY: 0,                                    
//      maxY: 0                                        
//  }
//}).draw();


//
//var canvas_meter = $('#canvas_meter');
//
//canvas_meter.css({
//    width: 250,
//    height: 250
//}).Meter({
//    target: 80,                
//    min: 0,                    
//    max: 100,                  
//    background: 'transparent', 
//    frames: 60,                 
//    startAngle: 0.8,           
//    endAngle: 2.2,             
//    isAnimation: true,          
//    animationTime: 3,          
//    isDebug: false,             
//    events: {                                 
//        start: function (options) {           
//        },
//        drawing: function (cValue, tValue, options) {  
//        },
//        end: function (options) {     
//        }
//    },
//    colors: ['#ff6131', '#ffad1f', '#4ebf42', '#317fff'],
//    title: {                   
//        text: 'Score',           
//        fontSize: 18,               
//        fontFamily: 'Roboto', 
//        color: '#333333'            
//    },
//    subTitle: {
//        text: 'Custom Text',   
//        fontSize: 14,          
//        fontFamily: 'Roboto', 
//        color: '#333333'            
//    },
//    arc: {
//        type: 0,  // 0 or 1
//        defaultColor: 'rgba(51, 51, 51,0.2)',
//        targetColor: '#FFFFFF',
//        width: 1,
//        pointRadius: 6
//    },
//    tick: {
//        type: 0,   // 0 or 1
//        length: 10,
//        width: 1,
//        defaultColor0: '#3c3c3c',
//        defaultColor1: '#3c3c3c',
//        targetColor: '#3c3c3c'
//    },
//    tickText: {
//        fontSize: 10,               
//        color: '#3c3c3c',  
//        fontFamily: 'Roboto' 
//    },
//    scoreText: {
//        fontSize: 50,
//        fontFamily: 'Roboto',
//        type: 0,   // 0 or 1
//        color: '#333333',
//        precision: 2
//    }
//}).draw();
//

var canvas_radar = $('#canvas_radar');

canvas_radar.css({
    width: 300,
    height: 300
}).Radar({
    data: [8, 8, 6, 4, 7],
    background: 'transparent',  //背景颜色
    min: 0,
    max: 10,
    dimensions: {
        data: ['jQuery', 'JavaScript', 'Pythor', 'HTML5', 'CSS3'],
        fontSize: 12,                                   //文字大小
        fontFamily: 'Microsoft YaHei',                  //字体
        color: '#666666',                              //文字颜色
        margin: 5
    },
    colors: {
        base: {
            line: '#ced0d1',
            background: '#e2f6ff'
        },
        data: {
            line: '#1799d3',
            background: '#1799d3',
            opacity:0.5
        }
    },

    frames: 60,        //帧数
    isAnimation: true,  //是否启用动画
    animationTime: 5,   //动画时间
    isDebug: false,     //是否调试模式
    events: {                                           //绘图事件
        start: function (options) {                     //开始绘图
        },
        drawing: function (cValue, tValue, options) {   //没帧开始
        },
        end: function (options) {                       //绘图结束
        }
    }
}).draw();

//var canvas_scale = $('#canvas_scale');
//
//canvas_scale.css({
//    width: 300,
//    height: 120
//}).Scale({
//    type: 1, // 0 or 1
//    min: 0,
//    max: 100,
//    target: 100,
//    background: 'transparent', 
//    frames: 60,    
//    isAnimation: true,
//    animationTime: 5,
//    isDebug: false,   
//    events: {                                   
//        start: function (options) {                   
//        },
//        drawing: function (cValue, tValue, options) { 
//        },
//        end: function (options) {                     
//        }
//    },
//    tick: {
//        colorType: 0, // 0 or 1
//        valueType: 0, // 0 or 1
//        width: 1, 
//        defaultColor: '#CCCCCC',
//        targetColor: '#ffc733', 
//        tickCount: 100,
//        textColor: '#999999',  
//        fontSize: 12,  
//        fontFamily: 'Roboto'
//    },
//    cursor: {
//        textColor: 'white',           
//        fontSize: 10,          
//        fontFamily: 'Roboto',
//        background: 'black',           
//        triangleColor: 'black',
//        textStart: '',             
//        textEnd: '' 
//    },
//    colors: ['#3bb268', '#48efb2', '#ffee30', '#ffa530', '#ff6131']
//}).draw();
//
//var canvas_scatter = $('#canvas_scatter');
//
//canvas_scatter.css({
//  width: 300,
//  height: 300
//}).Scatter({
//  alpha: 0.3,
//  beta: 1, 
//  background: 'transparent', 
//  frames: 60, 
//  isAnimation: true,  
//  animationTime: 5,
//  lineWidth: 1,        
//  isDebug: false,  
//  events: {                               
//      start: function (options) {     
//      },
//      drawing: function (type,cValue, tValue, options) {  
//      },
//      end: function (options) {           
//      }
//  },
//  axis: {                                         
//      color: '#666666',
//      width: 1
//  },
//  point: {               
//      color: '#666666',  
//      radius: 1,        
//      count: 60,         
//      rang: 20
//  },
//  line: {                
//      base: {               
//          width: 1,          
//          color: 'orange'     
//      },
//      alpha: {
//          width: 1,        
//          color: 'red'     
//      },
//      beta: {
//          width: 1,        
//          color: 'green'     
//      }
//  },
//  valueText: {                    
//      type: 2,                     
//      fontSize: 12,                  
//      fontFamily: 'Roboto', 
//      color: '#333333'              
//  }
//}).draw();