import { createRoot } from 'react-dom/client'
import { BrowserRouter } from 'react-router-dom'
import App from './App.jsx'

import { AddressTypeProvider } from './contexts/AddressTypeContext.jsx'
import { CustomerAddressProvider } from './contexts/CustomerAddressContext.jsx'
import { CustomerProvider } from './contexts/CustomerContext.jsx'
import { EmployeeProvider } from './contexts/EmployeeContext.jsx'
import { InvoiceProvider } from './contexts/InvoiceContext.jsx'
import { PostalCodeProvider } from './contexts/PostalCodeContext.jsx'
import { ProjectProvider } from './contexts/ProjectContext.jsx'
import { ProjectTypeProvider } from './contexts/ProjectTypeContext.jsx'
import { RoleProvider } from './contexts/RoleContext.jsx'
import { ServiceProvider } from './contexts/ServiceContext.jsx'
import { StatusProvider } from './contexts/StatusContext.jsx'
import { TaskAssignmentProvider } from './contexts/TaskAssignmentContext.jsx'
import { TasksProvider } from './contexts/TasksContext.jsx'
import { UserAddressProvider } from './contexts/UserAddressContext.jsx'
import { UserProvider } from './contexts/UserContext.jsx'

createRoot(document.getElementById('root')).render(
    <BrowserRouter>
        <RoleProvider>
          <UserProvider> 
            <EmployeeProvider> 
              <PostalCodeProvider> 
                <CustomerAddressProvider> 
                  <UserAddressProvider> 
                    <CustomerProvider> 
                      <InvoiceProvider>
                        <ServiceProvider> 
                          <StatusProvider> 
                            <ProjectTypeProvider> 
                              <AddressTypeProvider> 
                                <ProjectProvider> 
                                  <TasksProvider> 
                                    <TaskAssignmentProvider> 
                                      <App />
                                    </TaskAssignmentProvider>
                                  </TasksProvider>
                                </ProjectProvider>
                              </AddressTypeProvider>
                            </ProjectTypeProvider>
                          </StatusProvider>
                        </ServiceProvider>
                      </InvoiceProvider>
                    </CustomerProvider>
                  </UserAddressProvider>
                </CustomerAddressProvider>
              </PostalCodeProvider>
            </EmployeeProvider>
          </UserProvider>
        </RoleProvider>
      </BrowserRouter>
)
