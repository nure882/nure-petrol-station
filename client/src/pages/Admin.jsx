import React, { useContext, useState } from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Context } from '..';
import Button from '../components/UI/Button/Button';
import Details from '../components/UI/Details/Details';
import { getAdmin } from '../http/adminAPI';
import { banAccount } from '../http/authAPI';
import { STATION_ROUTE, UPDATE_ADMIN_ROUTE } from '../utils/consts';
import normalizeDate from '../utils/normalDate';


export default function Admin() {
    const params = useParams();
    const {user} = useContext(Context);
  
    const [admin, setAdmin] = useState();
    const navigate = useNavigate();

    const BanButton = () => {
      return <Button style={{backgroundColor: (admin?.isBanned ? "green" : 'red')}} onClick={setBan}>{(!admin?.isBanned) ? "Ban" : "UnBan"}</Button>
    }

    const setBan = async () => {
      await banAccount(admin?.userId).then((data) => setAdmin({...admin, isBanned: data}));
    }

    useEffect(() => {
      getAdmin(params.id).then((data) => setAdmin(data))
    }, [])

    const normalizeAdmin = useMemo(() => {
      if (admin) {
        const { userId, email, name, createDate, stationId, isBanned} = admin;
        const entity = {
            userId,
            email,
            name,
            createDate: normalizeDate(createDate),
            isBanned: isBanned.toString(),
            stationId,
            controlls:
            <div style={{display: 'flex', gap: 20}}>
              {(user.user.UserId != admin.userId) && <BanButton></BanButton>}
              <Button onClick={() => navigate(`${UPDATE_ADMIN_ROUTE}/${admin.userId}`)}>Update</Button>
            </div>
          };
          
          if (admin.stationId !== null) {
            entity.station = (
              <Button onClick={() => navigate(STATION_ROUTE + `/${stationId}`)}>Open</Button>
            );
          }
      
          return { entity };
        }

      return null;
    }, [admin])
    
    return (
      <Details obj={normalizeAdmin} title={`admin №${admin?.userId}`}></Details>
    )
}
