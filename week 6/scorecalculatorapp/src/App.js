import './App.css';
import { CalculateScore } from './components/CalculateScore';

function App() {
  return (
    <div>
      <CalculateScore Name={"Sunderesan"}
      School={"Sathyabama Institute of Science and Technology"}
      total={294}
      goal={3} />
    </div>
  );
}

export default App;
