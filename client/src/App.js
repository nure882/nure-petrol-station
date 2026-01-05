import React, { useContext, useEffect, useState } from 'react'
import {observer} from 'mobx-react-lite'
import { BrowserRouter } from 'react-router-dom';
import Navbar from './components/UI/Navbar/Navbar';
import AppRouter from './components/AppRouter';
import { Context } from '.';
import Spinner from './components/UI/Spinner/Spinner';
import { check } from './http/authAPI';
import jwtDecode from 'jwt-decode';
import mapJwtClaims from './utils/mapJwtClaims';
import "./styles/App.css";

const App = observer(() => {
  const {user} = useContext(Context);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    check().then(data => {
      console.log(data)
      user.setIsAuth(true);
      user.setUser(mapJwtClaims(jwtDecode(localStorage.getItem('GasStationToken'))))
    }).catch((e) => console.log(e)).finally(() => setLoading(false));
  }, [user])

  if(loading) {
    return <Spinner />
  }

  return (
    <div>
      <BrowserRouter className="browserRouter">
        <Navbar />
        <AppRouter />
      </BrowserRouter>
    </div>
  )
});

export default App;