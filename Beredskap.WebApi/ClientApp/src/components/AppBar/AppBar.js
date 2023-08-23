import React, { useEffect } from 'react';
import { AppBar, Toolbar, Typography, IconButton } from '@mui/material';
import { Menu as MenuIcon, AccountCircle as AccountCircleIcon, Home, Logout } from '@mui/icons-material';
import { Link, useNavigate } from 'react-router-dom';
import { UserStoreContext } from '../../store/user.store';
import { TenantStoreContext } from '../../store/tenant.store';

const CustomAppBar = ({onLogout}) => {
    const navigator = useNavigate();
    const userStore = React.useContext(UserStoreContext);
    const tenantStore = React.useContext(TenantStoreContext);

    useEffect(() => {
    },[userStore.user]);

    return (
        <AppBar position="static">
            <Toolbar>
                 {userStore?.user != null && (
                    <IconButton
                    color="inherit"
                    aria-label="home"
                    sx={{ mr: 2 }}
                    onClick={() => {
                        if (userStore.isAdmin()){
                            return navigator('/tenants');
                            
                        }

                        return navigator(`/tenants/${tenantStore.tenant.id}`);
                            
                    }}
                >
                    <Home />
                </IconButton>
                 )}
                {userStore?.user != null && (
                    <IconButton
                    edge="end"
                    color="inherit"
                    aria-label="account"
                    onClick={() => onLogout()}
                >
                    <Logout />
                </IconButton>
                )}
                
              
            </Toolbar>
        </AppBar>
    );
};

export default CustomAppBar;