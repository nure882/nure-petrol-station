import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import { getType, updateType } from '../http/typeAPI';
import { TYPES_ROUTE } from '../utils/consts';

export default function UpdateType() {
    const [form, setForm] = useState({gasTypeId: 0, name: ""});
    const navigate = useNavigate();
    const params = useParams();

    const create = async () => {
        await updateType(form).then(() => {
            navigate(TYPES_ROUTE);
        })
    }

    useEffect(() => {
        getType(params.id).then(({gasTypeId, name}) => setForm({gasTypeId, name}));
    }, [])

  return (
    <Form label="Update type">
        <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
        <Button onClick={(event) => { event.preventDefault(); create();}}>Update</Button>
    </Form>
  )
}
