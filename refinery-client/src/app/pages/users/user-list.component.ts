import { Component, OnInit, ChangeDetectorRef } from '@angular/core'; 
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  template: `
    <div class="container mt-4">
      <div class="d-flex justify-content-between align-items-center mb-4">
        <h2>Пользователи системы</h2>
        <!-- Кнопку создания делаем, если нужно -->
      </div>
      
      <!-- Индикатор загрузки -->
      <div *ngIf="isLoading" class="alert alert-info">Загрузка данных...</div>

      <table class="table table-striped border" *ngIf="!isLoading">
        <thead>
          <tr>
            <th>ID</th>
            <th>Логин</th>
            <th>Email</th>
            <th>Роль</th>
            <th>ID Сотрудника</th>
            <th>Действия</th>
          </tr>
        </thead>
        <tbody>
          <tr *ngFor="let u of users">
            <td>{{ u.userID }}</td>
            <td>{{ u.login || u.name }}</td> 
            <td>{{ u.email }}</td>
            <td><span class="badge bg-primary">{{ u.role }}</span></td>
            <td>{{ u.employeeID }}</td>
            <td>
              <button class="btn btn-sm btn-danger" (click)="deleteUser(u.userID)">Удалить</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  `
})
export class UserListComponent implements OnInit {
  users: any[] = [];
  isLoading = false;

  constructor(
    private apiService: ApiService,
    private cdr: ChangeDetectorRef 
  ) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.isLoading = true;
    this.apiService.getUsers().subscribe({
      next: (data: any) => {
        this.users = data;
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error(err);
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  deleteUser(id: number) {
    if (confirm('Удалить пользователя?')) {
      this.apiService.deleteUser(id).subscribe({
        next: () => {
          this.loadUsers();
        },
        error: (err) => console.error(err)
      });
    }
  }
}
