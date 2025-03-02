import React, { createContext, useEffect, useState } from 'react'

export const ServiceContext = createContext()

export const ServiceProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/services'
    const [services, setServices] = useState([])

    const getServices = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setServices(data)
    }

    useEffect(() => {
        getServices()
    }, [])

    return (
        <ServiceContext.Provider value={{ services, getServices }}>
            {children}
        </ServiceContext.Provider>
    )
}