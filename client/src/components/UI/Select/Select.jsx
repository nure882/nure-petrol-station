import React from 'react'
import cl from './Select.module.css'

export default function Select(props) {
  return (
<div className={cl.content}>
<span>{props.text}</span>
<select {...props} className={cl.select}>
        {props.options.map(({id, text, selected}) => 
            <option selected={selected} key={id} value={id}>{text}</option>
        )}
    </select>
</div>
  )
}
