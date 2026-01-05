import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import Select from '../components/UI/Select/Select';
import { getStations } from '../http/stationAPI';
import { getWorker, updateWorker } from '../http/workerAPI';
import { MAIN_ROUTE } from '../utils/consts';
import formatDateToYYYYMMDD from '../utils/formatDateToYYYYMMDD';

export default function UpdateWorker() {
    const [form, setForm] = useState({email: "", name: "", surname: "", birthday: null, stationId: 0})
    const [stations, setStations] = useState([]);
    const [worker, setWorker] = useState();
    const params = useParams();
    const navigate = useNavigate();

    const update = async () => {
        if (form.email === "" || form.name === "") {
            alert("Empty field")
        } else {
            await updateWorker({...form, userId: worker.userId}).then(() => navigate(-1));
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
        getWorker(params.id).then((data) => {
            setWorker(data);
            setForm({
                email: data.email,
                name: data.name,
                surname: data.surname,
                birthday: formatDateToYYYYMMDD(data.birthday),
                stationId: data.stationId
            })
        })
        getStations().then((data) => setStations(data));
      }, [])

  return (
    <Form label="Update info about worker">
          <Input disabled value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} text="Email"></Input>
          <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
          <Input value={form.surname} onChange={(e) => setForm({...form, surname: e.target.value})} text="Surname"></Input>
          <Input value={form.birthday} onChange={(e) => setForm({...form, birthday: e.target.value})} type="date" text="Birthday"></Input>
          <Select text="Station" value={form.stationId} options={normilizeStations} onChange={(e) => setForm({...form, stationId: e.target.value})}></Select>
          <Button onClick={(event) => { event.preventDefault(); update();}}>Update</Button>
    </Form>
  )
}
