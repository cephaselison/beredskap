
export {};
// import { CreateUser } from '@/dto/users/CreateUser.dto';
// import { InfoUserWidthCredential } from '@/dto/users/InfoUser.dto';
// import { LoginRequestDto } from '@/dto/users/LoginRequest.dto';
// import { UpdateUser } from '@/dto/users/UpdateUser.dto';
// import http from './httpService';

// class AuthenticateService {
//   prefix = 'users';

//   public async checkToken(
//     token: string
//   ): Promise<InfoUserWidthCredential | undefined> {
//     const result = await http.post(`${this.prefix}/check-token`, {
//       token,
//     });
//     return result?.data?.result;
//   }

//   public async login(model: LoginRequestDto): Promise<InfoUserWidthCredential> {
//     const result = await http.post(`${this.prefix}/login`, model);
//     return result.data.result;
//   }

//   public async logout(token: string): Promise<boolean> {
//     const result = await http.post(`${this.prefix}/logout`, {
//       token,
//     });
//     return result.data.result;
//   }

//   public async registerUser(model: CreateUser): Promise<boolean> {
//     const result = await http.post(`${this.prefix}`, model);
//     return result.data.result;
//   }

//   public async updateUser(model: UpdateUser): Promise<boolean> {
//     const result = await http.put(`${this.prefix}`, model);
//     return result.data.result;
//   }
// }

// export default new AuthenticateService();
