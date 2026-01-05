import React from 'react'
import { useState } from 'react';
import Button from '../Button/Button';
import Confirm from '../Confirm/Confirm';
import Table from '../Table/Table';
import cl from './Details.module.css';

export default function Details({obj, title, update, remove}) {
    const [confirmVisible, setConfirmVisible] = useState(false);
    const tryRemove = () => {
        setConfirmVisible(false);
        remove();
    }

  return (
   (obj?.entity &&
    <div className={cl.content}>
        {(confirmVisible) &&
            <Confirm setVisible={setConfirmVisible} text="Are you sure want to remove this?" confirmed={tryRemove}></Confirm>
        }
        <div className={cl.title}>Details about {title}</div>
    {Object.keys(obj?.entity)?.map((key) => 
        <div key={key} className={cl.item}>
            <span>{key}:</span>
            <span>{obj?.entity[key]}</span>
        </div>
    )}

    <div className={cl.controll}>
    {update &&
    <Button onClick={update}>Update</Button>
    }

    {remove &&
    <Button onClick={() => setConfirmVisible(true)}>Remove</Button>
    }
    </div>

    {obj?.tables?.map(({array, title}) => 
        <div className={cl.table} key={title}>
            <div className={cl.table__title}>{title}</div>
            <Table items={array}></Table>
        </div>
    )}
</div>
    )
  )
}
