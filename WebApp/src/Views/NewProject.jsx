import React, { useState } from 'react'
import SectionHeader from '../Components/elements/SectionHeader'
import ProjectDetails from '../Components/ProjectDetails'
import CreateProjectForm from '../Components/CreateProjectForm'


const NewProject = () => {


        return (
            <main id='project'>
                <div className="container">
                    <SectionHeader title={`PROJEKT SKAPA NYTT`}></SectionHeader>
                    {/* <ProjectDetails /> */}
                    <CreateProjectForm />
                </div>
            </main> 
        )
    }


export default NewProject