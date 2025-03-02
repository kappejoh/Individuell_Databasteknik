import React, { createContext, useEffect, useState } from 'react'

export const UserContext = createContext()

export const UserProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/users'
    const [users, setUsers] = useState([])

    const getUsers = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setUsers(data)
    }

    useEffect(() => {
        getUsers()
    }, [])

    return (
        <UserContext.Provider value={{ users, getUsers }}>
            {children}
        </UserContext.Provider>
    )
}