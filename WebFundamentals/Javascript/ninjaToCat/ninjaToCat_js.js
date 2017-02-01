$(document).ready(function(){
  $('img').mouseenter(function() {
    console.log('Trying...');
    var $this = $(this); //This image saved as $this
    var currentSrc = $this.attr("src"); //Save the current src path
    var altSrc = $this.attr("data-alt-src"); //Save alt src path
    $this.attr("src",altSrc); //Set src path to alt src path
    $this.attr("data-alt-src",currentSrc); //Set alt src path to src path
    });
  });
