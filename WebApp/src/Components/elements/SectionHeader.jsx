import React from 'react'
import { Link } from 'react-router-dom'


const SectionHeader = ({title}) => {
  return (
    <section id='section-header'>
        <h1>{title}</h1>
        <div className="nav-buttons">
            <Link to="/projects/new" className='btn btn-gray'>Skapa nytt projekt</Link>
            <Link to="/projects/" className='btn btn-yellow'>Visa lista</Link>
        </div>
    </section>
  )
}

export default SectionHeader