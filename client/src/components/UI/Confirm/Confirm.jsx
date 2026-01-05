import React from 'react'
import Button from '../Button/Button';
import cl from './Confirm.module.css';

export default function Confirm({text, setVisible, confirmed}) {
  return (
    <div className={cl.modal}>
        <div className={cl.content}>
            <div className={cl.head}>
                <div className={cl.title}>Confirmation</div>
            </div>
            <div className={cl.container}>
                <div className={cl.text}>{text}</div>
                <div className={cl.buttons}>
                    <Button onClick={() => setVisible(false)} style={{backgroundColor: '#f54c4c'}}>No</Button>
                    <Button onClick={confirmed}>Yes</Button>
                </div>
            </div>
        </div>
    </div>
  )
}
