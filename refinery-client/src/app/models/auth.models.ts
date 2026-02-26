export interface LoginData { //интерфейс, описывающий данные для входа пользователя:
  username: string;
  password: string;
}

export interface AuthResponse {  // интерфейс, описывающий ответ от сервера при успешной аутентификации:
  token: string;
}

export interface UserContext {  //нтерфейс, описывающий контекст пользователя, извлекаемый из токена:
  unique_name: string; // Login
  role: string;
  
}
