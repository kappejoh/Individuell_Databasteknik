import React, { useContext, useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { StatusContext } from '../contexts/StatusContext'


const ProjectDetails = () => {
    const navigate = useNavigate()
    const {statuses} = useContext(StatusContext)

    const [formData, setFormData] = useState({})

    const handleSubmit = async (e) => {
        e.preventDefault()

        const res = await fetch('', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })
        if (res.status === 201)
            navigate('/projects')
    }

  return (
    <form onSubmit={handleSubmit}>
            <select>
                {
                    statuses.map(option => {
                        return <option key={option.id} value={option.id}>{option.statusName}</option>
                    })
                }
            </select>
    </form>
  )
}

export default ProjectDetails 