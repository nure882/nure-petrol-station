import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import Select from '../components/UI/Select/Select';
import { createCoupon } from '../http/couponsAPI';
import { getCustomers } from '../http/customerAPI';
import { getTypes } from '../http/typeAPI';
import { COUPONS_ROUTE } from '../utils/consts';

export default function CreateCoupon() {
  const [form, setForm] = useState({customerId: 0, gasTypeId: 0, liters: 0, expirationDate: null});
  const [customers, setCustomers] = useState([]);
  const [types, setTypes] = useState([]);
    const navigate = useNavigate();
    
    const create = async () => {
        await createCoupon(form).then(() => {
            navigate(COUPONS_ROUTE);
        })
    }

    const normilizeCustomers = useMemo(() => {
      return [
        { id: 0, text: "not chosen" },
        ...customers.map(({ userId, email }) => ({
          id: userId,
          text: email
        }))
      ];
    }, [customers])

    const normilizeTypes = useMemo(() => {
      return [
        { id: 0, text: "not chosen" },
        ...types.map(({ gasTypeId, name }) => ({
          id: gasTypeId,
          text: name
        }))
      ];
    }, [types])

    useEffect(() => {
      getCustomers().then((data) => setCustomers(data));
      getTypes().then((data) => setTypes(data));
    }, [])

  return (
    <Form label="Create coupon">
        <Select text="Customer" options={normilizeCustomers} onChange={(e) => setForm({...form, customerId: e.target.value})}></Select>
        <Select text="Type" options={normilizeTypes} onChange={(e) => setForm({...form, gasTypeId: e.target.value})}></Select>
        <Input value={form.liters} onChange={(e) => setForm({...form, liters: e.target.value})} text="Liters"></Input>
        <Input value={form.expirationDate} onChange={(e) => setForm({...form, expirationDate: e.target.value})} type="date" text="Expiration Date"></Input>
        <Button onClick={(event) => { event.preventDefault(); create();}}>Create</Button>
    </Form>
  )
}
