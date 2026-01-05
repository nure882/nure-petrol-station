import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form'
import Input from '../components/UI/Input/Input';
import { getStation, updateStation } from '../http/stationAPI';
import { STATIONS_ROUTE, STATION_ROUTE } from '../utils/consts';

export default function UpdateStation() {
    const [form, setForm] = useState({stationId: 0, city: "", address: "", workTime: "", description: "", equipmentList: ""});
    const navigate = useNavigate();
    const params = useParams();

    const update = async () => {
        await updateStation(form).then(() => {
            navigate(STATION_ROUTE + `/${params.id}`);
        })
    }

    useEffect(() => {
        getStation(params.id).then(({stationId, city, address, workTime, description, equipmentList}) => 
            setForm({stationId, city, address, workTime, description, equipmentList}));
    }, [])

  return (
    <Form label="Update station">
        <Input value={form.city} onChange={(e) => setForm({...form, city: e.target.value})} text="City"></Input>
        <Input value={form.address} onChange={(e) => setForm({...form, address: e.target.value})} text="Address"></Input>
        <Input value={form.workTime} onChange={(e) => setForm({...form, workTime: e.target.value})} text="Work time"></Input>
        <Input value={form.description} onChange={(e) => setForm({...form, description: e.target.value})} text="Description"></Input>
        <Input value={form.equipmentList} onChange={(e) => setForm({...form, equipmentList: e.target.value})} text="Equipment list"></Input>
        <Button onClick={(event) => { event.preventDefault(); update();}}>Update</Button>
    </Form>
  )
}
