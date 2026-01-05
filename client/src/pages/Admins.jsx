import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Input from '../components/UI/Input/Input';
import Select from '../components/UI/Select/Select';
import Table from '../components/UI/Table/Table';
import { getAdmins } from '../http/adminAPI';
import { getStations } from '../http/stationAPI';
import { ADMIN_ROUTE } from '../utils/consts';
import normalizeDate from '../utils/normalDate';

export default function Admins() {
  const [admins, setAdmins] = useState([]);
  const [form, setForm] = useState({name: "", email: "", stationId: 0});
  const [stations, setStations] = useState([]);
  
    const navigate = useNavigate();
    
    const normilizeAdmins = useMemo(() => {
      if (admins) {
        return admins.map(({userId, email, name, createDate, stationId}) => {
            return {id: userId, email, name, createDate: normalizeDate(createDate), stationId, actions: <Button onClick={() => navigate(ADMIN_ROUTE + `/${userId}`)}>Open</Button>};
        });
      }

      return [];
    }, [admins])

    const search = () => {
      getAdmins(form.name, form.email, form.stationId).then((data) => setAdmins(data));
    }

    const normilizeStations = useMemo(() => {
      return [
        { id: 0, text: "not chosen" },
        ...stations.map(({ stationId }) => ({
          id: stationId,
          text: stationId
        }))
      ];
    }, [stations, form])

    useEffect(() => {
        getAdmins().then((data) => setAdmins(data));
        getStations().then((data) => setStations(data));
    }, [])

  return (
  <div>
    <div style={{marginBottom: 20}}>
        <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
        <Input value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} text="Email"></Input>
        <Select text="Station" options={normilizeStations} onChange={(e) => setForm({...form, stationId: e.target.value})}></Select>
        <div style={{display: 'flex', justifyContent: 'flex-end'}}><Button style={{maxWidth: 100}} onClick={search}>Search</Button></div>
        </div>
    <Table items={normilizeAdmins}></Table>
    </div>
  )
}
