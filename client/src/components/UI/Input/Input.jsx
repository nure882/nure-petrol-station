import React from 'react'
import cl from './Input.module.css'

export default function Input(props) {
  return (
    <div className={cl.content}>
        <span>{props.text}</span>
        <input className={cl.input} {...props}></input>
    </div>
  )
}
