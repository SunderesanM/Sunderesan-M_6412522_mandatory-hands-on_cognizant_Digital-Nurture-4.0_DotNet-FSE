import './App.css';
import { Blog } from './components/Blog';
import { Book } from './components/Book';
import { Course } from './components/Course';

function App() {
  return (
    <div className="App">
      <div className="section">
        <Course />
      </div>

      <div className="divider"></div>

      <div className="section">
        <Book />
      </div>

      <div className="divider"></div>

      <div className="section">
        <Blog />
      </div>

    </div>
  );
}

export default App;
