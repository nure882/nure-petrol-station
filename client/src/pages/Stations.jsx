import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react'
import { NavLink, useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Input from '../components/UI/Input/Input';
import Table from '../components/UI/Table/Table'
import { getStations } from '../http/stationAPI';
import { CREATE_STATION_ROUTE, STATION_ROUTE } from '../utils/consts';

export default function Stations() {
    const [stations, setStations] = useState([]);
    const [form, setForm] = useState({city: "", address: ""});
    const navigate = useNavigate();

    const normilizeStations = useMemo(() => {
        return stations.map(({stationId, city, address, workTime, description, equipmentList}) => {
            return {id: stationId, city, address, workTime, description, equipmentList, actions: <Button onClick={() => navigate(STATION_ROUTE + `/${stationId}`)}>Open</Button>};
        })
    }, [stations])

    const search = () => {
        getStations(form.city, form.address).then((data) => setStations(data))
    }

    useEffect(() => {
        getStations().then((data) => setStations(data))
    }, [])

  return (
    <div>
        <div style={{marginBottom: 20}}>
        <Input value={form.city} onChange={(e) => setForm({...form, city: e.target.value})} text="City"></Input>
        <Input value={form.address} onChange={(e) => setForm({...form, address: e.target.value})} text="Address"></Input>
        <div style={{display: 'flex', justifyContent: 'flex-end'}}><Button style={{maxWidth: 100}} onClick={search}>Search</Button></div>
        </div>
        <Button onClick={() => navigate(CREATE_STATION_ROUTE)} style={{marginBottom: "10px"}}>Create</Button>
        <Table items={normilizeStations}></Table>
    </div>
  )
}
