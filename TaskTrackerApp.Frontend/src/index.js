import ReactDOM from 'react-dom/client'
import './index.css'
import App from './Components/App';
import Modal from 'react-modal';

Modal.setAppElement('#root');

let root = ReactDOM.createRoot(document.getElementById("root"));

root.render(<App />);