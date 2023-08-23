import React, { ReactNode } from "react";
import { Route, Navigate, RouteObject } from "react-router-dom";

interface AuthRouteProps {
  element: ReactNode;
  caseSensitive?: boolean;
  children?: ReactNode;
}

const AuthRoute: React.FC<AuthRouteProps> = ({ element, ...rest }) => {
  // Replace this with your actual authentication logic
  const isAuthenticated = localStorage.getItem("access_token") !== null;

  if (!isAuthenticated) {
    return <Navigate to="/login" />;
  }

  return <Route {...rest} element={element} />;
};

export default AuthRoute;
