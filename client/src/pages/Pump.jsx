import React, { useMemo, useState } from 'react'
import { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Details from '../components/UI/Details/Details';
import { getPump, removePump } from '../http/pumpAPI';
import { PUMPS_ROUTE, UPDATE_PUMP_ROUTE } from '../utils/consts';

export default function Pump() {
  const params = useParams();
  
  const [pump, setPump] = useState();
  const navigate = useNavigate();

  const remove = async () => {
    await removePump(params.id).then(() => navigate(PUMPS_ROUTE))
  }

  useEffect(() => {
    getPump(params.id).then((data) => setPump(data))
  }, [])

  const normalizePump = useMemo(() => {
    if (pump) {
      const { pumpId, gasCount, cost, gasType, number, stationId } = pump;
      return {
        entity: { pumpId, gasCount, cost, gasType: gasType?.name, number, stationId },
      };
    }
    return null;
  }, [pump])

  return (
    <Details obj={normalizePump} title={`pump №${pump?.pumpId}`} update={() => navigate(UPDATE_PUMP_ROUTE + `/${params.id}`)} remove={() => remove()}></Details>
  )
}
