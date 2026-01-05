import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Input from '../components/UI/Input/Input';
import Table from '../components/UI/Table/Table';
import { getPumps } from '../http/pumpAPI';
import { CREATE_PUMP_ROUTE, PUMP_ROUTE } from '../utils/consts';

export default function Pumps() {
    const [pumps, setPumps] = useState([]);
    const [form, setForm] = useState({number: 0, gasCountFrom: 0, gasCountTo: 0});
    const navigate = useNavigate();

    const normilizePumps = useMemo(() => {
        return pumps.map(({pumpId, gasCount, number, stationId, gasTypeId, cost}) => {
            return {id: pumpId, gasCount, number, stationId, gasTypeId, cost, actions: <Button onClick={() => navigate(PUMP_ROUTE + `/${pumpId}`)}>Open</Button>};
        });
    }, [pumps])

    useEffect(() => {
        getPumps().then((data) => setPumps(data));
    }, [])

    const search = () => {
      getPumps(form.number, form.gasCountFrom, form.gasCountTo).then((data) => setPumps(data));
    }

  return (
    <div>
        <div style={{marginBottom: 20}}>
        <Input value={form.number} onChange={(e) => setForm({...form, number: e.target.value})} type="number" text="Number"></Input>
        <Input value={form.gasCountFrom} onChange={(e) => setForm({...form, gasCountFrom: e.target.value})} type="number" text="Gas count from"></Input>
        <Input value={form.gasCountTo} onChange={(e) => setForm({...form, gasCountTo: e.target.value})} type="number" text="Gas count to"></Input>
        <div style={{display: 'flex', justifyContent: 'flex-end'}}><Button style={{maxWidth: 100}} onClick={search}>Search</Button></div>
        </div>
      <Button onClick={() => navigate(CREATE_PUMP_ROUTE)} style={{marginBottom: "10px"}}>Create</Button>
      <Table items={normilizePumps}></Table>
    </div>
  )
}
