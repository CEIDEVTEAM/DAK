
import * as React from 'react';
import DenseAppBar from './components/DenseAppBar';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './components/navbar/Navbar';
import Home from './pages/Home';
import Products from './pages/Products';
import Checkout from './pages/CheckOut';
import PackageRegistration from './pages/PackageRegistration';

export default function App() {
  return (
    <>
      <Router>
        <Navbar />
        <Routes>
          <Route path='/' element={<Home/>} />
          <Route path='/checkOut' element={<Checkout/>} />
          <Route path='/Products' element={<Products/>} /> 
          <Route path='/PackageRegistration' element={<PackageRegistration/>} /> 
        </Routes>
      </Router>

      
   
    </>
    
  );
}

