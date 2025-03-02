import React, { createContext, useEffect, useState } from 'react'

export const CustomerAddressContext = createContext()

export const CustomerAddressProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/customeraddresses'
    const [customerAddresses, setCustomerAddresses] = useState([])

    const getCustomerAddresses = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setCustomerAddresses(data)
    }

    useEffect(() => {
        getCustomerAddresses()
    }, [])

    return (
        <CustomerAddressContext.Provider value={{ customerAddresses, getCustomerAddresses }}>
            {children}
        </CustomerAddressContext.Provider>
    )
}