import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ApiService } from '../../../services/api.service';
import { Employee } from '../../../models/employee.models';

@Component({
  selector: 'app-facility-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './facility-form.component.html'
})
export class FacilityFormComponent implements OnInit {
  form: FormGroup;
  employees: Employee[] = [];
  isEditMode = false;
  facilityId: number | null = null;
  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      type: ['', [Validators.required]],
      columnType: ['', [Validators.required]],
      temperatureTop: [0, [Validators.required]],
      temperatureBottom: [0, [Validators.required]],
      pressureTop: [0, [Validators.required]],
      employeeId: [null, [Validators.required]]
    });
  }

  ngOnInit(): void {
    // 1. Загружаем список сотрудников для выпадающего списка
    this.apiService.getEmployees().subscribe(data => this.employees = data);

    // 2. Проверяем, есть ли ID в адресе (значит это редактирование)
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.facilityId = +id;
      this.loadFacilityData(this.facilityId);
    }
  }

  loadFacilityData(id: number) {
    this.apiService.getFacilityById(id).subscribe(data => {
      this.form.patchValue(data);
    });
  }

  onSubmit() {
    if (this.form.invalid) return;
    this.isLoading = true;

    const data = this.form.value;

    if (this.isEditMode && this.facilityId) {
      // Редактирование
      this.apiService.updateFacility(this.facilityId, data).subscribe({
        next: () => this.router.navigate(['/facilities']),
        error: () => { alert('Ошибка обновления'); this.isLoading = false; }
      });
    } else {
      // Создание
      this.apiService.createFacility(data.employeeId, data).subscribe({
        next: () => this.router.navigate(['/facilities']),
        error: () => { alert('Ошибка создания'); this.isLoading = false; }
      });
    }
  }
}
