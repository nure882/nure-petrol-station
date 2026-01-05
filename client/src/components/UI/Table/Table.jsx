import React from 'react'
import cl from './Table.module.css';

export default function Table({items}) {
  return (
    <div>
        {items.length < 1 ?
    <div>Empty</div>
    :
    <table className={cl.table}>
        <thead>
            <tr>
                {Object.keys(items[0]).map((item) => <th key={item}>{item}</th>)}
            </tr>
        </thead>
        <tbody>
            {items.map((obj, index) =>
                <tr key={`object${index}`}>
                    {Object.values(obj).map((item, index) => <td key={`item${index}`}>{item}</td>)}
                </tr>
            )}
        </tbody>
    </table>
    }
    </div>
  )
}
