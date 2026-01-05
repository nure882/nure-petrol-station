import React from 'react'
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import { registAdmin } from '../http/authAPI';
import cl from '../styles/Login.module.css'
import { MAIN_ROUTE } from '../utils/consts';

export default function Registration() {
    const [form, setForm] = useState({email: "", password: "", confirmPassword: "", name: ""})
    const navigate = useNavigate();

    const regist = () => {
        if (form.confirmPassword === "" || form.email === "" || form.password === "" || form.name === "") {
            alert("Empty field")
        } else {
            if (form.password !== form.confirmPassword) {
                alert ("Wrong passwords")
            } else {
                registAdmin(form).then(() => navigate(MAIN_ROUTE))
            }
        }
    }

  return (
    <Form label="Registration">
          <Input value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} text="Email"></Input>
          <Input value={form.password} type="password" onChange={(e) => setForm({...form, password: e.target.value})} text="Password"></Input>
          <Input value={form.confirmPassword} type="password" onChange={(e) => setForm({...form, confirmPassword: e.target.value})} text="Confirm password"></Input>
          <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
          <Button onClick={(event) => { event.preventDefault(); regist();}}>Regist</Button>
    </Form>
  )
}
