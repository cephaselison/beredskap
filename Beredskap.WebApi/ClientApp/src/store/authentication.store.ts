// import authenticateService from '@/apis/authenticate.service';
// import { LoginRequestDto } from '@/dto/users/LoginRequest.dto';
// import {
//   removeFromCookie,
//   removeFromStorage,
//   retrieveFromCookie,
//   retrieveFromStorage,
//   saveToCookie,
//   saveToStorage,
// } from '../utils/storage.util';
// import { action, makeObservable, observable } from 'mobx';
// import React from 'react';
// import { InfoUserWidthCredential } from '@/dto/users/InfoUser.dto';
// import { UpdateUser } from '@/dto/users/UpdateUser.dto';

// class AuthenticationStore {
//   loggedUser: InfoUserWidthCredential | null;
//   loginFormValue: LoginRequestDto;
//   loginFormValueInit: LoginRequestDto = {
//     email: '',
//     password: '',
//     rememberMe: false,
//   };
//   errorLoginFormValue: Record<string, boolean>;
//   errorLoginFormValueInit: Record<string, boolean> = {
//     email: false,
//     password: false,
//   };
//   expireTokenCookie: number;

//   constructor() {
//     this.loggedUser = null;
//     this.loginFormValue = {
//       email: '',
//       password: '',
//       rememberMe: false,
//     };
//     this.errorLoginFormValue = {
//       email: false,
//       password: false,
//     };

//     this.expireTokenCookie = 1;
//     if (process.env.REACT_APP_TOKEN_EXPIRE_COOKIE) {
//       this.expireTokenCookie = +process.env.REACT_APP_TOKEN_EXPIRE_COOKIE;
//     }
//     makeObservable(this, {
//       loggedUser: observable,
//       loginFormValue: observable,

//       login: action,
//       logout: action,
//       saveUser: action,
//     });
//   }

//   private _setCurrentInfo(
//     data: InfoUserWidthCredential,
//     rememberMe: boolean
//   ): void {
//     const token = data.token;
//     this.loggedUser = data;

//     if (rememberMe) {
//       saveToStorage('token', token);
//       saveToStorage('loggedUser', JSON.stringify(data));
//     } else {
//       saveToCookie('token', token, this.expireTokenCookie * 60 * 60);
//       saveToCookie(
//         'loggedUser',
//         JSON.stringify(data),
//         this.expireTokenCookie * 60 * 60
//       );
//     }
//   }

//   private _redirectAfterLogin(history: any): void {
//     if (this.loggedUser) {
//       return history.push('/home/supply');
//     }
//     return history.push('/');
//   }

//   saveUser(data: any): void {
//     this.loggedUser = data;
//   }

export {};
//   async login(history: any): Promise<void> {
//     if (this._isErrorLogin()) {
//       return;
//     }
//     const data = await authenticateService.login(this.loginFormValue);
//     this._setCurrentInfo(data, this.loginFormValue.rememberMe);
//     this.loginFormValue = this.loginFormValueInit;
//     this._redirectAfterLogin(history);
//   }

//   private _isErrorLogin(): boolean {
//     this.errorLoginFormValue = this.errorLoginFormValueInit;
//     let isError = false;

//     if (!this.loginFormValue.email) {
//       this.errorLoginFormValue.email = true;
//       isError = true;
//     }

//     if (!this.loginFormValue.password) {
//       this.errorLoginFormValue.password = true;
//       isError = true;
//     }

//     return isError;
//   }

//   async checkToken(token: string): Promise<void> {
//     const data = await authenticateService.checkToken(token);
//     if (data) {
//       this.saveUser(data);
//     }
//   }

//   async logout(history: any): Promise<any> {
//     const token = retrieveFromStorage('token') || retrieveFromCookie('token');
//     if (token) {
//       const result = await authenticateService.logout(token);
//       if (result) {
//         removeFromStorage('token');
//         removeFromStorage('loggedUser');
//         removeFromCookie('token');
//         removeFromCookie('loggedUser');
//         this.loggedUser = null;
//         return history.push('/');
//       }
//     }
//   }

//   async updateUser(model: UpdateUser): Promise<boolean> {
//     return await authenticateService.updateUser(model);
//   }
// }

// export const AuthenticationStoreContext = React.createContext(
//   new AuthenticationStore()
// );
