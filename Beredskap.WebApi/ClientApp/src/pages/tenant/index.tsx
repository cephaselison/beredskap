import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
  Button,
  Container,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Dialog,
  DialogTitle,
  DialogActions,
  DialogContent,
  TextField,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
} from "@mui/material";
import { Add } from "@mui/icons-material";
import { TenantStoreContext } from "../../store/tenant.store";
import { IncidentStoreContext } from "../../store/incident.store";
import { IncidentDTO } from "../../dto/incident/Incident.dto";
import { INCIDENT_STATUS } from "../../enum/incident.status.enum";
import { GuidEmpty } from "../../constants/general";
import { observer } from "mobx-react";

const TenantPage = () => {
  const { tenantId } = useParams();
  const [openDialogue, setOpenDialogue] = React.useState(false);
  const [name, setName] = useState("");
  const [location, setLocation] = useState("");
  const [selectedStatus, setSelectedStatus] = useState(INCIDENT_STATUS.Unknown);

  const tenantStore = React.useContext(TenantStoreContext);
  const incidentStore = React.useContext(IncidentStoreContext);

  const handleOpenDialogue = () => {
    setOpenDialogue(true);
  };

  const handleCloseDialogue = () => {
    setOpenDialogue(false);
  };

  const handleAddIncident = async () => {
    const model: IncidentDTO = {
      name: name,
      location: location,
      id: GuidEmpty,
      incidentStatus: selectedStatus,
    };
    try {
      await incidentStore.addIncident(model);
      handleCloseDialogue();
    } catch (error) {
      console.error("Error adding tenant:", error);
      // Handle error if necessary
    }
  };

  useEffect(() => {
    localStorage.setItem("tenantId", tenantId ? tenantId : "");
    if (tenantStore.tenant.id !== tenantId && tenantId !== null) {
      tenantStore.getTenant(tenantId!);
      incidentStore.getIncidents();
    }
  }, [tenantId]);

  return (
    <Container>
      <Stack
        direction="row"
        justifyContent="space-between"
        alignItems="center"
        spacing={0}
        paddingTop={4}
      >
        <h1>Incidents Overview</h1>
        <Button
          variant="outlined"
          startIcon={<Add />}
          onClick={handleOpenDialogue}
        >
          Add
        </Button>
        <Dialog open={openDialogue} onClose={handleCloseDialogue} fullWidth>
          <DialogTitle>Add Incident</DialogTitle>
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

            <TextField
              autoFocus
              margin="normal"
              id="location"
              label="Location"
              type="location"
              value={location}
              fullWidth
              variant="standard"
              onChange={(e) => setLocation(e.target.value)}
            />

            <FormControl fullWidth margin="normal">
              <Select
                title="Status"
                value={selectedStatus}
                onChange={(e) =>
                  setSelectedStatus(e.target.value as INCIDENT_STATUS)
                }
              >
                {Object.values(INCIDENT_STATUS).map((status) => (
                  <MenuItem key={status} value={status}>
                    {status}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </DialogContent>
          <DialogActions>
            <Button onClick={handleCloseDialogue}>Cancel</Button>
            <Button disabled={name.length === 0} onClick={handleAddIncident}>
              Add
            </Button>
          </DialogActions>
        </Dialog>
      </Stack>
      <TableContainer component={Paper} style={{ marginTop: "16px" }}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Name</TableCell>
              <TableCell>Location</TableCell>
              <TableCell>Status</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {incidentStore.incidents.map((row) => (
              <TableRow key={row.id}>
                <TableCell>{row.name}</TableCell>
                <TableCell>{row.location}</TableCell>
                <TableCell>{row.incidentStatus as INCIDENT_STATUS}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
  );
};

export default observer(TenantPage);
