import React from 'react'
import { useState } from 'react';
import { useMemo } from 'react';
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Input from '../components/UI/Input/Input';
import Table from '../components/UI/Table/Table';
import { getTypes } from '../http/typeAPI';
import { CREATE_TYPE_ROUTE, TYPE_ROUTE } from '../utils/consts';

export default function Types() {
    const [types, setTypes] = useState([]);
    const [form, setForm] = useState({name: ""});
    const navigate = useNavigate();

    const normilizeStations = useMemo(() => {
        return types.map(({gasTypeId, name}) => {
            return {id: gasTypeId, name, actions: <Button onClick={() => navigate(TYPE_ROUTE + `/${gasTypeId}`)}>Open</Button>};
        });
    }, [types])

    const search = () => {
        getTypes(form.name).then((data) => setTypes(data));
    }

    useEffect(() => {
        getTypes().then((data) => setTypes(data));
    }, [])

  return (
  <div>
    <div style={{marginBottom: 20}}>
        <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
        <div style={{display: 'flex', justifyContent: 'flex-end'}}><Button style={{maxWidth: 100}} onClick={search}>Search</Button></div>
        </div>
    <Button onClick={() => navigate(CREATE_TYPE_ROUTE)} style={{marginBottom: "10px"}}>Create</Button>
    <Table items={normilizeStations}></Table>
    </div>
  )
}
