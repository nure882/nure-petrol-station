import React from 'react'
import { NavLink } from 'react-router-dom';
import cl from '../styles/AdminMenu.module.css';
import { ADMINS_ROUTE, COUPONS_ROUTE, PUMPS_ROUTE, STATIONS_ROUTE, TYPES_ROUTE, CUSTOMERS_ROUTE, WORKERS_ROUTE } from '../utils/consts';

export default function AdminMenu() {
  return (
    <div className={cl.container}>
        <NavLink to={STATIONS_ROUTE} className={cl.item}><div>Stations</div></NavLink>
        <NavLink to={TYPES_ROUTE} className={cl.item}><div>Types</div></NavLink>
        <NavLink to={CUSTOMERS_ROUTE} className={cl.item}><div>Customers</div></NavLink>
        <NavLink to={WORKERS_ROUTE} className={cl.item}><div>Workers</div></NavLink>
        <NavLink to={ADMINS_ROUTE} className={cl.item}><div>Admins</div></NavLink>
        <NavLink to={COUPONS_ROUTE} className={cl.item}><div>Coupons</div></NavLink>
        <NavLink to={PUMPS_ROUTE} className={cl.item}><div>Pumps</div></NavLink>
    </div>
  )
}
