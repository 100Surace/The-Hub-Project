import React, { useEffect, useState } from 'react';
import { Grid, TextField, withStyles, Button, FormControl, InputLabel, Select, MenuItem } from '@material-ui/core';
import useForm from '../useForm';
import { connect } from 'react-redux';
import * as actions from '../../actions/organization/moduleCategories';
import { useToasts } from 'react-toast-notifications';

const mapStateToProps = (state) => ({
  moduleList: state.modules.list,
});

const mapActionToProps = {
  create: actions.create,
  update: actions.update,
};

const styles = (theme) => ({
  root: {
    '& .MuiTextField-root': {
      margin: theme.spacing(1),
      minWidth: 230,
    },
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 230,
  },
  smMargin: {
    margin: theme.spacing(1),
  },
});

const initialFieldValues = {
  module: '',
  name: '',
};

const ModuleForm = ({ classes, ...props }) => {
  //toast msg.
  const { addToast } = useToasts();

  //validate()
  //validate({fullName:'jenny'})
  const validate = (fieldValues = values) => {
    let temp = { ...errors };
    if ('module' in fieldValues) temp.module = fieldValues.module ? '' : 'This field is required.';

    if ('name' in fieldValues) temp.name = fieldValues.name ? '' : 'This field is required.';

    setErrors({
      ...temp,
    });

    if (fieldValues === values) {
      return Object.values(temp).every((x) => x === '');
    }
  };

  const { values, setValues, errors, setErrors, handleInputChange, resetForm } = useForm(initialFieldValues, validate, props.setCurrentId);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (validate()) {
      const onSuccess = () => {
        resetForm();
        addToast('Submitted successfully', { appearance: 'success' });
      };

      if (props.currentId === 0 || props.currentId === undefined) props.create(values, onSuccess);
      else props.update(props.currentId, values, onSuccess);
    }
  };

  const [modules, setModules] = useState([]);

  useEffect(() => {
    props.fetchModules().then(({ data }) => {
      setModules(data);
    }); // fetch moduels and set to `modules` state

    if (props.currentId !== 0) {
      setValues({
        ...props.moduleList.find((x) => x.ids === props.currentId),
      });
      setErrors({});
    }
  }, [props.currentId]);

  return (
    <form autoComplete='off' noValidate className={classes.root} onSubmit={handleSubmit}>
      <Grid container>
        <Grid item xs={12}>
          <FormControl variant='outlined' className={classes.formControl}>
            <InputLabel id='demo-simple-select-outlined-label'>Module Name</InputLabel>
            <Select
              name='module'
              labelId='demo-simple-select-outlined-label'
              id='demo-simple-select-outlined'
              value={values.module && props.currentId ? values.module : values.moduleId}
              label='Module Name'
              onChange={handleInputChange}>
              {modules.map(({ ids, moduleName }) => (
                <MenuItem key={ids} value={ids}>
                  {moduleName}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
        <Grid item xs={12}>
          <TextField
            name='name'
            variant='outlined'
            label='Module CategoryName'
            value={values.name}
            onChange={handleInputChange}
            {...(errors.name && { error: true, helperText: errors.name })} // uppercase module is not form json, just initiized it above
          />
        </Grid>
        <Grid item xs={12}>
          <div>
            <Button variant='contained' color='primary' type='submit' className={classes.smMargin}>
              Submit
            </Button>
            <Button variant='contained' className={classes.smMargin} onClick={resetForm}>
              Reset
            </Button>
          </div>
        </Grid>
      </Grid>
    </form>
  );
};

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(ModuleForm));
