import React, { createContext, useEffect, useState } from 'react'

export const ProjectTypeContext = createContext()

export const ProjectTypeProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/projecttypes'
    const [projecttypes, setProjectTypes] = useState([])

    const getProjectTypes = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setProjectTypes(data)
    }

    useEffect(() => {
        getProjectTypes()
    }, [])

    return (
        <ProjectTypeContext.Provider value={{ projecttypes, getProjectTypes }}>
            {children}
        </ProjectTypeContext.Provider>
    )
}