import React, { useState, useEffect } from 'react';
import { Grid, TextField, withStyles, Button, FormGroup } from '@material-ui/core';
import useForm from '../useForm';
import { connect } from 'react-redux';
import * as actions from '../../actions/organization/module';
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
  fileDiv: {
    padding: '8px',
  },
});

const initialFieldValues = {
  id: '',
  moduleCategoryId: '',
  serviceType: '',
  organizationType: '',
  orgName: '',
  secondEmail: '',
  secondPhone: '',
  shortDesc: '',
  longDesc: '',
  status: '',
  orgCreatedDate: '',
};

const ModuleForm = ({ classes, ...props }) => {
  //toast msg.
  const { addToast } = useToasts();
  // states
  const [logo, setLogo] = useState();
  const [bannerImg, setBanner] = useState();
  const [orgImg, setOrgImg] = useState();

  const validate = (fieldValues = values) => {
    let temp = { ...errors };
    if ('moduleName' in fieldValues) temp.moduleName = fieldValues.moduleName ? '' : 'This field is required.';

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

    const formData = new FormData();
    if (logo) formData.append('logo', logo);
    if (bannerImg) formData.append('bannerImg', bannerImg);
    if (orgImg) formData.append('orgImg', orgImg);

    if (validate()) {
      const onSuccess = () => {
        resetForm();
        addToast('Submitted successfully', { appearance: 'success' });
      };

      if (props.currentId === 0 || props.currentId === undefined) props.create(formData, onSuccess);
      else props.update(props.currentId, formData, onSuccess);
    }
  };

  const handleLogoUpload = (e) => {
    const logo = e.target.files[0];
    setLogo({ logo });
  };

  const handleBannerUpload = (e) => {
    const bannerImg = e.target.files[0];
    setBanner({ bannerImg });
  };

  const handleOrgImgUpload = (e) => {
    const OrgImg = e.target.files[0];
    setOrgImg({ OrgImg });
  };

  useEffect(() => {
    if (props.currentId !== 0) {
      setValues({
        ...props.moduleList.find((x) => x.ids === props.currentId),
      });
      setErrors({});
    }
  });

  return (
    <form autoComplete='off' noValidate className={classes.root} onSubmit={handleSubmit}>
      <Grid container>
        <Grid item xs={12}>
          <TextField
            name='id'
            variant='outlined'
            label='Hub User Id'
            value={values.id}
            onChange={handleInputChange}
            {...(errors.id && { error: true, helperText: errors.id })}
          />
          <TextField
            name='moduleCategoryId'
            variant='outlined'
            label='Module Id'
            value={values.moduleCategoryId}
            onChange={handleInputChange}
            {...(errors.moduleCategoryId && { error: true, helperText: errors.moduleCategoryId })}
          />
          <TextField
            name='serviceType'
            variant='outlined'
            label='service Type'
            value={values.serviceType}
            onChange={handleInputChange}
            {...(errors.serviceType && { error: true, helperText: errors.serviceType })}
          />
          <TextField
            name='organizationType'
            variant='outlined'
            label='organization Type'
            value={values.moduleName}
            onChange={handleInputChange}
            {...(errors.organizationType && { error: true, helperText: errors.organizationType })}
          />
          <TextField
            name='orgName'
            variant='outlined'
            label='Organization Name'
            value={values.orgName}
            onChange={handleInputChange}
            {...(errors.orgName && { error: true, helperText: errors.orgName })}
          />
          <TextField
            name='secondEmail'
            variant='outlined'
            label='second Email'
            value={values.secondEmail}
            onChange={handleInputChange}
            {...(errors.secondEmail && { error: true, helperText: errors.secondEmail })}
          />
          <TextField
            name='secondPhone'
            variant='outlined'
            label='second Phone'
            value={values.secondPhone}
            onChange={handleInputChange}
            {...(errors.secondPhone && { error: true, helperText: errors.secondPhone })}
          />

          <TextField
            name='shortDesc'
            variant='outlined'
            label='Short Desc'
            value={values.shortDesc}
            onChange={handleInputChange}
            {...(errors.shortDesc && { error: true, helperText: errors.shortDesc })}
          />
          <TextField
            name='longDesc'
            variant='outlined'
            label='long Desc'
            value={values.longDesc}
            onChange={handleInputChange}
            {...(errors.longDesc && { error: true, helperText: errors.longDesc })}
          />
          <div className={classes.fileDiv}>
            <input
              type='file'
              name='logo'
              accept='image/*'
              label='logo'
              onChange={handleLogoUpload}
              {...(errors.logo && { error: true, helperText: errors.logo })}
            />
          </div>
          <div className={classes.fileDiv}>
            <input
              type='file'
              name='bannerImg'
              accept='image/*'
              label='bannerImg'
              onChange={handleBannerUpload}
              {...(errors.bannerImg && { error: true, helperText: errors.bannerImg })}
            />
          </div>
          <div className={classes.fileDiv}>
            <input
              type='file'
              name='orgImg'
              accept='image/*'
              label='orgImg'
              onChange={handleOrgImgUpload}
              {...(errors.orgImg && { error: true, helperText: errors.orgImg })}
            />
          </div>
          <TextField
            name='status'
            variant='outlined'
            label='status'
            value={values.status}
            onChange={handleInputChange}
            {...(errors.status && { error: true, helperText: errors.status })}
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
