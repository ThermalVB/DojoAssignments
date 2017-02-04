$(document).ready(function(){
  //alert("ready");

  $(document).on("click", ".butt", function(){

    var first = $("#first").val();
    var last = $("#last").val();
    var description = $("#description").val();
    console.log(first,last,description);
    $("#cards").prepend("<div class='card1'><h1>"+first+" "+last+"</h1><button class='flip' style='button'>Flip</button></div>");
    $("#cards").append("<div class='card2'><h1>"+description+"</h1><button class='flip' style='button'>Flip</button></div>");

  });

  $(document).on("click", ".flip", function(){
    $(this).siblings().toggle();
    // $(".card2").slideToggle(function(){
    // });
    // $(".card2").css({"display": "inline-block"
    // });
  });

});
