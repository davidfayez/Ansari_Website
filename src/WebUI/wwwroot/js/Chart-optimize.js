if(document.getElementById('myChart')){
const ctx = document.getElementById('myChart').getContext('2d');
const myChart = new Chart(ctx, {
  type: 'bar',
  data: {
    labels: ['Inbox', 'Trash', 'Send', 'Contact', ' Drafts  ',],
    datasets: [{
      label: '# of Votes',
      data: [20, 10, 3, 5, 2, 3],
      backgroundColor: [
        'rgba(54, 162, 235, 0.2)',
        'rgba(255, 99, 132, 0.2)',
        'rgba(105, 137, 170, 0.2)',
        'rgba(60, 161, 70, 0.2)',
        'rgba(255, 159, 64, 0.2)'
      ],
      borderColor: [
        'rgba(54, 162, 235, 1)',
        'rgba(255, 99, 132, 1)',
        'rgba(105, 137, 170, 1)',
        'rgba(60, 161, 70, 1)',
        'rgba(255, 159, 64, 1)'
      ],
      borderWidth: 1
    }]
  },
  options: {
    scales: {
      y: {
        beginAtZero: true
      }
    }
  }
});
}

// ....................lines..............

if(document.getElementById('LinesChart')){


const labels = [
  'January',
  'February',
  'March',
  'April',
  'May',
  'June',
  'July',
  'August',
  'September',
  'October',
  'November',
  'December',

];

const data = {
  labels: labels,
  datasets: [{
    label: 'Booking Chart',
    backgroundColor: 'rgb(33, 105, 147)',
    borderColor: 'rgb(43, 146, 205)',
    data: [0, 10, 5, 2, 20, 30, 45, 20, 30, 7, 30, 25],
  }]
};

const config = {
  type: 'line',
  data: data,
  options: {}
};


const LinesChart = new Chart(
  document.getElementById('LinesChart'),
  config
);

}


