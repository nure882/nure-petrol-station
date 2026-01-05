import React from 'react'
import { NavLink } from 'react-router-dom';
import cl from '../styles/AdminMenu.module.css';
import { COUPONS_ROUTE, CUSTOMERS_ROUTE } from '../utils/consts';

export default function WorkerMenu() {
  return (
    <div className={cl.container}>
        <NavLink to={CUSTOMERS_ROUTE} className={cl.item}><div>Customers</div></NavLink>
        <NavLink to={COUPONS_ROUTE} className={cl.item}><div>Coupons</div></NavLink>
    </div>
  )
}
