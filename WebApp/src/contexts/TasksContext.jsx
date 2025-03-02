import React, { createContext, useEffect, useState } from 'react'

export const TasksContext = createContext()

export const TasksProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/tasks'
    const [tasks, setTasks] = useState([])

    const getTasks = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setTasks(data)
    }

    useEffect(() => {
        getTasks()
    }, [])

    return (
        <TasksContext.Provider value={{ tasks, getTasks }}>
            {children}
        </TasksContext.Provider>
    )
}