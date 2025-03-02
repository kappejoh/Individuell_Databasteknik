import React, { createContext, useEffect, useState } from 'react'

export const ProjectContext = createContext()

export const ProjectProvider = ({ children }) => {
    const apiUri = 'https://localhost:7298/api/projects'
    const defaultProjectValues = { id: 0, title: 'CMS24 Databasteknik', description: '', status: {}, startDate: '', endDate: '', projectManager: { id: 0, displayName: '' }, customerId: ''}
    
    const [projects, setProjects] = useState([])
    const [project, setProject] = useState(defaultProjectValues)

    const getProjects = async () => {
        const res = await fetch(`${apiUri}`)
        const data = await res.json()
        setProjects(data)
    }

    const getProject = async (id) => {
        console.log("Fetching project from API with ID:", id);
        const res = await fetch(`${apiUri}/${id}`);
        const data = await res.json();
        console.log("Fetched project data:", data);
        setProject(data);
    };
    

    useEffect(() => {
        getProjects()
    }, [])

    return (
        <ProjectContext.Provider value={{ project, projects, setProjects, getProjects, getProject }}>
            {children} 
        </ProjectContext.Provider>
    )
}