import React from 'react';
import { Drawer, List, ListItem, ListItemIcon, ListItemText } from '@mui/material';
import HomeIcon from '@mui/icons-material/Home';
import PersonIcon from '@mui/icons-material/Person';
import { Link } from 'react-router-dom';
import { LogoutOutlined } from '@mui/icons-material';

const CustomSidebar = ({ onLogout }) => {


    return (
        <Drawer variant="permanent" sx={{ marginTop: '64px' }}>
            <List>
                <ListItem button component={Link} to="/tenants">
                    <ListItemIcon>
                        <HomeIcon />
                    </ListItemIcon>
                    <ListItemText primary="Tenants" />
                </ListItem>

                
                <ListItem button onClick={() => onLogout()}>
                    <ListItemIcon>
                        <LogoutOutlined />
                    </ListItemIcon>
                    <ListItemText primary="Signout" />
                </ListItem>
            </List>
        </Drawer>
    );
};

export default CustomSidebar;