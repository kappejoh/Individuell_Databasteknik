import React, { createContext, useEffect, useState } from 'react'

export const AddressTypeContext = createContext()

export const AddressTypeProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/AddressTypes'
    const [addressTypes, setAddressTypes] = useState([])

    const getAddressTypes = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setAddressTypes(data)
    }

    useEffect(() => {
        getAddressTypes()
    }, [])

    return (
        <AddressTypeContext.Provider value={{ addressTypes, getAddressTypes }}>
            {children}
        </AddressTypeContext.Provider>
    )
}