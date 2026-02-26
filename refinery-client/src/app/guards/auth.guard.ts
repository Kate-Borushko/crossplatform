import { inject } from '@angular/core'; //функция внедрения зависимостей позволяет передавать зависимости в компоненты а не создавать их внутри себя
import { CanActivateFn, Router } from '@angular/router'; //canActivate представляет один из типов guards, который позволяет управлять доступом к ресурсу при маршрутизации.
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => { //Создаётся функция authGuard, которая принимает параметры route и state (информация о текущем маршруте и состоянии навигации).
  const authService = inject(AuthService); // authService — для проверки наличия токена.
  const router = inject(Router); //router — для перенаправления пользователя.

  if (authService.getToken()) { 
    return true;                   //Если метод getToken() возвращает значение (токен существует), значит пользователь аутентифицирован, и доступ к маршруту разрешается (return true).
  } else {
    router.navigate(['/login']);
    return false;
  }
};
//Этот код реализует защиту маршрута, 
// которая проверяет, есть ли у пользователя токен (то есть он авторизован). 
// Если токен есть — маршрут открывается, если нет — пользователь перенаправляется на 
// страницу входа в систему.