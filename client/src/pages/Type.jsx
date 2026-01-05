import React, { useMemo } from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Details from '../components/UI/Details/Details';
import { getType, removeType } from '../http/typeAPI';
import { TYPES_ROUTE, UPDATE_TYPE_ROUTE } from '../utils/consts';

export default function Type() {
  const params = useParams();
  
  const [type, setType] = useState();
  const navigate = useNavigate();

  const remove = async () => {
    await removeType(params.id).then(() => navigate(TYPES_ROUTE))
  }

  useEffect(() => {
    getType(params.id).then((data) => setType(data))
  }, [])

  const normalizeType = useMemo(() => {
    if (type) {
      const { gasTypeId, name } = type;
      return {
        entity: { gasTypeId, name },
      };
    }
    return null;
  }, [type])

  return (
    <Details obj={normalizeType} title={`type №${type?.gasTypeId}`} update={() => navigate(UPDATE_TYPE_ROUTE + `/${params.id}`)} remove={() => remove()}></Details>
  )
}
