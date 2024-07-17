import './App.css';
import { Navbar, Container} from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';

import {Navbar1} from './Navbar';
import {HomePage} from './HomePage';

import Register from './components/Register';
import Login from './components/Login';
import './components/main.css'

import {UserProvider} from './components/Userprovider';
import {BrowserRouter,Routes,Route} from 'react-router-dom';

import MyTicket from './components/MyTicket';
import MovieDetail from './components/MovieDetail';
import OrderTicket from './components/OrderTicket';
import SeatPage from './components/SeatPage';

function App() {
  return (
    <UserProvider>
    
    <BrowserRouter>
        <Navbar1 />
      <Routes>
        <Route path='/' element={<main className="bg-dark text-light"><HomePage /></main>}></Route>
        <Route path='/register' element={<Register />} /> 
        <Route path='/login' element={<Login />} />
        <Route path='/myticket' element={<MyTicket />} />
        <Route path='/seatpage/:title/:room/:count' element={<SeatPage />} />
        <Route path='/moviedetails/:id' element={<MovieDetail />} />
        <Route path='/orderticket/:id' element={<OrderTicket />} />
      </Routes>
       <footer class="bg-secondary">
         <Container className="px-4 py-5">
           <p className="text-center text-white">
             Copyright &copy; CINEMAJESTY website 2023 <br/> Wilmer. Davenn. Alvin. Andreas. Bun Jak Sin.
           </p>
         </Container>
       </footer>
    </BrowserRouter>
    </UserProvider>
  );
}

export default App;
