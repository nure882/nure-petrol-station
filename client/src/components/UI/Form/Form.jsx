import React from 'react'
import cl from './Form.module.css';

export default function Form({children, label}) {
  return (
    <div className={cl.container}>
      <div className={cl.content}>
          <div className={cl.label}>{label}</div>
        <form className={cl.form}>
          {children}
        </form>
      </div>
    </div>
  )
}
