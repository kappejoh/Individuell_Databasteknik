import React, { createContext, useEffect, useState } from 'react'

export const RoleContext = createContext()

export const RoleProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/roles'
    const [roles, setRoles] = useState([])

    const getRoles = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setRoles(data)
    }

    useEffect(() => {
        getRoles()
    }, [])

    return (
        <RoleContext.Provider value={{ roles, getRoles }}>
            {children}
        </RoleContext.Provider>
    )
}