import React, { useEffect, useContext, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import SectionHeader from '../Components/elements/SectionHeader';
import { ProjectContext } from '../contexts/ProjectContext';

const Project = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const { project, getProject } = useContext(ProjectContext);

    const [statuses, setStatuses] = useState([]);
    const [users, setUsers] = useState([]);
    const [services, setServices] = useState([]);
    const [projectTypes, setProjectTypes] = useState([]);
    const [customers, setCustomers] = useState([]);

    const [formData, setFormData] = useState({
        projectName: '',
        description: '',
        startDate: '',
        endDate: '',
        statusId: '',
        projectManagerId: '',
        serviceId: '',
        projectTypeId: '',
        customerId: '',
    });

    useEffect(() => {
        getProject(id);
    }, [id]);

    useEffect(() => {
        if (project && project.id) {
            setFormData({
                projectName: project.projectName || '',
                description: project.description || '',
                startDate: project.startDate ? project.startDate.split('T')[0] : '',
                endDate: project.endDate ? project.endDate.split('T')[0] : '',
                statusId: project.status?.id || '',
                projectManagerId: project.projectManager?.id || '',
                serviceId: project.serviceId || '',
                projectTypeId: project.projectTypeId || '',
                customerId: project.customer?.id || '',
            });
        }
    }, [project]);

    useEffect(() => {
        const fetchData = async (endpoint, setState) => {
            try {
                const res = await fetch(`https://localhost:7298/api/${endpoint}`);
                if (!res.ok) throw new Error(`Failed to fetch ${endpoint}`);
                const data = await res.json();
                setState(data);
            } catch (error) {
                console.error(`Error fetching ${endpoint}:`, error);
            }
        };

        fetchData('statuses', setStatuses);
        fetchData('users', setUsers);
        fetchData('services', setServices);
        fetchData('projectTypes', setProjectTypes);
        fetchData('customers', setCustomers);
    }, []);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prev) => ({ ...prev, [name]: value }));
    };

    
    const handleSubmit = async (e) => {
        e.preventDefault();

        const payload = {
            id: parseInt(id, 10),
            projectName: formData.projectName || "",
            description: formData.description || "",
            startDate: formData.startDate ? new Date(formData.startDate).toISOString() : null,
            endDate: formData.endDate ? new Date(formData.endDate).toISOString() : null,
            statusId: formData.statusId ? parseInt(formData.statusId, 10) : project.status?.id || 1,
            customerId: formData.customerId ? parseInt(formData.customerId, 10) : project.customer?.id || 1,
            projectManagerId: formData.projectManagerId ? parseInt(formData.projectManagerId, 10) : project.projectManager?.id || 1,
            serviceId: formData.serviceId ? parseInt(formData.serviceId, 10) : project.serviceId || 1,
            projectTypeId: formData.projectTypeId ? parseInt(formData.projectTypeId, 10) : project.projectTypeId || 1,
        };

        try {
            const res = await fetch(`https://localhost:7298/api/projects/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            });

            if (!res.ok) {
                throw new Error("Failed to update project");
            }

            alert("Project updated successfully!");
            await getProject(id);
            navigate('/projects');
        } catch (error) {
            console.error("Error updating project:", error);
            alert("Error updating project");
        }
    };

    return (
        <main id='project'>
            <div className="container">
                <SectionHeader title={`PROJEKT ${project.id || ''} - ${formData.projectName}`} />
                <form className="new-project-form" onSubmit={handleSubmit}>
                    <label>
                        Projektnamn:
                        <input type="text" name="projectName" value={formData.projectName} onChange={handleChange} required />
                    </label>

                    <label>
                        Beskrivning:
                        <textarea name="description" value={formData.description} onChange={handleChange} required />
                    </label>

                    <label>
                        Startdatum:
                        <input type="date" name="startDate" value={formData.startDate} onChange={handleChange} required />
                    </label>

                    <label>
                        Slutdatum:
                        <input type="date" name="endDate" value={formData.endDate} onChange={handleChange} required />
                    </label>

                    <label>
                        Status:
                        <select name="statusId" value={formData.statusId} onChange={handleChange} required>
                            <option value="" disabled hidden>Välj en status</option>
                            {statuses.map((status) => (
                                <option key={status.id} value={status.id}>{status.statusName}</option>
                            ))}
                        </select>
                    </label>

                    <label>
                        Projektledare:
                        <select name="projectManagerId" value={formData.projectManagerId} onChange={handleChange} required>
                            <option value="" disabled hidden>Välj en projektledare</option>
                            {users.map((user) => (
                                <option key={user.id} value={user.id}>{user.displayName}</option>
                            ))}
                        </select>
                    </label>

                    <label>
                        Service:
                        <select name="serviceId" value={formData.serviceId} onChange={handleChange} required>
                            <option value="" disabled hidden>Välj en tjänst</option>
                            {services.map((service) => (
                                <option key={service.id} value={service.id}>{service.serviceName}</option>
                            ))}
                        </select>
                    </label>

                    <label>
                        Projekttyp:
                        <select name="projectTypeId" value={formData.projectTypeId} onChange={handleChange} required>
                            <option value="" disabled hidden>Välj en projekttyp</option>
                            {projectTypes.map((type) => (
                                <option key={type.id} value={type.id}>{type.typeName}</option>
                            ))}
                        </select>
                    </label>

                    <label>
                        Kund:
                        <select name="customerId" value={formData.customerId} onChange={handleChange} required>
                            <option value="" disabled hidden>Välj en kund</option>
                            {customers.map((customer) => (
                                <option key={customer.id} value={customer.id}>{customer.customerName}</option>
                            ))}
                        </select>
                    </label>

                    <button type="submit" className='btn btn-yellow'>Uppdatera Projekt</button>
                    <button type="button" className='btn btn-gray' onClick={() => navigate('/projects')}>Avbryt</button>
                </form>
            </div>
        </main>
    );
};

export default Project;
