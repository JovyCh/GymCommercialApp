export interface UserDto{
    email: string;
    password: string;
}

export interface LoginResponse {
  isSuccess: boolean;
  token: string;
  userType: string;
  expiration: string;
  errorMessage: string;
}