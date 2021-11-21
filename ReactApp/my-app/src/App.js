
import * as React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './components/navbar/Navbar';
import Home from './pages/Home';
import Products from './pages/Products';
import PackageRegister from './pages/PackageRegister';

export default function App() {
  return (
    <>
      <Router>
        <Navbar />
        <Routes>
          <Route path='/' element={<Home/>} />
          <Route path='/PackageRegister' element={<PackageRegister/>} />
          <Route path='/Products' element={<Products/>} /> 
        </Routes>
      </Router>
    </>
    
  );
}

