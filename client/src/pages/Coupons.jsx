import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Input from '../components/UI/Input/Input';
import Table from '../components/UI/Table/Table';
import { getCoupons } from '../http/couponsAPI';
import { COUPON_ROUTE, CREATE_COUPON_ROUTE } from '../utils/consts';
import normalizeDate from '../utils/normalDate';

export default function Coupons() {
    const [coupons, setCoupons] = useState([]);
    const [form, setForm] = useState({name: "", email: ""});
    const navigate = useNavigate();

    const normilizeCoupons = useMemo(() => {
        return coupons.map(({couponId, liters, gasType, customer, expirationDate, useDate}) => {
            return {id: couponId, liters, gasType: gasType.name, customer: customer.email, expirationDate: normalizeDate(expirationDate), useDate: normalizeDate(useDate), actions: <Button onClick={() => navigate(COUPON_ROUTE + `/${couponId}`)}>Open</Button>};
        });
    }, [coupons])

    const search = () => {
        getCoupons(form.name, form.email).then((data) => setCoupons(data));
    }

    useEffect(() => {
        getCoupons().then((data) => setCoupons(data));
    }, [])

  return (
    <div>
         <div style={{marginBottom: 20}}>
        <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Gas type name"></Input>
        <Input value={form.email} onChange={(e) => setForm({...form, email: e.target.value})} text="Customer email"></Input>
        <div style={{display: 'flex', justifyContent: 'flex-end'}}><Button style={{maxWidth: 100}} onClick={search}>Search</Button></div>
        </div>
        <Button onClick={() => navigate(CREATE_COUPON_ROUTE)} style={{marginBottom: "10px"}}>Create</Button>
        <Table items={normilizeCoupons}></Table>
    </div>
  )
}
