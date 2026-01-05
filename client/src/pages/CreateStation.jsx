import React from 'react'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form'
import Input from '../components/UI/Input/Input';
import { createStation } from '../http/stationAPI';
import { STATIONS_ROUTE } from '../utils/consts';

export default function CreateStation() {
    const [form, setForm] = useState({city: "", address: "", workTime: "", description: "", equipmentList: ""});
    const navigate = useNavigate();

    const create = async () => {
        await createStation(form).then(() => {
            navigate(STATIONS_ROUTE);
        })
    }

  return (
    <Form label="Create station">
        <Input value={form.city} onChange={(e) => setForm({...form, city: e.target.value})} text="City"></Input>
        <Input value={form.address} onChange={(e) => setForm({...form, address: e.target.value})} text="Address"></Input>
        <Input value={form.workTime} onChange={(e) => setForm({...form, workTime: e.target.value})} text="Work time"></Input>
        <Input value={form.description} onChange={(e) => setForm({...form, description: e.target.value})} text="Description"></Input>
        <Input value={form.equipmentList} onChange={(e) => setForm({...form, equipmentList: e.target.value})} text="Equipment list"></Input>
        <Button onClick={(event) => { event.preventDefault(); create();}}>Create</Button>
    </Form>
  )
}
