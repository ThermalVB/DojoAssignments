//A program that takes hour, minute, and time of day and returns a message
function ifYouDontMind(hour,minute,period){
  var part1 = "";
  var part2 = "";
  var modTime;
  if(minute < 30){
    part1 = "It's just after ";
    modTime = hour;
    //console.log(part1);
    //console.log(modTime);
  }
  if(minute >= 30){
    part1 = "It's almost ";
    modTime = hour + 1;
    //console.log(part1);
    //console.log(modTime);
  }
  if(period === "AM"){
    part2 = " in the morning.";
    //console.log(part2);
  }
  if(period === "PM"){
    part2 = " in the evening.";
    //console.log(part2);
  }
  console.log(part1+modTime+part2);
  return(part1+modTime+part2);
}

ifYouDontMind(7,15,"PM");
