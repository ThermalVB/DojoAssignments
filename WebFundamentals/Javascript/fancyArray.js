function fancyArray (arr, symb = "->", reversed = false){
  if(reversed == false){
    for(var i = 0; i < arr.length; i++){
      console.log(i + " " + symb + " " + arr[i]);
    }
  }
  else{
    for(var i = arr.length - 1; i >= 0; i--){
      console.log(i + " " + symb + " " + arr[i]);
    }
  }
}
//fancyArray([1,2,3,4,5],"---", true);
