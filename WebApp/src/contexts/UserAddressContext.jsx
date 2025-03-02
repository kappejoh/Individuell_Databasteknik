import React, { createContext, useEffect, useState } from 'react'

export const UserAddressContext = createContext()

export const UserAddressProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/useraddresses'
    const [useraddresses, setUserAddresses] = useState([])

    const getUserAddresses = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setUserAddresses(data)
    }

    useEffect(() => {
        getUserAddresses()
    }, [])

    return (
        <UserAddressContext.Provider value={{ useraddresses, getUserAddresses }}>
            {children}
        </UserAddressContext.Provider>
    )
}