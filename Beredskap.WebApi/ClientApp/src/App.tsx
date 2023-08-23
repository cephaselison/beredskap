import React, { useState, useEffect } from "react";
import {
  CssBaseline,
  Container,
  Grid,
  createTheme,
  ThemeProvider,
} from "@mui/material";
import { Route, Routes, Navigate } from "react-router-dom";
import LoginForm from "./components/LoginForm";
import CustomSidebar from "./components/SideMenu/Sidebar";
import CustomAppBar from "./components/AppBar/AppBar";
import { useNavigate } from "react-router-dom";
import { observer } from "mobx-react";
import TenantsPage from "./pages/tenants/index";
import TenantPage from "./pages/tenant";
import { UserStoreContext } from "./store/user.store";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const navigator = useNavigate();
  const theme = createTheme();
  const userStore = React.useContext(UserStoreContext);

  const handleLogin = () => {
    setIsLoggedIn(true);
    if (userStore.isAdmin()) {
      return navigator("/tenants");
    }

    if (userStore?.user === null) return;

    return navigator(`/tenants/${userStore.user.tenantId}`);
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    userStore.logoutUser();
    navigator("/login");
  };

  useEffect(() => {}, [isLoggedIn]);

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <CustomAppBar onLogout={handleLogout} />
      <Container>
        <Routes>
          <Route path="/login" element={<LoginForm onLogin={handleLogin} />} />
          {/* <Route
            path="/tenants"
            element={<AuthRoute element={<TenantsPage />} />}
          />
          <Route
            path="/tenants/:tenantId"
            element={<AuthRoute element={<TenantPage />} />}
          /> */}
          <Route path="/tenants" element={<TenantsPage />} />
          <Route path="/tenants/:tenantId" element={<TenantPage />} />
          {/* <Route
            path="/tenants/*"
            element={
              <PrivateRoute isLoggedIn={isLoggedIn} onLogout={handleLogout} />
            }
          /> */}
          {/* You can add more private routes for other components */}
          <Route path="/" element={<Navigate to="/login" />} />
        </Routes>
      </Container>
    </ThemeProvider>
  );
}

interface PrivateRouteProps {
  isLoggedIn: boolean;
  onLogout: () => void;
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({
  isLoggedIn,
  onLogout,
}) => {
  return isLoggedIn ? (
    <>
      {/* <CustomSidebar onLogout={onLogout} /> */}
      <Routes>
        <Route path="/" element={<TenantsPage />} />
        <Route path="/tenants/:tenantId" element={<TenantPage />} />
        {/* Add more private sub-routes here */}
      </Routes>
    </>
  ) : (
    <Navigate to="/login" />
  );
};

export default observer(App);
