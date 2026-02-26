import { HttpInterceptorFn } from '@angular/common/http'; //HTTP Interceptor позволяет перехватывать HTTP-запросы перед их отправкой и вносить в них необходимые изменения.
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => { //Создаётся функция tokenInterceptor, которая принимает: req — исходный HTTP-запрос. next — функция, вызывающая следующий обработчик (следующий интерсептор или отправку запроса).
  const authService = inject(AuthService); // Через inject получаем сервис AuthService и вызываем метод getToken(), чтобы получить текущий токен аутентификации пользователя (например, JWT).
  const token = authService.getToken();

  if (token) {                                          //Если токен существует, создаём копию запроса с помощью метода clone() и добавляем в заголовки HTTP-запроса поле:
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}` //передаем токен аутентификации
      }
    });
  }

  return next(req);                                     //  После модификации (или без неё, если токена нет) передаём запрос дальше по цепочке интерсепторов или непосредственно в HTTP-клиент для отправки.
};

//Этот код реализует HTTP-интерсептор, который автоматически добавляет токен аутентификации в заголовок Authorization каждого исходящего HTTP-запроса, если такой токен есть