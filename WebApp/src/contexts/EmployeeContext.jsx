import React, { createContext, useEffect, useState } from 'react'

export const EmployeeContext = createContext()

export const EmployeeProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/employees'
    const [employees, setEmployees] = useState([])

    const getEmployees = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setEmployees(data)
    }

    useEffect(() => {
        getEmployees()
    }, [])

    return (
        <EmployeeContext.Provider value={{ employees, getEmployees }}>
            {children}
        </EmployeeContext.Provider>
    )
}