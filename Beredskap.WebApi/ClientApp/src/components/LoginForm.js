// src/components/LoginForm.js
import React, { useEffect, useState } from 'react';
import { TextField, Button, Container, Paper } from '@mui/material';
import axios from 'axios';
import { observer } from 'mobx-react-lite';
import { UserStoreContext } from '../store/user.store';

const LoginForm = ({ onLogin }) => {
    const [email, setEmail] = useState('admin@root.com');
    const [password, setPassword] = useState('Password123!');
    const [error, setError] = useState(null);
    const userStore = React.useContext(UserStoreContext);

    const handleLogin = async () => {
        try {
            const headers = {
                'tenant': 'user' // Add the 'tenant' header
            };

            await axios.post('https://localhost:7250/api/tokens', {
                email: email,
                password: password
            }, {
                headers: headers,
            }).then((result) => {
                userStore.setUser({user: result.data.user, id: result.data.id, roles: [...result.data.roles], tenantId: result.data.tenantId});


                const token = result.data.token;

                // Store the token in local storage or wherever you prefer
                localStorage.setItem('access_token', token);

                // Call the parent onLogin callback to update the login state
                onLogin();
            });
       
        } catch (error) {
            console.log(error);
            setError('Invalid credentials. Please try again.');
        }
    };

    useEffect(() => {
        userStore.logoutUser();
    },[])

    return (
        <Container maxWidth="xs" style={{paddingTop: '36px'}}>
            <Paper elevation={3} style={{ padding: '20px' }}>
                <h2>Login</h2>
                {error && <p style={{ color: 'red' }}>{error}</p>}
                <TextField
                    label="Email"
                    fullWidth
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    margin="normal"
                />
                <TextField
                    label="Password"
                    fullWidth
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    margin="normal"
                />
                <Button variant="contained" color="primary" onClick={handleLogin} fullWidth>
                    Login
                </Button>
            </Paper>
        </Container>
    );
};

export default observer(LoginForm);
