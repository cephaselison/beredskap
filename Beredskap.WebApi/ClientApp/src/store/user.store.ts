import { makeObservable, observable, action } from 'mobx';
import React from 'react';

class UserStore {
    user:any = null;
     isLoggedIn = false;

    constructor() {
        
        makeObservable(this, {
            isLoggedIn: observable,
            user: observable,
            setUser: action,
            logoutUser: action,
            isAdmin: action
        });

        this.loadUserFromLocalStorage();
    }

    setUser(user:any) {
        this.isLoggedIn = true;
        this.user = user;
        
    }

    logoutUser() {
        this.user = null;
        this.isLoggedIn = false;
        this.clearUserFromLocalStorage();
    }

     isAdmin(): boolean {
        return this.user?.roles?.some((x:any)=> x ==='SuperAdmin');
    }

    saveUserToLocalStorage() {
    localStorage.setItem("isLoggedIn", this.isLoggedIn.toString());
    localStorage.setItem("user", JSON.stringify(this.user));
    }

    loadUserFromLocalStorage() {
      const isLoggedIn = localStorage.getItem("isLoggedIn") === "true";
      const user = JSON.parse(localStorage.getItem("user") || "{}");

      this.isLoggedIn = isLoggedIn;
      this.user = user;
    }

    clearUserFromLocalStorage() {
      localStorage.removeItem("isLoggedIn");
      localStorage.removeItem("user");
    }
    
}

const userStore = new UserStore();
export default userStore;

export const UserStoreContext = React.createContext(new UserStore());