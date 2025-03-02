import React, { useState, useEffect } from 'react';
import {  useNavigate } from 'react-router-dom';


const CreateProjectForm = () => {
    const navigate = useNavigate();
    
    const [customers, setCustomers] = useState([]);
    const [services, setServices] = useState([]);
    const [users, setUsers] = useState([]);
    const [projectTypes, setProjectTypes] = useState([]);
    const [statuses, setStatuses] = useState([])

    const [projectName, setProjectName] = useState('');
    const [description, setDescription] = useState('');
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [customerId, setCustomerId] = useState('');
    const [projectManagerId, setProjectManagerId] = useState('');
    const [serviceId, setServiceId] = useState('');
    const [projectTypeId, setProjectTypeId] = useState('');
    const [statusId, setStatusId] = useState(''); 

    const fetchData = async (endpoint, setState) => {
            const res = await fetch(`https://localhost:7298/api/${endpoint}`);
            const data = await res.json();
            setState(data);

    };

    useEffect(() => {
        fetchData('customers', setCustomers);
        fetchData('users', setUsers);
        fetchData('services', setServices);
        fetchData('projectTypes', setProjectTypes);
        fetchData('statuses', setStatuses)
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();

        const formData = {
            projectName,
            description,
            startDate: startDate ? new Date(startDate).toISOString() : null,
            endDate: endDate ? new Date(endDate).toISOString() : null,
            statusId: parseInt(statusId, 10),
            customerId: parseInt(customerId, 10),
            projectManagerId: parseInt(projectManagerId, 10),
            serviceId: parseInt(serviceId, 10),
            projectTypeId: parseInt(projectTypeId, 10),
        }

            const res = await fetch('https://localhost:7298/api/projects', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(formData)
            })

            navigate('/projects');
    }

    return (
        <section className="new-project-form">
            <div>
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="projectName">Projektnamn</label>
                        <input type="text" id="projectName" value={projectName} onChange={(e) => setProjectName(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="description">Projektbeskrivning</label>
                        <textarea id="description" value={description} onChange={(e) => setDescription(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="startdate">Startdatum</label>
                        <input type="date" id="startdate" value={startDate} onChange={(e) => setStartDate(e.target.value)} />
                    </div>
                    <div className="form-group">
                        <label htmlFor="enddate">Slutdatum</label>
                        <input type="date" id="enddate" value={endDate} onChange={(e) => setEndDate(e.target.value)} />
                    </div>

                    <div className="form-group">
                        <label htmlFor="status">Status</label>
                        <select id="status" value={statusId} onChange={(e) => setStatusId(e.target.value)}>
                            <option value="" disabled hidden>Välj en status</option>
                            {statuses.map(status => (
                                <option key={status.id} value={status.id}>{status.statusName}</option>
                            ))}
                        </select>
                    </div>
                    
                    <div className="form-group">
                        <label htmlFor="customers">Kunder</label>
                        <select id="customers" value={customerId} onChange={(e) => setCustomerId(e.target.value)}>
                            <option value="" disabled hidden>Välj en kund</option>
                            {customers.map(customer => (
                                <option key={customer.id} value={customer.id}>{customer.customerName}</option>
                            ))}
                        </select>
                    </div>
                    
                    <div className="form-group">
                        <label htmlFor="projectManagers">Projektledare</label>
                        <select id="projectManagers" value={projectManagerId} onChange={(e) => setProjectManagerId(e.target.value)}>
                            <option value="" disabled hidden>Välj en projektledare</option>
                            {users.map(user => (
                                <option key={user.id} value={user.id}>{user.displayName}</option>
                            ))}
                        </select>
                    </div>
                    
                    <div className="form-group">
                        <label htmlFor="services">Tjänst</label>
                        <select id="services" value={serviceId} onChange={(e) => setServiceId(e.target.value)}>
                            <option value="" disabled hidden>Välj en tjänst</option>
                            {services.map(service => (
                                <option key={service.id} value={service.id}>{service.serviceName}</option>
                            ))}
                        </select>
                    </div>
                    
                    <div className="form-group">
                        <label htmlFor="projectTypes">Projekttyp</label>
                        <select id="projectTypes" value={projectTypeId} onChange={(e) => setProjectTypeId(e.target.value)}>
                            <option value="" disabled hidden>Välj en projekttyp</option>
                            {projectTypes.map(type => (
                                <option key={type.id} value={type.id}>{type.typeName}</option>
                            ))}
                        </select>
                    </div>

                    <button type="submit" className='btn btn-yellow'>Skapa projekt</button>
                </form>
            </div>
        </section>
    );
};

export default CreateProjectForm;
