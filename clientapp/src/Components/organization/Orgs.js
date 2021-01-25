import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import * as actions from '../../actions/organization/orgs';
import { Grid, Paper, TableContainer, Table, TableHead, TableRow, TableCell, TableBody, withStyles, ButtonGroup, Button } from '@material-ui/core';
import OrgsForm from './OrgsForm';
import EditIcon from '@material-ui/icons/Edit';
import DeleteIcon from '@material-ui/icons/Delete';
import { useToasts } from 'react-toast-notifications';

const styles = (theme) => ({
  root: {
    '& .MuiTableCell-head': {
      fontSize: '1.25rem',
    },
  },
  paper: {
    margin: theme.spacing(2),
    padding: theme.spacing(2),
  },
});

const Orgs = ({ classes, ...props }) => {
  const [currentId, setCurrentId] = useState(0);

  useEffect(() => {
    props.fetchAll();
  }); //componentDidMount

  //toast msg.
  const { addToast } = useToasts();

  const onDelete = (id) => {
    if (window.confirm('Are you sure to delete this record?')) props.delete(id, () => addToast('Deleted successfully', { appearance: 'info' }));
  };
  return (
    <Paper className={classes.paper} elevation={3}>
      <Grid container>
        <Grid item xs={6}>
          <OrgsForm {...{ currentId, setCurrentId }} />
        </Grid>
        <Grid item xs={6}>
          <TableContainer>
            <Table>
              <TableHead className={classes.root}>
                <TableRow>
                  <TableCell>organization</TableCell>
                  <TableCell></TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {props.orgList.map(
                  ({
                    ids,
                    id,
                    moduleCategoryId,
                    serviceType,
                    organizationType,
                    orgName,
                    secondEmail,
                    secondPhone,
                    shortDesc,
                    longDesc,
                    logo,
                    bannerImg,
                    orgImg,
                    status,
                    orgCreatedDate,
                    index,
                  }) => {
                    return (
                      <TableRow key={index} hover>
                        <TableCell>{id}</TableCell>
                        <TableCell>{moduleCategoryId}</TableCell>
                        <TableCell>{serviceType}</TableCell>
                        <TableCell>{organizationType}</TableCell>
                        <TableCell>{orgName}</TableCell>
                        <TableCell>{secondEmail}</TableCell>
                        <TableCell>{secondPhone}</TableCell>
                        <TableCell>{shortDesc}</TableCell>
                        <TableCell>{longDesc}</TableCell>
                        <TableCell>{logo}</TableCell>
                        <TableCell>{bannerImg}</TableCell>
                        <TableCell>{orgImg}</TableCell>
                        <TableCell>{status}</TableCell>
                        <TableCell>{orgCreatedDate}</TableCell>
                        <TableCell>
                          <ButtonGroup variant='text'>
                            <Button>
                              <EditIcon
                                color='primary'
                                onClick={() => {
                                  setCurrentId(ids);
                                }}
                              />
                            </Button>
                            <Button>
                              <DeleteIcon color='secondary' onClick={() => onDelete(ids)} />
                            </Button>
                          </ButtonGroup>
                        </TableCell>
                      </TableRow>
                    );
                  }
                )}
              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
      </Grid>
    </Paper>
  );
};

const mapStateToProps = (state) => ({
  orgList: state.modules.list,
});

const mapActionToProps = {
  fetchAll: actions.fetchAll,
  delete: actions.Delete,
};

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(Orgs));
