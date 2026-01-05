import React from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import Select from '../components/UI/Select/Select';
import { createCoupon, getCoupon, updateCoupon } from '../http/couponsAPI';
import { getCustomers } from '../http/customerAPI';
import { getTypes } from '../http/typeAPI';
import { COUPONS_ROUTE, COUPON_ROUTE } from '../utils/consts';
import formatDateToYYYYMMDD from '../utils/formatDateToYYYYMMDD';

export default function UpdateCoupon() {
    const [form, setForm] = useState({couponId: 0, customerId: 0, gasTypeId: 0, liters: 0, expirationDate: null, useDate: null});
    const [customers, setCustomers] = useState([]);
    const [types, setTypes] = useState([]);
      const navigate = useNavigate();
      const params = useParams();
      
      const update = async () => {
          await updateCoupon(form).then(() => {
              navigate(COUPON_ROUTE + `/${params.id}`);
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
  
      useEffect(() => {
        getCustomers().then((data) => setCustomers(data));
        getTypes().then((data) => setTypes(data));
        getCoupon(params.id).then(({couponId, customerId, gasTypeId, liters, expirationDate, useDate}) =>
            setForm({couponId, customerId, gasTypeId, liters, expirationDate, useDate}));
      }, [])

    return (
      <Form label="Update coupon">
            <div style={{marginBottom: 10}}><p>Customer: {customers.find(c => c.userId === form.customerId)?.email}</p></div>
          <Select text="Type" options={normilizeTypes} onChange={(e) => setForm({...form, gasTypeId: e.target.value})}></Select>
          <Input value={form.liters} onChange={(e) => setForm({...form, liters: e.target.value})} text="Liters"></Input>
          <Input value={formatDateToYYYYMMDD(form.expirationDate)} onChange={(e) => setForm({...form, expirationDate: e.target.value})} type="date" text="Expiration Date"></Input>
          <Input value={formatDateToYYYYMMDD(form.useDate)} onChange={(e) => setForm({...form, useDate: e.target.value})} type="date" text="Use date"></Input>
          <Button onClick={(event) => { event.preventDefault(); update();}}>Update</Button>
      </Form>
    )
}
