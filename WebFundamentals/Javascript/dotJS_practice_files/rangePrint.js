function printRange(end, start = 0, skip = 1){
  //skip = typeof skip !== 'undefined' ?  skip : 1;
  //start = typeof start !== 'undefined' ?  start : 0;
  if(end > start){
    for(var i = start; i < end; i += skip){
      console.log(i);
    }
  }
  else{
    for(var i = start; i > end; i -= skip){
      console.log(i);
    }
  }
}
printRange(-5);
