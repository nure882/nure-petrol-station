import React, { useEffect } from 'react'
import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import cl from '../styles/Login.module.css'
import { MAIN_ROUTE } from '../utils/consts';
import {getAdmin, updateAdmin} from '../http/adminAPI'
import { useMemo } from 'react';
import Select from '../components/UI/Select/Select';
import { getStations } from '../http/stationAPI';

export default function UpdateAdmin() {
    const [form, setForm] = useState({ email: "", password: "", confirmPassword: "", name: "", stationId: 0})
    const [stations, setStations] = useState([]);
    const [admin, setAdmin] = useState();
    const navigate = useNavigate();
    const params = useParams();

    const update = async () => {
        if (form.confirmPassword === "" || form.password === "" || form.name === "") {
            alert("Empty field")
        } else {
            if (form.password !== form.confirmPassword) {
                alert ("Wrong passwords")
            } else {
                await updateAdmin({...form, userId: admin.userId}).then(() => navigate(-1));
            }
        }
    }
    
    const normilizeStations = useMemo(() => {
        return [...stations.map(({ stationId, city, address }) => ({
            id: stationId,
            text: `№${stationId} (${city}, ${address})`
          }))];
      }, [stations, form])

    useEffect(() => {
        getStations().then((data) => setStations(data))
        getAdmin(params.id).then((data) => {
            setAdmin(data);
            setForm({
                email: data.email,
                password: data.password,
                confirmPassword: data.password,
                name: data.name,
                stationId: data.stationId
            });
        })
    }, [])

  return (
    <Form label="Update admin">
          <Input disabled value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} text="Email"></Input>
          <Input value={form.password} type="password" onChange={(e) => setForm({...form, password: e.target.value})} text="Password"></Input>
          <Input value={form.confirmPassword} type="password" onChange={(e) => setForm({...form, confirmPassword: e.target.value})} text="Confirm password"></Input>
          <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
          <Select text="Station" value={form.stationId} options={normilizeStations} onChange={(e) => setForm({...form, stationId: e.target.value})}></Select>
          <Button onClick={(event) => { event.preventDefault(); update();}}>Update</Button>
    </Form>
  )
}
