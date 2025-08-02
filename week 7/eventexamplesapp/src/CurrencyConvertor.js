export const IndiaToEuro=({...data})=>{
    const euro=(data.value/101);
    alert(`Converting to ${data.currency} Amount is ${euro}`);
}