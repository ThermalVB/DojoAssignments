$(document).ready(function(){
  $('img').click(function() {
    console.log('Trying...');
    console.log($(this).text('img src'));
    console.log($(this).text('data-alt-src'));
  });
});
