import React, { useState } from 'react'
import { useEffect } from 'react';
import { useMemo } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Details from '../components/UI/Details/Details';
import { banAccount } from '../http/authAPI';
import { getWorker } from '../http/workerAPI';
import { STATION_ROUTE, UPDATE_WORKER_ROUTE } from '../utils/consts';
import normalizeDate from '../utils/normalDate';

export default function Worker() {
    const params = useParams();
  
    const [worker, setWorker] = useState();
    const navigate = useNavigate();

    const BanButton = () => {
      return <Button style={{backgroundColor: (worker?.isBanned ? "green" : 'red')}} onClick={setBan}>{(!worker?.isBanned) ? "Ban" : "UnBan"}</Button>
    }

    const setBan = async () => {
      await banAccount(worker?.userId).then((data) => setWorker({...worker, isBanned: data}));
    }

    useEffect(() => {
      getWorker(params.id).then((data) => setWorker(data));
    }, [])
  
    const normalizeWorker = useMemo(() => {
      if (worker) {
        const { userId, email, name, surname, createDate, birthday, stationId, isBanned } = worker;
        return {
          entity: { userId, email, name, surname, createDate: normalizeDate(createDate), birthday: normalizeDate(birthday), isBanned: isBanned.toString(),
            stationId, station: <Button onClick={() => navigate(STATION_ROUTE + `/${stationId}`)}>Open</Button>, 
            controlls:
            <div style={{display: 'flex', gap: 20}}>
              <BanButton></BanButton>
              <Button onClick={() => navigate(`${UPDATE_WORKER_ROUTE}/${worker.userId}`)}>Update</Button>
            </div>
          },
        };
      }
      return null;
    }, [worker])
    
    return (
      <Details obj={normalizeWorker} title={`worker №${worker?.userId}`}></Details>
    )
}