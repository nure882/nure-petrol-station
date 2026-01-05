import React, { useEffect } from 'react'
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import Select from '../components/UI/Select/Select';
import { registWorker } from '../http/authAPI';
import { getStations } from '../http/stationAPI';
import { MAIN_ROUTE } from '../utils/consts';

export default function RegistrationWorker() {
    const [form, setForm] = useState({email: "", password: "", confirmPassword: "", name: "", surname: "", birthday: null, stationId: 0})
    const [stations, setStations] = useState([]);
    const navigate = useNavigate();

    const regist = () => {
        if (form.confirmPassword === "" || form.email === "" || form.password === "" || form.name === "") {
            alert("Empty field")
        } else {
            if (form.password !== form.confirmPassword) {
                alert ("Wrong passwords")
            } else {
                registWorker(form).then(() => navigate(MAIN_ROUTE))
            }
        }
    }

    const normilizeStations = useMemo(() => {
        return [
          { id: 0, text: "not chosen" },
          ...stations.map(({ stationId, city, address }) => ({
            id: stationId,
            text: `№${stationId} (${city}, ${address})`
          }))
        ];
      }, [stations, form])

      useEffect(() => {
        getStations().then((data) => setStations(data));
      }, [])

  return (
    <Form label="Registration of worker">
          <Input value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} text="Email"></Input>
          <Input value={form.password} type="password" onChange={(e) => setForm({...form, password: e.target.value})} text="Password"></Input>
          <Input value={form.confirmPassword} type="password" onChange={(e) => setForm({...form, confirmPassword: e.target.value})} text="Confirm password"></Input>
          <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
          <Input value={form.surname} onChange={(e) => setForm({...form, surname: e.target.value})} text="Surname"></Input>
          <Input value={form.birthday} onChange={(e) => setForm({...form, birthday: e.target.value})} type="date" text="Birthday"></Input>
          <Select text="Station" options={normilizeStations} onChange={(e) => setForm({...form, stationId: e.target.value})}></Select>
          <Button onClick={(event) => { event.preventDefault(); regist();}}>Regist</Button>
    </Form>
  )
}
