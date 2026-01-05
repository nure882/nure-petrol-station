import React from 'react'
import { useState } from 'react';
import { useMemo } from 'react';
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Input from '../components/UI/Input/Input';
import Table from '../components/UI/Table/Table';
import { getCustomers } from '../http/customerAPI';
import { CUSTOMER_ROUTE } from '../utils/consts';
import normalizeDate from '../utils/normalDate';

export default function Customers() {
  const [customers, setCustomers] = useState([]);
  const [form, setForm] = useState({name: "", surname: "", email: ""});
    const navigate = useNavigate();

    const normilizeCustomers = useMemo(() => {
        return customers.map(({userId, email, name, surname, createDate, birthday}) => {
            return {id: userId, email, name, surname, createDate: normalizeDate(createDate), birthday: normalizeDate(birthday), actions: <Button onClick={() => navigate(CUSTOMER_ROUTE + `/${userId}`)}>Open</Button>};
        });
    }, [customers]);

    const search = () => {
      getCustomers(form.name, form.surname, form.email).then((data) => setCustomers(data));
    }

    useEffect(() => {
        getCustomers().then((data) => setCustomers(data));
    }, [])

  return (
  <div>
    <div style={{marginBottom: 20}}>
        <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
        <Input value={form.surname} onChange={(e) => setForm({...form, surname: e.target.value})} text="Surname"></Input>
        <Input value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} text="Email"></Input>
        <div style={{display: 'flex', justifyContent: 'flex-end'}}><Button style={{maxWidth: 100}} onClick={search}>Search</Button></div>
        </div>
    <Table items={normilizeCustomers}></Table>
    </div>
  )
}
