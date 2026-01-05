import React from 'react'
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/UI/Button/Button';
import Form from '../components/UI/Form/Form';
import Input from '../components/UI/Input/Input';
import { createType } from '../http/typeAPI';
import { TYPES_ROUTE } from '../utils/consts';

export default function CreateType() {
    const [form, setForm] = useState({name: ""});
    const navigate = useNavigate();

    const create = async () => {
        await createType(form).then(() => {
            navigate(TYPES_ROUTE);
        })
    }

  return (
    <Form label="Create type">
        <Input value={form.name} onChange={(e) => setForm({...form, name: e.target.value})} text="Name"></Input>
        <Button onClick={(event) => { event.preventDefault(); create();}}>Create</Button>
    </Form>
  )
}
