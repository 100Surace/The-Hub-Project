import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import * as actions from '../../actions/organization/moduleCategories';
import { Grid, Paper, TableContainer, Table, TableHead, TableRow, TableCell, TableBody, withStyles, ButtonGroup, Button } from '@material-ui/core';
import ModuleForm from './moduleCategoriesForm';
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

const ModuleCategories = ({ classes, ...props }) => {
  const [currentId, setCurrentId] = useState(0);

  useEffect(() => {
    props.fetchAll();
  }, [props]); //componentDidMount

  //toast msg.
  const { addToast } = useToasts();

  const onDelete = (id) => {
    if (window.confirm('Are you sure to delete this record?')) props.delete(id, () => addToast('Deleted successfully', { appearance: 'info' }));
  };
  return (
    <Paper className={classes.paper} elevation={3}>
      <Grid container>
        <Grid item xs={6}>
          <ModuleForm {...{ currentId, setCurrentId }} fetchModules={props.fetchModules} />
        </Grid>
        <Grid item xs={6}>
          <TableContainer>
            <Table>
              <TableHead className={classes.root}>
                <TableRow>
                  <TableCell>Module Category</TableCell>
                  <TableCell></TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {props.dataList.map(({ ids, moduleCategoryName, moduleName }, index) => {
                  return (
                    <TableRow key={index} hover>
                      <TableCell>{moduleCategoryName}</TableCell>
                      <TableCell>{moduleName}</TableCell>
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
                })}
              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
      </Grid>
    </Paper>
  );
};

const mapStateToProps = (state) => ({
  dataList: state.modules.list,
});

const mapActionToProps = {
  fetchAll: actions.fetchAll,
  delete: actions.Delete,
  fetchModules: actions.fetchModules,
};

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(ModuleCategories));
