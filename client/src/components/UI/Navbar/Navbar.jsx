import React from 'react'
import { useContext } from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import { Context } from '../../..';
import { ADMIN, ADMIN_MENU_ROUTE, LOGIN_ROUTE, MAIN_ROUTE, REGISTRATION_ROUTE, REGISTRATION_WORKER_ROUTE, WORKER, WORKER_MENU_ROUTE } from '../../../utils/consts';
import cl from './Navbar.module.css';

export default function Navbar() {
  const {user} = useContext(Context);
  const navigate = useNavigate();

  const logout = () => {
    user.setIsAuth(false)
    user.setUser({});
    localStorage.removeItem('GasStationToken');
    navigate(LOGIN_ROUTE);
  }

  const DefaultBar = ({children}) => {
    return <div className={cl.menu__filling}>
                <NavLink to={MAIN_ROUTE} className={cl.item}>Home</NavLink>
                {children}
              <div onClick={logout} className={cl.item}>Logout</div>
    </div>
  }

  const AdminBar = () => {
    return <>
                <NavLink className={cl.item} to={ADMIN_MENU_ROUTE}>Admin menu</NavLink>
                <NavLink className={cl.item} to={REGISTRATION_ROUTE}>Regist new admin</NavLink>
                <NavLink className={cl.item} to={REGISTRATION_WORKER_ROUTE}>Regist new worker</NavLink>
    </>
  }

  const WorkerBar = () => {
    return <>
                <NavLink className={cl.item} to={WORKER_MENU_ROUTE}>Worker menu</NavLink>
    </>
  }

  return (
    <div className={cl.container}>
      <div className={cl.content}>
        
      {user.isAuth ? 
        <div className={cl.menu}>
              <DefaultBar>
                {user.user.role === ADMIN &&
                  <AdminBar></AdminBar>
                }
                {user.user.role === WORKER &&
                  <WorkerBar></WorkerBar>
                }
              </DefaultBar>
            <div className={cl.menu__user}>{user.user.email}</div>
        </div>
       :
       <div className={cl.menu}>
       <div className={cl.menu__filling}>
            <NavLink to={MAIN_ROUTE} className={cl.item}>Home</NavLink>
            <NavLink className={cl.item} to={LOGIN_ROUTE}>Login</NavLink>
          </div>
       </div>
       }
      </div>
    </div>
  )
}
