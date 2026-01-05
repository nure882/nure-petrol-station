import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Input from '../components/UI/Input/Input';
import Select from '../components/UI/Select/Select';
import Table from '../components/UI/Table/Table';
import { getStations } from '../http/stationAPI';
import { getWorkers } from '../http/workerAPI';
import { WORKER_ROUTE } from '../utils/consts';
import normalizeDate from '../utils/normalDate';

export default function Workers() {
  const [workers, setWorkers] = useState([]);
  const [form, setForm] = useState({name: "", surname: "", email: "", stationId: 0});
  const [stations, setStations] = useState([]);
    const navigate = useNavigate();
    
    const normilizeWorkers = useMemo(() => {
      if (workers) {
        return workers.map(({userId, email, name, surname, createDate, birthday, stationId}) => {
            return {id: userId, email, name, surname, createDate: normalizeDate(createDate), birthday: normalizeDate(birthday), stationId, actions: <Button onClick={() => navigate(WORKER_ROUTE + `/${userId}`)}>Open</Button>};
        });
      }

      return [];
    }, [workers])

    const search = () => {
      getWorkers(form.name, form.surname, form.email, form.stationId).then((data) => setWorkers(data));
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
        getWorkers().then((data) => setWorkers(data));
        getStations().then((data) => setStations(data));
    }, [])

  return (
  <div>
    <div style={{marginBottom: 20}}>
        <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
        <Input value={form.surname} onChange={(e) => setForm({...form, surname: e.target.value})} text="Surname"></Input>
        <Input value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} text="Email"></Input>
        <Select text="Station" options={normilizeStations} onChange={(e) => setForm({...form, stationId: e.target.value})}></Select>
        <div style={{display: 'flex', justifyContent: 'flex-end'}}><Button style={{maxWidth: 100}} onClick={search}>Search</Button></div>
        </div>
    <Table items={normilizeWorkers}></Table>
    </div>
  )
}
