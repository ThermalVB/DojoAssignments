$(document).ready(function(){
   $("img").click(function(){
     var id = $(this).attr("id")
     html_str = "";
     $.get("https://anapioficeandfire.com/api/houses/"+ id, function(data){
       var name = data.name;
       var words = data.words;
       console.log(words);

       html_str += "<li> "+ name +" </li>" ;
       html_str += "<li> "+ words +" </li>" ;
       for(var i = 0; i < data.titles.length; i++){
         html_str += "<li> "+ data.titles[i] +" </li>" ;
       }

       console.log(html_str);
       $("#list").html(html_str);
       }, "json");
     });
   });
//});
