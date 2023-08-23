import React, { useEffect, useState } from "react";
import { observer } from "mobx-react";
import {
  Card,
  CardContent,
  Typography,
  Grid,
  Container,
  Stack,
  Button,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
  TextField,
} from "@mui/material";
import { Link } from "react-router-dom";
import { TenantStoreContext } from "../../store/tenant.store";
import { Add } from "@mui/icons-material";
import { AddTenantDTO } from "../../services/tenant/dto/add.tenant.dto";

const TenantsPage = () => {
  const tenantStore = React.useContext(TenantStoreContext);
  const [openDialogue, setOpenDialogue] = React.useState(false);
  const [name, setName] = useState("");

  useEffect(() => {
    tenantStore.getTenants();
  }, []);

  useEffect(() => {}, [tenantStore.tenants]);

  const handleOpenDialogue = () => {
    setOpenDialogue(true);
  };

  const handleCloseDialogue = () => {
    setOpenDialogue(false);
  };

  const handleAddTenant = async () => {
    const model: AddTenantDTO = {
      key: name,
    };
    try {
      const response = await tenantStore.addTenant(model);
      handleCloseDialogue();
    } catch (error) {
      console.error("Error adding tenant:", error);
      // Handle error if necessary
    }
  };

  useEffect(() => {
    console.log("foo");
  }, []);

  return (
    <Container>
      <Stack
        paddingTop={4}
        direction="row"
        justifyContent="space-between"
        alignItems="center"
        spacing={0}
      >
        <h1>Tenant</h1>
        <Button
          onClick={handleOpenDialogue}
          variant="outlined"
          startIcon={<Add />}
        >
          Add
        </Button>
        <Dialog open={openDialogue} onClose={handleCloseDialogue}>
          <DialogTitle>Add Tenant</DialogTitle>
          <DialogContent>
            <TextField
              autoFocus
              margin="normal"
              id="name"
              label="Name"
              type="name"
              value={name}
              fullWidth
              variant="standard"
              onChange={(e) => setName(e.target.value)}
            />
          </DialogContent>
          <DialogActions>
            <Button onClick={handleCloseDialogue}>Cancel</Button>
            <Button disabled={name.length === 0} onClick={handleAddTenant}>
              Add
            </Button>
          </DialogActions>
        </Dialog>
      </Stack>
      <Grid container spacing={3}>
        {tenantStore.tenants?.map((tenant) => (
          <Grid item xs={12} sm={6} md={4} key={tenant.id}>
            <Link
              to={`/tenants/${tenant.id}`}
              style={{ textDecoration: "none" }}
            >
              <Card>
                <CardContent>
                  <Typography variant="h6" component="div">
                    {tenant.key}
                  </Typography>
                  {/* Add more card content here */}
                </CardContent>
              </Card>
            </Link>
          </Grid>
        ))}
      </Grid>
    </Container>
  );
};

export default observer(TenantsPage);
