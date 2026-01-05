import jwtDecode from 'jwt-decode'
import React from 'react'
import { useContext } from 'react'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Context } from '..'
import Button from '../components/UI/Button/Button'
import Form from '../components/UI/Form/Form'
import Input from '../components/UI/Input/Input'
import { defaultLogin } from '../http/authAPI'
import cl from '../styles/Login.module.css'
import { MAIN_ROUTE } from '../utils/consts'
import mapJwtClaims from '../utils/mapJwtClaims'

export default function Login() {
  const {user} = useContext(Context)
  const navigate = useNavigate();
  const [form, setForm] = useState({login: "", password: ""});

  const login = () => {
    defaultLogin(form).then((res) => {
      if (!res.successed) {
        alert(res.errorString)
      } else if (res.successed) {
        localStorage.setItem('GasStationToken', res.jwtToken)
        user.setUser(mapJwtClaims(jwtDecode(res.jwtToken)));
        user.setIsAuth(true);
        navigate(MAIN_ROUTE); 
      }
    })
  }
  return (
    <Form label="Login">
      <Input value={form.login} onChange={(e) => setForm({...form, login: e.target.value})} text="Email"></Input>
      <Input value={form.password} type="password" onChange={(e) => setForm({...form, password: e.target.value})} text="Password"></Input>
      <Button onClick={(event) => { event.preventDefault(); login();}}>Login</Button>
    </Form>
  )
}
