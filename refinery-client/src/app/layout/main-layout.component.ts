import { Component } from '@angular/core'; //Component — декоратор для определения Angular компонента.
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router'; //директивы для маршрутизации
import { AuthService } from '../services/auth.service'; //сервис для работы с аутентификацией

@Component({
  selector: 'app-main-layout',
  standalone: true, // — компонент автономный, не требует объявления в модуле.
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent {
  userRole: string | null = null; //Свойство userRole — хранит роль текущего пользователя (например, "admin", "user" или null, если не авторизован).

  constructor(public authService: AuthService) { // получаем доступ к сервису аутентификации.
    this.userRole = this.authService.getUserRole(); //Вызывается метод getUserRole() сервиса, чтобы получить роль пользователя и сохранить в userRole.
  }

  logout() {
    this.authService.logout(); // Позволяет пользователю выйти из системы с помощью метода logout().
  }
}
//главный шаблон приложения с навигацией и управлением аутентификацией пользователя.