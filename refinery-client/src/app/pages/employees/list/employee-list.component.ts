import { Component, OnInit, ChangeDetectorRef } from '@angular/core'; 
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../../services/api.service';
import { Employee } from '../../../models/employee.models';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];
  isLoading = false;
  viewMode: 'table' | 'cards' = 'table';

  // Фильтры
  searchSurname: string = '';
  searchPosition: string = '';
  sortBy: string = 'Id';
  isDescending: boolean = false;

  constructor(
    private apiService: ApiService,
    private cdr: ChangeDetectorRef 
  ) { }

  ngOnInit(): void {  
    this.loadEmployees(); 
  }

  loadEmployees() {
    this.isLoading = true;

    // Формируем параметры запроса
    const params: any = {};
    if (this.searchSurname) params['Surname'] = this.searchSurname;
    if (this.searchPosition) params['Position'] = this.searchPosition;
    if (this.sortBy) params['SortBy'] = this.sortBy;
    params['IsDescending'] = this.isDescending;

    this.apiService.getEmployees(params).subscribe({
      next: (data) => {
        console.log('Данные получены:', data); // Для отладки
        this.employees = data;
        this.isLoading = false;

        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Ошибка при загрузке:', err);
        this.isLoading = false;

        this.cdr.detectChanges();
      }
    });
  }

  deleteEmployee(id: number) {
    if (confirm('Вы уверены, что хотите удалить этого сотрудника?')) {
      this.apiService.deleteEmployee(id).subscribe({
        next: () => {
          this.loadEmployees(); 
        },
        error: (err) => console.error(err)
      });
    }
  }

  toggleSort(field: string) { 
    if (this.sortBy === field) {
      this.isDescending = !this.isDescending;
    } else {
      this.sortBy = field;
      this.isDescending = false;
    }
    this.loadEmployees();
  }

  toggleView(mode: 'table' | 'cards') {  
    this.viewMode = mode;
  }
}
