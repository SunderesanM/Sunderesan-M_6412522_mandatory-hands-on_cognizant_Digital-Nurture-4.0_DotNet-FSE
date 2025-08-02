export const ListOfPlayers = ({players}) => {

  return (
    players.map((player)=>{
        return(
            <div>
                <li>Mr. {player.name}<span> {player.score}</span></li>
            </div>
        )
    })
  );
};

export const FilteredPlayers=({players})=>{
    return(
    players.map((player)=>{
        if(player.score<=70){
            return(
                <div>
                    <li>Mr. {player.name}<span> {player.score}</span></li>
                </div>
            )
        }
        
    })
);
};

