import React, { createContext, useEffect, useState } from 'react'

export const CustomerContext = createContext()

export const CustomerProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/customers'
    const [customers, setCustomers] = useState([])

    const getCustomers = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setCustomers(data)
    }

    useEffect(() => {
        getCustomers()
    }, [])

    return (
        <CustomerContext.Provider value={{ customers, getCustomers }}>
            {children}
        </CustomerContext.Provider>
    )
}