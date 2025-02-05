import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Projects from './Views/Projects'
import CreateProject from './Views/CreateProject'

function App() {

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/projects" element={<Projects />} ></Route>
        <Route path="/projects/create" element={<CreateProject />} ></Route>
        <Route path="/" element={<CreateProject />} ></Route>
      </Routes>
    </BrowserRouter>
  )
}

export default App
