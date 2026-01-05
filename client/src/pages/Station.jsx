import { observer } from 'mobx-react-lite';
import React, { useMemo } from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom'
import Button from '../components/UI/Button/Button';
import Details from '../components/UI/Details/Details';
import { getStation, removeStation } from '../http/stationAPI';
import { ADMIN_ROUTE, PUMP_ROUTE, STATIONS_ROUTE, UPDATE_STATION_ROUTE, WORKER_ROUTE } from '../utils/consts';

const Station = observer(() => {
  const params = useParams();
  const [station, setStation] = useState();
  const navigate = useNavigate();

  const remove = async () => {
    await removeStation(params.id).then(() => navigate(STATIONS_ROUTE))
  }

  useEffect(() => {
    getStation(params.id).then((data) => setStation(data))
  }, [])

  const normalizeStation = useMemo(() => {
    if (station) {
      const { stationId, city, address, workTime, description, equipmentList, admins, workers, pumps } = station;
      return {
        entity: { stationId, city, address, workTime, description, equipmentList },
        tables: [
          {title: "Admins", array: admins.map(({userId, email, name}) => {
            return {id: userId, email, name, actions: <Button onClick={() => navigate(ADMIN_ROUTE + `/${userId}`)}>Open</Button>};
        })},
          {title: "Workers", array: workers.map(({userId, email, name, surname}) => {
            return {id: userId, email, name, surname, actions: <Button onClick={() => navigate(WORKER_ROUTE + `/${userId}`)}>Open</Button>};
        })},
          {title: "Pumps", array: pumps.map(({cost, gasCount, gasType, number, pumpId}) => {
            return {cost, gasCount, gasType: gasType?.name, number, actions: <Button onClick={() => navigate(PUMP_ROUTE + `/${pumpId}`)}>Open</Button>};
        })},
        ]
      };
    }
    return null;
  }, [station])

  return (
    <Details obj={normalizeStation} title={`station №${station?.stationId}`} update={() => navigate(UPDATE_STATION_ROUTE + `/${params.id}`)} remove={() => remove()}></Details>
  )
});

export default Station;