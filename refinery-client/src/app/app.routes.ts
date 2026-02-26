import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { MainLayoutComponent } from './layout/main-layout.component';
import { authGuard } from './guards/auth.guard';
import { EmployeeListComponent } from './pages/employees/list/employee-list.component';
import { EmployeeFormComponent } from './pages/employees/form/employee-form.component';
import { FacilityListComponent } from './pages/facilities/list/facility-list.component';
import { FacilityFormComponent } from './pages/facilities/form/facility-form.component';
import { UserListComponent } from './pages/users/user-list.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'employees', pathMatch: 'full' },

      // Employees
      { path: 'employees', component: EmployeeListComponent },
      { path: 'employees/add', component: EmployeeFormComponent },
      { path: 'employees/edit/:id', component: EmployeeFormComponent },

      // Facilities
      { path: 'facilities', component: FacilityListComponent },
      { path: 'facilities/add', component: FacilityFormComponent },
      
      { path: 'facilities/edit/:id', component: FacilityFormComponent },

      // Users
      { path: 'users', component: UserListComponent }
    ]
  },
  { path: '**', redirectTo: 'login' }
];
