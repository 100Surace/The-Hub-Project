import React from 'react';
import { makeStyles, useTheme } from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';
import AppHeader from '../Components/AppHeader';
import AppDrawer from '../Components/AppDrawer';
import Content from '../Components/Content';

const useStyles = makeStyles((theme) => ({
  root: {
    display: 'flex',
  },
}));

export default function Dashboard() {
  const classes = useStyles();
  const theme = useTheme();
  const [open, setOpen] = React.useState(false);

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  return (
    <div className={classes.root}>
      <CssBaseline />
      <AppHeader handleDrawerOpen={handleDrawerOpen} open={open} />
      <AppDrawer handleDrawerClose={handleDrawerClose} open={open}/>
      <Content open={open}/>
    </div>
  );
}
