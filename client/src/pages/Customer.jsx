import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { useMemo } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Details from '../components/UI/Details/Details';
import { getCustomer } from '../http/customerAPI';
import { COUPON_ROUTE, CUSTOMERS_ROUTE } from '../utils/consts';
import normalizeDate from '../utils/normalDate';

export default function Customer() {
  const params = useParams();
  
  const [customer, setCustomer] = useState();
  const navigate = useNavigate();

  useEffect(() => {
    getCustomer(params.id).then((data) => setCustomer(data))
  }, [])

  const normalizeType = useMemo(() => {
    if (customer) {
      const { userId, name, surname, email, birthday, createDate, coupons } = customer;
      return {
        entity: { userId, name, surname, email, birthday: normalizeDate(birthday), createDate: normalizeDate(createDate) },
        tables: [
          {title: "Coupons", array: coupons.map(({couponId, expirationDate, gasType, liters, useDate}) => {
            return {couponId, expirationDate: normalizeDate(expirationDate), gasType: gasType?.name, liters, useDate: normalizeDate(useDate),
              actions: <Button onClick={() => navigate(COUPON_ROUTE + `/${couponId}`)}>Open</Button>};
        })} ]
      };
    }
    return null;
  }, [customer])

  return (
    <Details obj={normalizeType} title={`customer №${customer?.userId}`}></Details>
  )
}
