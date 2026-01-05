import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import Select from '../components/UI/Select/Select';
import { getPump, updatePump } from '../http/pumpAPI';
import { getStations } from '../http/stationAPI';
import { getTypes } from '../http/typeAPI';
import { PUMP_ROUTE } from '../utils/consts';

export default function UpdatePump() {
    const [form, setForm] = useState({ pumpId: 0, gasCount: 0, number: 0, cost: 0, stationId: 0, gasTypeId: 0 });
    const [types, setTypes] = useState([]);
    const [stations, setStations] = useState([]);
    const params = useParams();

    const navigate = useNavigate();

    const update = async () => {
        await updatePump(form).then(() => {
            navigate(PUMP_ROUTE + `/${params.id}`);
        })
    }

    const normilizeTypes = useMemo(() => {
        return [
          { id: 0, text: "not chosen" },
          ...types.map(({ gasTypeId, name }) => ({
            id: gasTypeId,
            text: name,
            selected: (gasTypeId === form.gasTypeId)
          }))
        ];
      }, [types, form])

      const normilizeStations = useMemo(() => {
        return [
          { id: 0, text: "not chosen" },
          ...stations.map(({ stationId }) => ({
            id: stationId,
            text: stationId,
            selected: (stationId === form.stationId)
          }))
        ];
      }, [stations,form])

    useEffect(() => {
        getStations().then((data) => setStations(data))
        getTypes().then((data) => setTypes(data));
        getPump(params.id).then(({pumpId, gasCount, number, cost, stationId, gasTypeId}) => setForm({pumpId, gasCount, number, cost, stationId, gasTypeId}))
      }, [])

  return (
    <Form label="Update station">
        <Input value={form.gasCount} onChange={(e) => setForm({...form, gasCount: e.target.value})} text="Gas count"></Input>
        <Input value={form.number} onChange={(e) => setForm({...form, number: e.target.value})} text="Number"></Input>
        <Input value={form.cost} onChange={(e) => setForm({...form, cost: e.target.value})} text="Cost"></Input>
        <Select text="Station" options={normilizeStations} onChange={(e) => setForm({...form, stationId: e.target.value})}></Select>
        <Select text="Type" options={normilizeTypes} onChange={(e) => setForm({...form, gasTypeId: e.target.value})}></Select>
        <Button onClick={(event) => { event.preventDefault(); update();}}>Update</Button>
    </Form>
  )
}
