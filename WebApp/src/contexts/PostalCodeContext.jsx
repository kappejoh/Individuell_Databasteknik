import React, { createContext, useEffect, useState } from 'react'

export const PostalCodeContext = createContext()

export const PostalCodeProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/postalcodes'
    const [postalcodes, setPostalCodes] = useState([])

    const getPostalCodes = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setPostalCodes(data)
    }

    useEffect(() => {
        getPostalCodes()
    }, [])

    return (
        <PostalCodeContext.Provider value={{ postalcodes, getPostalCodes }}>
            {children}
        </PostalCodeContext.Provider>
    )
}