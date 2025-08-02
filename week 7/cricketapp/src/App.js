import { ListOfPlayers, FilteredPlayers } from './ListofPlayers';
import { OddPlayers, ListofIndianPlayers, EvenPlayers, IndianPlayers } from './IndianPlayers';



function App() {
  var flag=false;
  
  if(flag){

    const players = [
  { name: "Virat", score: 92 ,nation:"India"},
  { name: "Rohit", score: 45 ,nation:"India"},
  { name: "Dhoni", score: 89 ,nation:"India"},
  { name: "Jadeja", score: 66 ,nation:"India"},
  { name: "Bumrah", score: 35 ,nation:"India"},
  { name: "Head", score: 77 ,nation:"foreign"},
  { name: "Gayle", score: 54 ,nation:"foreign"},
  { name: "ABD", score: 81 ,nation:"foreign"},
  { name: "Williams", score: 70 ,nation:"foreign"},
  { name: "Starc", score: 49 ,nation:"foreign"},
  { name: "KlRahul", score: 99 ,nation:"India"},
];
  return (
    <div>
      <h1>List of players</h1>
      <ListOfPlayers players={players}/>
      <br />
      <hr />
      <h1>List of players who scores below 70</h1>
      <FilteredPlayers players={players}/>
    </div>
  );
}
  else {
    return (
      <div>
        <div>
          <h1>Indian Team</h1>
          <h1>Odd Players</h1>
          <OddPlayers />
          <hr />
          <h1>Even Players</h1>
          <EvenPlayers />
        </div>
        <hr />
        <div>
          <h1>List of Indian Players Merged:</h1>
          <ListofIndianPlayers IndianPlayers={IndianPlayers} />
        </div>
      </div>
    );
  }

}

export default App;
