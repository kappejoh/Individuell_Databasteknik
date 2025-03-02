import React, { useContext, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'

const ProjectListItem = ({project}) => {
    const navigate = useNavigate();

    return (
        <tr onClick={() => navigate(`/project/${project.id}`)}>
            <td> {project.id}</td>
            <td> {project.projectName}</td>
            <td> {project.description}</td>
            <td> {project.startDate}</td>
            <td> {project.endDate}</td>
            <td> {project.status.statusName}</td>
            <td> {project.projectManager.displayName}</td>
        </tr>
    )
}

export default ProjectListItem