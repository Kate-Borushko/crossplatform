import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ApiService } from '../../../services/api.service';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './employee-form.component.html'
})
export class EmployeeFormComponent implements OnInit {
  form: FormGroup; 
  isEditMode = false; 
  employeeId: number | null = null; 
  isLoading = false; 

  constructor( 
    private fb: FormBuilder,  
    private apiService: ApiService,  
    private router: Router,  
    private route: ActivatedRoute 
  ) {
    
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      surname: ['', [Validators.required, Validators.minLength(2)]],
      position: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      shift: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      phoneNumber: [null, [Validators.required, Validators.pattern("^[0-9]*$")]]
    });
  }

  ngOnInit(): void { 
    const id = this.route.snapshot.paramMap.get('id');
    if (id) { 
      this.isEditMode = true;
      this.employeeId = +id;
      this.loadEmployeeData(this.employeeId); 
    }
  }

  loadEmployeeData(id: number) { 
    this.apiService.getEmployeeById(id).subscribe(data => {
      this.form.patchValue(data);
    }); 
  }

  onSubmit() { 
    if (this.form.invalid) return; 

    this.isLoading = true; 
    const request = this.form.value;  

    if (this.isEditMode && this.employeeId) { 
      this.apiService.updateEmployee(this.employeeId, request).subscribe({ 
        error: (err) => { console.error(err); this.isLoading = false; }
      });
    } else {
      this.apiService.createEmployee(request).subscribe({ 
        next: () => this.router.navigate(['/employees']), 
        error: (err) => { console.error(err); this.isLoading = false; }
      });
    } 
  }
}
