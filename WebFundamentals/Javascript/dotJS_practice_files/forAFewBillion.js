function forAFewBillion(days){
  var money = 0.01;
  for(var i = 1; i <= days; i++){
    money = money * 2;
    //console.log(money);
    //console.log(i);
  }
  return money;
}
forAFewBillion(30);
