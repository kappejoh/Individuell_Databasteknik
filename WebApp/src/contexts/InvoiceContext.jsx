import React, { createContext, useEffect, useState } from 'react'

export const InvoiceContext = createContext()

export const InvoiceProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/invoices'
    const [invoices, setInvoices] = useState([])

    const getInvoices = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setInvoices(data)
    }

    useEffect(() => {
        getInvoices()
    }, [])

    return (
        <InvoiceContext.Provider value={{ invoices, getInvoices }}>
            {children}
        </InvoiceContext.Provider>
    )
}