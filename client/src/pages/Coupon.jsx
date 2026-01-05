import React, { useEffect } from 'react'
import { useState } from 'react';
import { useMemo } from 'react';
import { NavLink, useNavigate, useParams } from 'react-router-dom';
import Details from '../components/UI/Details/Details';
import { getCoupon, removeCoupon } from '../http/couponsAPI';
import { COUPONS_ROUTE, CUSTOMER_ROUTE, UPDATE_COUPON_ROUTE } from '../utils/consts';
import normalizeDate from '../utils/normalDate';

export default function Coupon() {
  const params = useParams();
  
  const [coupon, setCoupon] = useState();
  const navigate = useNavigate();

  const remove = async () => {
    await removeCoupon(params.id).then(() => navigate(COUPONS_ROUTE))
  }

  useEffect(() => {
    getCoupon(params.id).then((data) => setCoupon(data))
  }, [])

  const normalizeCoupon = useMemo(() => {
    if (coupon) {
      const { couponId, customer, expirationDate, gasType, liters, useDate } = coupon;
      return {
        entity: { couponId, customer: <NavLink to={CUSTOMER_ROUTE + `/${customer?.userId}`}>{customer?.email}</NavLink>, expirationDate: normalizeDate(expirationDate), gasType: gasType?.name, liters, useDate: normalizeDate(useDate) },
      };
    }
    return null;
  }, [coupon])

  return (
    <Details obj={normalizeCoupon} title={`coupon №${coupon?.couponId}`} update={() => navigate(UPDATE_COUPON_ROUTE + `/${params.id}`)} remove={() => remove()}></Details>
  )
}
