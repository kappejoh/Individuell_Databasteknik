import React from 'react'
import { Routes, Route } from 'react-router-dom'
import Projects from '../Views/Projects'
import Project from '../Views/Project'
import NewProject from '../Views/NewProject'
import Home from '../Views/Home'


const Main = () => {
  return (
    <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/projects' element={<Projects />} />
        <Route path='/project/:id' element={<Project />} />
        <Route path='/projects/new' element={<NewProject />} />
    </Routes>
  )
}

export default Main