import React, { useContext, useEffect } from 'react'
import { ProjectContext } from '../../contexts/ProjectContext'
import ProjectListItem from './ProjectListItem'

const ProjectList = () => {
    const {projects, setProjects} = useContext(ProjectContext)
      
    const getProjects = async () => {
        const res = await fetch('https://localhost:7298/api/projects')
        const data = await res.json()
        
        setProjects(data)
    } 

    useEffect(() => {
        getProjects()
    }, [])

    return (
        <table className="project-list">
            <thead>
                <tr>
                    <th className="projectnumber">PROJEKTNUMMER</th>
                    <th className="projectname">PROJEKTNAMN</th>
                    <th className="description">BESKRIVING</th>
                    <th className="startdate">START</th>
                    <th className="enddate">SLUT</th>
                    <th className="status">STATUS</th>
                    <th className="projectmanager">PROJEKTLEDARE</th>
                </tr>
            </thead>
            <tbody>
            {
                projects.map(project => (<ProjectListItem key={project.id} project={project}></ProjectListItem>
                ))
            }
            </tbody>
        </table>
   )
}

export default ProjectList