function randomChance(qtrs, walkingAwayWith = 100){
  var win = 0;
  while(qtrs > 0 && qtrs < walkingAwayWith){
    qtrs--;
    if(Math.floor(Math.random() * 100) == 1){
      win = Math.floor( 50 + Math.random() * 50);
      qtrs += win;
    }
  console.log(qtrs);
  }
}
