
import './App.css';
import {useState } from 'react';
import { IndiaToEuro } from './CurrencyConvertor';

function App() {
  const [count,setCount]=useState(0);

  function increment(){
    setCount(count+1);
    alert(`Hello Member ${count+1}`);
  }

  function decrement(){
    setCount(count-1);
  }

  function sayWelcome(msg){
    alert(msg);
  }

  function submitForm(data){
    const value=data.get("value");
    const currency=data.get("currency");
    const convert={value:value,currency:currency};
    IndiaToEuro({...convert});
  }


  return (
    <div className="App">
      <h4>{count}</h4>
      <button onClick={increment}>Increment</button>
      <br/>
      <button onClick={decrement}>Decrement</button>
      <br />
      <button onClick={()=>sayWelcome('Welcome')}>Say welcome</button>
      <br />
      <button onClick={()=>alert("I was clicked")}>Click on me</button>
      <br />

      <h1>Currency Converter!!!</h1>
      <form action={submitForm}>
        <label>Amount: </label>
        <input style={{marginLeft:'20px'}} type='number' name='value'></input>
        <br />
        <label>Currency:</label>
        <input style={{marginLeft:'20px'}} type='text' name='currency'></input>
        <br /><br />
        <button style={{textAlign: 'center',marginLeft:'130px'}} type="submit">Submit</button>
      </form>
      
    </div>
  );
}

export default App;
