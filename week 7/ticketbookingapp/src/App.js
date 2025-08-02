import { useState } from 'react';
import './App.css';

function App() {

const [user,setUser]=useState(false);

function LoginButton(){
  return(
    <button onClick={()=>setUser(true)}>Login</button>
  )
}
function LogoutButton(){
  return(
    <button onClick={()=>setUser(false)}>Logout</button>
  )
}

function UserGreeting(){
  return(
    <h1>Welcome back</h1>
  );
}
function GuestGreeting(){
  return(
    <h1>Please sign up.</h1>
  )
}

function Greeting(){
  //if logged in
  if(user){
    return (
    <div>
    <UserGreeting />
    <LogoutButton />
    </div>
  );
  }
  //if logged out
  return (
    <div>
      <GuestGreeting />
      <LoginButton />
    </div>
  )
}

  return (
    <div className='App'>
      <Greeting />
    </div>
  );
}

export default App;
