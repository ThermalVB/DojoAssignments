$(document).ready(function(){
  //alert("ready");
  $(document).on("click", ".btn", function(){

    $(".username").submit(function(){
      return false;
    });

    var first = $("#first").val();
    var last = $("#last").val();
    var email = $("#email").val();
    var number = $("#number").val();
    console.log(first,last,email,number);
    $("#tablebody").append("<tr><td>"+first+"</td><td>"+last+"</td><td>"+email+"</td><td>"+number+"</td></tr>");

  });
});
